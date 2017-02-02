using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Tasky.Core;

namespace CompleteGolfAppAndroid.Adapters
{
    /// <summary>
    /// Adapter that presents Tasks in a row-view
    /// </summary>
    public class CourseTeeListAdapter : BaseAdapter<CourseTee>
    {
        Activity context = null;
        IList<CourseTee> courseTees = new List<CourseTee>();

        public CourseTeeListAdapter(Activity context, IList<CourseTee> courseTees) : base()
        {
            this.context = context;
            this.courseTees = courseTees;
        }

        public override CourseTee this[int position]
        {
            get { return courseTees[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return courseTees.Count; }
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            // Get our object for position
            var item = courseTees[position];

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
            var txtCourseReportedYardage = view.FindViewById<TextView>(Resource.Id.TeeListCourseReportedYardageText);
            //var txtActualYardage = view.FindViewById<TextView>(Resource.Id.TeeListActualYardageText);


            //Assign item's values to the various subviews
            txtTeeName.SetText(item.TeeName, TextView.BufferType.Normal);
            txtCourseReportedYardage.SetText(item.CourseReportedYardage.ToString(), TextView.BufferType.Normal);
            //txtActualYardage.SetText(item.CourseActualYardage, TextView.BufferType.Normal);


            //Finally return the view
            return view;
        }
    }
}