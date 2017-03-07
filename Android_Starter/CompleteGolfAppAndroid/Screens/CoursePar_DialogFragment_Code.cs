using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Tasky.Core;
using Tasky;

namespace CompleteGolfAppAndroid
{
    public class CoursePar_DialogFragment : Android.Support.V4.App.DialogFragment
    {
        EditText parEntered;
        private static int CourseID = new int();
        private static int HoleNumber;
        private static int Par;
        public event DialogEventHandler Dismissed;

        //public event DialogEventHandler Dismissed;

        public static HoleDetails_DialogFragment NewInstance(Bundle bundle, int courseId, int holeNumber, int par)
        {
            HoleDetails_DialogFragment fragment = new HoleDetails_DialogFragment();
            CourseID = courseId;
            HoleNumber = holeNumber;
            Par = par;
            fragment.Arguments = bundle;
            return fragment;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.HoleDetails_DialogFragmentLayout, container, false);
            Button saveButton = view.FindViewById<Button>(Resource.Id.HoleDetails_DialogFragment_Save_Button);
            Button cancelButton = view.FindViewById<Button>(Resource.Id.HoleDetails_DialogFragment_Cancel_Button);
            parEntered = view.FindViewById<EditText>(Resource.Id..CourseDetailsEdit_EditText_City);

            saveButton.Click += delegate {

                int par = 0;
                Int32.TryParse(parEntered.Text, out par);

                HoleManager.UpdateCourseTeeHole(CourseID, HoleNumber, par);

                //Toast.MakeText(Activity, "Hole info saved!" + " " + yards.ToString(), ToastLength.Long).Show();
                if (null != Dismissed)
                {
                    Dismissed(this, new DialogEventArgs { Text = "Saved" });
                }


                Dismiss();
            };

            cancelButton.Click += delegate {

                Dismiss();

            };


            return view;
        }
    }
}
