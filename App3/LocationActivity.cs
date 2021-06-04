using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Gms.Common;
using Android.Gms.Location;
using Android.Util;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.Locations;
using Android.Gms.Maps.Model;

namespace App3
{
    
    public class LocationCallbackHelper : LocationCallback
    {
        public EventHandler<OnLocationCapturedEventArgs> MyLocation;

        public class OnLocationCapturedEventArgs : EventArgs
        {
            public Android.Locations.Location Location { get; set; }
        }

        public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("Uber Clone", "IsLocationAvailable: {0}", locationAvailability.IsLocationAvailable);
        }

        public override void OnLocationResult(LocationResult result)
        {
            if (result.Locations.Count != 0)
            {
                var location = result.Locations.First();
                //  LocationActivity.longitude.Text = "Long:" + location.Longitude.ToString();
                // LocationActivity.latitude.Text = "Lat:" + location.Latitude.ToString();
                LocationActivity.googleMap.MoveCamera(CameraUpdateFactory.NewCameraPosition(new Android.Gms.Maps.Model.CameraPosition(new Android.Gms.Maps.Model.LatLng(location.Latitude, location.Longitude), LocationActivity.googleMap.CameraPosition.Zoom, LocationActivity.googleMap.CameraPosition.Tilt, LocationActivity.googleMap.CameraPosition.Bearing)));

                Log.Debug("Sample", "The latitude is :" + location.Latitude);
            }
        }
    }
    [Activity(Label = "LocationActivity")]
    public class LocationActivity : AppCompatActivity, IOnMapReadyCallback
    {
        public static GoogleMap googleMap;
        FusedLocationProviderClient fusedLocationProviderClient;
        public static TextView longitude;
        public static TextView latitude;
        LocationRequest locationRequest;
        static int UPDATE_INTERVAL = 5; //5 SECONDS
        static int FASTEST_INTERVAL = 5;
        static int DISPLACEMENT = 3; //meters
        LocationCallbackHelper locationCallback;
        private RepositoryDB repositoryDB;
        JavaList<Shop> shopsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {

           
            base.OnCreate(savedInstanceState);
            repositoryDB = new RepositoryDB();
            shopsList = new JavaList<Shop>();

            foreach (Shop s in repositoryDB.getAllShops())
                shopsList.Add(s);
            
            SetContentView(Resource.Layout.location);

            var mapFrag = MapFragment.NewInstance();
            
            FragmentManager.BeginTransaction()
                
                                    .Add(Resource.Id.map_container, mapFrag, "map_fragment")
                                    
                                    .Commit();
            mapFrag.GetMapAsync(this);
            locationCallback = new LocationCallbackHelper();
            fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(this);
          //  longitude = FindViewById<TextView>(Resource.Id.longi);
           // latitude = FindViewById<TextView>(Resource.Id.lat);
            GetLastLocationFromDevice();
            Subscribe();
            //OnMapReady();
        }

        private void Subscribe()
        {
            locationRequest = new LocationRequest();
            locationRequest.SetInterval(UPDATE_INTERVAL);
            locationRequest.SetFastestInterval(FASTEST_INTERVAL);
            locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
            locationRequest.SetSmallestDisplacement(DISPLACEMENT);
            fusedLocationProviderClient.RequestLocationUpdates(locationRequest, locationCallback, null);
        }

        bool IsGooglePlayServicesInstalled()
        {
            var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (queryResult == ConnectionResult.Success)
            {
                Log.Info("MainActivity", "Google Play Services is installed on this device.");
                return true;
            }

            if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
            {
                // Check if there is a way the user can resolve the issue
                var errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                Log.Error("MainActivity", "There is a problem with Google Play Services on this device: {0} - {1}",
                          queryResult, errorString);

                // Alternately, display the error to the user.
                Finish();
            }

            return false;
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
                longitude.Text += location.Longitude;
                latitude.Text += location.Latitude;

                Log.Debug("Sample", "The latitude is " + location.Latitude);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {

            googleMap.MapType = GoogleMap.MapTypeHybrid;
            googleMap.MyLocationEnabled = true;
            //googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            LocationActivity.googleMap = googleMap;
            
           foreach (Shop s in shopsList)
            {
                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(new LatLng(s.Latitude, s.Longitude));
                markerOpt1.SetTitle(s.Name);

                googleMap.AddMarker(markerOpt1);
                
            }
        }


    }
}