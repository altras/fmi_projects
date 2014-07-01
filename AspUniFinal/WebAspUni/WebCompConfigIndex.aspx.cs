using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAspUni.DAL;

namespace WebAspUni
{
    public partial class WebCompConfigIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Page"] == "First")
            {
                ViewState["page"] = 1;
            }
            else if (Request.Params["Page"] == "Last")
            {
                ViewState["page"] = ConfigurationDAL.PageCount();
            }
            else
            {
                ViewState["page"] = Request.Params["Page"] == null ? 1 : 0;
                if ((int)ViewState["page"] == 0)
                {
                    int page = 1;
                    int.TryParse(Request.Params["Page"], out page);
                    ViewState["page"] = page;
                }
            }
            if(!Page.IsPostBack)
            {
                
                ViewState["pageCount"] = ConfigurationDAL.PageCount();
                if ((int)ViewState["page"] > (int)ViewState["pageCount"] || (int)ViewState["page"] < 0)
                {
                    ViewState["page"] = 1;
                }
                LiteralPage.Text = ViewState["page"] + "/" + ViewState["pageCount"];
            }

            var config = ConfigurationDAL.ConfigurationOnPage((int)ViewState["page"])[0];

            this.FillBoxSetTable(config.boxId);
            this.FillMonitorTable(config.monitorId);
            this.FillPeripheralsTable(config.id);
            this.FillSoftwareTable(config.id);
            LastPageLink.NavigateUrl = @"\WebCompConfigIndex.aspx?page=" + PageCount;
            this.BindPagingRepeater();
        }
        public int PageCount { get { return (int)ViewState["pageCount"]; } }
        private void BindPagingRepeater()
        {
            List<int> pages = new List<int>();
            for (int i = 1; i <= (int)ViewState["pageCount"]; i++)
            {
                if (i != (int)ViewState["page"])
                {
                    pages.Add(i);
                }
                else
                {

                }
            }
            RepeaterPaging.DataSource = pages;
            RepeaterPaging.DataBind();
        }

        private void FillBoxSetTable(int boxId)
        {
            List<Tuple<string, string>> boxList = new List<Tuple<string, string>>();
            BoxSet box = ConfigurationDAL.GetBoxSetById(boxId);
            Cpu cp = ConfigurationDAL.GetCpulById(box.cupId);
            Hdd hdd = ConfigurationDAL.GetHddlById(box.hddId);
            VideoCard video = ConfigurationDAL.GetVideoCardlById(box.videoCardId);
            boxList.Add(new Tuple<string, string>("номер", box.id.ToString()));
            boxList.Add(new Tuple<string, string>("процесор", cp.name));
            boxList.Add(new Tuple<string, string>("процесорен производител", cp.producer));
            boxList.Add(new Tuple<string, string>("дъно", box.motherboard));
            boxList.Add(new Tuple<string, string>("рам", box.ram));
            boxList.Add(new Tuple<string, string>("видео карта", video.name));
            boxList.Add(new Tuple<string, string>("производител на видео карта", video.producer));
            boxList.Add(new Tuple<string, string>("охлаждане", box.coolingSystem));
            boxList.Add(new Tuple<string, string>("захранване", box.powerSupply));
            boxList.Add(new Tuple<string, string>("лан карта", box.expansionCards));
            boxList.Add(new Tuple<string, string>("хард диск", hdd.name));
            boxList.Add(new Tuple<string, string>("производител на хард диск", hdd.producer));
            boxList.Add(new Tuple<string, string>("преносими устройства", box.removableDevices));
            boxList.Add(new Tuple<string, string>("кутия", box.box));
            BoxSetGrid.DataSource = boxList;
            BoxSetGrid.DataBind();
        }

        private void FillMonitorTable(int monitorId)
        {
            Monitor mon = ConfigurationDAL.GetMonitorById(monitorId);
            Material mat = ConfigurationDAL.GetMaterialById(mon.materialsId);

            List<Tuple<string, string>> monitorList = new List<Tuple<string, string>>();
            monitorList.Add(new Tuple<string, string>("номер", mon.id.ToString()));
            monitorList.Add(new Tuple<string, string>("номер на материали", mon.materialsId.ToString()));
            monitorList.Add(new Tuple<string, string>("матрица", mon.matrix));
            monitorList.Add(new Tuple<string, string>("aspect ratio", mon.aspectRatio));
            monitorList.Add(new Tuple<string, string>("led", mon.led));
            monitorList.Add(new Tuple<string, string>("производител", mon.producer));
            monitorList.Add(new Tuple<string, string>("материали на поставка", mat.stand));
            monitorList.Add(new Tuple<string, string>("материали на дисплей", mat.display));
            MonitorGridView.DataSource = monitorList;
            MonitorGridView.DataBind();
        }

        private void FillPeripheralsTable(int configId)
        {
            var peripherals = ConfigurationDAL.GetPeripheralsByConfigId(configId);
            List<Tuple<string, string, string, string>> peripheralList = new List<Tuple<string, string, string, string>>();
            foreach (var peripheral in peripherals)
            {
                peripheralList.Add(new Tuple<string, string, string, string>(peripheral.id.ToString(), peripheral.name, peripheral.type, peripheral.producer));
            }
            PeripheralGridView.DataSource = peripheralList;
            PeripheralGridView.DataBind();
        }

        private void FillSoftwareTable(int configId)
        {
            var software = ConfigurationDAL.GetSoftwareByConfigId(configId);
            List<Tuple<string, string, string, string>> softwareList = new List<Tuple<string, string, string, string>>();
            foreach (var soft in software)
            {
                softwareList.Add(new Tuple<string, string, string, string>(soft.id.ToString(), soft.name, soft.type, soft.producer));
            }
            SoftwareGridView.DataSource = softwareList;
            SoftwareGridView.DataBind();
        }
    }
}