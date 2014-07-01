using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WebAspUni.XMLvalidation;
using WebAspUni.InsertIntoDataBase;
using WebAspUni.XMLDocumentParsing;
using System.Reflection;
using System.IO;

namespace WebAspUni.CreatingNewEntry
{
    public class XMLSingleFileInsert
    {
        private string xmlPath = null;
        public XMLSingleFileInsert(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }

        public void Insert()
        {
            XMLValidator validator = new XMLValidator();
            XmlDocument doc = new XmlDocument();
            doc.Load(this.xmlPath);
            if (validator.ValidateXml(validator.XmlShcemaPath, this.xmlPath))
            {
                XMLMonitorParse monitor = new XMLMonitorParse(doc);
                XMLBoxSetParse box = new XMLBoxSetParse(doc);
                XMLPeripheralsParse per = new XMLPeripheralsParse(doc);
                XMLAdditionalSoftwareParse soft = new XMLAdditionalSoftwareParse(doc);

                InsertMonitor insMonitor = new InsertMonitor(monitor);
                int monId = insMonitor.PopulateDatabase();
                InsertBoxSet insBox = new InsertBoxSet(box);
                int boxId = insBox.PopulateDataBase();
                InsertConfiguration insConfig = new InsertConfiguration();
                int configId = insConfig.PopulateDataBase(boxId,monId);
                InsertPeripheral insPer = new InsertPeripheral(per, configId);
                insPer.PopulateDatabse();
                InsertSoftware insSoft = new InsertSoftware(soft, configId);
                insSoft.PopulateDataBase();
            }
        }
    }
}