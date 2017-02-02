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
        //public FlashCardDeck flashCardDeck;

        public CourseHoleByNumberListList courseHoles;

        //public HoleDetailsAdapter(Android.Support.V4.App.FragmentManager fm, FlashCardDeck flashCards)
        //    : base(fm)
        //{
        //    this.flashCardDeck = flashCards;
        //}

        public HoleDetailsAdapter(Android.Support.V4.App.FragmentManager fm, CourseHoleByNumberListList courseHoles)
            : base(fm)
        {
            this.courseHoles = courseHoles;
        }

        public override int Count
        {
            //get { return flashCardDeck.NumCards; }
            get { return courseHoles.NumHoles; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            //return (Android.Support.V4.App.Fragment)
            //    FlashCardFragment.newInstance(
            //        flashCardDeck[position].Problem, flashCardDeck[position].Answer);

            var x = courseHoles.CourseHoleDataLists.ElementAt(position);

            return (Android.Support.V4.App.Fragment)
                HoleDetailsFragment.newInstance(courseHoles.CourseHoleDataLists.ElementAt(position));
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String("Hole " + (position + 1) + " , Par " + courseHoles.CourseHoleDataLists[position].CourseHoles.FirstOrDefault().Par);
        }
    }
}