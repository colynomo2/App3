using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App3
{
    public class ItemHolder : RecyclerView.ViewHolder,View.IOnCreateContextMenuListener, View.IOnClickListener
    {
        public TextView Name { get; private set; }
     //   public Button Button { get; private set; }
        public TextView InStock { get; private set; }
        public TextView Category { get; private set; }
        public TextView Price { get; private set; }
        public CheckBox SlectedCheckBox { get; private set; }
        public LinearLayout hiddenLayout { get; private set; }

        private ItemsAdapter itemsAdapter;
        public ItemHolder(View itemView,ItemsAdapter itemsAdapter) : base(itemView)
        {
            
            Name = itemView.FindViewById<TextView>(Resource.Id.labelRecycleItem);
            //Button = itemView.FindViewById<Button>(Resource.Id.buttonRecycleItem);
            InStock = itemView.FindViewById<TextView>(Resource.Id.numberRecycleItem);
            Category = itemView.FindViewById<TextView>(Resource.Id.categoryRecycleItem);
            Price = itemView.FindViewById<TextView>(Resource.Id.priceRecycleItem);
            SlectedCheckBox = itemView.FindViewById<CheckBox>(Resource.Id.checkBoxRecycle);
            hiddenLayout = itemView.FindViewById<LinearLayout>(Resource.Id.showMoreLayout);
            itemView.SetOnCreateContextMenuListener(this);
            itemView.SetOnClickListener(this);
            //SlectedCheckBox.SetOnClickListener(this);

            this.itemsAdapter = itemsAdapter;
            


        }

       

        public void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            menu.SetHeaderTitle("Action");
            menu.Add(Resource.Id.action_edit).SetOnMenuItemClickListener(itemsAdapter).SetTitle("Edit");
            menu.Add(Resource.Id.action_delete).SetOnMenuItemClickListener(itemsAdapter).SetTitle("Delete");
         


        }

        public void OnClick(View v)
        {
            if(hiddenLayout.Visibility==ViewStates.Gone)
            hiddenLayout.Visibility = ViewStates.Visible;
            else
                hiddenLayout.Visibility = ViewStates.Gone;
        }
    }
}