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

namespace CompleteGolfAppAndroid
{
    public class HoleDetailsFragment : Android.Support.V4.App.Fragment
    {
        private static string FLASH_CARD_QUESTION = "card_question";
        private static string HOLE_YARDS = "hy";
        private static string FLASH_CARD_ANSWER = "card_answer";
        //private static CourseHoleByNumberList chbnl;
        

        public HoleDetailsFragment()
        {
            
        }

        public static HoleDetailsFragment newInstance(CourseHoleByNumberList holesByNumber)
        {
            HoleDetailsFragment fragment = new HoleDetailsFragment();
            Bundle args = new Bundle();


            args.PutString("holesByNumber", JsonConvert.SerializeObject(holesByNumber));
            //args.PutString(HOLE_YARDS, holesByNumber.CourseHoles[0].CourseReportedYardage.ToString());

            fragment.Arguments = args;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            string yards = Arguments.GetString(HOLE_YARDS, "");
            var courseHoleByNumberList = JsonConvert.DeserializeObject<CourseHoleByNumberList>(Arguments.GetString("holesByNumber"));
            View view = inflater.Inflate(Resource.Layout.HoleDetailsFragment_Layout, container, false);

            var gridview = (GridView)view.FindViewById<GridView>(Resource.Id.HoleDetails_GridView_HoleInfo);
            Context context = Android.App.Application.Context;

            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("Tee", typeof(string));
            //itemTable.Columns.Add("ReportedYards", typeof(string));
            itemTable.Columns.Add("Yards", typeof(string));

            var debugg = courseHoleByNumberList.HoleNumber;
            
            foreach( var courseHole in courseHoleByNumberList.CourseHoles)
            {
                DataRow row = itemTable.NewRow();
                row["Tee"] = courseHole.TeeName;
                //row["ReportedYards"] = courseHole.CourseReportedYardage;
                row["Yards"] = courseHole.ActualYardage;
                itemTable.Rows.Add(row);
            }
            
            gridview.Adapter = new HoleDetails_GridView_HoleInfo_Adapter2(context, itemTable);

            //gridview.ItemClick += Gridview_ItemClick;

            //gridview.Click += Gridview_Click;

            return view;
        }

        private void Gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var u = 7;
        }

        private void Gridview_Click(object sender, EventArgs e)
        {
            var y = 8;
        }
    }
}