using System;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Tasky.Core;
using System.Linq;

namespace CompleteGolfAppAndroid
{
    class HoleDetailsAdapter : FragmentPagerAdapter
    {

        public HoleDetailsAdapter(Android.Support.V4.App.FragmentManager fm)
            : base(fm)
        {
            //this.courseHoles = courseHoles;
        }

        public override int Count
        {
            get { return Tasky.GlobalEntities.courseHoleByNumberListList.NumHoles; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {

            var x = Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.ElementAt(position);

            return (Android.Support.V4.App.Fragment)
                HoleDetailsFragment.newInstance(Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.ElementAt(position));

        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String("Hole " + (position + 1) + " , Par " + Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists[position].CourseHoles.FirstOrDefault().Par);
        }
    }
}