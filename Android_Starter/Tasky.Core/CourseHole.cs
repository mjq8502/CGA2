using System;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;
using Java.IO;

namespace Tasky.Core
{
    /// <summary>
    /// Tee business object
    /// </summary>
    public class CourseHole
    {
        public CourseHole()
        {
        }

        //public int ID { get; set; }
        public int CourseTeeID { get; set; }
        public string TeeName { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int CourseReportedYardage { get; set; }
        public int ActualYardage { get; set; }

    }

    public class CourseHoleData
    {
        public CourseHoleData()
        {

        }

        public int CourseTeeID { get; set; }
        public string TeeName { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int CourseReportedYardage { get; set; }
        public int ActualYardage { get; set; }

    }

    public class CourseHoleDataList 
    {
        public CourseHoleDataList()
        {
            
        }
        public int CourseTeeID { get; set; }
        public string TeeName { get; set; }
        public List<CourseHole> CourseHoles { get; set; }


    }

    public class CourseHoleDataListList
    {
        public CourseHoleDataListList()
        {

        }
        public List<CourseHoleDataList> CourseHoleDataLists { get; set; }

    }

    public class CourseHoleByNumberListList
    {
        public CourseHoleByNumberListList()
        {

        }
        public List<CourseHoleByNumberList> CourseHoleDataLists { get; set; }

        // Returns the number of holes in the course:
        public int NumHoles { get { return CourseHoleDataLists.Count; } }

    }

    public class CourseHoleByNumberList : ISerializable
    {
        public CourseHoleByNumberList()
        {

        }
        public int HoleNumber { get; set; }
        public List<CourseHole> CourseHoles { get; set; }

        IntPtr IJavaObject.Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }

}