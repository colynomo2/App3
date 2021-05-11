using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace App3
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public int InStock { get; set; }

       

    }
    [Table("Categorie")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        
        

    }
    [Table("Product_Category")]
    public class Product_Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Indexed]
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Indexed]
        [Column("product_id")]
        public int ProductId { get; set; }

    }

    public class RepositoryDB
    {
        string dbPath;
        SQLiteConnection db;
        public RepositoryDB()
        {
            dbPath = Path.Combine(
        Globals.RootDirectory,
        "database.db");
           
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Product>();
            db.CreateTable<Category>();
            db.CreateTable<Product_Category>();
           


        }
        public void addProduct(Product product)
        {
            db.Insert(product);
        }

    }
}