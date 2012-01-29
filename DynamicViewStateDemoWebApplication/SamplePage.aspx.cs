using System;

using ViewStateEx;

namespace DynamicViewStateDemoWebApplication
{
    public partial class SamplePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ViewState.loadCount++;
                loadLabel.Text = string.Format("Load count: {0}", ViewState.loadCount);
            }
            else
            {
                ViewState["loadCount"] = 0;
                loadLabel.Text = "Load count: 0";
            }
        }
    }
}