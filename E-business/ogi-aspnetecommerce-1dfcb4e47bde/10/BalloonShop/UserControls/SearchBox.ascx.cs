using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SearchBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // don't repopulate control on postbacks
        if (!IsPostBack)
        {
            // load search box controls' values
            string allWords = Request.QueryString["AllWords"];
            string searchString = Request.QueryString["Search"];
            if (allWords != null)
                allWordsCheckBox.Checked = (allWords.ToUpper() == "TRUE");
            if (searchString != null)
                searchTextBox.Text = searchString;
        }
    }

    protected void goButton_Click(object sender, EventArgs e)
    {
        ExecuteSearch();
    }

    // Redirect to the search results page
    private void ExecuteSearch()
    {
        string searchText = searchTextBox.Text;
        bool allWords = allWordsCheckBox.Checked;
        if (searchTextBox.Text.Trim() != "")
            Response.Redirect(Link.ToSearch(searchText, allWords, "1"));
    }

}
