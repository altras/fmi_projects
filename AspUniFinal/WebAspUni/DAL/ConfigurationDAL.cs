using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    public static class ConfigurationDAL
    {
        private const int nuberBoxSetsPerPage = 1;
        public static List<Configuration> ConfigurationOnPage(int pageNumber = 1, int boxSetsPerPage = nuberBoxSetsPerPage)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Configurations.OrderBy(b => b.id).Skip((pageNumber - 1) * boxSetsPerPage).Take(boxSetsPerPage).ToList();
            }
            catch (Exception ex)
            {
                throw new ConfigurationDALException("Couldn't retrieve Configuration on page " + pageNumber, ex);
            }
        }

        public static int PageCount(int boxPerPage = nuberBoxSetsPerPage)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            int count = db.Configurations.Count() / boxPerPage;
            count += db.Configurations.Count() % boxPerPage > 0 ? 1 : 0;
            return count;
        }

        public static BoxSet GetBoxSetById(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.BoxSets.FirstOrDefault(b => b.id == id);
            }
            catch (Exception ex)
            {
                throw new BoxSetDALException("Couldn't retrieve BoxSet with id = " + id, ex);
            }
        }
        public static Monitor GetMonitorById(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Monitors.FirstOrDefault(m => m.id == id);
            }
            catch (Exception ex)
            {
                throw new MonitorDALException("Couldn't retrieve monitor with id = " + id, ex);
            }
        }
        public static List<Peripheral> GetPeripheralsByConfigId(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Peripherals.Where(p => p.configId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new PeripheralDALException("Couldn't retrieve Peripherals with configid = " + id, ex);
            }
        }

        public static IQueryable<Software> GetSoftwareByConfigId(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Softwares.Where(s => s.configId == id);
            }
            catch (Exception ex)
            {
                throw new PeripheralDALException("Couldn't retrieve Software with configid = " + id, ex);
            }
        }

        public static Material GetMaterialById(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Materials.FirstOrDefault(s => s.id == id);
            }
            catch (Exception ex)
            {
                throw new MaterialDALException("Couldn't retrieve Materials with configid = " + id, ex);
            }
        }
        public static Cpu GetCpulById(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Cpus.FirstOrDefault(s => s.id == id);
            }
            catch (Exception ex)
            {
                throw new CpuDALException("Couldn't retrieve Cpu with id = " + id, ex);
            }
        }
        public static Hdd GetHddlById(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.Hdds.FirstOrDefault(s => s.id == id);
            }
            catch (Exception ex)
            {
                throw new HddDALException("Couldn't retrieve Hdd with id = " + id, ex);
            }
        }
        public static VideoCard GetVideoCardlById(int id)
        {
            CustomComputersAspEntities db = new CustomComputersAspEntities();
            try
            {
                return db.VideoCards.FirstOrDefault(s => s.id == id);
            }
            catch (Exception ex)
            {
                throw new VideoCardDALException("Couldn't retrieve VideoCard with id = " + id, ex);
            }
        }
    }
}
