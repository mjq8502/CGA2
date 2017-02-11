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

namespace CompleteGolfAppAndroid
{
    public class DialogFragment1 : Android.Support.V4.App.DialogFragment
    {
        EditText et;

        public static DialogFragment1 NewInstance(Bundle bundle)
        {
            DialogFragment1 fragment = new DialogFragment1();
            fragment.Arguments = bundle;
            return fragment;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.DialogFragment1Layout, container, false);
            Button button = view.FindViewById<Button>(Resource.Id.CloseButton);
            et = view.FindViewById<EditText>(Resource.Id.blah_blah);

            button.Click += delegate {
                var zz = et.Text;
                Dismiss();
                Toast.MakeText(Activity, "Dialog fragment dismissed!" + " " + zz.ToString(), ToastLength.Long).Show();
            };
            return view;
        }
    }
}
