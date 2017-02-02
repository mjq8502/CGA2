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

namespace CompleteGolfAppAndroid.Adapters
{
    class HoleDetails_GridView_HoleInfo_Adapter : BaseAdapter
    {
        Context context;

        public HoleDetails_GridView_HoleInfo_Adapter(Context c)
        {
            context = c;
        }

        public override int Count
        {
            get { return thumbIds.Length; }
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
            ImageView imageView;

            if (convertView == null)
            {  // if it's not recycled, initialize some attributes
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(85, 85);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            imageView.SetImageResource(thumbIds[position]);
            return imageView;
        }


        int[] thumbIds = {
        Resource.Drawable.birch, Resource.Drawable.coconut,
        Resource.Drawable.elm, Resource.Drawable.fir
        ////Resource.Drawable.larch, Resource.Drawable.maple,
        ////Resource.Drawable.oak, Resource.Drawable.pine,
        ////        Resource.Drawable.birch, Resource.Drawable.coconut,
        ////Resource.Drawable.elm, Resource.Drawable.fir,
        ////Resource.Drawable.larch, Resource.Drawable.maple,
        ////Resource.Drawable.oak, Resource.Drawable.pine,
        ////        Resource.Drawable.birch, Resource.Drawable.coconut,
        ////Resource.Drawable.elm, Resource.Drawable.fir,
        ////Resource.Drawable.larch, Resource.Drawable.maple,
        ////Resource.Drawable.oak, Resource.Drawable.pine

    };
    }
}

    
