A sample project showing how to access ViewState data dynamically by using DynamicObject class in the same manner as ViewBag in ASP.NET MVC 3

``` csharp
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
```

Related blog posts:
http://www.aboutmycode.com/asp-net/dynamic-viewstate-in-asp-net-webforms/
http://www.aboutmycode.com/asp-net/dynamic-viewstate-in-asp-net-webforms-part-2/
