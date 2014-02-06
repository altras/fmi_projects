using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Catalog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // don't reload data during postbacks
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    // Fill the page with data
    private void PopulateControls()
    {
        // Retrieve DepartmentID from the query string
        string departmentId = Request.QueryString["DepartmentID"];
        // Retrieve CategoryID from the query string
        string categoryId = Request.QueryString["CategoryID"];
        // If browsing a category...
        if (categoryId != null)
        {
            // Retrieve category and department details and display them
            CategoryDetails cd = CatalogAccess.GetCategoryDetails(categoryId);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(cd.Name);
            DepartmentDetails dd = CatalogAccess.GetDepartmentDetails(departmentId);
            catalogDescriptionLabel.Text = HttpUtility.HtmlEncode(cd.Description);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(BalloonShopConfiguration.SiteName +
                         ": " + dd.Name + ": " + cd.Name);
        }
        // If browsing a department...
        else if (departmentId != null)
        {
            // Retrieve department details and display them
            DepartmentDetails dd = CatalogAccess.GetDepartmentDetails(departmentId);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(dd.Name);
            catalogDescriptionLabel.Text = HttpUtility.HtmlEncode(dd.Description);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(BalloonShopConfiguration.SiteName + ": " + dd.Name);
        }
    }
}

