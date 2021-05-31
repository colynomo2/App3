using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "Gallery")]
    public class Gallery : Activity
    {
        public static RecyclerView mRecyclerView;
        GridLayoutManager gridLayoutManager;
        Products products;
        public static GalleryAdapter itemsAdapter;
        public static RepositoryDB repositoryDB;
        public static ViewPager viewPager;
        Button buttonDeleteAll;
        Spinner spinnerCategories;
        public int lastPosition;
        Android.Support.V7.Widget.SearchView searchView;
        SwipeRefreshLayout mSwipeRefreshLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            List<string> imagePaths = GetAllImagePath();

            List<byte[]> allImages = new List<byte[]>();
            byte[] cachedBytes;
            List<Bitmap> images = new List<Bitmap>();
            TreePage[] imaesPages;
            List<TreePage> imaesPagesl =new List<TreePage>();
            Bitmap bitmap;
            foreach (var path in imagePaths)
            {

                bitmap = BitmapFactory.DecodeFile(path);


                images.Add(bitmap);
                var x = new TreePage();
                x.image = bitmap;
                x.caption = path.Split("/").Last();
                imaesPagesl.Add(x);

            }
            imaesPages = imaesPagesl.ToArray();

            SetContentView(Resource.Layout.recyclre3);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycleV2);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            //  fullScreenImage.Click += FullScreenImage_Click;

            TreeCatalog treeCatalog = new TreeCatalog(imaesPages);
            viewPager.Adapter = new TreePagerAdapter(this, treeCatalog);

          

            itemsAdapter = new GalleryAdapter(images, mRecyclerView);
            //itemsAdapter.ItemClick += OnItemClick;



            gridLayoutManager = new GridLayoutManager(this, 3);
            mRecyclerView.SetLayoutManager(gridLayoutManager);
            mRecyclerView.SetAdapter(itemsAdapter);



            viewPager.PageScrolled += ViewPager_PageScrolled; 



        }

        private void ViewPager_PageScrolled(object sender, ViewPager.PageScrolledEventArgs e)
        {
            viewPager.ScaleX -= 0.1f;
            viewPager.ScaleY -= 0.1f;
            
        }







        //string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath + "/Camera";


        //   Java.IO.File file = new Java.IO.File(path);
        //  Java.IO.File[] files = file.ListFiles();
        //for (int i = 0; i < files.Length; i++)
        //{
        //    if (files[i].Path.Contains(".jpg"))
        //    imagePaths.Add(files[i].Path);
        //}
        public List<string> GetAllImagePath()
        {

            string[] imagePaths = Directory.GetFiles(Globals.RootDirectory, "*.jpg", SearchOption.AllDirectories);

            return imagePaths.ToList();
        }

    }
    class TreePagerAdapter : PagerAdapter
    {
        private void ViewPager_Click(object sender, EventArgs e)
        {
            if (Gallery.viewPager.Visibility == ViewStates.Visible)
            {
                Gallery.viewPager.Visibility = ViewStates.Gone;
                Gallery.mRecyclerView.Visibility = ViewStates.Visible;
            }
        }
        private Context context;
        private TreeCatalog treeCatalog;

        public TreePagerAdapter(Context context, TreeCatalog treeCatalog)
        {
            this.context = context;
            this.treeCatalog = treeCatalog;
        }
        public override int Count
        {
            get { return treeCatalog.NumTrees; }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }

        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            var imageView = new ImageView(context);
            imageView.SetImageBitmap(treeCatalog[position].Image);
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(imageView);
            imageView.Click +=ViewPager_Click ;
            return imageView;
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }
        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(treeCatalog[position].caption);
        }
    }
    public class TreePage
    {
        // Image ID for this tree image:
        public Bitmap image;

        // Caption text for this image:
        public string caption;

        // Returns the ID of the image:
        public Bitmap Image { get { return image; } }

        // Returns the caption text for the image:
        public string Caption { get { return caption; } }
    }
    public class TreeCatalog
    {
        // Built-in tree catalog (could be replaced with a database)
        static TreePage[] treeInCatalog = {
            
        };

        // Array of tree pages that make up the catalog:
        private TreePage[] treePages;

        // Create an instance copy of the built-in tree catalog:
        public TreeCatalog(TreePage[] treePages) { this.treePages = treePages; }

        // Indexer (read only) for accessing a tree page:
        public TreePage this[int i] { get { return treePages[i]; } }

        // Returns the number of tree pages in the catalog:
        public int NumTrees { get { return treePages.Length; } }
    }
}