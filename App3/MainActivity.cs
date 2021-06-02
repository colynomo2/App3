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
using Java.IO;
using Android.Support.V4.Content;
using Android.Content.PM;
using Android.Support.V4.App;
using Android.Hardware;
using Plugin.Media;
using Android.Provider;
using Android.Graphics;

namespace App3
{
    public static class App
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {



        
        Button testPageButton;
        Button recycleViewPageButton;
        Button gridViewPageButton;
        Button cameraButton;
        Button locationButton;
        private Button notificationButton;
        private static readonly int notificationButtonClicl = 9999;
        protected override void OnCreate(Bundle savedInstanceState)
        { StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            base.OnCreate(savedInstanceState);
           
          
            var listPermissions = new System.Collections.Generic.List<string>();
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) != Permission.Granted)
                listPermissions.Add(Android.Manifest.Permission.AccessFineLocation);


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
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Camera) != (int)Permission.Granted)
            {
                listPermissions.Add(Android.Manifest.Permission.Camera);
            }
            

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
            App._dir = new File(Application.Context.GetExternalFilesDir(null).ToString());
            SetContentView(Resource.Layout.main);
            testPageButton = FindViewById<Button>(Resource.Id.testPage);
            testPageButton.Click += TestPageButton_Click;
            recycleViewPageButton = FindViewById<Button>(Resource.Id.recycleViewPage);
            recycleViewPageButton.Click += RecycleViewPageButton_Click;
            gridViewPageButton = FindViewById<Button>(Resource.Id.gridViewPage);
            gridViewPageButton.Click += GridViewPageButton_Click;
            notificationButton = FindViewById<Button>(Resource.Id.notificationButton);
            notificationButton.Click += NotificationButton_Click;
            cameraButton = FindViewById<Button>(Resource.Id.cameraButton);
            cameraButton.Click += CameraButton_Click;
            locationButton = FindViewById<Button>(Resource.Id.locationButton);
            locationButton.Click += LocationButton_Click; ;

        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(LocationActivity));
            StartActivity(nextActivity);
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new File(App._dir, System.String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(App._file));
            StartActivityForResult(intent, 0);


        }

        private async void takePhoto()
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                await CrossMedia.Current.Initialize();

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

            }
        }

        private void NotificationButton_Click(object sender, EventArgs e)
        {
            //Bundle valueSend = new Bundle();
            //valueSend.PutString("sendContent", "You are notified");

            //Intent nextActivity = new Intent(this, typeof(Game));
            //Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            //stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(Game)));
            //stackBuilder.AddNextIntent(nextActivity);

            //PendingIntent pendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);


            NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
                .SetAutoCancel(true)
            //    .SetContentIntent(pendingIntent)
                .SetContentTitle("My notification")
                .SetSmallIcon(Resource.Drawable.navigation_empty_icon)
                .SetContentText("HEY");
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);

            notificationManager.Notify(notificationButtonClicl, builder.Build());

        }

        private void GridViewPageButton_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(Gallery));
            StartActivity(nextActivity);
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