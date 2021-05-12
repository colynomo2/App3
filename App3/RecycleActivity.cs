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
        Products products ;
        ItemsAdapter itemsAdapter;
        RepositoryDB repositoryDB;
        Button buttonAdd;
        Android.Support.V7.Widget.SearchView searchView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            repositoryDB = new RepositoryDB();
            JavaList<Product> productsList = new JavaList<Product>();

            foreach (Product p in repositoryDB.getAllProducts())
                productsList.Add(p);
            products = new Products(productsList);

        
            itemsAdapter = new ItemsAdapter(products);
            SetContentView(Resource.Layout.recycle_gl);

            itemsAdapter.ItemClick += OnItemClick;

            searchView= FindViewById<Android.Support.V7.Widget.SearchView>(Resource.Id.searchView);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycleV);

            mRecyclerView.SetAdapter(itemsAdapter);

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            searchView.QueryTextChange += SearchView_QueryTextChange;

            buttonAdd = FindViewById<Button>(Resource.Id.addButton);
            buttonAdd.Click += ButtonAdd_Click;


        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(AddActivity));
            StartActivityForResult(nextActivity,0);
            
        }
        protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
        {
            switch (requestCode) {
            case 0:
                if (resultCode == Result.Ok) {
                   //data.getExtra
                   
                }
                break;
           
            }
        }
        private void SearchView_QueryTextChange(object sender, Android.Support.V7.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            itemsAdapter.Filter.InvokeFilter(e.NewText);
        }

        void OnItemClick(object sender, int position)
        {
        //    products[position].Counter++;
        //    itemsAdapter.NotifyItemChanged(position);
        }

    }
}