using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasky.Core;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace CompleteGolfAppAndroid.Adapters
{
    class HoleDetails_GridView_HoleInfo_Adapter : BaseAdapter<string>
    {
        //public List<Model> items;
        Activity context;
        TextView txtFirst;
        TextView txtSecond;
        public string[] STR;
        public List<CourseHole> ChList;

        //public HoleDetails_GridView_HoleInfo_Adapter(HoleDetailsFragment c, string[] str) : base()
        public HoleDetails_GridView_HoleInfo_Adapter(HoleDetailsFragment c, List<CourseHole> chList) : base()
        {
            context = c.Activity;
            //STR = str;
            ChList = chList;

            //this.items = new List<Model>();
            //Model m = new Adapters.Model("Blue", "321");
            //items.Add(m);
            //m = new Adapters.Model("Red", "333");
            //items.Add(m);

        }
        public override int Count
        {
            //get { return STR.Length;  }
            get { return ChList.Count; }
        }

        public override string this[int position]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.HoleDetailsFragmentRow, null);
            }

            txtFirst = (TextView)view.FindViewById(Resource.Id.Tee_TextView);
            txtSecond = (TextView)view.FindViewById(Resource.Id.Yards_TextView);


            //string[] splited = STR[position].Split('|');

            //txtFirst.Text = splited[0];  
            //txtSecond.Text = splited[1];
            txtFirst.Text = ChList[position].TeeName;
            txtSecond.Text = ChList[position].ActualYardage.ToString();

            return view;

        }


    }

    //public class Model
    //{

    //    private String Tee;
    //    private String Yards;


    //    public Model(String tee, String yards)
    //    {
    //        this.Tee = tee;
    //        this.Yards = yards;

    //    }

    //    public String getsTee()
    //    {
    //        return Tee;
    //    }

    //    public String getYards()
    //    {
    //        return Yards;
    //    }
    //}
}
    
