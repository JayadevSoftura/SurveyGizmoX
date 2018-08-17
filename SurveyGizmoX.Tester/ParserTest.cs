using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyGizmoX.Parser;
namespace SurveyGizmoX.Tester
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = string.Format("{0}\\{1}", directory, "SampleData1.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                SurveyGizmoResponse response = SurveyGizmoResponse.FromJson(json);
                Assert.IsNotNull(response);


            }
        }
    }
}
