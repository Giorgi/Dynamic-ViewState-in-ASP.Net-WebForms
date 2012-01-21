using System.Dynamic;
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

    internal class DynamicViewState : DynamicObject
    {
        private readonly StateBag viewState;

        public DynamicViewState(StateBag viewState)
        {
            this.viewState = viewState;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            viewState[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = viewState[binder.Name];

            return true;
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length == 1)
            {
                viewState[indexes[0].ToString()] = value;
                return true;
            }
            return base.TrySetIndex(binder, indexes, value);
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1)
            {
                result = viewState[indexes[0].ToString()];
                return true;
            }
            return base.TryGetIndex(binder, indexes, out result);
        }
    }
}