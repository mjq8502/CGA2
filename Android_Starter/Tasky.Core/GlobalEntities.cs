using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Tasky.Core;

namespace Tasky
{
    public static class GlobalEntities
    {
        public static int testINT;
        public static CourseHoleByNumberListList courseHoleByNumberListList;
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