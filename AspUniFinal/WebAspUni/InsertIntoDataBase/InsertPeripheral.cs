using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAspUni.XMLDocumentParsing;

namespace WebAspUni.InsertIntoDataBase
{
    public class InsertPeripheral
    {
        private XMLPeripheralsParse peripheral = null;
        private int configId;
        public InsertPeripheral()
        {
        }

        public InsertPeripheral(XMLPeripheralsParse peripheral,int configId)
        {
            this.peripheral = peripheral;
            this.configId = configId;
        }


        private void InsertMouse()
        {
            string mousename = this.peripheral.GetMouseAndMouesProducer().Item1;
            string producername = this.peripheral.GetMouseAndMouesProducer().Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Peripherals.FirstOrDefault(p => p.name == mousename && p.producer == producername && p.configId==this.configId);
            if (match == null)
            {
                db.AddToPeripherals(new Peripheral()
                {
                    name = mousename,
                    producer = producername,
                    type = "mouse",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertKeyBoard()
        {
            string keyBoardName = this.peripheral.GetKeyBoardAndKeyboardProducer().Item1;
            string producerName = this.peripheral.GetKeyBoardAndKeyboardProducer().Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Peripherals.FirstOrDefault(p => p.name == keyBoardName && p.producer == producerName && p.configId==this.configId);
            if(match==null)
            {
                db.AddToPeripherals(new Peripheral()
                {
                    name = keyBoardName,
                    producer = producerName,
                    type = "keyoard",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertOtherDevices()
        {
            string otherDevices = this.peripheral.GetOtherDevices();
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Peripherals.FirstOrDefault(p => p.name == otherDevices && p.configId==this.configId);
            if (match == null)
            {
                db.AddToPeripherals(new Peripheral()
                {
                    name = otherDevices,
                    producer = "",
                    type = "otherDevices",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertVideoCamera()
        {
            string videoCamera = this.peripheral.GetVideoCamera();
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Peripherals.FirstOrDefault(p => p.name == videoCamera && p.configId==this.configId);
            if (match == null)
            {
                db.AddToPeripherals(new Peripheral()
                {
                    name = videoCamera,
                    producer = "",
                    type = "videoCamera",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertMicrophone()
        {
            string microphone = this.peripheral.GetMicrophone();
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Peripherals.FirstOrDefault(p => p.name == microphone && p.configId==this.configId);
            if (match == null)
            {
                db.AddToPeripherals(new Peripheral()
                {
                    name = microphone,
                    producer = "",
                    type = "microphone",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertHeadphones()
        {
            string headphonesName = this.peripheral.GetHeadphonesAndHeadphoneProducer().Item1;
            string producerName = this.peripheral.GetHeadphonesAndHeadphoneProducer().Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Peripherals.FirstOrDefault(p => p.name == headphonesName && p.producer == producerName && p.configId==this.configId);
            if (match == null)
            {
                db.AddToPeripherals(new Peripheral()
                {
                    name = headphonesName,
                    producer = producerName,
                    type = "headphones",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        public void PopulateDatabse()
        {
            try
            {
                this.InsertMouse();
                this.InsertKeyBoard();
                this.InsertOtherDevices();
                this.InsertVideoCamera();
                this.InsertMicrophone();
                this.InsertHeadphones();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not successfully populate Database with Peripherals.Reason: {0}", ex.Message);
            }
        }
    }
}
