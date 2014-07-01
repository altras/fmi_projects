using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAspUni.XMLDocumentParsing;

namespace WebAspUni.InsertIntoDataBase
{
    public class InsertMonitor
    {
        private XMLMonitorParse monitor = null;
        public InsertMonitor()
        {
        }

        public InsertMonitor(XMLMonitorParse monitor)
        {
            this.monitor = monitor;
        }

        public int PopulateDatabase()
        {
            try
            {
                CustomComputersAspEntities db = new CustomComputersAspEntities();
                int materialsid = this.InsertMaterials();
                string producerMonitor = this.monitor.GetMonitorProducer();
                string ledMonitor = this.monitor.GetLed();
                string aspectRatioMonitor = this.monitor.GetAspecRatio().Item1.ToString() + "x" + this.monitor.GetAspecRatio().Item2.ToString();
                string matrixMonitor = this.monitor.GetMatrixAndMatrixProducer().Item1;
                Monitor match = db.Monitors.FirstOrDefault(m => m.led == ledMonitor && m.aspectRatio == aspectRatioMonitor && m.producer == producerMonitor
                                                                && m.matrix == matrixMonitor && m.materialsId == materialsid);
                if (match == null)
                {
                    db.AddToMonitors(new Monitor()
                    {
                        led = ledMonitor,
                        aspectRatio = aspectRatioMonitor,
                        producer = producerMonitor,
                        materialsId = materialsid,
                        matrix = matrixMonitor
                    });
                    db.SaveChanges();
                    match = db.Monitors.FirstOrDefault(m => m.led == ledMonitor && m.aspectRatio == aspectRatioMonitor && m.producer == producerMonitor
                                                                    && m.matrix == matrixMonitor && m.materialsId == materialsid);
                }
                return match.id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not successfully populate DB with monitor information. Reason: {0}", ex.Message);
                return 0;
            }
        }

        private int InsertMaterials()
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            string standmaterial = this.monitor.GetMaterials().Item1;
            string displaymaterial = this.monitor.GetMaterials().Item2;
            Material match = db.Materials.FirstOrDefault(x => x.stand == standmaterial && x.display == displaymaterial);
            if (match == null)
            {
                db.AddToMaterials(new Material()
                {
                    stand = standmaterial,
                    display = displaymaterial
                });
                db.SaveChanges();
            }
            match = db.Materials.FirstOrDefault(x => x.stand == standmaterial && x.display == displaymaterial);
            return match.id;
        }
    }
}
