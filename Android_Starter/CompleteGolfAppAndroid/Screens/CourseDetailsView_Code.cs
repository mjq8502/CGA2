using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core;

using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Graphics;
using Tasky;
using static Android.Support.V4.View.PagerTitleStrip;
using System;

namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "Course Details")]
    public class CourseDetailsView_Code : FragmentActivity, ViewPager.IOnPageChangeListener
    {
        Course course = new Course();
        Button cancelDeleteButton;
        TextView courseNameValue;
        TextView courseCityValue;
        TextView courseParValue;
        TextView courseHolesValue;
        TextView tvHoles;
        Button addTeeButton;
        ViewPager holesViewPager;
        TreeCatalog treeCatalog;
        PagerTitleStrip pts;
        LinearLayout linearLayout_CourseNameBasicInfo;

        HoleDetailsAdapter hdAdapter;

        public int holeNumber;


        CompleteGolfAppAndroid.Adapters.CourseTeeListAdapter courseTeeListAdapter;
        ListView courseTees_ListView;
        List<Tasky.CourseHoleByNumberList> chbnl;

        IList<CourseTee> courseTees;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            int courseID = Intent.GetIntExtra("CourseID", 0);

            if (courseID > 0)
            {
                //courseName = Intent.GetStringExtra("CourseName") ?? "No data, why";
                course = CourseManager.GetCourse(courseID);
            }
            else
            {

            }

            // set our layout to be the home screen
            SetContentView(Resource.Layout.CourseDetailsView_Layout);

            

            // find all our controls
            courseNameValue = FindViewById<TextView>(Resource.Id.CourseDetailsView_TextView_Name);
            courseParValue = FindViewById<TextView>(Resource.Id.CourseDetailsView_TextView_Par);
            courseHolesValue = FindViewById<TextView>(Resource.Id.CourseDetailsView_TextView_Holes);
            courseTees_ListView = FindViewById<ListView>(Resource.Id.CourseDetailsView_ListView_TeeSummary);
            addTeeButton = FindViewById<Button>(Resource.Id.CourseDetailsView_Button_AddTee);
            linearLayout_CourseNameBasicInfo = FindViewById<LinearLayout>(Resource.Id.CourseDetailsView_LinearLayout_CourseNameBasicInfo);

            courseNameValue.Text = course.CourseName;
            courseHolesValue.Text = course.Holes.ToString();
            courseParValue.Text = course.Par.ToString();

            
            if (addTeeButton != null)
            {
                addTeeButton.Click += delegate {

                    var activity2 = new Intent(this, typeof(CourseTeeDetails_Code));
                    activity2.PutExtra("CourseName", courseNameValue.Text);
                    activity2.PutExtra("CourseID", course.ID);
                    StartActivity(activity2);

                };
            }


            Tasky.GlobalEntities.courseHoleByNumberListList = HoleManager.GetCourseHolesByHole(course.ID);
            Tasky.GlobalEntities.courseHoleParByNumberListList = CourseHoleParManager.GetCourseHoleParsByHole(courseID);

            holesViewPager = FindViewById<ViewPager>(Resource.Id.CourseDetailsView_ViewPager_Holes);

            holesViewPager.AddOnPageChangeListener(this);

            pts = FindViewById<PagerTitleStrip>(Resource.Id.CourseDetailsView_PagerTitleStrip);
            pts.LongClick += Pts_LongClick;

            

            //List<Tasky.CourseHoleByNumberList> chbnl = new List<Tasky.CourseHoleByNumberList>();
            chbnl = new List<Tasky.CourseHoleByNumberList>();

            foreach (Tasky.CourseHoleByNumberList chb in Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists)
            {
                chbnl.Add(chb);
            }

            //HoleDetailsAdapter hdAdapter = new HoleDetailsAdapter(SupportFragmentManager, chbnl, courseID);
            hdAdapter = new HoleDetailsAdapter(SupportFragmentManager, chbnl, courseID);
            holesViewPager.Adapter = hdAdapter;


            ImageView backgroundImage = (ImageView)FindViewById<ImageView>(Resource.Id.CourseDetailsView_BackgroundImage);
            backgroundImage.SetBackgroundResource(Resource.Drawable.Screenshot_20170225_142830);

            courseTees_ListView.SetBackgroundColor(new Color(0x00, 0x65, 0x00));
            addTeeButton.SetBackgroundColor(new Color(0x00, 0x65, 0x00));
            linearLayout_CourseNameBasicInfo.SetBackgroundColor(new Color(0x00, 0x65, 0x00));

            

        }

        private void Pts_LongClick(object sender, System.EventArgs e)
        {
            Android.App.FragmentTransaction ft = FragmentManager.BeginTransaction();
            //Remove fragment else it will crash as it is already added to backstack
            Android.App.Fragment prev = FragmentManager.FindFragmentByTag("dialog");
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);

            var zz = chbnl;

            // Create and show the dialog.
            CoursePar_DialogFragment newFragment = CoursePar_DialogFragment.NewInstance(null, course.ID, holeNumber, 99);     
            newFragment.Dismissed += NewFragment_Dismissed;                                                                                                                                       //Add fragment
            newFragment.Show(ft, "dialog");
        }




        protected override void OnResume()
        {
            base.OnResume();


            courseTees = CourseTeeManager.GetCourseTees(course.ID);

            // create our adapter
            courseTeeListAdapter = new Adapters.CourseTeeListAdapter(this, courseTees);


            //Hook up our adapter to our ListView

            courseTees_ListView.Adapter = courseTeeListAdapter;

        }


        void Save()
        {
            course.CourseName = courseNameValue.Text;
            course.City = courseCityValue.Text;

            CourseManager.SaveCourse(course);

            Finish();
        }

        void CancelDelete()
        {
            //if (task.ID != 0)
            //{
            //    TaskManager.DeleteTask(task.ID);
            //}
            Finish();
        }

        private void NewFragment_Dismissed(object sender, DialogEventArgs args)
        {
            Tasky.GlobalEntities.courseHoleParByNumberListList = CourseHoleParManager.GetCourseHoleParsByHole(course.ID);
            //var updatedCourseHoles = HoleManager.GetCourseHolesByHole(course.ID);
            //List<CourseTeeHole> chList = new List<CourseTeeHole>();
            //foreach (var courseHolePar in Tasky.GlobalEntities.courseHoleParByNumberListList.CourseHoleParDataLists[holeNumber].CourseHolePars)
            //{
            //    chList.Add(courseHole);
            //}
            hdAdapter = new HoleDetailsAdapter(SupportFragmentManager, chbnl, course.ID);
            holesViewPager.Adapter = hdAdapter;
            holesViewPager.SetCurrentItem(holeNumber - 1, true);

            //_listView.Adapter = new HoleDetails_GridView_HoleInfo_Adapter(this, chList);
        }

        public void OnPageScrollStateChanged(int state)
        {
            
            //throw new NotImplementedException();
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            holeNumber = position + 1;  // This is called about three times on a swipe, but always has the destination position correct at the end.
            //throw new NotImplementedException();
        }

        public void OnPageSelected(int position)
        {
            //holeNumber = position + 1;
            //throw new NotImplementedException();
        }
    }
}