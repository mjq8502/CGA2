using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Tasky.Core;
using Tasky;
using Android.Graphics;
using Android.Views.InputMethods;
using Android.Hardware;
using System.Threading;

namespace CompleteGolfAppAndroid
{
    public class CoursePar_DialogFragment : Android.App.DialogFragment
    {
        private EditText parEntered;
        private static int CourseID = new int();
        private static int HoleNumber;
        private static int Par;
        public event DialogEventHandler Dismissed;
        private TextView holeNumberTextView;
        //private static InputMethodManager imm;
        //private static Context context;

        public static CoursePar_DialogFragment NewInstance(Bundle bundle, int courseId, int holeNumber, int par)
        {
            CoursePar_DialogFragment fragment = new CoursePar_DialogFragment();
            CourseID = courseId;
            HoleNumber = holeNumber;
            Par = par;
            fragment.Arguments = bundle;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.CoursePar_DialogFragmentLayout, container, false);
            view.SetBackgroundColor(new Color(0x00, 0x65, 0x00));

            Button saveButton = view.FindViewById<Button>(Resource.Id.CoursePar_DialogFragment_Save_Button);
            Button cancelButton = view.FindViewById<Button>(Resource.Id.CoursePar_DialogFragment_Cancel_Button);
            parEntered = view.FindViewById<EditText>(Resource.Id.CoursePar_DialogFragment_Par_EditText);
            holeNumberTextView = view.FindViewById<TextView>(Resource.Id.CoursePar_DialogFragment_HoleNumber_Text_Value);

            holeNumberTextView.Text = HoleNumber.ToString();

            // This actually works, It shows a number keyboard when the DialogFragment opens.
            //parEntered.RequestFocus(); // This is an EditText
            //InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
            //imm.ShowSoftInput(parEntered, Android.Views.InputMethods.ShowFlags.Forced); // InputMethodManager.ShowImplicit);
            //imm.ToggleSoftInput(Android.Views.InputMethods.ShowFlags.Forced, 0);
            
            //I've played around with various flag settings, but no luck in having the keyboard go away when the DialogFragment is dismissed.

            parEntered.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    //add your logic here
                    e.Handled = true;

                    int par = 0;
                    Int32.TryParse(parEntered.Text, out par);

                    CourseHoleParManager.SaveCourseHole(CourseID, HoleNumber, par);

                    if (null != Dismissed)
                    {
                        Dismissed(this, new DialogEventArgs { Text = "Saved" });
                    }

                    Dismiss();
                }
            };

            saveButton.Click += delegate
            {

                int par = 0;
                Int32.TryParse(parEntered.Text, out par);

                CourseHoleParManager.SaveCourseHole(CourseID, HoleNumber, par);

                if (null != Dismissed)
                {
                    Dismissed(this, new DialogEventArgs { Text = "Saved" });
                }
                
                // I think I want the keyboard to go away right before the DialogFragment is dismissed,
                // But if someone has a different idea I'll take it.
                
                // Things I write here always have some kind of method not found error.

                //InputMethodManager immx = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
                ////immx.HideSoftInputFromWindow(container.getWindowToken(), 0);  // I'm never able to get a Window Token.

                //InputMethodManager immz = (InputMethodManager)Context.GetSystemService(Activity.InputMethodService);
                ////immz.ToggleSoftInput(InputMethodManager.HIDE_IMPLICIT_ONLY, 0); // Another method not found error.


                Dismiss();

                // After the DialogFragment is dismissed, the keyboard changes from all numbers to a QWERTY keyboard.
                // However I wish it would disappear completely.

            };

            cancelButton.Click += delegate
            {

                Dismiss();

            };





            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            //parEntered.ShowSoftInputOnFocus = true;
            //parEntered.RequestFocusFromTouch();
            //InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
            // Tasky.GlobalEntities.imm.ShowSoftInput(parEntered, Android.Views.InputMethods.ShowFlags.Forced); // InputMethodManager.ShowImplicit);
            //Thread.Sleep(100); // For some reason, a short delay is required here.
            //Tasky.GlobalEntities.imm.ShowSoftInput(parEntered, Android.Views.InputMethods.ShowFlags.Implicit); // InputMethodManager.ShowImplicit);
            //Thread.Sleep(100); // For some reason, a short delay is required here.
            //Tasky.GlobalEntities.imm.ToggleSoftInput(Android.Views.InputMethods.ShowFlags.Implicit, 0);
            //Thread.Sleep(100); // For some reason, a short delay is required here.
        }

        //private void ShowSoftKeyboard(View input, bool selectText)
        //{
        //    if (selectText) ((EditText)input).SelectAll();
        //    ThreadPool.QueueUserWorkItem(s =>
        //    {
        //        Thread.Sleep(100); // For some reason, a short delay is required here.
        //        RunOnUiThread(() => (Tasky.GlobalEntities.imm.ShowSoftInput(input, ShowFlags.Implicit)));
        //    });
        //}



        private void ForceShowKeyboard(EditText editText)
        {
            
            //SensorManager  sensorManager = (SensorManager) getActivity().getSystemService(Context.SensorService);
            //editText.RequestFocus();
            //InputMethodManager imm = (InputMethodManager)  getSystemService(Android.Content.Context.InputMethodService);
            //InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Android.Content.Context.InputMethodService);
            //Tasky.GlobalEntities.imm.ShowSoftInput(editText, ShowFlags.Implicit);

            //public static void hideKeyboardFrom(Context context, View view)
            //{
            //    InputMethodManager imm = (InputMethodManager)context.GetSystemService(Activity.InputMethodService);
            //    //imm.HideSoftInputFromWindow(view.getWindowToken(), 0);
            //}

        }

    }


}
