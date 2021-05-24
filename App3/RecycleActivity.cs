using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public static RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        Products products ;
        public static ItemsAdapter itemsAdapter;
        public static RepositoryDB repositoryDB;
        Button buttonAdd;
        Button buttonDeleteAll;
        Spinner spinnerCategories;
        public int lastPosition;
        Android.Support.V7.Widget.SearchView searchView;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            repositoryDB = new RepositoryDB();
            JavaList<Product> productsList = new JavaList<Product>();

            foreach (Product p in repositoryDB.getAllProducts())
                productsList.Add(p);
            products = new Products(productsList);

              
            SetContentView(Resource.Layout.recycle_gl);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycleV);

            itemsAdapter = new ItemsAdapter(products,mRecyclerView, repositoryDB,this);
            itemsAdapter.ItemClick += OnItemClick;

            searchView= FindViewById<Android.Support.V7.Widget.SearchView>(Resource.Id.searchView);
            mRecyclerView.SetAdapter(itemsAdapter);

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            searchView.QueryTextChange += SearchView_QueryTextChange;

            buttonAdd = FindViewById<Button>(Resource.Id.addButton);
            buttonAdd.Click += ButtonAdd_Click;

            buttonDeleteAll = FindViewById<Button>(Resource.Id.deleteSelectedButton);
            buttonDeleteAll.Click += ButtonDeleteAll_Click;

            spinnerCategories = FindViewById<Spinner>(Resource.Id.spinnerCategory);
            ArrayAdapter<Category> arrayAdapter = new ArrayAdapter<Category>(this, Resource.Layout.support_simple_spinner_dropdown_item);
            List<Category> categories = RecycleActivity.repositoryDB.GetCategories();
            arrayAdapter.Add(new Category().Name = "All");
            arrayAdapter.AddAll(categories);
            spinnerCategories.Adapter = arrayAdapter;
            spinnerCategories.ItemSelected += SpinnerCategories_ItemSelected;

            var swipeHandlerDelete = new SwipeToDeleteCallback(0, Android.Support.V7.Widget.Helper.ItemTouchHelper.Left, this, products);
            var itemTouchHelperDelete = new Android.Support.V7.Widget.Helper.ItemTouchHelper(swipeHandlerDelete);
            itemTouchHelperDelete.AttachToRecyclerView(mRecyclerView);

            var swipeHandlerEdit = new SwipeToEditCallback(0, Android.Support.V7.Widget.Helper.ItemTouchHelper.Right, this, products,itemsAdapter);
            var itemTouchHelperEdit = new Android.Support.V7.Widget.Helper.ItemTouchHelper(swipeHandlerEdit);
            itemTouchHelperEdit.AttachToRecyclerView(mRecyclerView);

        }

        private void SpinnerCategories_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            itemsAdapter.FilterCategory.InvokeFilter(spinnerCategories.SelectedItem.ToString());
        }

        private void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            JavaList<Product> list = new JavaList<Product>(itemsAdapter.mItems.getItems());
            foreach (Product product in list)
                if(product.Checked)
                {
                    itemsAdapter.currentItems.deleteProduct(product);
                    itemsAdapter.mItems.deleteProduct(product);
                    repositoryDB.delete(product);
                }
            itemsAdapter.NotifyDataSetChanged();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(AddActivity));
            StartActivityForResult(nextActivity,0);
            
        }
        public void StartEditMode(Product product, int position)
        {
            Intent nextActivity = new Intent(this, typeof(AddActivity));
            string jsonString = JsonSerializer.Serialize(product);
            nextActivity.PutExtra("product", jsonString);
            lastPosition = position;
            StartActivityForResult(nextActivity, 1);
        }
        protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
        {
            switch (requestCode) {
            case 0:
                    {
                        if (resultCode == Result.Ok)
                        {
                            Product product;
                            string jsonProduct = data.GetStringExtra("product");
                            product = JsonSerializer.Deserialize<Product>(jsonProduct);
                            
                            itemsAdapter.mItems.addProduct(product);
                            if(!spinnerCategories.SelectedItem.ToString().Equals("All"))
                            itemsAdapter.currentItems.addProduct(product);
                            repositoryDB.addProduct(product);
                            itemsAdapter.NotifyDataSetChanged();
                            itemsAdapter.FilterCategory.InvokeFilter(spinnerCategories.SelectedItem.ToString());
                        }
                       break;
                    }
            case 1:
                {
                    if (resultCode == Result.Ok)
                    {
                        Product product;
                        string jsonProduct = data.GetStringExtra("product");
                        product = JsonSerializer.Deserialize<Product>(jsonProduct);
                      
                        itemsAdapter.currentItems.updateProduct(product,itemsAdapter.mItems.updateProduct(product, lastPosition));
                        repositoryDB.updateProduct(product);

                        itemsAdapter.NotifyItemChanged(lastPosition);
                        itemsAdapter.FilterCategory.InvokeFilter(spinnerCategories.SelectedItem.ToString());
                        }
                        else if (resultCode == Result.Canceled)
                        {
                            itemsAdapter.NotifyItemChanged(lastPosition);
                            itemsAdapter.FilterCategory.InvokeFilter(spinnerCategories.SelectedItem.ToString());
                        }
                        break;
                }
            }
        }
        private void SearchView_QueryTextChange(object sender, Android.Support.V7.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            itemsAdapter.Filter.InvokeFilter(e.NewText);
        }

        void OnItemClick(object sender, int position)
        {
           // products[position].Checked = !products[position].Checked;

        }

    }
}