using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tasky.Core;

namespace CompleteGolfAppAndroid.Screens
{
    [Activity(Label = "CourseTeeDetails_Code")]
    public class CourseTeeDetails_Code : Activity
    {
        //Tee tee = new Tee();

        EditText yardsEditText;
        Button saveButton;
        Course course;
        CourseTee courseTee;

        CompleteGolfAppAndroid.Adapters.TeeListAdapter teeListAdapter;
        Spinner teesSpinner;
        IList<Tee> tees;

        Tee selectedTee;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            courseTee = new CourseTee();
            course = new Course();
            selectedTee = new Tee();

            course.CourseName = Intent.GetStringExtra("CourseName") ?? "Do data, why";
            course.ID = Intent.GetIntExtra("CourseID", 0);

            courseTee.CourseID = course.ID;

            // set our layout to be the home screen
            SetContentView(Resource.Layout.CourseTeeDetails_Layout);

            // find all our controls
            yardsEditText = FindViewById<EditText>(Resource.Id.CourseTeeDetails_EditText_ReportedYards);

            saveButton = FindViewById<Button>(Resource.Id.CourseTeeDetails_Button_Save);
            teesSpinner = FindViewById<Spinner>(Resource.Id.CourseTeeDetails_Spinner_Tee);

            // set the cancel delete based on whether or not it's an existing task
            //cancelDeleteButton.Text = (task.ID == 0 ? "Cancel" : "Delete");

            // button clicks 

            saveButton.Click += (sender, e) => { Save(); };

            teesSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            int pos = e.Position;
            selectedTee = tees.ElementAt<Tee>(pos);    

            //string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        void Save()
        {


            int x = 0;
            if (Int32.TryParse(yardsEditText.Text, out x))
            {
                courseTee.CourseReportedYardage = x;
            }

            courseTee.TeeID = selectedTee.ID;

            CourseTeeManager.SaveCourseTee(courseTee);

            Finish();
        }

        void Cancel()
        {
            //if (task.ID != 0)
            //{
            //    TaskManager.DeleteTask(task.ID);
            //}
            Finish();
        }


        protected override void OnResume()
        {
            base.OnResume();


            tees = TeeManager.GetTees();

            // create our adapter
            teeListAdapter = new Adapters.TeeListAdapter(this, tees);

            //Hook up our adapter to our ListView
            teesSpinner.Adapter = teeListAdapter;

        }

    }
}