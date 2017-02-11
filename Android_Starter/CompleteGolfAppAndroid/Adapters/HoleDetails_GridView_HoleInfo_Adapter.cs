using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace CompleteGolfAppAndroid.Adapters
{
    class HoleDetails_GridView_HoleInfo_Adapter : BaseAdapter
    {
        public List<Model> items;
        Activity context;
        TextView txtFirst;
        TextView txtSecond;
        public string[] STR;

        public HoleDetails_GridView_HoleInfo_Adapter(HoleDetailsFragment c, string[] str) : base()
        {
            context = c.Activity;
            STR = str;

            this.items = new List<Model>();
            Model m = new Adapters.Model("Blue", "321");
            items.Add(m);
            m = new Adapters.Model("Red", "333");
            items.Add(m);

        }
        public override int Count
        {
            get { return STR.Length;  }
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

            txtFirst = (EditText)view.FindViewById(Resource.Id.Tee_EditText);
            txtSecond = (EditText)view.FindViewById(Resource.Id.Yards_EditText);

            //txtFirst = (TextView)view.FindViewById(Resource.Id.Tee_TextView);
            //txtSecond = (TextView)view.FindViewById(Resource.Id.Yards_TextView);

            
            string[] splited = STR[position].Split('|');

            txtFirst.Text = splited[0];  
            txtSecond.Text = splited[1];  


            return view;

        }


    }

    public class Model
    {

        private String Tee;
        private String Yards;


        public Model(String tee, String yards)
        {
            this.Tee = tee;
            this.Yards = yards;

        }

        public String getsTee()
        {
            return Tee;
        }

        public String getYards()
        {
            return Yards;
        }
    }
}
    
