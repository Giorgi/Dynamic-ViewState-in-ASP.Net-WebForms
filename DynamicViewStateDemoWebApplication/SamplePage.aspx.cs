using System;

namespace DynamicViewStateDemoWebApplication
{
    public partial class SamplePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ViewBag.loadCount++;

                loadLabel.Text = string.Format("Load count: {0}", ViewState["loadCount"]);
            }
            else
            {
                ViewBag.loadCount = 0;
                loadLabel.Text = "Load count: 0";
            }
        }
    }
}