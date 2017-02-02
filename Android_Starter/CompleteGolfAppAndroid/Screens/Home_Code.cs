using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core;
using CompleteGolfAppAndroid;
using System;

namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// Main ListView screen displays a list of tasks, plus an [Add] button
    /// </summary>
    [Activity(Label = "CompleteGolfApp5", MainLauncher = true, Icon = "@drawable/icon")]
    public class Home_Code : Activity
    {
        //Adapters.TaskListAdapter taskList;
        //IList<Task> tasks;
        Button teesButton;
        Button coursesButton;
        Button scoresButton;
        //ListView taskListView;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);


                var x = TeeManager.GetTees();
                var z = CourseTeeManager.GetAllCourseTees();

                // set our layout to be the home screen
                SetContentView(Resource.Layout.Home_Layout);

                //Find our controls
                //taskListView = FindViewById<ListView>(Resource.Id.TaskList);
                teesButton = FindViewById<Button>(Resource.Id.Home_Button_Tees);
                coursesButton = FindViewById<Button>(Resource.Id.Home_Button_Courses);
                scoresButton = FindViewById<Button>(Resource.Id.Home_Button_Scores);

                // wire up button handlers

                if (teesButton != null)
                {
                    teesButton.Click += (sender, e) => {
                        StartActivity(typeof(Tees_Code));
                    };
                }

                if (coursesButton != null)
                {
                    coursesButton.Click += (sender, e) => {
                        StartActivity(typeof(Courses_Code));
                    };
                }

                //if (scoresButton != null)
                //{
                //    scoresButton.Click += (sender, e) => {
                //        StartActivity(typeof(Scores_Code));
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
            // wire up task click handler
            //if (taskListView != null)
            //{
            //    taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
            //        var taskDetails = new Intent(this, typeof(TaskDetailsScreen));
            //        taskDetails.PutExtra("TaskID", tasks[e.Position].ID);
            //        StartActivity(taskDetails);
            //    };
            //}
        }

        protected override void OnResume()
        {
            base.OnResume();

            //tasks = TaskManager.GetTasks();

            //// create our adapter
            //taskList = new Adapters.TaskListAdapter(this, tasks);

            ////Hook up our adapter to our ListView
            //taskListView.Adapter = taskList;
        }
    }
}