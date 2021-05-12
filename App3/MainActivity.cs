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
    public class MainActivity : AppCompatActivity, IOnDateSetListener
    {
        private const int DATE_DIALOG = 1;
        private int dayOfMonth, year, month;
        EditText dateText;
        Button buttonChange;
        Button buttonConfirm;
        
        Spinner spinner;
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

        private void init( )
        {
          
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            dateText = FindViewById<EditText>(Resource.Id.dateText);
            dateText.Touch += DateText_Touch;
            DateTime dateTimeNow = DateTime.Now;
            year = dateTimeNow.Year;
            dayOfMonth = dateTimeNow.Day;
            month = dateTimeNow.Month;

            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            ArrayList arlist = new ArrayList
            {
                1,
                2,
                3,
                4
            };
            var adapter = ArrayAdapter.CreateFromResource(
          this, Resource.Array.spinner_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

           


            buttonChange = FindViewById<Button>(Resource.Id.changePageButton);
            buttonChange.Click += ButtonChange_Click;
            

          
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(ListView));
            StartActivity(nextActivity);
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
         Intent nextActivity = new Intent(this, typeof(RecycleActivity)   );
        StartActivity(nextActivity);
    }

        private void DateText_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            ShowDialog(DATE_DIALOG);
        }
        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG:
                    {
                        Dialog dialog = new DatePickerDialog(this, this, year, month, dayOfMonth);

                        return dialog;
                    }
                default:
                    break;
            }
            return null;
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.year = year;
            this.month = month + 1;
            this.dayOfMonth = dayOfMonth;
            dateText.Text = dayOfMonth + "/" + month + "/" + year;
        }
    }
}