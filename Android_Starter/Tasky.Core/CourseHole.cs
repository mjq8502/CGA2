using System;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;
using Java.IO;

namespace Tasky.Core
{
    /// <summary>
    /// CourseHole object
    /// </summary>
    public class CourseHole
    {
        public int _id { get; set; }
        public int CourseID { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }

        public CourseHole()
        {
        }
    }

}