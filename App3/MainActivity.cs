using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.App.DatePickerDialog;
using System;
using System.Collections.Generic;
using System.Collections;
using static Android.Resource;
using Android.Content;
using System.IO;
using Android.Support.V4.Content;
using Android.Content.PM;
using Android.Support.V4.App;

namespace App3
{
   

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
      
        
           

        Button testPageButton;
        Button recycleViewPageButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var listPermissions = new System.Collections.Generic.List<string>();

            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.ReadExternalStorage) != Permission.Granted)
                listPermissions.Add(Android.Manifest.Permission.ReadExternalStorage);

            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                listPermissions.Add(Android.Manifest.Permission.WriteExternalStorage);

            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Internet) != Permission.Granted)
                listPermissions.Add(Android.Manifest.Permission.Internet);

            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.ReadPhoneState) != Permission.Granted)
                listPermissions.Add(Android.Manifest.Permission.ReadPhoneState);

            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) != Permission.Granted)
                listPermissions.Add(Android.Manifest.Permission.AccessFineLocation);

            // Make the request with the permissions needed...and then check OnRequestPermissionsResult() for the results
            if (listPermissions.Count > 0)
                ActivityCompat.RequestPermissions(this, listPermissions.ToArray(), 123/*a code in OnRequestPermissionsResult*/);
            else
            {

                init();

            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == 123)
            {

                init();

            }
        }

        private void init()
        {
            SetContentView(Resource.Layout.main);
            testPageButton = FindViewById<Button>(Resource.Id.testPage);
            testPageButton.Click += TestPageButton_Click;
            recycleViewPageButton = FindViewById<Button>(Resource.Id.recycleViewPage);
            recycleViewPageButton.Click += RecycleViewPageButton_Click;
        }

        private void RecycleViewPageButton_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(RecycleActivity));
            StartActivity(nextActivity);
        }

        private void TestPageButton_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(TestActivity));
            StartActivity(nextActivity);
        }
    }
}