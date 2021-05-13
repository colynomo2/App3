using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using static Android.Resource;

namespace App3
{
    public class ItemsAdapter : RecyclerView.Adapter, IFilterable,IMenuItemOnMenuItemClickListener,View.IOnLongClickListener
    {
        public Products mItems;
        private Products currentItems;
        private int positionx;
        private RecyclerView recyclerView;
        public event EventHandler<int> ItemClick;
        RepositoryDB db;
        RecycleActivity recycleActivity;
        public ItemsAdapter(Products items,RecyclerView recyclerView,RepositoryDB db,RecycleActivity recycleActivity)
        {
            this.db = db;
            mItems = items;
            this.recyclerView = recyclerView;
            currentItems = new Products(items.getItems());
            this.recycleActivity = recycleActivity;
        }
        public bool OnLongClick(View v)
        {
            positionx = recyclerView.GetChildAdapterPosition(v);
            return false;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemHolder vh = holder as ItemHolder;
         
            //vh.Button.SetBackgroundResource(mItems[position].ItemID);
            vh.Label.Text = mItems[position].Name;
            vh.Counter.Text = mItems[position].InStock.ToString();
            holder.ItemView.SetOnLongClickListener(this);
    
        }
        public bool OnMenuItemClick(IMenuItem item)
        {
            switch (item.TitleFormatted.ToString())
            {
                case "Delete":
                    {
                        delete(positionx);
                        return true;

                    }
                case "Edit":
                    {
                        edit(positionx);
                        return true;
                    }
            }
            return false;
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

            ItemHolder vh = new ItemHolder(itemView,this);
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

        //void OnClick(int position,string option)
        //{
        //    switch(option)
        //    {
        //        case "Delete":
        //            {
        //                delete(position);
        //                break;
        //            }
        //        case "Edit":
        //            {
        //                edit(position);
        //                break;
        //            }

        //    }
        //    //if (ItemClick != null)
        //    //    ItemClick(this, position);
        //}

        private void delete(int position)
        {
            
            db.delete(mItems[position]);
            mItems.deleteProduct(position);
            NotifyItemRemoved(position);
        }

        private void edit(int position)
        {
            recycleActivity.StartEditMode(mItems[position],position);
        }


    }
}