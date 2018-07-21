using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// class modelling the OBJ 3D model format
    /// </summary>
    public class Obj
    {
        //http://en.wikipedia.org/wiki/Wavefront_.obj_file

        public struct Vector3
        {
            public float x;
            public float y;
            public float z;
        }

        public struct Vector2
        {
            public float x;
            public float y;
        }

        public struct Vertex
        {
            public int pointIndex;
            public int texcoordIndex;
            public int normalIndex;
        }

        public struct Face
        {
            public int materialIndex;
            public int smoothing;
            public Vertex[] verticies;
        }

        public List<Vector3> points = new List<Vector3>();
        public List<Vector3> normals = new List<Vector3>();
        public List<Vector2> texcoords = new List<Vector2>();
        public List<string> mtlLibs = new List<string>();
        public List<string> materials = new List<string>();

        public List<Face> faces = new List<Face>();

        public static Obj Load(string Filename)
        {
            if (!File.Exists(Filename))
                return null;

            Obj Result = new Obj();
            string[] Whitespace =
            {
                " ",
                "\t",
                "\r",
                "\n"
            };

            using (var file = File.OpenText(Filename))
            {
                string Line = file.ReadLine().Trim();
                string keyword;
                int smoothing = -1;
                int material = -1;

                while (Line != null)
                {
                    Line = Line.Trim();

                    if (Line.Contains("#"))
                        Line = Line.Substring(0, Line.IndexOf("#"));

                    if (Line.Length == 0)
                    {
                        Line = file.ReadLine();

                        continue;
                    }

                    Line = Line.Replace("\t", " ");
                    Line = Line.Replace("  ", " ");

                    string[] words = Line.Split(' ');

                    keyword = words[0].ToLowerInvariant();
                    //Debug.WriteLine(keyword)

                    switch (keyword)
                    {
                        case "v":
                            Vector3 point;
                            string strX;
                            string strY;
                            string strZ;

                            strX = words[1];
                            point.x = float.Parse(strX);

                            strY = words[2];
                            point.y = float.Parse(strY);

                            strZ = words[3];
                            point.z = float.Parse(strZ);

                            Result.points.Add(point);
                            break;
                        case "vt":
                            Vector2 UV;

                            UV.x = float.Parse(words[1]);
                            UV.y = float.Parse(words[2]);

                            Result.texcoords.Add(UV);
                            break;
                        case "vn":
                            Vector3 normal;

                            normal.x = float.Parse(words[1]);
                            normal.y = float.Parse(words[2]);
                            normal.z = float.Parse(words[3]);

                            Result.normals.Add(normal);
                            break;
                        case "mtllib":
                            Result.mtlLibs.Add(words[1]);
                            break;
                        case "usemtl":
                            string strMaterial = words[1];

                            if (!Result.materials.Contains(strMaterial))
                            {
                                Result.materials.Add(strMaterial);
                            }

                            material = Result.materials.IndexOf(strMaterial);
                            break;
                        case "s":
                            smoothing = int.Parse(words[1]);
                            break;
                        case "f":
                            string[] Vertices = new string[words.Length - 2];
                            System.Array.Copy(words, 1, Vertices, 0, words.Length - 1);
                            Face F = new Face();

                            F.verticies = new Vertex[Vertices.Length];

                            int Index = 0;

                            foreach (string StrVerice in Vertices)
                            {
                                F.verticies[Index] = ParseVertex(StrVerice);
                                Index += 1;
                            }


                            F.materialIndex = material;
                            F.smoothing = smoothing;

                            Result.faces.Add(F);
                            break;
                        case "o":
                            //objects
                            Debug.WriteLine(words[1]);
                            break;
                        case "g":
                            //groups
                            Debug.WriteLine(words[1]);
                            break;
                        case "":
                        default:
                            Debug.Write(Line);
                            break;
                    }

                    Line = file.ReadLine();
                }
            }

            return Result;
        }

        private static string ReadLine(BinaryReader file)
        {
            if (file == null)
                return null;

            System.Text.StringBuilder Result = new System.Text.StringBuilder();
            char C = file.ReadChar();

            try
            {
                while (C != '\n')
                {
                    Result.Append(C);
                    C = file.ReadChar();
                }

            }
            catch (EndOfStreamException)
            {
            }

            return Result.ToString();
        }

        private static string ReadWord(BinaryReader file)
        {
            if (file == null)
                return null;

            System.Text.StringBuilder Result = new System.Text.StringBuilder();

            try
            {
                char C = file.ReadChar();

                while (!char.IsWhiteSpace(C))
                {
                    Result.Append(C);
                    C = file.ReadChar();
                }

                while (char.IsWhiteSpace(C))
                {
                    C = (Char)file.PeekChar();

                    if (!char.IsWhiteSpace(C))
                        break; // TODO: might not be correct. Was : Exit While

                    C = file.ReadChar();
                }
            }
            catch (EndOfStreamException)
            {
                if (Result.Length == 0)
                    return null;
            }

            return Result.ToString();
        }

        private static Vertex ParseVertex(string vertex_def)
        {
            string[] Parts = vertex_def.Split('/');
            Vertex Result = new Vertex();

            Result.pointIndex = int.Parse(Parts[0]) - 1;

            if (Parts.Length == 2)
            {
                Result.texcoordIndex = int.Parse(Parts[1]) - 1;
            }

            if (Parts.Length > 2)
            {
                if (Parts[1].Length > 0)
                {
                    Result.texcoordIndex = int.Parse(Parts[1]) - 1;
                }

                Result.normalIndex = int.Parse(Parts[2]) - 1;
            }

            return Result;
        }

    }

}