using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "ListView")]
    public class ListView : Activity
    {
        List<Product> products;
        RepositoryDB repositoryDB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            // Create your application here
            repositoryDB = new RepositoryDB();
            products = repositoryDB.getAllProducts();
            string[] names = convertMethod();


        }

        private string[] convertMethod()
        {
            List<string> s=new List<string>();
            foreach (Product product in products)
                s.Add(product.Name);
            return s.ToArray();
        }
    }
}