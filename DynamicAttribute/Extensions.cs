using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace DynamicAttribute
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this IEnumerable collection)
        {
            foreach(var e in collection)
                yield return (T)e;
        }
    }

    //https://stackoverflow.com/questions/43331145/how-can-i-improve-performance-of-an-addrange-method-on-a-custom-bindinglist
    internal static class BindingListExtensions
    {
        public static void AddRange<T>(this BindingList<T> bindingList, IEnumerable<T> collection)
        {
            if(collection == null) throw new ArgumentNullException(nameof(collection));
            var oldRaiseEventsValue = bindingList.RaiseListChangedEvents;
            try
            {
                bindingList.RaiseListChangedEvents = false;

                foreach(var value in collection)
                    bindingList.Add(value);
            }
            finally
            {
                bindingList.RaiseListChangedEvents = oldRaiseEventsValue;

                if(bindingList.RaiseListChangedEvents)
                    bindingList.ResetBindings();
            }
        }
    }
}
