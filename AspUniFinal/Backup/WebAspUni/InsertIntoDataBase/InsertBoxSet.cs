using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAspUni.XMLDocumentParsing;

namespace WebAspUni.InsertIntoDataBase
{
    public class InsertBoxSet
    {
        private XMLBoxSetParse boxSet;

        public InsertBoxSet()
        {
        }

        public InsertBoxSet(XMLBoxSetParse box)
        {
            this.boxSet = box;
        }

        private int InsertCpu()
        {
            string cpu = this.boxSet.GetCpuAndCpuProducer().Item1;
            string cpuProducer = this.boxSet.GetCpuAndCpuProducer().Item2;

            CustomComputersAspEntities db = new CustomComputersAspEntities();
            Cpu match = db.Cpus.FirstOrDefault(c => c.name == cpu && c.producer == cpuProducer);
            if (match == null)
            {
                db.AddToCpus(new Cpu()
                {
                    name = cpu,
                    producer = cpuProducer
                });
                db.SaveChanges();
                match = db.Cpus.FirstOrDefault(c => c.name == cpu && c.producer == cpuProducer);
            }
            return match.id;
        }

        private int InsertVideoCard()
        {
            string video = this.boxSet.GetVideoCardAndVideoCardProducer().Item1;
            string videoProducer = this.boxSet.GetVideoCardAndVideoCardProducer().Item2;

            CustomComputersAspEntities db = new CustomComputersAspEntities();
            VideoCard match = db.VideoCards.FirstOrDefault(v => v.name == video && v.producer == videoProducer);
            if (match == null)
            {
                db.AddToVideoCards(new VideoCard()
                {
                    name = video,
                    producer = videoProducer
                });
                db.SaveChanges();
                match = db.VideoCards.FirstOrDefault(v => v.name == video && v.producer == videoProducer);
            }
            return match.id;
        }

        private int InsertHdd()
        {
            string hdd = this.boxSet.GetHddAndHddProducer().Item1;
            string hddProducer = this.boxSet.GetHddAndHddProducer().Item2;

            CustomComputersAspEntities db = new CustomComputersAspEntities();
            Hdd match = db.Hdds.FirstOrDefault(h => h.name == hdd && h.producer == hddProducer);
            if (match == null)
            {
                db.AddToHdds(new Hdd()
                {
                    name = hdd,
                    producer = hddProducer
                });
                db.SaveChanges();
                match = db.Hdds.FirstOrDefault(h => h.name == hdd && h.producer == hddProducer);
            }
            return match.id;
        }

        public int PopulateDataBase()
        {
            try
            {
                int cpuId = this.InsertCpu();
                int videoId = this.InsertVideoCard();
                int hddId = this.InsertHdd();
                string motherBoard = this.boxSet.GetMotherBoard();
                string ram = this.boxSet.GetRam();
                string coolSys = this.boxSet.GetCoolingSystem();
                string soundCard = this.boxSet.GetSoundCard();
                string powerSupply = this.boxSet.GetPowerSupply();
                string expansionCard = this.boxSet.GetExpansionCard();
                string box = this.boxSet.GetBox();
                string usb = this.boxSet.GetRemovableDevices().Item1;
                string disk = this.boxSet.GetRemovableDevices().Item2;
                string cardReader = this.boxSet.GetRemovableDevices().Item3;
                string removableDev = usb + "; " + disk + "; " + cardReader;

                CustomComputersAspEntities db = new CustomComputersAspEntities();

                BoxSet match = db.BoxSets.FirstOrDefault(b => b.cupId == cpuId && b.videoCardId == videoId && b.hddId == hddId
                                                           && b.motherboard == motherBoard && b.ram == ram && b.coolingSystem == coolSys
                                                           && b.powerSupply == powerSupply && b.expansionCards == expansionCard
                                                           && b.box == box && b.removableDevices == removableDev);
                if (match == null)
                {
                    db.AddToBoxSets(new BoxSet()
                    {
                        cupId = cpuId,
                        videoCardId = videoId,
                        hddId = hddId,
                        motherboard = motherBoard,
                        ram = ram,
                        coolingSystem = coolSys,
                        powerSupply = powerSupply,
                        expansionCards = expansionCard,
                        box = box,
                        removableDevices = removableDev,
                    });
                    db.SaveChanges();
                    match = db.BoxSets.FirstOrDefault(b => b.cupId == cpuId && b.videoCardId == videoId && b.hddId == hddId
                                                           && b.motherboard == motherBoard && b.ram == ram && b.coolingSystem == coolSys
                                                           && b.powerSupply == powerSupply && b.expansionCards == expansionCard
                                                           && b.box == box && b.removableDevices == removableDev);
                }
                return match.id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not successsfully populate DataBase with BoxSet. Reason: {0}",ex.Message);
                return 0;
            }
        }
    }
}
