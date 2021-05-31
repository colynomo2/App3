using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;
using System.Collections.Generic;
using static Android.Resource;

namespace App3
{
    public class ItemsAdapter : RecyclerView.Adapter, IFilterable,IMenuItemOnMenuItemClickListener,View.IOnLongClickListener
    {
        public Products mItems;
        public Products currentItems;
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
            
            holder.ItemView.SetOnLongClickListener(this);
            switch (mItems[position].getType()) {
                case 1:
                    {

                        ItemHolder vh = holder as ItemHolder;

                        //vh.Button.SetBackgroundResource(mItems[position].ItemID);
                        vh.Name.Text = mItems[position].Name;
                        vh.InStock.Text = mItems[position].InStock.ToString();
                        vh.Price.Text = mItems[position].Price.ToString();
                        vh.Category.Text = db.GetCategoryById(mItems[position].categoryId).Name;
                        
                        vh.SlectedCheckBox.Checked = mItems[vh.AdapterPosition].Checked;
                        if (!vh.SlectedCheckBox.HasOnClickListeners)
                        {
                            vh.SlectedCheckBox.Click += (sender, e) =>
                            {
                                mItems[vh.AdapterPosition].Checked = !mItems[vh.AdapterPosition].Checked;
                            };
                        }
                        if(!vh.hiddenDelete.HasOnClickListeners)
                        {
                            vh.hiddenDelete.Click += (sender, e) =>
                            {
                                delete(vh.AdapterPosition);
                            };
                        }
                        if (!vh.hiddenEdit.HasOnClickListeners)
                        {
                            vh.hiddenEdit.Click += (sender, e) =>
                            {
                                edit(vh.AdapterPosition);
                            };
                        }
                        break;
                    }
                case 0:
                    {
                        ItemHolder2 vh = holder as ItemHolder2;
                        vh.Name.Text = "EMPTY\nEMPTY\nEMPTY";
                        break;
                    }

        }

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
        public override int GetItemViewType(int position)
        {
            return mItems[position].getType();
            

        }
        public override RecyclerView.ViewHolder
             OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            switch (viewType)
            {
                case 1:
                    {
                        View itemView = LayoutInflater.From(parent.Context).
                                    Inflate(Resource.Layout.card, parent, false);

                        ItemHolder vh = new ItemHolder(itemView, this);
                        return vh;
                    }
                case 0:
                    {
                        View itemView = LayoutInflater.From(parent.Context).
                                   Inflate(Resource.Layout.card2, parent, false);

                        ItemHolder2 vh = new ItemHolder2(itemView, this);
                        return vh;
                    }   
            }
            return null;
        }
        
        public override int ItemCount
        {
            get { return mItems.NumItems; }
        }

        public Filter Filter
        {
            get { return FilterHelper.newInstace(currentItems, this); }
        }

        public Filter FilterCategory
        {
            get { return FilterHelperCategory.newInstace(currentItems, this); }
        }
        public void OnClick()
        {
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

           
            if (ItemClick != null)
                ItemClick(this, recycleActivity.lastPosition);
        }
        //public void deleteSelected()
        //{
        //    for (int i = 0; i < isChecked.Capacity; i++)
        //    {
        //        if (isChecked[i] == true)
        //        {
        //            db.delete(mItems[i]);
        //            mItems.deleteProduct(i);
        //            isChecked.RemoveAt(i);
        //        }
                
        //    }
        //    NotifyDataSetChanged();
        //}
        public void delete(int position)
        {
            
            db.delete(mItems[position]);
            currentItems.deleteProduct(mItems.deleteProduct(position));
            
            NotifyItemRemoved(position);
        }

        public void edit(int position)
        {
            recycleActivity.StartEditMode(mItems[position],position);
        }


    }
}