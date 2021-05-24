using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.App.DatePickerDialog;

namespace App3
{
    [Activity(Label = "TestActivity")]
    public class TestActivity : Activity, IOnDateSetListener
    {
        private const int DATE_DIALOG = 1;
        private int dayOfMonth, year, month;
        EditText dateText;


        Spinner spinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            init();





        }




        private void init()
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








        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(ListView));
            StartActivity(nextActivity);
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(RecycleActivity));
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