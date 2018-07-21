using System.IO;

namespace ModMaker
{
    /// <summary>
    /// Tool for converting an OBJ 3D model file into a refrence SMD file
    /// </summary>
    public class ObjToSMD
    {
        Obj anObj;

        string DefaultMaterial;

        public ObjToSMD(string FilePath)
        {
            if (!File.Exists(FilePath))
                return;

            this.anObj = Obj.Load(FilePath);

            DefaultMaterial = Path.GetFileNameWithoutExtension(FilePath) + "_sheet";

            string OutputPath = Path.Combine(Path.GetDirectoryName(FilePath),
                Path.GetFileNameWithoutExtension(FilePath) + ".smd");

            using (StreamWriter File = new StreamWriter(OutputPath))
            {
                File.WriteLine("version 1");
                File.WriteLine("nodes");
                File.WriteLine("0 \"root\" -1");
                File.WriteLine("end");
                File.WriteLine("skeleton");
                File.WriteLine("time 0");
                File.WriteLine("0 0 0 0 0 0 0");
                File.WriteLine("end");
                File.WriteLine("triangles");

                int IFace = 1;

                foreach (Obj.Face Face in this.anObj.faces)
                {
                    // File.WriteLine("// {0}", IFace)
                    Triangulate(Face, File);
                    IFace += 1;
                }

                File.WriteLine("end");
            }
        }

        protected void Triangulate(Obj.Face Face, StreamWriter File)
        {
            int I;

            for (I = 1; I <= Face.verticies.Length - 3; I++)
            {
                if (anObj.materials.Count == 0)
                {
                    File.WriteLine(DefaultMaterial);
                }
                else
                {
                    if (Face.materialIndex < 0)
                    {
                        File.WriteLine(anObj.materials[0]);
                    }
                    else
                    {
                        File.WriteLine(anObj.materials[Face.materialIndex]);
                    }
                }

                File.WriteLine(VertToString(Face.verticies[0]));
                File.WriteLine(VertToString(Face.verticies[I]));
                File.WriteLine(VertToString(Face.verticies[I + 1]));
            }
        }

        object VertToString(Obj.Vertex V)
        {
            Obj.Vector3 Point = new Obj.Vector3();
            Obj.Vector3 Normal = new Obj.Vector3();
            Obj.Vector2 UV = new Obj.Vector2();

            if (V.pointIndex < anObj.points.Count)
                Point = anObj.points[V.pointIndex];
            if (V.normalIndex < anObj.normals.Count)
                Normal = anObj.normals[V.normalIndex];
            if (V.texcoordIndex < anObj.texcoords.Count)
                UV = anObj.texcoords[V.texcoordIndex];

            return string.Format("0 {0:F6} {1:F6} {2:F6} {3:F6} {4:F6} {5:F6} {6:F6} {7:F6} 1 0 1.000000", Point.x, Point.y, Point.z, Normal.x, Normal.y, Normal.z, UV.x, UV.y);
        }
    }

}