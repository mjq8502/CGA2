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
    public class HoleDetailsFragment : Fragment  //Android.Support.V4.App.ListFragment
    {
        private static string HOLE_YARDS = "hy";
        //private static CourseHoleByNumberList chbnl;
        HoleDetails_GridView_HoleInfo_Adapter listAdapter;

        public HoleDetailsFragment()
        {
            
        }

        public static HoleDetailsFragment newInstance(Tasky.CourseHoleByNumberList holesByNumber)
        {
            HoleDetailsFragment fragment = new HoleDetailsFragment();
            Bundle args = new Bundle();


            args.PutString("holesByNumber", JsonConvert.SerializeObject(holesByNumber));
            //args.PutString(HOLE_YARDS, holesByNumber.CourseHoles[0].CourseReportedYardage.ToString());

            //fragment.Arguments = args;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //string yards = Arguments.GetString(HOLE_YARDS, "");
            //var courseHoleByNumberList = JsonConvert.DeserializeObject<Tasky.CourseHoleByNumberList>(Arguments.GetString("holesByNumber"));
            View view = inflater.Inflate(Resource.Layout.HoleDetailsFragment_Layout2, container, false);

            //var listview = view.FindViewById<ListView>(Resource.Id.android:list);
            Context context = Android.App.Application.Context;

            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("Tee", typeof(string));
            //itemTable.Columns.Add("ReportedYards", typeof(string));
            itemTable.Columns.Add("Yards", typeof(string));


            List<string> stringList = new List<string>();

            //foreach ( var courseHole in courseHoleByNumberList.CourseHoles)
            //{
            //    DataRow row = itemTable.NewRow();
            //    row["Tee"] = courseHole.TeeName;
            //    //row["ReportedYards"] = courseHole.CourseReportedYardage;
            //    row["Yards"] = courseHole.ActualYardage;
            //    itemTable.Rows.Add(row);
            //    stringList.Add(courseHole.TeeName + "   " + courseHole.ActualYardage);
            //}

            stringList.ToArray();

            //this.ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSelectableListItem, stringList);
            //listAdapter = new Adapters.HoleDetails_GridView_HoleInfo_Adapter(this);
            ListView client = view.FindViewById<ListView>(Resource.Id.HoleDetails_ListView);
            client.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this);
            //listview.Adapter = new HoleDetails_GridView_HoleInfo_Adapter2(context, itemTable);

            return view;
        }


        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    string yards = Arguments.GetString(HOLE_YARDS, "");
        //    var courseHoleByNumberList = JsonConvert.DeserializeObject<Tasky.CourseHoleByNumberList>(Arguments.GetString("holesByNumber"));
        //    View view = inflater.Inflate(Resource.Layout.HoleDetailsFragment_Layout, container, false);

        //    var gridview = (GridView)view.FindViewById<GridView>(Resource.Id.HoleDetails_GridView_HoleInfo);
        //    Context context = Android.App.Application.Context;

        //    DataTable itemTable = new DataTable();
        //    itemTable.Columns.Add("Tee", typeof(string));
        //    //itemTable.Columns.Add("ReportedYards", typeof(string));
        //    itemTable.Columns.Add("Yards", typeof(string));

        //    var debugg = courseHoleByNumberList.HoleNumber;

        //    foreach (var courseHole in courseHoleByNumberList.CourseHoles)
        //    {
        //        DataRow row = itemTable.NewRow();
        //        row["Tee"] = courseHole.TeeName;
        //        //row["ReportedYards"] = courseHole.CourseReportedYardage;
        //        row["Yards"] = courseHole.ActualYardage;
        //        itemTable.Rows.Add(row);
        //    }

        //    gridview.Adapter = new HoleDetails_GridView_HoleInfo_Adapter2(context, itemTable);

        //    return view;
        //}


        //private void setDynamicHeight(GridView gridView)
        //{
        //    ListAdapter gridViewAdapter = gridView.getAdapter();
        //    if (gridViewAdapter == null)
        //    {
        //        // pre-condition
        //        return;
        //    }

        //    int totalHeight = 0;
        //    int items = gridViewAdapter.getCount();
        //    int rows = 0;

        //    View listItem = gridViewAdapter.getView(0, null, gridView);
        //    listItem.measure(0, 0);
        //    totalHeight = listItem.getMeasuredHeight();

        //    float x = 1;
        //    if (items > 5)
        //    {
        //        x = items / 5;
        //        rows = (int)(x + 1);
        //        totalHeight *= rows;
        //    }

        //    ViewGroup.LayoutParams params = gridView.getLayoutParams();
        //params.height = totalHeight;
        //    gridView.setLayoutParams(params);
        //}

    }
}