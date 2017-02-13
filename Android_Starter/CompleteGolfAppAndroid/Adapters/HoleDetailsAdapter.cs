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

        public HoleDetailsAdapter(Android.Support.V4.App.FragmentManager fm, List<Tasky.CourseHoleByNumberList> chbnl) : base(fm)
        {
            CHBNL = chbnl;
            //this.courseHoles = courseHoles;
        }

        public override int Count
        {
            get { return CHBNL.Count; }
            //get { return Tasky.GlobalEntities.courseHoleByNumberListList.NumHoles; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {

            var x = Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.ElementAt(position);

            return (Android.Support.V4.App.Fragment)
                HoleDetailsFragment.newInstance(CHBNL.ElementAt(position));
            //HoleDetailsFragment.newInstance(Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.ElementAt(position));

        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            //var holeNumber = Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists[position].CourseHoles.FirstOrDefault().HoleNumber;
            var holeNumber = CHBNL.ElementAt(position).HoleNumber.ToString();
            return new Java.Lang.String("Hole " + holeNumber.ToString() + " , Par " + Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists[position].CourseHoles.FirstOrDefault().Par);
        }
    }
}