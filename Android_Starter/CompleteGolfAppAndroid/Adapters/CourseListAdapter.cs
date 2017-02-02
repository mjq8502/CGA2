using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Tasky.Core;

namespace CompleteGolfAppAndroid.Adapters
{
    /// <summary>
    /// Adapter that presents Tasks in a row-view
    /// </summary>
    public class CourseListAdapter : BaseAdapter<Course>
    {
        Activity context = null;
        IList<Course> courses = new List<Course>();

        public CourseListAdapter(Activity context, IList<Course> courses) : base()
        {
            this.context = context;
            this.courses = courses;
        }

        public override Course this[int position]
        {
            get { return courses[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return courses.Count; }
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            // Get our object for position
            var item = courses[position];

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            // will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
            var view = (convertView ??
                    context.LayoutInflater.Inflate(
                    Resource.Layout.CourseListItem,
                    parent,
                    false)) as LinearLayout;

            // Find references to each subview in the list item's view
            var txtCourseName = view.FindViewById<TextView>(Resource.Id.CourseNameText);
            //var txtCityName = view.FindViewById<TextView>(Resource.Id.CourseCityValue);

            //Assign item's values to the various subviews
            txtCourseName.SetText(item.CourseName, TextView.BufferType.Normal);
            //txtCityName.SetText(item.City, TextView.BufferType.Normal);

            //Finally return the view
            return view;
        }
    }
}