using System;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Tasky.Core;
using System.Linq;
using System.Collections.Generic;

namespace CompleteGolfAppAndroid
{
    class HoleDetailsAdapter : FragmentPagerAdapter
    {
        private List<Tasky.CourseHoleByNumberList> CHBNL;
        private int CourseID;
        public int holeNumber;
        public int Position;

        public HoleDetailsAdapter(Android.Support.V4.App.FragmentManager fm, List<Tasky.CourseHoleByNumberList> chbnl, int courseID) : base(fm)
        {
            CHBNL = chbnl;
            CourseID = courseID;
            //this.courseHoles = courseHoles;
        }

        public override int Count
        {
            get { return CHBNL.Count; }
            //get { return Tasky.GlobalEntities.courseHoleByNumberListList.NumHoles; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            var x = CHBNL.ElementAt(position).HoleNumber;
            var y = position;

            //Toast.MakeText(null, "hole = " + x.ToString() + " pos = " + y.ToString(), ToastLength.Short).Show();

            var xx = Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.ElementAt(position);

            return (Android.Support.V4.App.Fragment)
                HoleDetailsFragment.newInstance(CHBNL.ElementAt(position), CourseID);
            //HoleDetailsFragment.newInstance(Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.ElementAt(position));

        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            //var holeNumber = Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists[position].CourseHoles.FirstOrDefault().HoleNumber;
            holeNumber = CHBNL.ElementAt(position).HoleNumber;
            Position = position;
            return new Java.Lang.String("Hole " + holeNumber.ToString() + " , Par " + Tasky.GlobalEntities.courseHoleParByNumberListList.CourseHoleParDataLists[position].CourseHolePars.FirstOrDefault().Par);

        }
    }
}