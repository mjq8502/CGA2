using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core;
using System.Collections.Generic;
using System;
using Android.Views;

namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "Courses")]
    public class Courses_Code : Activity  //, ListView.IOnItemClickListener
    {
        //Task task = new Task();
        Button cancelDeleteButton;
        CompleteGolfAppAndroid.Adapters.CourseListAdapter courseList;
        IList<Course> courses;

        Button addNewCourseButton;
        ListView courseListView;
        Course selectedFromList;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);

                //int taskID = Intent.GetIntExtra("TaskID", 0);
                //if (taskID > 0)
                //{
                //    task = TaskManager.GetTask(taskID);
                //}

                // set our layout to be the home screen
                SetContentView(Resource.Layout.Courses_Layout);

                addNewCourseButton = FindViewById<Button>(Resource.Id.Courses_Button_AddNew);
                courseListView = FindViewById<ListView>(Resource.Id.Courses_ListView_CourseList);
                //courseListView.OnItemClickListener = this;

                //teeListView = FindViewById<ListView>(Resource.Id.TeeList);

                // find all our controls

                // button clicks 

                //wire up add task button handler
                if (addNewCourseButton != null)
                {
                    addNewCourseButton.Click += delegate {
                        var activity2 = new Intent(this, typeof(CourseDetailsEdit_Code));
                        activity2.PutExtra("CourseID", 0); //Send 0 to identify it as a brand new course.
                        StartActivity(activity2);
                    };

                }

                courseListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
                {
                    selectedFromList = courses[e.Position];
                    var activity2 = new Intent(this, typeof(CourseDetailsView_Code));
                    activity2.PutExtra("CourseID", selectedFromList.ID);
                    //activity2.PutExtra("CourseName", selectedFromList.CourseName);
                    StartActivity(activity2);
                    
                };

                courseListView.ItemLongClick += delegate (object sender, AdapterView.ItemLongClickEventArgs e)
                {
                    selectedFromList = courses[e.Position];
                    var activity2 = new Intent(this, typeof(CourseDetailsEdit_Code));
                    activity2.PutExtra("CourseID", selectedFromList.ID);
                    //activity2.PutExtra("CourseName", selectedFromList.CourseName);
                    StartActivity(activity2);

                };

            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnResume()
        {
            base.OnResume();


            courses = CourseManager.GetCourses();

            // create our adapter
            courseList = new Adapters.CourseListAdapter(this, courses);


            //Hook up our adapter to our ListView
            courseListView.Adapter = courseList;

        }


    }
}