using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using CompleteGolfAppAndroid;
using Tasky.Core;

namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "TeeDetailsScreen")]
    public class TeeDetails_Code : Activity
    {
        Tee tee = new Tee();
        
        EditText teeTextEdit;
        Button saveButton;
        Button deleteButton;
        Button cancelButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            int teeID = Intent.GetIntExtra("TeeID", 0);
            if (teeID > 0)
            {
                tee = TeeManager.GetTee(teeID);
            }

            // set our layout to be the home screen
            SetContentView(Resource.Layout.TeeDetails_Layout);

            // find all our controls
            teeTextEdit = FindViewById<EditText>(Resource.Id.TeesDetail_EditText_TeeValue);

            deleteButton = FindViewById<Button>(Resource.Id.TeesDetail_Button_Delete);
            saveButton = FindViewById<Button>(Resource.Id.TeesDetail_Button_Save);
            cancelButton = FindViewById<Button>(Resource.Id.TeesDetail_Button_Cancel);

            // set the teeTextEdit based on whether or not it's an existing tee that was long clicked.
            teeTextEdit.Text = (tee.ID == 0 ? "" : tee.TeeName);

            // button clicks 
            cancelButton.Click += (sender, e) => { Cancel(); };
            saveButton.Click += (sender, e) => { Save(); };
            deleteButton.Click += (sender, e) => { Delete(); };
        }

        void Save()
        {

            tee.TeeName = teeTextEdit.Text;
            TeeManager.SaveTee(tee);

            Finish();
        }

        void Cancel()
        {

            Finish();
        }

        void Delete()
        {
            if (tee.ID != 0)
            {
                TeeManager.DeleteTee(tee.ID);
            }
            Finish();
        }

    }
}