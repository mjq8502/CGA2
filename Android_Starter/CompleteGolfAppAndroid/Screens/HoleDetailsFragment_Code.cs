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

            fragment.Arguments = args;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //string yards = Arguments.GetString(HOLE_YARDS, "");
            var courseHoleByNumberList = JsonConvert.DeserializeObject<Tasky.CourseHoleByNumberList>(Arguments.GetString("holesByNumber"));
            View view = inflater.Inflate(Resource.Layout.HoleDetailsFragment_Layout2, container, false);

            Context context = Android.App.Application.Context;

            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("Tee", typeof(string));
            //itemTable.Columns.Add("ReportedYards", typeof(string));
            itemTable.Columns.Add("Yards", typeof(string));


            List<string> stringList = new List<string>();

            foreach (var courseHole in courseHoleByNumberList.CourseHoles)
            {
                DataRow row = itemTable.NewRow();
                row["Tee"] = courseHole.TeeName;
                //row["ReportedYards"] = courseHole.CourseReportedYardage;
                row["Yards"] = courseHole.ActualYardage;
                itemTable.Rows.Add(row);
                stringList.Add(courseHole.TeeName + "|" + courseHole.ActualYardage);
            }

            var sl = stringList.ToArray();

            ListView client = view.FindViewById<ListView>(Resource.Id.HoleDetails_ListView);
            client.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this, sl);

            client.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {

                var selected = sl[e.Position];
            };

            client.ItemSelected += Client_ItemSelected;

            return view;
        }

        private void Client_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var x = 5;
        }

        //void OnSelection(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //    {
        //        return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
        //    }
        //    //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
        //    //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        //}


    }
}