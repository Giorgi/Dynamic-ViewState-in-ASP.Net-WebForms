using System;
using System.Web.UI;

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
                //loadLabel.Text = ViewState.Person.Name;
            }
            else
            {
                ViewState.Person = new Person { Name = "Giorgi" };
                ViewState.loadCount = 0;
                loadLabel.Text = "Load count: 0";
            }
        }
    }

    [Serializable]
    class Person
    {
        public string Name { get; set; }
    }
}