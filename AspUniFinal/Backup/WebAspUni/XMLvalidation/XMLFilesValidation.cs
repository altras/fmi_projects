using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace WebAspUni.XMLvalidation
{
    public class XMLFilesValidation
    {
        private string xmlSchemaPath;

        public XMLFilesValidation()
        {
            string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fullAppPath = Path.GetDirectoryName(fullAppName);
            this.xmlSchemaPath = fullAppPath.Substring(6, fullAppPath.Length - 9) + "XMLSchema\\XmlShema.xsd";
        }

        public bool ValidateFilesFromDirectory(string directory)
        {
            bool success = true;
            string[] xmlFiles = Directory.GetFiles(directory);
            XMLValidator validator = new XMLValidator();
            int numberOfCurrentlyValidatedFile = 0;
            try
            {
                foreach (string xmlFile in xmlFiles)
                {
                    if (!validator.ValidateXml(xmlSchemaPath, xmlFile))
                    {
                        break;
                    }
                    numberOfCurrentlyValidatedFile++;
                }

                if (numberOfCurrentlyValidatedFile == xmlFiles.Length)
                {
                    Console.WriteLine("All xml files were validated!");
                }
                else
                {
                    success = false;
                    Console.WriteLine("Error found in XML file with path {0}.", xmlFiles[numberOfCurrentlyValidatedFile++]);
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
