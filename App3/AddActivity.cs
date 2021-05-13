using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "AddActivity")]
    public class AddActivity : Activity
    {
        Button confirmButton;
        Button cancelButton;
        Product product=null;
        EditText editTextName;
        EditText editTextStock;
        Spinner spinnerCategories;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addProduct);
            confirmButton = FindViewById<Button>(Resource.Id.buttonConfirm);
            confirmButton.Click += ConfirmButton_Click;

            cancelButton = FindViewById<Button>(Resource.Id.buttonCancel);
            cancelButton.Click += CancelButton_Click;

            editTextName = FindViewById<EditText>(Resource.Id.nameEdit);


            editTextStock = FindViewById<EditText>(Resource.Id.stockEdit);


            spinnerCategories = FindViewById<Spinner>(Resource.Id.spinnerCategory);
            if (Intent.HasExtra("product"))
            {
                string productJson = Intent.Extras.GetString("product");
            
                
                product = JsonSerializer.Deserialize<Product>(productJson);
                editTextName.Text = product.Name;
                editTextStock.Text = product.InStock.ToString();
                
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SetResult(Result.Canceled);
            Finish();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if(product==null)
            product = new Product();
            product.Name = editTextName.Text;
            product.InStock = int.Parse(editTextStock.Text);
           // product.categoryId = int.Parse(spinnerCategories.SelectedItem.ToString());
            string jsonString = JsonSerializer.Serialize(product);
            Intent intent = new Intent(this,typeof(RecycleActivity));
            intent.PutExtra("product", jsonString);
            SetResult(Result.Ok,intent);
            Finish();
        }
    }
}