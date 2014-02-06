using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ProductsList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateControls();
    }

    private void PopulateControls()
    {
        // Retrieve DepartmentID from the query string
        string departmentId = Request.QueryString["DepartmentID"];
        // Retrieve CategoryID from the query string
        string categoryId = Request.QueryString["CategoryID"];
        // Retrieve Page from the query string
        string page = Request.QueryString["Page"];
        if (page == null) page = "1";
        // How many pages of products?
        int howManyPages = 1;
        // pager links format
        string firstPageUrl = "";
        string pagerFormat = "";

        // If browsing a category...
        if (categoryId != null)
        {
            // Retrieve list of products in a category
            list.DataSource =
            CatalogAccess.GetProductsInCategory(categoryId, page, out howManyPages);
            list.DataBind();
            // get first page url and pager format
            firstPageUrl = Link.ToCategory(departmentId, categoryId, "1");
            pagerFormat = Link.ToCategory(departmentId, categoryId, "{0}");
        }
        else if (departmentId != null)
        {
            // Retrieve list of products on department promotion
            list.DataSource = CatalogAccess.GetProductsOnDeptPromo
            (departmentId, page, out howManyPages);
            list.DataBind();
            // get first page url and pager format
            firstPageUrl = Link.ToDepartment(departmentId, "1");
            pagerFormat = Link.ToDepartment(departmentId, "{0}");
        }
        else
        {
            // Retrieve list of products on catalog promotion
            list.DataSource =
            CatalogAccess.GetProductsOnFrontPromo(page, out howManyPages);
            list.DataBind();
            // have the current page as integer
            int currentPage = Int32.Parse(page);

        }

        // Display pager controls
        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, false);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
    }
}
