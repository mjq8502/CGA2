using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Tasky.Core;

namespace CompleteGolfAppAndroid.Adapters
{
    /// <summary>
    /// Adapter that presents Tasks in a row-view
    /// </summary>
    public class TeeListAdapter : BaseAdapter<Tee>
    {
        Activity context = null;
        IList<Tee> tees = new List<Tee>();

        public TeeListAdapter(Activity context, IList<Tee> tees) : base()
        {
            this.context = context;
            this.tees = tees;
        }

        public override Tee this[int position]
        {
            get { return tees[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return tees.Count; }
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            // Get our object for position
            var item = tees[position];

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            // will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
            var view = (convertView ??
                    context.LayoutInflater.Inflate(
                    Resource.Layout.TeeListItem,
                    parent,
                    false)) as LinearLayout;

            // Find references to each subview in the list item's view
            var txtTeeName = view.FindViewById<TextView>(Resource.Id.TeeListNameText);

            //Assign item's values to the various subviews
            txtTeeName.SetText(item.TeeName, TextView.BufferType.Normal);

            //Finally return the view
            return view;
        }
    }
}