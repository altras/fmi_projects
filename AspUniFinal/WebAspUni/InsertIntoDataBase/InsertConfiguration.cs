using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.InsertIntoDataBase
{
    public class InsertConfiguration
    {
        public InsertConfiguration()
        {
        }

        public int PopulateDataBase(int boxId, int monitorId)
        {
            try
            {
                CustomComputersAspEntities db = new CustomComputersAspEntities();

                Configuration match = db.Configurations.FirstOrDefault(c => c.boxId == boxId && c.monitorId == monitorId);
                if (match == null)
                {
                    db.AddToConfigurations(new Configuration()
                    {
                        boxId = boxId,
                        monitorId = monitorId
                    });
                    db.SaveChanges();
                    match = db.Configurations.FirstOrDefault(c => c.boxId == boxId && c.monitorId == monitorId);
                }
                return match.id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not successfully populate DataBase with Configuration. Reason: {0}", ex.Message);
                return 0;
            }
        }
    }
}
