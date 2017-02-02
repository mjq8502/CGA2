using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Tasky.Core;

namespace CompleteGolfAppAndroid.Adapters
{
    /// <summary>
    /// Adapter that presents Tasks in a row-view
    /// </summary>
    public class HoleListAdapter : BaseAdapter<Hole>
    {
        Activity context = null;
        IList<Hole> holes = new List<Hole>();

        public HoleListAdapter(Activity context, IList<Hole> holes) : base()
        {
            this.context = context;
            this.holes = holes;
        }

        public override Hole this[int position]
        {
            get { return holes[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return holes.Count; }
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            // Get our object for position
            var item = holes[position];

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            // will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
            var view = (convertView ??
                    context.LayoutInflater.Inflate(
                    Resource.Layout.HoleListItem,
                    parent,
                    false)) as LinearLayout;

            // Find references to each subview in the list item's view
            var txtHoleNumber = view.FindViewById<TextView>(Resource.Id.HoleNumberText);


            //Assign item's values to the various subviews
            txtHoleNumber.SetText(item.HoleNumber, TextView.BufferType.Normal);


            //Finally return the view
            return view;
        }
    }
}