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
using Tasky.Core;
using Android.Graphics;
using System.Data;

namespace CompleteGolfAppAndroid.Adapters
{
    class HoleDetails_GridView_HoleInfo_Adapter2 : BaseAdapter<string>
    {
        Context context;
        private DataTable itemTable = null;

        public HoleDetails_GridView_HoleInfo_Adapter2(Context c, DataTable ItemTable) : base()
        {
            context = c;
            itemTable = ItemTable;

        }

        public override string this[int position]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Count
        {
            get { return (itemTable.Rows.Count + 1) * itemTable.Columns.Count; }
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
            // find the current row number, need to test we're in the header 
            int row = GetRow(position);


            // Get our text for position 
            var item = PositionToString(position);

            // find if we have a control for the cell, if not create it 
            var txtName = convertView as EditText ?? new EditText(context);


            // if the row is a header give it a different colour 
            if (row == 0)
            {
                txtName.SetBackgroundColor(new Color(0x0d, 0x12, 0xf5));
                txtName.SetTextColor(new Color(0x0, 0x0, 0x0));
            }

            txtName.Tag = "row=" + row.ToString() + "|" + "col=" + GetCol(position);


            //Assign item's values to the various subviews 
            txtName.SetText(item, TextView.BufferType.Normal);

            txtName.Click += delegate {

                var x = txtName.Text;
                var z = itemTable;
                var tg = txtName.Tag;

            };

            var xx = Tasky.GlobalEntities.testINT;
            var zz = Tasky.GlobalEntities.courseHoleByNumberListList;
            //Finally return the view 
            return txtName;
        }


        private int GetCol(int pos)
        {
            int col = pos % (itemTable.Columns.Count);
            return col;
        }
        private int GetRow(int pos)
        {
            int row = pos / (itemTable.Columns.Count);
            return row;
        }
        private string PositionToString(int pos)
        {
            int row = GetRow(pos);
            int col = GetCol(pos);
            if (row == 0)
            {
                return itemTable.Columns[col].ColumnName;
            }
            if (itemTable.Rows[row - 1][col] != DBNull.Value)
            {
                return itemTable.Rows[row - 1][col].ToString();
            }
            return "";
        }


      
    }
}


