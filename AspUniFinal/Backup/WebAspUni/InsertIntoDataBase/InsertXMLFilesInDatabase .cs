using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WebAspUni.XMLDocumentParsing;
using WebAspUni.XMLvalidation;

namespace WebAspUni.InsertIntoDataBase
{
    public class InsertXMLFilesInDatabase
    {
        public InsertXMLFilesInDatabase()
        {
        }

        public Tuple<List<string>,List<string>> InsertFiles(string xmlFolderPath)
        {
            try
            {
                XMLSingleFileLoader manipulator = new XMLSingleFileLoader();
                string[] xmlPaths = Directory.GetFiles(xmlFolderPath);
                XMLValidator validator = new XMLValidator();
                //valid and invalid xmls list.
                List<string> validXmls = new List<string>();
                List<string> invalidXmls = new List<string>();

                foreach (string path in xmlPaths)
                {
                    if (validator.ValidateXml(validator.XmlShcemaPath, path))
                    {
                        manipulator.LoadXmlFile(path);
                        XMLMonitorParse mon = new XMLMonitorParse(manipulator.Doc);
                        InsertMonitor insMonitor = new InsertMonitor(mon);
                        XMLBoxSetParse box = new XMLBoxSetParse(manipulator.Doc);
                        InsertBoxSet insBox = new InsertBoxSet(box);

                        int monitorId = insMonitor.PopulateDatabase();
                        int boxId = insBox.PopulateDataBase();

                        InsertConfiguration config = new InsertConfiguration();

                        int configId = config.PopulateDataBase(boxId, monitorId);

                        XMLAdditionalSoftwareParse sof = new XMLAdditionalSoftwareParse(manipulator.Doc);
                        InsertSoftware insSoftware = new InsertSoftware(sof, configId);
                        XMLPeripheralsParse per = new XMLPeripheralsParse(manipulator.Doc);
                        InsertPeripheral insPeripheral = new InsertPeripheral(per, configId);

                        insSoftware.PopulateDataBase();
                        insPeripheral.PopulateDatabse();

                        validXmls.Add(path);
                    }
                    else
                    {
                        invalidXmls.Add(path);
                    }
                }
                Tuple<List<string>, List<string>> result = new Tuple<List<string>, List<string>>(validXmls, invalidXmls);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not load successfully xml files into Database.Reason: {0}", ex.Message);
                return null;
            }
        }
    }
}
