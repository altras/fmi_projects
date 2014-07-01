using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAspUni.InsertIntoDataBase;
using System.IO;
using System.Reflection;
using System.Text;

namespace WebAspUni
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PopulateDatabase(object sender, EventArgs e)
        {
            string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fullAppPath = Path.GetDirectoryName(fullAppName);
            string xmlDirectoryPath = fullAppPath.Substring(6, fullAppPath.Length - 9) + "XMLS";
            InsertXMLFilesInDatabase inserter = new InsertXMLFilesInDatabase();
            Tuple<List<string>,List<string>> xmlValidationResults = inserter.InsertFiles(xmlDirectoryPath);
            if (xmlValidationResults == null)
            {
                this.invalidatedXmlsResults.Text = "No Xml Files were validated and inserted into database";
            }
            else
            {
                StringBuilder textToBePutInSpanValidResults = new StringBuilder();
                StringBuilder textToBePutInSpanInvalidResults = new StringBuilder();
                textToBePutInSpanValidResults.Append(xmlValidationResults.Item1.Count.ToString() + " Valid XMLS <br>");
                foreach (var validXml in xmlValidationResults.Item1)
                {
                    textToBePutInSpanValidResults.Append(validXml + "<br>");
                }
                textToBePutInSpanInvalidResults.Append(xmlValidationResults.Item2.Count.ToString() + " Invalid XMLS <br>");
                foreach (var invalidXml in xmlValidationResults.Item2)
                {
                    textToBePutInSpanInvalidResults.Append(invalidXml + "<br>");
                }
                this.validatedXmlsResults.Text = textToBePutInSpanValidResults.ToString();
                this.invalidatedXmlsResults.Text = textToBePutInSpanInvalidResults.ToString();
            }
        }
    }
}