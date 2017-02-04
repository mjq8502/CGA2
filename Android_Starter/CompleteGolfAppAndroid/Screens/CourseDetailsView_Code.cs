using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using CompleteGolfAppAndroid;
using Tasky.Core;

using System.Collections.Generic;
using Android.Support.V4.View;
using CompleteGolfAppAndroid.Adapters;
using Android.Support.V4.App;
using System.Linq;


namespace CompleteGolfAppAndroid.Screens
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "CourseDetailsScreen")]
    public class CourseDetailsView_Code : FragmentActivity
    {
        Course course = new Course();
        Button cancelDeleteButton;
        TextView courseNameValue;
        TextView courseCityValue;
        TextView courseParValue;
        TextView courseHolesValue;
        Button addTeeButton;
        ViewPager holesViewPager;
        TreeCatalog treeCatalog;
        FlashCardDeck flashCards;
        //ViewPager viewPager;

        CompleteGolfAppAndroid.Adapters.CourseTeeListAdapter courseTeeListAdapter;
        ListView courseTees_ListView;

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
            courseCityValue = FindViewById<TextView>(Resource.Id.CourseDetailsView_TextView_City);
            courseParValue = FindViewById<TextView>(Resource.Id.CourseDetailsView_TextView_Par);
            courseHolesValue = FindViewById<TextView>(Resource.Id.CourseDetailsView_TextView_Holes);
            courseTees_ListView = FindViewById<ListView>(Resource.Id.CourseDetailsView_ListView_TeeSummary);
            addTeeButton = FindViewById<Button>(Resource.Id.CourseDetailsView_Button_AddTee);


            courseNameValue.Text = course.CourseName;
            courseCityValue.Text = course.City;
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


            #region courseHolesByHole
            //var courseHolesByHole = new CourseHoleByNumberListList
            //{
            //    CourseHoleDataLists = chd.GroupBy(g => new
            //    {
            //        g.HoleNumber
            //    })
            //    .Select(ch => new CourseHoleByNumberList
            //    {
            //        HoleNumber = ch.Key.HoleNumber,
            //        CourseHoles = ch.GroupBy(g => new
            //        {
            //            g.CourseTeeID,
            //            g.HoleNumber,
            //            g.ActualYardage,
            //            g.CourseReportedYardage,
            //            g.Par,
            //            g.TeeName

            //        }).Select(ch2 => new CourseHole
            //        {
            //            CourseTeeID = ch2.Key.CourseTeeID,
            //            HoleNumber = ch2.Key.HoleNumber,
            //            Par = ch2.Key.Par,
            //            CourseReportedYardage = ch2.Key.CourseReportedYardage,
            //            ActualYardage = ch2.Key.ActualYardage,
            //            TeeName = ch2.Key.TeeName
            //        }).ToList()
            //    }).ToList()
            //};
            #endregion

            Tasky.GlobalEntities.courseHoleByNumberListList = HoleManager.GetCourseHolesByHole(course.ID);

            if (Tasky.GlobalEntities.courseHoleByNumberListList.NumHoles < course.Holes)
            {
                for (int x = Tasky.GlobalEntities.courseHoleByNumberListList.NumHoles + 1; x < course.Holes + 1; x++)
                {
                    Tasky.CourseHoleByNumberList newHole = new Tasky.CourseHoleByNumberList();
                    newHole.HoleNumber = x;
                    newHole.CourseHoles = new List<CourseHole>();
                    foreach(var z in Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.FirstOrDefault().CourseHoles)
                    {
                        CourseHole ch = new CourseHole();
                        ch.CourseTeeID = z.CourseTeeID;
                        ch.ActualYardage = 0;
                        ch.CourseReportedYardage = 0;
                        ch.HoleNumber = x;
                        ch.Par = 0;
                        ch.TeeName = z.TeeName;
                        newHole.CourseHoles.Add(ch);
                    }
                    Tasky.GlobalEntities.courseHoleByNumberListList.CourseHoleDataLists.Add(newHole);



                }
                 
            }

            holesViewPager = FindViewById<ViewPager>(Resource.Id.CourseDetailsView_ViewPager_Holes);

            HoleDetailsAdapter hdAdapter = new HoleDetailsAdapter(SupportFragmentManager);
            holesViewPager.Adapter = hdAdapter; 

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
    }
}