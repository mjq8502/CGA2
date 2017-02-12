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

namespace CompleteGolfAppAndroid
{
    public class HoleDetails_DialogFragment : Android.Support.V4.App.DialogFragment
    {
        EditText yardsEntered;
        private static int CourseTeeID = new int();
        private static int HoleNumber;
        private static int Yards;
        private static int Par;

        public static HoleDetails_DialogFragment NewInstance(Bundle bundle, int courseTeeId, int holeNumber)
        {
            HoleDetails_DialogFragment fragment = new HoleDetails_DialogFragment();
            CourseTeeID = courseTeeId;
            HoleNumber = holeNumber;
            Par = 99;
            fragment.Arguments = bundle;
            return fragment;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.HoleDetails_DialogFragmentLayout, container, false);
            Button saveButton = view.FindViewById<Button>(Resource.Id.HoleDetails_DialogFragment_Save_Button);
            Button cancelButton = view.FindViewById<Button>(Resource.Id.HoleDetails_DialogFragment_Cancel_Button);
            yardsEntered = view.FindViewById<EditText>(Resource.Id.HoleDetails_DialogFragment_Yards_EditText);

            saveButton.Click += delegate {

                int yards = 0;

                Int32.TryParse(yardsEntered.Text, out yards);

                HoleManager.UpdateCourseTeeHole(CourseTeeID, HoleNumber, yards, 99);
                
                Dismiss();
                Toast.MakeText(Activity, "Dialog fragment saved!" + " " + yards.ToString(), ToastLength.Long).Show();
            };

            cancelButton.Click += delegate {

                Dismiss();
                
            };


            return view;
        }
    }
}
