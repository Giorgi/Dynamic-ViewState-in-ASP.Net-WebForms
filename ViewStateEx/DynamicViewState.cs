using System;
using System.Collections;
using System.Dynamic;
using System.Linq;
using System.Web.UI;

namespace ViewStateEx
{
    public class DynamicViewState : DynamicObject, IStateManager, IDictionary, ICollection, IEnumerable
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

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return Keys.Cast<string>().AsEnumerable();
        }

        public object this[string key]
        {
            get { return viewState[key]; }
            set { viewState[key] = value; }
        }

        #region StateBag Methods

        public StateItem Add(string key, object value)
        {
            return viewState.Add(key, value);
        }

        public bool IsItemDirty(string key)
        {
            return viewState.IsItemDirty(key);
        }

        public void Remove(string key)
        {
            viewState.Remove(key);
        }

        public void SetDirty(bool dirty)
        {
            viewState.SetDirty(dirty);
        }

        public void SetItemDirty(string key, bool dirty)
        {
            viewState.SetItemDirty(key, dirty);
        }

        #endregion

        #region Implementation of IStateManager

        void IStateManager.LoadViewState(object state)
        {
            ((IStateManager)viewState).LoadViewState(state);
        }

        object IStateManager.SaveViewState()
        {
            return ((IStateManager)viewState).SaveViewState();
        }

        void IStateManager.TrackViewState()
        {
            ((IStateManager)viewState).TrackViewState();
        }

        bool IStateManager.IsTrackingViewState
        {
            get { return ((IStateManager)viewState).IsTrackingViewState; }
        }

        #endregion

        #region Implementation of IDictionary

        void IDictionary.Add(object key, object value)
        {
            ((IDictionary)viewState).Add(key, value);
        }

        public void Clear()
        {
            viewState.Clear();
        }

        bool IDictionary.Contains(object key)
        {
            return ((IDictionary)viewState).Contains(key);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return viewState.GetEnumerator();
        }

        bool IDictionary.IsFixedSize
        {
            get { return ((IDictionary)viewState).IsFixedSize; }
        }

        bool IDictionary.IsReadOnly
        {
            get { return ((IDictionary)viewState).IsReadOnly; }
        }

        public ICollection Keys
        {
            get { return viewState.Keys; }
        }

        void IDictionary.Remove(object key)
        {
            ((IDictionary)viewState).Remove(key);
        }

        public ICollection Values
        {
            get { return viewState.Values; }
        }

        object IDictionary.this[object key]
        {
            get
            {
                return ((IDictionary)viewState)[key];
            }
            set
            {
                ((IDictionary)viewState)[key] = value;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((IDictionary)viewState).CopyTo(array, index);
        }

        public int Count
        {
            get { return viewState.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return ((IDictionary)viewState).IsSynchronized; }
        }

        object ICollection.SyncRoot
        {
            get { return ((IDictionary)viewState).SyncRoot; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary)viewState).GetEnumerator();
        }

        #endregion
    }
}