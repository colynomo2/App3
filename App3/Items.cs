using Android.Runtime;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace App3
{
    public class Item
    {
       public Item() { }
        public Item(int id, string text)
        {
            ItemID = id;
            Text = text;
            Counter = 0;
        }

        public int Counter { get; set; }
        public int ItemID { get; }

       
        public string Text { get; }
    }

   
    public class Products
    {


        JavaList<Product> mBuiltInItems;

     

        private JavaList<Product> mItems;


        internal JavaList<Product> getItems()
        {
            return mItems;
        }

        public Products(JavaList<Product> products)
        {
            mItems = products; 
        }
        public void setItems(JavaList<Product> list)
        {
            mItems = list;
        }
        public int NumItems
        {
            get { return mItems.Count; }
        }
        
        public Product this[int i]
        {
            get { return mItems[i]; }
        }

        
    }
}