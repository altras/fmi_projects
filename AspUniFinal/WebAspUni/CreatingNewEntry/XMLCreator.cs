using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Reflection;
using System.IO;
namespace WebAspUni.CreatingNewEntry
{
    public class XMLCreator
    {
        private XmlDocument doc=null;
        private string xmlPath = @"C:\";
        public XMLCreator()
        {
            doc = new XmlDocument();
            string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fullAppPath = Path.GetDirectoryName(fullAppName);
            this.xmlPath = fullAppPath.Substring(6, fullAppPath.Length - 9) + "NewEntries\\";
        }

        public string SaveToXml(XmlNode root)
        {
            int newEntryNumber = 0;
            string[] newExistingEntries = Directory.GetFiles(xmlPath);
            if (newExistingEntries.Count() == 0)
            {
                newEntryNumber = 1;
            }
            else
            {
                newEntryNumber = newExistingEntries.Count() + 1;
            }
            XmlNode dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            doc.AppendChild(root);
            string file = "newEntry" + newEntryNumber + ".xml";
            string fileNamePath = this.xmlPath + file;
            string xmlOutput = doc.OuterXml;
            doc.Save(fileNamePath);
            return fileNamePath;
        }

        public XmlNode CreateRoot(XmlNode monitor, XmlNode boxSet, XmlNode peripherals, XmlNode software)
        {
            XmlNode root = doc.CreateElement("computerConfiguration");
            root.AppendChild(monitor);
            root.AppendChild(boxSet);
            root.AppendChild(peripherals);
            root.AppendChild(software);
            XmlAttribute xmlSchemaValidationAttribute = doc.CreateAttribute("xmlns");
            xmlSchemaValidationAttribute.Value = @"http://tempuri.org/XmlShema.xsd";
            root.Attributes.Append(xmlSchemaValidationAttribute);

            return root;
        }

        public XmlNode CreateMonitorNode(string aspectRatioHeight,string aspectRatioWidth,
                                         string standMaterials,string displayMaterials,
                                         string matrixName, string matrixProducer,
                                         string led, string monitorName, string monitorProducer)
        {
            XmlNode monitor = doc.CreateElement("monitor");

            XmlNode aspectRatio = doc.CreateElement("aspectRatio");
            XmlNode height = doc.CreateElement("height");
            height.AppendChild(doc.CreateTextNode(aspectRatioHeight));
            XmlNode width = doc.CreateElement("width");
            width.AppendChild(doc.CreateTextNode(aspectRatioWidth));
            aspectRatio.AppendChild(height);
            aspectRatio.AppendChild(width);


            XmlNode materials = doc.CreateElement("materials");
            XmlNode stand = doc.CreateElement("stand");
            stand.AppendChild(doc.CreateTextNode(standMaterials));
            XmlNode display = doc.CreateElement("display");
            display.AppendChild(doc.CreateTextNode(displayMaterials));
            materials.AppendChild(stand);
            materials.AppendChild(display);

            XmlNode matrix = doc.CreateElement("matrix");
            XmlNode matrixNameNode = doc.CreateElement("name");
            matrixNameNode.AppendChild(doc.CreateTextNode(matrixName));
            XmlAttribute matrixProducerNode = doc.CreateAttribute("producer");
            matrixProducerNode.Value = matrixProducer;
            matrix.AppendChild(matrixNameNode);
            matrix.Attributes.Append(matrixProducerNode);

            XmlNode ledNode = doc.CreateElement("LED");
            ledNode.AppendChild(doc.CreateTextNode(led));

            XmlNode nameNode = doc.CreateElement("name");
            nameNode.AppendChild(doc.CreateTextNode(monitorName));

            XmlAttribute producer = doc.CreateAttribute("producer");
            producer.Value = monitorProducer;
            

            monitor.AppendChild(aspectRatio);
            monitor.AppendChild(materials);
            monitor.AppendChild(matrix);
            monitor.AppendChild(ledNode);
            monitor.AppendChild(nameNode);
            monitor.Attributes.Append(producer);
            return monitor;
        }

        public XmlNode CreateBoxSetNode(string cpuName,string cpuProducer,
                                        string motherboard, string ram,
                                        string videoCard, string videoCardProducer,
                                        string coolingSys, string soundCard,
                                        string powerSupply, string expansionCards,
                                        string hdd, string hddProducer,
                                        string usbFlashDrive, string opticalDisc,string memoryCardReader,
                                        string box)
                                         
        {
            XmlNode boxSet = doc.CreateElement("boxSet");

            XmlNode cpuNode = doc.CreateElement("CPU");
            XmlNode cpuNameNode = doc.CreateElement("name");
            cpuNameNode.AppendChild(doc.CreateTextNode(cpuName));
            XmlAttribute cpuProducerAtr = doc.CreateAttribute("producer");
            cpuProducerAtr.Value=cpuProducer;
            cpuNode.AppendChild(cpuNameNode);
            cpuNode.Attributes.Append(cpuProducerAtr);


            XmlNode motherBoardNode = doc.CreateElement("motherBoard");
            motherBoardNode.AppendChild(doc.CreateTextNode(motherboard));

            XmlNode ramNode = doc.CreateElement("RAM");
            ramNode.AppendChild(doc.CreateTextNode(ram));

            XmlNode videoNode = doc.CreateElement("videoCard");
            XmlNode videoNameNode = doc.CreateElement("name");
            videoNameNode.AppendChild(doc.CreateTextNode(videoCard));
            XmlAttribute videoProducer = doc.CreateAttribute("producer");
            videoProducer.Value=videoCardProducer;
            videoNode.AppendChild(videoNameNode);
            videoNode.Attributes.Append(videoProducer);


            XmlNode coolSysNode = doc.CreateElement("coolingSystem");
            coolSysNode.AppendChild(doc.CreateTextNode(coolingSys));

            XmlNode soundCardNode = doc.CreateElement("soundCard");
            soundCardNode.AppendChild(doc.CreateTextNode(soundCard));

            XmlNode powerSupplyNode = doc.CreateElement("powerSupply");
            powerSupplyNode.AppendChild(doc.CreateTextNode(powerSupply));

            XmlNode expansionCardNode = doc.CreateElement("expansionCards");
            expansionCardNode.AppendChild(doc.CreateTextNode(expansionCards));

            XmlNode hddNode = doc.CreateElement("HDD");
            XmlNode hddNameNode = doc.CreateElement("name");
            hddNameNode.AppendChild(doc.CreateTextNode(hdd));
            XmlAttribute hddProducerAttr = doc.CreateAttribute("producer");
            hddProducerAttr.Value = hddProducer;
            hddNode.AppendChild(hddNameNode);
            hddNode.Attributes.Append(hddProducerAttr);

            XmlNode removableМediaDevicesNode = doc.CreateElement("removableМediaDevices");
            XmlNode usblashDriveNode = doc.CreateElement("USBFlashDrive");
            usblashDriveNode.AppendChild(doc.CreateTextNode(usbFlashDrive));
            XmlNode opticalDiscNode = doc.CreateElement("opticalDisc");
            opticalDiscNode.AppendChild(doc.CreateTextNode(opticalDisc));
            XmlNode memoryCardReaderNode = doc.CreateElement("memoryCardReader");
            memoryCardReaderNode.AppendChild(doc.CreateTextNode(memoryCardReader));
            removableМediaDevicesNode.AppendChild(usblashDriveNode);
            removableМediaDevicesNode.AppendChild(opticalDiscNode);
            removableМediaDevicesNode.AppendChild(memoryCardReaderNode);

            XmlNode boxNode = doc.CreateElement("box");
            boxNode.AppendChild(doc.CreateTextNode(box));

            boxSet.AppendChild(cpuNode);
            boxSet.AppendChild(motherBoardNode);
            boxSet.AppendChild(ramNode);
            boxSet.AppendChild(videoNode);
            boxSet.AppendChild(coolSysNode);
            boxSet.AppendChild(soundCardNode);
            boxSet.AppendChild(powerSupplyNode);
            boxSet.AppendChild(expansionCardNode);
            boxSet.AppendChild(hddNode);
            boxSet.AppendChild(removableМediaDevicesNode);
            boxSet.AppendChild(boxNode);
            return boxSet;
        }
        public XmlNode CreatePeripherals(string mouse,string mouseProducer,
                                         string keyBoard, string keyBoardProducer,
                                         string otherDevices,string videoCamera,
                                         string microphone, string headPhones, string headPhonesProducer)
        {
            XmlNode peripheralNode = doc.CreateElement("peripherals");

            XmlNode mouseNode = doc.CreateElement("mouse");
            XmlNode mouseNameNode = doc.CreateElement("name");
            mouseNameNode.AppendChild(doc.CreateTextNode(mouse));
            XmlAttribute mouseProducerAttr = doc.CreateAttribute("producer");
            mouseProducerAttr.Value = mouseProducer;
            mouseNode.AppendChild(mouseNameNode);
            mouseNode.Attributes.Append(mouseProducerAttr);

            XmlNode keyBoardNode = doc.CreateElement("keyboard");
            XmlNode keyBoardNameNode = doc.CreateElement("name");
            keyBoardNameNode.AppendChild(doc.CreateTextNode(keyBoard));
            XmlAttribute keyBoardProducerAttr = doc.CreateAttribute("producer");
            keyBoardProducerAttr.Value = keyBoardProducer;
            keyBoardNode.AppendChild(keyBoardNameNode);
            keyBoardNode.Attributes.Append(keyBoardProducerAttr);


            XmlNode otherDevicesNode = doc.CreateElement("otherDevices");
            otherDevicesNode.AppendChild(doc.CreateTextNode(otherDevices));

            XmlNode videoCameraNode = doc.CreateElement("videoCamera");
            videoCameraNode.AppendChild(doc.CreateTextNode(videoCamera));

            XmlNode microphoneNode = doc.CreateElement("microphone");
            microphoneNode.AppendChild(doc.CreateTextNode(microphone));

            XmlNode headPhonesNode = doc.CreateElement("headPhones");
            XmlNode headPhonesNameNode = doc.CreateElement("name");
            headPhonesNameNode.AppendChild(doc.CreateTextNode(headPhones));
            XmlAttribute headPhonesProducerAttr = doc.CreateAttribute("producer");
            headPhonesProducerAttr.Value = headPhonesProducer;
            headPhonesNode.AppendChild(headPhonesNameNode);
            headPhonesNode.Attributes.Append(headPhonesProducerAttr);

            peripheralNode.AppendChild(mouseNode);
            peripheralNode.AppendChild(keyBoardNode);
            peripheralNode.AppendChild(otherDevicesNode);
            peripheralNode.AppendChild(videoCameraNode);
            peripheralNode.AppendChild(microphoneNode);
            peripheralNode.AppendChild(headPhonesNode);
            return peripheralNode;
        }
        public XmlNode CreateSoftware(string os,string osProducer,
                                      string antiVirus,string antiVirusProducer,
                                      string game1, string game1Producer,
                                      string game2, string game2Producer,
                                      string game3, string game3Producer,
                                      string other, string otherProducer)
        {
            XmlNode additionalSoftwareNode = doc.CreateElement("additionalSoftware");

            XmlNode osNode = doc.CreateElement("OS");
            XmlNode osNameNode = doc.CreateElement("name");
            osNameNode.AppendChild(doc.CreateTextNode(os));
            XmlAttribute osProducerAtt = doc.CreateAttribute("producer");
            osProducerAtt.Value = osProducer;
            osNode.AppendChild(osNameNode);
            osNode.Attributes.Append(osProducerAtt);

            XmlNode antiVirusNode = doc.CreateElement("antiVirus");
            XmlNode antiVirusNameNode = doc.CreateElement("name");
            antiVirusNameNode.AppendChild(doc.CreateTextNode(antiVirus));
            XmlAttribute antiVirusProducerAtt = doc.CreateAttribute("producer");
            antiVirusProducerAtt.Value = antiVirusProducer;
            antiVirusNode.AppendChild(antiVirusNameNode);
            antiVirusNode.Attributes.Append(antiVirusProducerAtt);

            XmlNode gamesNode = doc.CreateElement("games");
            XmlNode game1Node = this.CreateGameNode(game1, game1Producer, 1);
            XmlNode game2Node = this.CreateGameNode(game1, game1Producer, 2);
            XmlNode game3Node = this.CreateGameNode(game1, game1Producer, 3);
            gamesNode.AppendChild(game1Node);
            gamesNode.AppendChild(game2Node);
            gamesNode.AppendChild(game3Node);

            XmlNode otherNode = doc.CreateElement("other");
            XmlNode otherNameNode = doc.CreateElement("name");
            otherNameNode.AppendChild(doc.CreateTextNode(other));
            XmlAttribute otherProducerAtt = doc.CreateAttribute("producer");
            otherProducerAtt.Value = otherProducer;
            otherNode.AppendChild(otherNameNode);
            otherNode.Attributes.Append(otherProducerAtt);

            additionalSoftwareNode.AppendChild(osNode);
            additionalSoftwareNode.AppendChild(antiVirusNode);
            additionalSoftwareNode.AppendChild(gamesNode);
            additionalSoftwareNode.AppendChild(otherNode);
            return additionalSoftwareNode;
        }

        public XmlNode CreateGameNode(string game, string producer, int number)
        {
            XmlNode gameNode = doc.CreateElement("game" + number.ToString());
            XmlNode gameNameNode = doc.CreateElement("name");
            gameNameNode.AppendChild(doc.CreateTextNode(game));
            XmlAttribute producerAtt = doc.CreateAttribute("producer");
            producerAtt.Value = producer;
            gameNode.AppendChild(gameNameNode);
            gameNode.Attributes.Append(producerAtt);

            return gameNode;
        }

    }
}