using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// Class to aid localising text at runtime, by loading translation terms from a spreadsheet
    /// </summary>
    public static class Lang
    {
        /// <summary>
        /// A dictionary of english terms and their translated equivilents
        /// </summary>
        private static Dictionary<string, string> Terms;

        /// <summary>
        /// Load terms and their translations from a spreadsheet
        /// </summary>
        /// <param name="filePath">path to an exell 2003 format XML docuemnt</param> (see example format at the end of this document)
        /// <returns>true on success, false on failure</returns>
        public static bool LoadTerms(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            var x = new XmlDocument();

            try
            {
                x.Load(filePath);

                var Rows = x.GetElementsByTagName("Row");
                Terms = new Dictionary<string, string>();

                foreach (XmlNode Row in Rows)
                {
                    if (Row.ChildNodes.Count < 2) continue;

                    //ChildNodes of a Row are expected to be Cells and have their own Data child node
                    string termText = Row.ChildNodes[0].ChildNodes[0].InnerText;
                    string valueText = Row.ChildNodes[1].ChildNodes[0].InnerText;

                    Terms.Add(termText, valueText);
                }
            }
            catch (Exception oops)
            {
                Debug.WriteLine("Lang.LoadTerms " + filePath);
                Debug.WriteLine(oops.GetType().Name);
                Debug.WriteLine(oops.Message);
                Debug.WriteLine(oops.StackTrace);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Translate a given term into the loaded language
        /// </summary>
        /// <param name="Term">term to translate</param>
        /// <param name="Default">text to use if no translation is available, defaults to the empty string</param>
        /// <returns>the text corrisponding to the given term from the loaded translations</returns>
        public static string Term(String Term, string Default = "")
        {
            if (string.IsNullOrEmpty(Term)) return string.Empty;
            if (Terms == null) return Default;
            if (Terms.ContainsKey(Term)) return Terms[Term];

            return Default;
        }

        /// <summary>
        /// Translate then format the given term and arguments
        /// </summary>
        /// <param name="FormatTerm">A term that transaltes to a composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to translate and format.</param>
        /// <returns>A copy of the translated format in which the format items have been translated and replaced by the string representation of the corresponding objects in args.</returns>
        public static string Format(string FormatTerm, params object[] args)
        {
            if (string.IsNullOrEmpty(FormatTerm)) return "";

            //replace any string argements with their translations
            int index = -1;

            foreach (object arg in args)
            {
                index++;

                if (arg.GetType().Name != "String") continue;

                string argString = args[index].ToString();

                args[index] = Term(argString, argString);
            }

            //translate the format term and apply the formatting
            return string.Format(Term(FormatTerm, FormatTerm), args);
        }

        //Example XML format we're expecting, excell can open and edit files in this format (although it may add more non-essential crap)
        /*
<?xml version="1.0"?>
<?mso-application progid="Excel.Sheet"?>
<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:o="urn:schemas-microsoft-com:office:office"
 xmlns:x="urn:schemas-microsoft-com:office:excel"
 xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:html="http://www.w3.org/TR/REC-html40">
 <Worksheet ss:Name="Sheet1">
  <Table>
   <Row>
    <Cell>
      <Data ss:Type="String">Key Title</Data></Cell>
    <Cell>
      <Data ss:Type="String">Value Title</Data></Cell>
   </Row>
   <Row>
    <Cell>
      <Data ss:Type="String">Key</Data></Cell>
    <Cell>
      <Data ss:Type="String">Value</Data></Cell>
   </Row>
  </Table>
 </Worksheet>
</Workbook>
         */
    }
}
