using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAspUni.CreatingNewEntry;
using System.Xml;

namespace WebAspUni
{
    public partial class NewCustomConfigOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void CreateNewEntry(object sender, EventArgs e)
        {
            XMLCreator creator = new XMLCreator();
            #region 
            //Dummy entry:
            //XmlNode mon=creator.CreateMonitorNode("123", "32", 
            //                                      "materialsStand", "displayMater", 
            //                                      "matrixName", "matrixProducer", 
            //                                      "yes", 
            //                                      "monName", "monProducer");
            //XmlNode box=creator.CreateBoxSetNode("cpuName", "cpuProducer",
            //                                        "motherBoardName", "123Ram", 
            //                                        "videoCardName", "videoProducer", 
            //                                        "cooolSys", "soundCard",
            //                                        "powerSupply", "expansionCard", 
            //                                        "hdd", "hddProducer", "usbFlash", 
            //                                        "opticalDisc", "memoryCard", "box");
            //XmlNode per=creator.CreatePeripherals("mouse", "mouseProducer", 
            //                                        "keyboard", "keyBoardProducer", 
            //                                        "otherDevices", "videoCarmera", "microphone", 
            //                                        "headphones", "headProducer");
            //XmlNode soft=creator.CreateSoftware("os", "osprod", 
            //                                    "antivir", "antivirProd", 
            //                                    "game1", "game1Prod",
            //                                    "game2", "game2Prod", 
            //                                    "game3", "game3Prod", 
            //                                    "other", "otherProd");
            #endregion
            XmlNode mon = creator.CreateMonitorNode(this.aspectRatioHeightTextBox.Text, this.aspectRatioWidthTextBox.Text,
                                                 this.materialsStandTextBox.Text, this.materialsDisplayTextBox.Text,
                                                 this.matrixNameTextBox.Text, this.matrixProducerTextBox.Text,
                                                 this.ledTextBox.Text,
                                                 this.monitorNameTextBox.Text, this.monitorProducerTextBox.Text);

            XmlNode box = creator.CreateBoxSetNode(this.cpuNameTextBox.Text, this.cpuProducerTextBox.Text,
                                                    this.motherBoardTextBox.Text, this.ramTextBox.Text,
                                                    this.videoCardNameTextBox.Text, this.videoCardProducerTextBox.Text,
                                                    this.coolingSystemTextBox.Text, this.soundCardTextBox.Text,
                                                    this.powerSupplyTextBox.Text, this.expansionCardTextBox.Text,
                                                    this.hddNameTextBox.Text, this.hddProducerTextBox.Text, this.usbFlashDriveTextBox.Text,
                                                    this.opticalDiscTextBox.Text, this.memoryCardReaderTextBox.Text, this.boxTextBox.Text);

            XmlNode per = creator.CreatePeripherals(this.mouseNameTextBox.Text, this.mouseProducerTextBox.Text,
                                                    this.keyboardNameTextBox.Text, this.keyboardProducerTextBox.Text,
                                                    this.otherDevicesTextBox.Text, this.videoCameraTextBox.Text, this.microphoneTextBox.Text,
                                                    this.headphonesNameTextBox.Text, this.headphonesProducerTextBox.Text);

            XmlNode soft = creator.CreateSoftware(this.osTextBox.Text, this.osProducerTextBox.Text,
                                                this.antivirusNameTextBox.Text, this.antivirusProducerTextBox.Text,
                                                this.game1NameTextBox.Text, this.game1ProducerTextBox.Text,
                                                this.game2NameTextBox.Text, this.game2ProducerTextBox.Text,
                                                this.game3NameTextBox.Text, this.game3ProducerTextBox.Text,
                                                this.otherNameTextBox.Text, this.otherProducerTextBox.Text);

            XmlNode root = creator.CreateRoot(mon, box, per, soft);
            string newFilePath = creator.SaveToXml(root);

            XMLSingleFileInsert newFile = new XMLSingleFileInsert(newFilePath);
            newFile.Insert();
        }
    }
}