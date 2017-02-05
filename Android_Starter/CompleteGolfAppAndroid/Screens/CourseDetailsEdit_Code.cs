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
    [Activity(Label = "CourseDetailsEdit")]
    public class CourseDetailsEdit_Code : Activity
    {
        Course course = new Course();

        EditText courseNameEditText;
        EditText courseCityEditText;
        EditText courseHolesEditText;
        EditText courseParEditText;
        Button addTeeButton;
        Button saveCourseDetailsEditButton;
        Button deleteCourseDetailsEditButton;
        Button cancelCourseDetailsEditButton;

        CompleteGolfAppAndroid.Adapters.CourseTeeListAdapter courseTeeListAdapter;
        ListView courseTees_ListView;

        IList<CourseTee> courseTees;        


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // set our layout to be the home screen
            SetContentView(Resource.Layout.CourseDetailsEdit_Layout);

            // find all our controls
            courseNameEditText = FindViewById<EditText>(Resource.Id.CourseDetailsEdit_EditText_Name);
            courseCityEditText = FindViewById<EditText>(Resource.Id.CourseDetailsEdit_EditText_City);
            courseHolesEditText = FindViewById<EditText>(Resource.Id.CourseDetailsEdit_EditText_Holes);
            courseParEditText = FindViewById<EditText>(Resource.Id.CourseDetailsEdit_EditText_ParTotal);
            courseTees_ListView = FindViewById<ListView>(Resource.Id.CourseDetailsEdit_ListView_TeeSummary);

            addTeeButton = FindViewById<Button>(Resource.Id.CourseDetailsEdit_Button_AddTee);
            saveCourseDetailsEditButton = FindViewById<Button>(Resource.Id.CourseDetailsEdit_Button_Save);
            deleteCourseDetailsEditButton = FindViewById<Button>(Resource.Id.CourseDetailsEdit_Button_Delete);
            cancelCourseDetailsEditButton = FindViewById<Button>(Resource.Id.CourseDetailsEdit_Button_Cancel);

            // set the cancel delete based on whether or not it's an existing task
            //cancelDeleteButton.Text = (task.ID == 0 ? "Cancel" : "Delete");


            int courseID = Intent.GetIntExtra("CourseID", 0);

            if (courseID > 0)
            {
                //courseName = Intent.GetStringExtra("CourseName") ?? "No data, why";
                course = CourseManager.GetCourse(courseID);
                addTeeButton.Enabled = true;
            }
            else
            {
                addTeeButton.Enabled = false;
            }


            courseNameEditText.Text = course.CourseName;
            courseCityEditText.Text = course.City;
            courseHolesEditText.Text = course.Holes.ToString();
            courseParEditText.Text = course.Par.ToString();

            // button clicks 
            if (addTeeButton != null)
            {
                addTeeButton.Click += delegate {


                    var activity2 = new Intent(this, typeof(CourseTeeDetails_Code));
                    activity2.PutExtra("CourseName", courseNameEditText.Text);
                    activity2.PutExtra("CourseID", course.ID);
                    activity2.PutExtra("CourseHoles", course.Holes);
                    StartActivity(activity2);
                };

            }

            saveCourseDetailsEditButton.Click += (sender, e) => { SaveCourse(); };
            cancelCourseDetailsEditButton.Click += (sender, e) => { Cancel(); };

            deleteCourseDetailsEditButton.Click += (sender, e) => { Delete(); };

        }

        //void Save()
        //{

        //    SaveCourse();
        //    Finish();
        //}

        void Delete()
        {

            CourseManager.DeleteCourse(course.ID);

            Finish();

        }

        bool SaveCourse()
        {

            //tee.TeeName = teeTextEdit.Text;
            //TeeManager.SaveTee(tee);
            if (courseNameEditText.Text.Trim().Length > 0)
            {
                course.CourseName = courseNameEditText.Text;
            }
            else
            {
                Toast toast = Toast.MakeText(this, "Name is required", Android.Widget.ToastLength.Short);
                toast.Show();
                return false; 
            }


            if (courseCityEditText.Text.Trim().Length > 0)
            {
                course.City = courseCityEditText.Text;
            }
            else
            {
                Toast toast = Toast.MakeText(this, "City is required", Android.Widget.ToastLength.Short);
                toast.Show();
                return false;
            }


            int x = 0;


            if (Int32.TryParse(courseHolesEditText.Text, out x))
            {
                course.Holes = x;
            }

            if (Int32.TryParse(courseParEditText.Text, out x))
            {
                course.Par = x;
            }



            CourseManager.SaveCourse(course);

            course.ID = CourseManager.GetCourse(course.CourseName).ID;  //Get the course ID of the new course.

            addTeeButton.Enabled = true;

            return true;

        }


        void Cancel()
        {

            Finish();
        }

        protected override void OnResume()
        {
            base.OnResume();


            courseTees = CourseTeeManager.GetCourseTees(course.ID);

            // create our adapter
            courseTeeListAdapter = new Adapters.CourseTeeListAdapter(this, courseTees);


            //Hook up our adapter to our ListView
            courseTees_ListView.Adapter = courseTeeListAdapter;

        }

    }
}