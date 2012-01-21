using System.Web.UI;

namespace DynamicViewStateDemoWebApplication
{
    public class BasePage : Page
    {
        private readonly dynamic viewBag;

        public BasePage()
        {
            viewBag = new DynamicViewState(base.ViewState);
        }

        protected new dynamic ViewState
        {
            get { return viewBag; }
        }
    }
}