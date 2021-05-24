using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace App3
{
    internal class FilterHelper:Filter
    {
        static Products currentItems;
        static ItemsAdapter adapter;

        protected override FilterResults PerformFiltering(ICharSequence constraint)
        {
            FilterResults filterResults = new FilterResults();
            if(constraint!=null && constraint.Length()>0)
            {
                string query = constraint.ToString().ToUpper();
                JavaList<Product> filteredItems = new JavaList<Product>();
                
                for(int i = 0; i < currentItems.NumItems; i++)
                {
                    string itemName = currentItems[i].Name;
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
            adapter.setItems((JavaList<Product>)results.Values);
            adapter.NotifyDataSetChanged();
        }

        internal static Filter newInstace(Products currentItems, ItemsAdapter itemsAdapter)
        {
            adapter = itemsAdapter;
            FilterHelper.currentItems = currentItems;
            return new FilterHelper();
        }
    }
    internal class FilterHelperCategory : Filter
    {
        static Products currentItems;
        static ItemsAdapter adapter;

        protected override FilterResults PerformFiltering(ICharSequence constraint)
        {
            
            FilterResults filterResults = new FilterResults();
            if (constraint != null && constraint.Length() > 0 && !constraint.ToString().ToUpper().Equals("ALL"))
            {
                string query = constraint.ToString().ToUpper();
               
                JavaList<Product> filteredItems = new JavaList<Product>();
                

                    for (int i = 0; i < currentItems.NumItems; i++)
                    {
                        string itemName = RecycleActivity.repositoryDB.GetCategoryById(currentItems[i].categoryId).Name;
                        if (itemName.ToUpper().Contains(query.ToString())&& currentItems[i].getType()>=1)
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
            adapter.setItems((JavaList<Product>)results.Values);
            adapter.NotifyDataSetChanged();
        }

        internal static Filter newInstace(Products currentItems, ItemsAdapter itemsAdapter)
        {
            adapter = itemsAdapter;
            FilterHelperCategory.currentItems = currentItems;
            return new FilterHelperCategory();
        }
    }
}