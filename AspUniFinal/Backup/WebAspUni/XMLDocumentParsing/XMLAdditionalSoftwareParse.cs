using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebAspUni.XMLDocumentParsing
{
    public class XMLAdditionalSoftwareParse
    {
        private XmlNode addSoftwareNode = null;
        public XMLAdditionalSoftwareParse()
        {
        }

        public XMLAdditionalSoftwareParse(XmlNode addSoft)
        {
            this.addSoftwareNode = addSoft;
        }

        public XMLAdditionalSoftwareParse(XmlDocument doc)
        {
            this.addSoftwareNode = doc.GetElementsByTagName("additionalSoftware").Item(0);
        }

        public Tuple<string, string> GetOsAndProducer()
        {
            XmlNodeList addSoft = addSoftwareNode.ChildNodes;
            XmlNode os = addSoft.Item(0);
            return new Tuple<string, string>(os.FirstChild.InnerText, os.Attributes[0].Value);
        }

        public Tuple<string, string> GetAntiVirusAndProducer()
        {
            XmlNodeList addSoft = addSoftwareNode.ChildNodes;
            XmlNode antivirus = addSoft.Item(1);
            return new Tuple<string, string>(antivirus.FirstChild.InnerText, antivirus.Attributes[0].Value);
        }

        public Tuple<string, string> GetGameAndProducer(int number)
        {
            XmlNodeList addSoft = addSoftwareNode.ChildNodes;
            XmlNode games = addSoft.Item(2);
            XmlNode game = games.ChildNodes.Item(number);
            return new Tuple<string, string>(game.FirstChild.InnerText, game.Attributes[0].Value);
        }

        public Tuple<string, string> GetOther()
        {
            XmlNodeList addSoft = addSoftwareNode.ChildNodes;
            XmlNode other = addSoft.Item(3);
            return new Tuple<string, string>(other.FirstChild.InnerText, other.Attributes[0].Value);
        }
    }
}
