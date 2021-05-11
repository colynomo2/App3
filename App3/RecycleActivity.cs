using System;
using System.Collections.Generic;
using System.Linq;
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
    [Activity(Label = "RecycleActivity")]
    public class RecycleActivity : Activity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        Items items ;
        ItemsAdapter itemsAdapter;
        Android.Support.V7.Widget.SearchView searchView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            items = new Items();

        
            itemsAdapter = new ItemsAdapter(items);
            SetContentView(Resource.Layout.recycle_gl);

            itemsAdapter.ItemClick += OnItemClick;

            searchView= FindViewById<Android.Support.V7.Widget.SearchView>(Resource.Id.searchView);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycleV);

            mRecyclerView.SetAdapter(itemsAdapter);

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            searchView.QueryTextChange += SearchView_QueryTextChange;
            
        }

        private void SearchView_QueryTextChange(object sender, Android.Support.V7.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            itemsAdapter.Filter.InvokeFilter(e.NewText);
        }

        void OnItemClick(object sender, int position)
        {
            items[position].Counter++;
            itemsAdapter.NotifyItemChanged(position);
        }

    }
}