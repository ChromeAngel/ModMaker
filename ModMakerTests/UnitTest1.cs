using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibModMaker;

namespace ModMakerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FGDParser()
        {
            var Subject = new ForgeGameData();

            Subject.Load("Samples/base.fgd");

            Debug.WriteLine("bases:{0}", Subject.Bases.Count);
            Debug.WriteLine("solids:{0}", Subject.Solids.Count);
            Debug.WriteLine("points:{0}", Subject.Points.Count);
            Debug.WriteLine("filters:{0}", Subject.Filters.Count);
        }

        [TestMethod]
        public void RadParser()
        {
            var Subject = Lights.Load("Samples/test.rad");

            Debug.WriteLine("{0} rules loaded", Subject.Rules.Count);

            foreach (var aRule in Subject.Rules)
            {
                Debug.WriteLine(aRule.ToString());
            }
        }
    }//end class
}
