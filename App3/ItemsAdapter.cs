using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using static Android.Resource;

namespace App3
{
    internal class ItemsAdapter : RecyclerView.Adapter, IFilterable
    {
        private Products mItems;
        private Products currentItems;

        public event EventHandler<int> ItemClick;
        public ItemsAdapter(Products items)
        {
            mItems = items;
            currentItems = new Products(items.getItems());
            
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemHolder vh = holder as ItemHolder;
         
            //vh.Button.SetBackgroundResource(mItems[position].ItemID);
            vh.Label.Text = mItems[position].Name;
            vh.Counter.Text = mItems[position].InStock.ToString();

            
        }

        public void setItems(JavaList<Product> items)
        {
            mItems.setItems(items);
           
        }

        public override RecyclerView.ViewHolder
             OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.card, parent, false);
            ItemHolder vh = new ItemHolder(itemView);
            return vh;
        }
        
        public override int ItemCount
        {
            get { return mItems.NumItems; }
        }

        public Filter Filter
        {
            get { return FilterHelper.newInstace(currentItems, this); }
        }

        //void OnClick(int position)
        //{
        //    if (ItemClick != null)
        //        ItemClick(this, position);
        //}
    }
}