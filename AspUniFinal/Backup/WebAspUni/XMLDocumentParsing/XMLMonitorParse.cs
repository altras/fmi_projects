using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebAspUni.XMLDocumentParsing
{
    public class XMLMonitorParse
    {
        private XmlNode monitorNode = null;

        public XMLMonitorParse()
        {
        }

        public XMLMonitorParse(XmlNode monitorNode)
        {
            this.monitorNode = monitorNode;
        }

        public XMLMonitorParse(XmlDocument document)
        {
            this.monitorNode = document.GetElementsByTagName("monitor").Item(0);
        }

        public string GetMonitorProducer()
        {
            string producer = monitorNode.Attributes[0].Value;
            return producer;
        }

        public Tuple<int, int> GetAspecRatio()
        {
            string height=monitorNode.FirstChild.FirstChild.InnerText;
            string width = monitorNode.FirstChild.LastChild.InnerText;
            Tuple<int, int> aspectRatio = new Tuple<int, int>(int.Parse(height),int.Parse(width));
            return aspectRatio;
        }

        public Tuple<string, string> GetMaterials()
        {
            XmlNodeList nodes = monitorNode.ChildNodes;
            XmlNodeList materials = nodes.Item(1).ChildNodes;
            string stand = materials.Item(0).InnerText;
            string display = materials.Item(1).InnerText;
            Tuple<string, string> monitorMaterials = new Tuple<string, string>(stand, display);
            return monitorMaterials;
        }

        public Tuple<string, string> GetMatrixAndMatrixProducer()
        {
            XmlNodeList nodes = monitorNode.ChildNodes;
            XmlNode matrix = nodes.Item(2).FirstChild;
            string producer = nodes.Item(2).Attributes[0].Value;
            return new Tuple<string, string>(matrix.InnerText, producer);
        }

        public string GetLed()
        {
            XmlNodeList nodes = monitorNode.ChildNodes;
            string led = nodes.Item(3).InnerText;
            return led;
        }

        public string GetMonitorName()
        {
            XmlNodeList nodes = monitorNode.ChildNodes;
            string name = nodes.Item(4).InnerText;
            return name;
        }
    }
}
