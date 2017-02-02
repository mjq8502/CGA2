using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core;
using System.Collections.Generic;
using System;

namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "TeesScreen3")]
    public class Tees_Code : Activity
    {
        private CompleteGolfAppAndroid.Adapters.TeeListAdapter teeList;
        private IList<Tee> tees;

        private Button addTeeButton;
        private ListView teeListView;

        private Tee selectedFromList;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);


                // set our layout to be the home screen
                SetContentView(Resource.Layout.Tees_Layout);

                // find all our controls
                addTeeButton = FindViewById<Button>(Resource.Id.Tees_Button_AddTee);
                teeListView = FindViewById<ListView>(Resource.Id.Tees_ListView_TeeList);



                // wire up add task button handler
                if (addTeeButton != null)
                {
                    addTeeButton.Click += (sender, e) => {
                        StartActivity(typeof(TeeDetails_Code));
                    };
                }

                //teeListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
                //{
                //    selectedFromList = tees[e.Position];
                //    var activity2 = new Intent(this, typeof(TeeDetails_Code));
                //    activity2.PutExtra("TeeID", selectedFromList.ID);
                //    StartActivity(activity2);

                //};

                teeListView.ItemLongClick += delegate (object sender, AdapterView.ItemLongClickEventArgs e)
                {
                    selectedFromList = tees[e.Position];
                    var activity2 = new Intent(this, typeof(TeeDetails_Code));
                    activity2.PutExtra("TeeID", selectedFromList.ID);
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

            //tasks = TaskManager.GetTasks();

            // create our adapter
            //taskList = new Adapters.TaskListAdapter(this, tasks);

            //Hook up our adapter to our ListView
            //taskListView.Adapter = taskList;

            tees = TeeManager.GetTees();

            // create our adapter
            teeList = new CompleteGolfAppAndroid.Adapters.TeeListAdapter(this, tees);

            //Hook up our adapter to our ListView
            teeListView.Adapter = teeList;
        }


    }
}