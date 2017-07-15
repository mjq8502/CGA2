using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core;
using System.Collections.Generic;
using System;
using Android.Views;
using Android.Graphics;

namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "ScoresEntry")]
    public class ScoresEntry_Code : Activity  //, ListView.IOnItemClickListener
    {
        //Task task = new Task();
        Button cancelDeleteButton;
        CompleteGolfAppAndroid.Adapters.CourseListAdapter courseList;
        IList<Course> courses;

        Button btnAddNewRound;
        ListView courseListView;
        Course selectedFromList;
        LinearLayout linRoundInfo;

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
                SetContentView(Resource.Layout.ScoresEntry_Layout);

                btnAddNewRound = FindViewById<Button>(Resource.Id.ScoresEntry_Button_AddNew);
                linRoundInfo = FindViewById<LinearLayout>(Resource.Id.ScoresEntry_LinearLayout_ChooseCourse);
                //courseListView.OnItemClickListener = this;

                //teeListView = FindViewById<ListView>(Resource.Id.TeeList);

                // find all our controls zz

                // button clicks 

                //wire up add task button handler
                if (btnAddNewRound != null)
                {
                    btnAddNewRound.Click += delegate
                    {
                        linRoundInfo.Visibility = ViewStates.Gone;
                        //var activity2 = new Intent(this, typeof(CourseDetailsEdit_Code));
                        //activity2.PutExtra("CourseID", 0); //Send 0 to identify it as a brand new course.
                        //StartActivity(activity2);
                    };

                }

                //courseListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
                //{
                //    selectedFromList = courses[e.Position];
                //    var activity2 = new Intent(this, typeof(CourseDetailsView_Code));
                //    activity2.PutExtra("CourseID", selectedFromList.ID);
                //    //activity2.PutExtra("CourseName", selectedFromList.CourseName);
                //    StartActivity(activity2);

                //};

                //courseListView.ItemLongClick += delegate (object sender, AdapterView.ItemLongClickEventArgs e)
                //{
                //    selectedFromList = courses[e.Position];
                //    var activity2 = new Intent(this, typeof(CourseDetailsEdit_Code));
                //    activity2.PutExtra("CourseID", selectedFromList.ID);
                //    //activity2.PutExtra("CourseName", selectedFromList.CourseName);
                //    StartActivity(activity2);

                //};

                ImageView backgroundImage = (ImageView)FindViewById<ImageView>(Resource.Id.ScoresEntry_BackgroundImage);
                backgroundImage.SetBackgroundResource(Resource.Drawable.ColbertHills);

                courseListView.SetBackgroundColor(new Color(0x00, 0x65, 0x00));
                //addNewCourseButton.SetBackgroundColor(new Color(0x00, 0x65, 0x00));

            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnResume()
        {
            base.OnResume();


            //courses = CourseManager.GetCourses();

            //// create our adapter
            //courseList = new Adapters.CourseListAdapter(this, courses);


            ////Hook up our adapter to our ListView
            //courseListView.Adapter = courseList;

        }


    }
}