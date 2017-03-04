using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Tasky.Core;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using CompleteGolfAppAndroid.Adapters;
using Android.Content;
using System.Data;
using Android.Graphics;
using Tasky;

namespace CompleteGolfAppAndroid
{
    public class HoleDetailsFragment : Fragment   //Android.Support.V4.App.ListFragment
    {
        private ListView _listView;
        private string[] list;
        private static Tasky.CourseHoleByNumberList chbnl;
        private static int CourseID;
        private int currentHoleNumber;

        private static Handler handler;

        public HoleDetailsFragment()
        {
            
        }

        public static HoleDetailsFragment newInstance(Tasky.CourseHoleByNumberList holesByNumber, int courseID)
        {
            HoleDetailsFragment fragment = new HoleDetailsFragment();
            Bundle args = new Bundle();
            chbnl = holesByNumber;
            CourseID = courseID;
            
            handler = new Handler();

            args.PutString("holesByNumber", JsonConvert.SerializeObject(holesByNumber));

            fragment.Arguments = args;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var courseHoleByNumberList = JsonConvert.DeserializeObject<Tasky.CourseHoleByNumberList>(Arguments.GetString("holesByNumber"));
            
            View view = inflater.Inflate(Resource.Layout.HoleDetailsFragment_Layout2, container, false);

            Context context = Android.App.Application.Context;
            
            List<CourseHole> chList = new List<CourseHole>();
            var zzz = HoleManager.GetCourseHolesByHole(CourseID).CourseHoleDataLists.Where(x => x.HoleNumber == courseHoleByNumberList.HoleNumber).FirstOrDefault().CourseHoles;
            foreach (var courseHole in courseHoleByNumberList.CourseHoles)
            {
                chList.Add(courseHole);
            }

            _listView = view.FindViewById<ListView>(Resource.Id.HoleDetails_ListView);
            //_listView.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this, chList);
            _listView.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this, zzz);

            _listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                var selected = courseHoleByNumberList.CourseHoles[e.Position];
                Toast toast = Toast.MakeText(this.Context, "Item click " + selected.TeeName.ToString()
                                                                + " hn " + selected.HoleNumber
                                                                + " ctID " + selected.CourseTeeID, Android.Widget.ToastLength.Short);
                toast.Show();
                
            };

            _listView.ItemLongClick += delegate (object sender, AdapterView.ItemLongClickEventArgs e)
            {
                
                var selected = courseHoleByNumberList.CourseHoles[e.Position];     //list[e.Position];
                currentHoleNumber = selected.HoleNumber;
                FragmentTransaction ft = FragmentManager.BeginTransaction();
                //Remove fragment else it will crash as it is already added to backstack
                Fragment prev = FragmentManager.FindFragmentByTag("dialog");
                if (prev != null)
                {
                    ft.Remove(prev);
                }
                ft.AddToBackStack(null);
                // Create and show the dialog.
                HoleDetails_DialogFragment newFragment = HoleDetails_DialogFragment.NewInstance(null, selected.CourseTeeID, selected.HoleNumber, selected.ActualYardage, selected.Par);           //(null);
                newFragment.Dismissed += NewFragment_Dismissed;                                                                                                                                       //Add fragment
                newFragment.Show(ft, "dialog");

                

            };



            return view;
        }

        private void NewFragment_Dismissed(object sender, DialogEventArgs args)
        {
            var updatedCourseHoles = HoleManager.GetCourseHolesByHole(CourseID);
            List<CourseHole> chList = new List<CourseHole>();
            foreach (var courseHole in updatedCourseHoles.CourseHoleDataLists[currentHoleNumber-1].CourseHoles)
            {
                chList.Add(courseHole);
            }
            _listView.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this, chList);
        }


        private void _listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var selected = chbnl.CourseHoles[e.Position];     //list[e.Position];
            Toast toast = Toast.MakeText(this.Context, "hole " + selected.HoleNumber + " CourseTeeID " + selected.CourseTeeID, Android.Widget.ToastLength.Short);
            toast.Show();
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            //Remove fragment else it will crash as it is already added to backstack
            Fragment prev = FragmentManager.FindFragmentByTag("dialog");
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);
            // Create and show the dialog.
            HoleDetails_DialogFragment newFragment = HoleDetails_DialogFragment.NewInstance(null,selected.CourseTeeID, selected.HoleNumber, selected.ActualYardage, selected.Par);           //(null);
            //Add fragment
            newFragment.Show(ft, "dialog");

        }




    }
}