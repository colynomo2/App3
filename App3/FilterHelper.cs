using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace App3
{
    internal class FilterHelper:Filter
    {
        static Items currentItems;
        static ItemsAdapter adapter;

        protected override FilterResults PerformFiltering(ICharSequence constraint)
        {
            FilterResults filterResults = new FilterResults();
            if(constraint!=null && constraint.Length()>0)
            {
                string query = constraint.ToString().ToUpper();
                JavaList<Item> filteredItems = new JavaList<Item>();
                
                for(int i = 0; i < currentItems.NumItems; i++)
                {
                    string itemName = currentItems[i].Text;
                    if(itemName.ToUpper().Contains(query.ToString()))
                    {
                        filteredItems.Add(currentItems[i]);
                    }
                }
                filterResults.Count = filteredItems.Count;
                filterResults.Values = filteredItems;


            }
            else
            {
                filterResults.Count = currentItems.NumItems;
                filterResults.Values = currentItems.getItems();

            }
            return filterResults;
        }

        protected override void PublishResults(ICharSequence constraint, FilterResults results)
        {
            adapter.setItems((JavaList<Item>)results.Values);
            adapter.NotifyDataSetChanged();
        }

        internal static Filter newInstace(Items currentItems, ItemsAdapter itemsAdapter)
        {
            adapter = itemsAdapter;
            FilterHelper.currentItems = currentItems;
            return new FilterHelper();
        }
    }
}