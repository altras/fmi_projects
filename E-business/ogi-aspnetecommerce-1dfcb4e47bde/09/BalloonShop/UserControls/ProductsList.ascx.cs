using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
        // Retrieve Search string from query string
        string searchString = Request.QueryString["Search"];
        // How many pages of products?
        int howManyPages = 1;
        // pager links format
        string firstPageUrl = "";
        string pagerFormat = "";

        // If performing a product search
        if (searchString != null)
        {
            // Retrieve AllWords from query string
            string allWords = Request.QueryString["AllWords"];
            // Perform search
            list.DataSource = CatalogAccess.Search(searchString, allWords,
      page, out howManyPages);
            list.DataBind();
            // Display pager
            firstPageUrl = Link.ToSearch(searchString, allWords.ToUpper() == "TRUE", "1");
            pagerFormat = Link.ToSearch(searchString, allWords.ToUpper() == "TRUE", "{0}");
        }

        // If browsing a category...
        else if (categoryId != null)
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
            // get first page url and pager format
            firstPageUrl = Link.ToFrontpage("1");
            pagerFormat = Link.ToFrontpage("{0}");
        }

        // Display pager controls
        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, false);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
    }


    // Executed when each item of the list is bound to the data source
    protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        // obtain the attributes of the product
        DataRowView dataRow = (DataRowView)e.Item.DataItem;
        string productId = dataRow["ProductID"].ToString();
        DataTable attrTable = CatalogAccess.GetProductAttributes(productId);

        // get the attribute placeholder
        PlaceHolder attrPlaceHolder = (PlaceHolder)e.Item.FindControl("attrPlaceHolder");

        // temp variables
        string prevAttributeName = "";
        string attributeName, attributeValue, attributeValueId;

        // current DropDown for attribute values
        Label attributeNameLabel;
        DropDownList attributeValuesDropDown = new DropDownList();

        // read the list of attributes
        foreach (DataRow r in attrTable.Rows)
        {
            // get attribute data
            attributeName = r["AttributeName"].ToString();
            attributeValue = r["AttributeValue"].ToString();
            attributeValueId = r["AttributeValueID"].ToString();

            // if starting a new attribute (e.g. Color, Size)
            if (attributeName != prevAttributeName)
            {
                prevAttributeName = attributeName;
                attributeNameLabel = new Label();
                attributeNameLabel.Text = attributeName + ": ";
                attributeValuesDropDown = new DropDownList();
                attrPlaceHolder.Controls.Add(attributeNameLabel);
                attrPlaceHolder.Controls.Add(attributeValuesDropDown);
            }

            // add a new attribute value to the DropDownList
            attributeValuesDropDown.Items.Add(new ListItem(attributeValue, attributeValueId));
        }
    }

}
