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
        public int categoryId { get; set; }
        public float Price { get; set; }
        [Ignore]
        public bool Checked { get; set; } = false;
        public static implicit operator String(Product product) => product.Name;

    }
    [Table("Category")]
    public class Category
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(20),Unique]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
    //[Table("Product_Category")]
    //public class Product_Category
    //{
    //    [PrimaryKey, AutoIncrement, Column("_id")]
    //    public int Id { get; set; }
    //    public int CategoryId { get; set; }
  

    //    public int ProductId { get; set; }

    //}

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

        }
        public void addProduct(Product product)
        {
            db.Insert(product);
        }
        public void addCategory(Category category)
        {
            db.Insert(category);
        }
       
        public List<Product> getAllProducts()
        {
           
            return db.Query<Product>("select * from Product");
            

        }
        public List<Category> GetCategories()
        {
            return db.Query<Category>("select * from Category");
        }
        internal void delete(Product p)
        {
            db.Delete(p);
        }
        public Category GetCategoryById(int id)
        {
            return db.Get<Category>(id);
        }
        internal void updateProduct(Product product)
        {
            db.Update(product);
        }
    }
}