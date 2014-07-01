using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.Data;
using System.Reflection;
using System.IO;

namespace WebAspUni.XMLvalidation
{
    public class XMLValidator
    {
        private string xmlSchemaPath;

        public string XmlShcemaPath
        {
            get
            {
                return this.xmlSchemaPath;
            }
        }
        private static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            ValidationFailed(args.Message);
        }
        private static void ValidationFailed(string msg)
        {
            throw new XmlSchemaValidationException(msg);
        }

        public XMLValidator()
        {
            string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fullAppPath = Path.GetDirectoryName(fullAppName);
            this.xmlSchemaPath = fullAppPath.Substring(6, fullAppPath.Length - 9) + "XMLSchema\\XmlShema.xsd";
        }

        public bool ValidateXml(string xmlSchema, string xmlPath)
        {
            bool success = false;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xmlSchema);
                settings.ValidationType = ValidationType.Schema;
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                var reader = XmlReader.Create(xmlPath, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                document.Validate(eventHandler);

                success = true;
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("XML Validation Failed! Reason: {0}", ex.Message));
            }
            return success;
        }   
    }
}
