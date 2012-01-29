/*Copyright (c) 2012 Giorgi Dalakishvili

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

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