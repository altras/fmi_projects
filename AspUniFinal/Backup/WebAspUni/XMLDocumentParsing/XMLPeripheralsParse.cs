using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebAspUni.XMLDocumentParsing
{
    public class XMLPeripheralsParse
    {
        private XmlNode peripheralsNode =null;
        
        public XMLPeripheralsParse()
        {
        }

        public XMLPeripheralsParse(XmlNode peripheralsNode)
        {
            this.peripheralsNode = peripheralsNode;
        }

        public XMLPeripheralsParse(XmlDocument doc)
        {
            this.peripheralsNode = doc.GetElementsByTagName("peripherals").Item(0);
        }

        public Tuple<string, string> GetMouseAndMouesProducer()
        {
            XmlNodeList peripherals = peripheralsNode.ChildNodes;
            XmlNode mouse = peripherals.Item(0);
            return new Tuple<string, string>(mouse.FirstChild.InnerText, mouse.Attributes[0].Value);
        }

        public Tuple<string, string> GetKeyBoardAndKeyboardProducer()
        {
            XmlNodeList peripherals = peripheralsNode.ChildNodes;
            XmlNode keyobard = peripherals.Item(1);
            return new Tuple<string, string>(keyobard.FirstChild.InnerText, keyobard.Attributes[0].Value);
        }

        public string GetOtherDevices()
        {
            XmlNodeList peripherals = peripheralsNode.ChildNodes;
            XmlNode otherDevices = peripherals.Item(2);
            return otherDevices.InnerText;
        }

        public string GetVideoCamera()
        {
            XmlNodeList peripherals = peripheralsNode.ChildNodes;
            XmlNode videoCamera = peripherals.Item(3);
            return videoCamera.InnerText;
        }

        public string GetMicrophone()
        {
            XmlNodeList peripherals = peripheralsNode.ChildNodes;
            XmlNode microphone = peripherals.Item(4);
            return microphone.InnerText;
        }

        public Tuple<string, string> GetHeadphonesAndHeadphoneProducer()
        {
            XmlNodeList peripherals = peripheralsNode.ChildNodes;
            XmlNode headphones = peripherals.Item(5);
            return new Tuple<string, string>(headphones.FirstChild.InnerText, headphones.Attributes[0].Value);
        }
    }
}
