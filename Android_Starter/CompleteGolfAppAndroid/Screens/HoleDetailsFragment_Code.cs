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

namespace CompleteGolfAppAndroid
{
    public class HoleDetailsFragment : Fragment   //Android.Support.V4.App.ListFragment
    {
        private ListView _listView;
        private string[] list;
        private static Tasky.CourseHoleByNumberList chbnl;

        public HoleDetailsFragment()
        {
            
        }

        public static HoleDetailsFragment newInstance(Tasky.CourseHoleByNumberList holesByNumber)
        {
            HoleDetailsFragment fragment = new HoleDetailsFragment();
            Bundle args = new Bundle();
            chbnl = holesByNumber;
           

            args.PutString("holesByNumber", JsonConvert.SerializeObject(holesByNumber));

            fragment.Arguments = args;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var courseHoleByNumberList = JsonConvert.DeserializeObject<Tasky.CourseHoleByNumberList>(Arguments.GetString("holesByNumber"));
            View view = inflater.Inflate(Resource.Layout.HoleDetailsFragment_Layout2, container, false);

            Context context = Android.App.Application.Context;

            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("Tee", typeof(string));
            itemTable.Columns.Add("Yards", typeof(string));


            List<string> stringList = new List<string>();
            List<CourseHole> chList = new List<CourseHole>();
            foreach (var courseHole in courseHoleByNumberList.CourseHoles)
            {
                DataRow row = itemTable.NewRow();
                row["Tee"] = courseHole.TeeName;
                row["Yards"] = courseHole.ActualYardage;
                itemTable.Rows.Add(row);
                stringList.Add(courseHole.TeeName + "|" + courseHole.ActualYardage);
                chList.Add(courseHole);
            }

            list = stringList.ToArray();

            _listView = view.FindViewById<ListView>(Resource.Id.HoleDetails_ListView);
            _listView.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this, chList);

            _listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                var selected = courseHoleByNumberList.CourseHoles[e.Position];
                Toast toast = Toast.MakeText(this.Context, "Item click " + selected.TeeName.ToString()
                                                                + " " + selected.ActualYardage
                                                                + " " + selected.CourseTeeID, Android.Widget.ToastLength.Short);
                toast.Show();
                
            };

            _listView.ItemLongClick += _listView_ItemLongClick;

            return view;
        }

        private void _listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var selected = list[e.Position];
            //Toast toast = Toast.MakeText(this.Context, "_listView_ItemLongClick " + selected.ToString(), Android.Widget.ToastLength.Short);
            //toast.Show();
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            //Remove fragment else it will crash as it is already added to backstack
            Fragment prev = FragmentManager.FindFragmentByTag("dialog");
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);
            // Create and show the dialog.
            DialogFragment1 newFragment = DialogFragment1.NewInstance(null);
            //Add fragment
            newFragment.Show(ft, "dialog");

        }




    }
}