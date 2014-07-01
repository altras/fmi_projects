using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebAspUni.XMLDocumentParsing
{
    public class XMLBoxSetParse
    {
        private XmlNode boxSetNode = null;

        public XMLBoxSetParse()
        {
        }

        public XMLBoxSetParse(XmlDocument doc)
        {
            this.boxSetNode = doc.GetElementsByTagName("boxSet").Item(0);
        }

        public XMLBoxSetParse(XmlNode boxNode)
        {
            this.boxSetNode = boxNode;
        }

        public Tuple<string, string> GetCpuAndCpuProducer()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode cpu = boxCompoments.Item(0);
            return new Tuple<string, string>(cpu.FirstChild.InnerText, cpu.Attributes[0].Value);
        }

        public string GetMotherBoard()
        {
            XmlNodeList components = boxSetNode.ChildNodes;
            XmlNode motherboard = components.Item(1);
            return motherboard.InnerText;
        }

        public string GetRam()
        {
            XmlNodeList components = boxSetNode.ChildNodes;
            XmlNode ram = components.Item(2);
            return ram.InnerText;
        }

        public Tuple<string, string> GetVideoCardAndVideoCardProducer()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode videocard = boxCompoments.Item(3);
            return new Tuple<string, string>(videocard.FirstChild.InnerText, videocard.Attributes[0].Value);
        }

        public string GetCoolingSystem()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode coolingSystem = boxCompoments.Item(4);
            return coolingSystem.InnerText;
        }

        public string GetSoundCard()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode soundCard = boxCompoments.Item(5);
            return soundCard.InnerText;
        }

        public string GetPowerSupply()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode powerSupply = boxCompoments.Item(6);
            return powerSupply.InnerText;
        }

        public string GetExpansionCard()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode expansionCard = boxCompoments.Item(7);
            return expansionCard.InnerText;
        }

        public Tuple<string, string> GetHddAndHddProducer()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode hdd = boxCompoments.Item(8);
            return new Tuple<string, string>(hdd.FirstChild.InnerText, hdd.Attributes[0].Value);
        }

        public Tuple<string, string, string> GetRemovableDevices()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode removableDevices = boxCompoments.Item(9);
            XmlNode usbFlashDrive = removableDevices.ChildNodes.Item(0);
            XmlNode opticalDisc = removableDevices.ChildNodes.Item(1);
            XmlNode memoryCardReader = removableDevices.ChildNodes.Item(2);
            return new Tuple<string, string, string>(usbFlashDrive.InnerText,opticalDisc.InnerText,memoryCardReader.InnerText);
        }

        public string GetBox()
        {
            XmlNodeList boxCompoments = boxSetNode.ChildNodes;
            XmlNode box = boxCompoments.Item(10);
            return box.InnerText;
        }
    }
}
