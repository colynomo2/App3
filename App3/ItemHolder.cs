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
    public class ItemHolder : RecyclerView.ViewHolder,View.IOnCreateContextMenuListener
    {
        public TextView Label { get; private set; }
     //   public Button Button { get; private set; }
        public TextView Counter { get; private set; }
        private ItemsAdapter itemsAdapter;
        public ItemHolder(View itemView,ItemsAdapter itemsAdapter) : base(itemView)
        {
            
            Label = itemView.FindViewById<TextView>(Resource.Id.labelRecycleItem);
            //Button = itemView.FindViewById<Button>(Resource.Id.buttonRecycleItem);
            Counter = itemView.FindViewById<TextView>(Resource.Id.numberRecycleItem);
            itemView.SetOnCreateContextMenuListener(this);
            this.itemsAdapter = itemsAdapter;


        }

       

        public void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            menu.SetHeaderTitle("Action");
            menu.Add(Resource.Id.action_edit).SetOnMenuItemClickListener(itemsAdapter).SetTitle("Edit");
            menu.Add(Resource.Id.action_delete).SetOnMenuItemClickListener(itemsAdapter).SetTitle("Delete");
         


        }

      
    }
}