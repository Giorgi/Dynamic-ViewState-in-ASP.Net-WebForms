using System.Dynamic;
using System.Web.UI;

namespace DynamicViewStateDemoWebApplication
{
    public class BasePage : Page
    {
        private class DynamicViewState : DynamicObject
        {
            private readonly BasePage basePage;

            public DynamicViewState(BasePage basePage)
            {
                this.basePage = basePage;
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                basePage.ViewState[binder.Name] = value;
                return true;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = basePage.ViewState[binder.Name];

                return true;
            }

            public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
            {
                if (indexes.Length == 1)
                {
                    basePage.ViewState[indexes[0].ToString()] = value;
                    return true;
                }
                return base.TrySetIndex(binder, indexes, value);
            }

            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
            {
                if (indexes.Length == 1)
                {
                    result = basePage.ViewState[indexes[0].ToString()];
                    return true;
                }
                return base.TryGetIndex(binder, indexes, out result);
            }
        }

        private readonly dynamic viewBag;

        public BasePage()
        {
            viewBag = new DynamicViewState(this);
        }

        protected dynamic ViewBag
        {
            get { return viewBag; }
        }
    }
}