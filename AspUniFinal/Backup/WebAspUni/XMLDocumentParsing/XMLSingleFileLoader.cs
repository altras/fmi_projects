using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace WebAspUni.XMLDocumentParsing
{
    public class XMLSingleFileLoader
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement rootNode = null;

        public XmlDocument Doc
        {
            get
            {
                return this.doc;
            }
        }

        public XmlNode RootNode
        {
            get
            {
                return this.rootNode;
            }
        }
        public XMLSingleFileLoader()
        {
        }


        public void LoadXmlFile(string xmlPath)
        {
            this.doc.Load(xmlPath);
            this.rootNode = doc.DocumentElement;
        }
    }
}
