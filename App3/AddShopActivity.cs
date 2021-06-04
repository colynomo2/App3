using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "AddShopActivity")]
    public class AddShopActivity : Activity
    {
        EditText name;
        EditText Long;
        EditText Lat;
        Button confirmButton;
        Button buttonCancelShop;
        private RepositoryDB repositoryDB;
        FusedLocationProviderClient fusedLocationProviderClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout3);
            repositoryDB = new RepositoryDB();
            fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(this);
            confirmButton = FindViewById<Button>(Resource.Id.buttonConfirmShop);
            buttonCancelShop = FindViewById<Button>(Resource.Id.buttonCancelShop);
            buttonCancelShop.Click += ButtonCancelShop_Click;
            confirmButton.Click += ConfirmButton_Click;

            name = FindViewById<EditText>(Resource.Id.nameShop);
            Long = FindViewById<EditText>(Resource.Id.Longitude);
            Lat = FindViewById<EditText>(Resource.Id.Latitude);
            GetLastLocationFromDevice();

        }

        private void ButtonCancelShop_Click(object sender, EventArgs e)
        {
            Finish();
        }

        async Task GetLastLocationFromDevice()
        {
            // This method assumes that the necessary run-time permission checks have succeeded.

            Android.Locations.Location location = await fusedLocationProviderClient.GetLastLocationAsync();

            if (location == null)
            {
                // Seldom happens, but should code that handles this scenario
            }
            else
            {
                // Do something with the location 
                Long.Text += location.Longitude;
                Lat.Text += location.Latitude;

               // Log.Debug("Sample", "The latitude is " + location.Latitude);
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Shop s=new Shop();
            s.Name = name.Text;
            s.Latitude = double.Parse(Lat.Text);
            s.Longitude = double.Parse(Long.Text);
            repositoryDB.addShop(s);
            Finish();
        }
    }
}