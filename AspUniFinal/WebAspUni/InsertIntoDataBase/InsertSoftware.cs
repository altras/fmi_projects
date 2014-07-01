using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAspUni.XMLDocumentParsing;

namespace WebAspUni.InsertIntoDataBase
{
    public class InsertSoftware
    {
        private XMLAdditionalSoftwareParse software;
        private int configId;

        public InsertSoftware()
        {
        }

        public InsertSoftware(XMLAdditionalSoftwareParse softParser, int configId)
        {
            this.software = softParser;
            this.configId = configId;
        }

        private void InsertOs()
        {
            string os = this.software.GetOsAndProducer().Item1;
            string osProducer = this.software.GetOsAndProducer().Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Softwares.FirstOrDefault(s => s.name == os && s.producer == osProducer && s.configId==this.configId);
            if (match == null)
            {
                db.AddToSoftwares(new Software()
                {
                    name = os,
                    producer = osProducer,
                    type = "os",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertAntivirus()
        {
            string antiVirus = this.software.GetAntiVirusAndProducer().Item1;
            string antiVirusProducer = this.software.GetAntiVirusAndProducer().Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Softwares.FirstOrDefault(s => s.name == antiVirus && s.producer == antiVirusProducer && s.configId == this.configId);
            if (match == null)
            {
                db.AddToSoftwares(new Software()
                {
                    name = antiVirus,
                    producer = antiVirusProducer,
                    type = "antiVirus",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        private void InsertGame(int gameNumber)
        {
            int newGameNumber = gameNumber - 1;
            string game = this.software.GetGameAndProducer(newGameNumber).Item1;
            string gameProducer = this.software.GetGameAndProducer(newGameNumber).Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Softwares.FirstOrDefault(s => s.name == game && s.producer == gameProducer && s.configId == this.configId);
            if(match == null)
            {
                db.AddToSoftwares(new Software()
                {
                    name = game,
                    producer = gameProducer,
                    type = "game",
                    configId = this.configId
                });
            db.SaveChanges();
            }
        }

        private void InsertOther()
        {
            string other = this.software.GetOther().Item1;
            string otherProducer = this.software.GetOther().Item2;
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            var match = db.Softwares.FirstOrDefault(s => s.name == other && s.producer == otherProducer && s.configId == this.configId);
            if (match == null)
            {
                db.AddToSoftwares(new Software()
                {
                    name = other,
                    producer = otherProducer,
                    type = "other",
                    configId = this.configId
                });
                db.SaveChanges();
            }
        }

        public void  PopulateDataBase()
        {
            try
            {
                this.InsertOs();
                this.InsertAntivirus();
                this.InsertGame(1);
                this.InsertGame(2);
                this.InsertGame(3);
                this.InsertOther();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not successfully populate Data Base with SoftWare Data.Reason:{0}", ex.Message);
            }
        }
    }
}
