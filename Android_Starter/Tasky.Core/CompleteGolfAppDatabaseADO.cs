using System;
using System.Linq;
using System.Collections.Generic;

using Mono.Data.Sqlite;
using System.IO;
using System.Data;

namespace Tasky.Core
{
    /// <summary>
    /// TaskDatabase uses ADO.NET to create the [Items] table and create,read,update,delete data
    /// </summary>
    public class CompleteGolfAppDatabase
    {
        static object locker = new object();

        public SqliteConnection connection;

        public string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.CompleteGolfAppDatabase"/> CompleteGolfAppDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        public CompleteGolfAppDatabase(string dbPath)
        {
            var output = "";
            path = dbPath;

            string dbName = "CompleteGolfAppDatabase.db3";
            dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName); // Use this for development so that SQLite Editor can see it.
            path = dbPath;  // Use this for development so that SQLite Editor can see it.

            // create the tables
            bool exists = File.Exists(dbPath);

            if (!exists)
            {
                connection = new SqliteConnection("Data Source=" + dbPath);

                connection.Open();
                var commands = new[] {
                    "CREATE TABLE [Tees] (_id INTEGER PRIMARY KEY ASC, TeeName NTEXT);",
                    "CREATE TABLE [Courses] (_id INTEGER PRIMARY KEY ASC, CourseName NTEXT, City NTEXT, State NTEXT, CourseHoles INTEGER, CoursePar INTEGER);",
                    "CREATE TABLE [CourseTees] (_id INTEGER PRIMARY KEY ASC, CourseID INTEGER, TeeID INTEGER, CourseReportedYardage INTEGER);",
                    "CREATE TABLE [Holes] (_id INTEGER PRIMARY KEY ASC, CourseTeeID INTEGER, HoleNumber INTEGER, Par INTEGER, CourseReportedYardage INTEGER, ActualYardage INTEGER);"
                };
                foreach (var command in commands)
                {
                    using (var c = connection.CreateCommand())
                    {
                        c.CommandText = command;
                        var i = c.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                // Database does not exist  or being modified.

                //connection = new SqliteConnection("Data Source=" + dbPath);

                //connection.Open();
                //var commands = new[] {
                //    "DROP TABLE [Holes] ;",

                //    "CREATE TABLE [Holes] (_id INTEGER PRIMARY KEY ASC, CourseTeeID INTEGER, HoleNumber INTEGER, Par INTEGER, CourseReportedYardage INTEGER, ActualYardage INTEGER);"
                //};
                //foreach (var command in commands)
                //{
                //    using (var c = connection.CreateCommand())
                //    {
                //        c.CommandText = command;
                //        var i = c.ExecuteNonQuery();
                //    }
                //}

            }
            Console.WriteLine(output);
        }

        /// <summary>Convert from DataReader to Tee object</summary>
        Tee FromReader(SqliteDataReader r)
        {
            var t = new Tee();
            t.ID = Convert.ToInt32(r["_id"]);
            t.TeeName = r["TeeName"].ToString();
            return t;
        }

        /// <summary>Convert from DataReader to Course object</summary>
        Course FromReaderCourse(SqliteDataReader r)
        {
            var t = new Course();
            t.ID = Convert.ToInt32(r["_id"]);
            t.CourseName = r["CourseName"].ToString();
            t.City = r["City"].ToString();
            t.State = r["State"].ToString();
            if (r["CourseHoles"]==System.DBNull.Value)
            {
                t.Holes = 0;
            }
            else
            {
                t.Holes = Convert.ToInt32(r["CourseHoles"]);
            }

            if (r["CoursePar"] == System.DBNull.Value)
            {
                t.Par = 0;
            }
            else
            {
                t.Par = Convert.ToInt32(r["CoursePar"]);
            }

            return t;
        }

        /// <summary>Convert from DataReader to CourseTee object</summary>
        CourseTee FromReaderCourseTee(SqliteDataReader r)
        {
            var t = new CourseTee();
            if (r["_id"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                t.ID = Convert.ToInt32(r["_id"]);
            }
            
            t.TeeID = Convert.ToInt32(r["TeeID"]);
            t.TeeName = r["TeeName"].ToString();
            if (r["CourseReportedYardage"] == System.DBNull.Value)
            {
                t.CourseReportedYardage = 0;
            }
            else
            {
                t.CourseReportedYardage = Convert.ToInt32(r["CourseReportedYardage"]);
            }


            return t;
        }


        /// <summary>Convert from DataReader to CourseTee object</summary>
        CourseTee FromReaderAllCourseTees(SqliteDataReader r)
        {
            var t = new CourseTee();
            if (r["_id"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                t.ID = Convert.ToInt32(r["_id"]);
            }


            if (r["TeeID"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                t.TeeID = Convert.ToInt32(r["TeeID"]);
            }

            if (r["CourseID"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                t.CourseID = Convert.ToInt32(r["CourseID"]);
            }

            if (r["CourseReportedYardage"] == System.DBNull.Value)
            {
                t.CourseReportedYardage = 0;
            }
            else
            {
                t.CourseReportedYardage = Convert.ToInt32(r["CourseReportedYardage"]);
            }


            return t;
        }

        /// <summary>Convert from DataReader to CourseHoles object</summary>
        CourseHoleData FromReaderCourseHoleData(SqliteDataReader r)
        {
            var chd = new CourseHoleData();


            if (r["CourseTeeID"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                chd.CourseTeeID = Convert.ToInt32(r["CourseTeeID"]);
            }

            if (r["HoleNumber"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                chd.HoleNumber = Convert.ToInt32(r["HoleNumber"]);
            }

            if (r["Par"] == System.DBNull.Value)
            {
                var j = 7;
            }
            else
            {
                chd.Par = Convert.ToInt32(r["Par"]);
            }

            if (r["CourseReportedYardage"] == System.DBNull.Value)
            {
                chd.CourseReportedYardage = 0;
            }
            else
            {
                chd.CourseReportedYardage = Convert.ToInt32(r["CourseReportedYardage"]);
            }

            if (r["ActualYardage"] == System.DBNull.Value)
            {
                chd.ActualYardage = 0;
            }
            else
            {
                chd.ActualYardage = Convert.ToInt32(r["ActualYardage"]);
            }

            chd.TeeName = r["TeeName"].ToString();

            return chd;
        }

        /// <summary>Convert from DataReader to CourseHole object</summary>
        CourseHole FromReaderCourseHole(SqliteDataReader r)
        {
            var ch = new CourseHole();


            return ch;
        }


        #region Tees
        public IEnumerable<Tee> GetTees()
        {
            var tl = new List<Tee>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var contents = connection.CreateCommand())
                {
                    contents.CommandText = "SELECT [_id], [TeeName] FROM [Tees]";
                    var r = contents.ExecuteReader();
                    while (r.Read())
                    {
                        tl.Add(FromReader(r));
                    }
                }
                connection.Close();
            }
            return tl;
        }

        public Tee GetTee(int id)
        {
            var t = new Tee();
            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [_id], [TeeName] From Tees WHERE [_id] = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        t = FromReader(r);
                        break;
                    }
                }
                connection.Close();
            }
            return t;
        }

        public int SaveTee(Tee item)
        {
            int r;
            lock (locker)
            {
                if (item.ID != 0)
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE [Tees] SET [TeeName] = ? WHERE [_id] = ?;";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.TeeName });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.ID });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }
                else
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [Tees] ([TeeName]) VALUES (?)";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.TeeName });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }

            }
        }

        public int DeleteTee(int id)
        {
            lock (locker)
            {
                int r;
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Tees] WHERE [_id] = ?;";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    r = command.ExecuteNonQuery();
                }
                connection.Close();
                return r;
            }
        }
        #endregion

        #region Courses
        public IEnumerable<Course> GetCourses()
        {
            var tl = new List<Course>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var contents = connection.CreateCommand())
                {
                    contents.CommandText = "SELECT [_id], [CourseName], [City], [State], [CourseHoles], [CoursePar] FROM [Courses]";
                    var r = contents.ExecuteReader();
                    while (r.Read())
                    {
                        tl.Add(FromReaderCourse(r));
                    }
                }
                connection.Close();
            }
            return tl;
        }

        public Course GetCourse(int id)
        {
            var t = new Course();
            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [_id], [CourseName], [City], [State], [CourseHoles], [CoursePar] FROM [Courses] WHERE [_id] = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        t = FromReaderCourse(r);
                        break;
                    }
                }
                connection.Close();
            }
            return t;
        }

        public Course GetCourse(string newCourseName)
        {
            var t = new Course();
            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [_id], [CourseName], [City], [State], [CourseHoles], [CoursePar] FROM [Courses] WHERE [CourseName] = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.String) { Value = newCourseName });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        t = FromReaderCourse(r);
                        break;
                    }
                }
                connection.Close();
            }
            return t;
        }

        public int SaveCourse(Course item)
        {
            int r;
            lock (locker)
            {
                if (item.ID != 0)
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE [Courses] SET [CourseName] = ?, [City] = ?, [State] = ?, [CourseHoles] = ?, [CoursePar] = ? WHERE [_id] = ?;";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.CourseName });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.City });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.State });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.Holes });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.Par });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.ID });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }
                else
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [Courses] ([CourseName],[City],[State],[CourseHoles],[CoursePar]) VALUES (?,?,?,?,?)";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.CourseName });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.City });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.State });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.Holes });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.Par });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }

            }
        }

        public int DeleteCourse(int id)
        {
            lock (locker)
            {
                int r;
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Courses] WHERE [_id] = ?;";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    r = command.ExecuteNonQuery();
                }
                connection.Close();
                return r;
            }
        }
        #endregion

        #region CourseTees
        public IEnumerable<CourseTee> GetCourseTees(int courseID)
        {
            var tl = new List<CourseTee>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ct._id, ct.TeeID, t.TeeName, ct.CourseReportedYardage "
                                         + "FROM [CourseTees] ct, [Tees] t "
                                         + "WHERE ct.TeeID = t._id "
                                         + "AND ct.CourseID = ?" ;
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = courseID });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        tl.Add(FromReaderCourseTee(r));
                    }
                }
                connection.Close();
            }
            return tl;
        }

        public IEnumerable<CourseTee> GetAllCourseTees()
        {
            var tl = new List<CourseTee>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ct._id, ct.CourseID, ct.TeeID, ct.CourseReportedYardage "
                                         + "FROM [CourseTees] ct ";
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        tl.Add(FromReaderAllCourseTees(r));
                    }
                }
                connection.Close();
            }
            return tl;
        }

        public CourseTee GetCourseTee(int id)
        {
            var t = new CourseTee();
            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [_id], [CourseID], [TeeID], [CourseReportedYardage] FROM [CourseTees] WHERE [_id] = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        t = FromReaderCourseTee(r);
                        break;
                    }
                }
                connection.Close();
            }
            return t;
        }

        public int SaveCourseTee(CourseTee item)
        {
            int r;
            lock (locker)
            {
                if (item.ID != 0)
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE [CourseTees] SET [CourseID] = ?, [TeeID] = ?, [CourseReportedYardage] = ? WHERE [_id] = ?;";
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseID });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseReportedYardage });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.TeeID });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.ID });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }
                else
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [CourseTees] ([CourseID],[TeeID],[CourseReportedYardage]) VALUES (?,?,?)";
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseID });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.TeeID });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseReportedYardage });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }

            }
        }

        public int DeleteCourseTee(int id)
        {
            lock (locker)
            {
                int r;
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [CourseTees] WHERE [_id] = ?;";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    r = command.ExecuteNonQuery();
                }
                connection.Close();
                return r;
            }
        }
        #endregion

        #region CourseHoles
        public IEnumerable<CourseHoleData> GetCourseHoleData(int courseID)
        {
            List<CourseHoleData> courseHoleDataList;
            courseHoleDataList = new List<Core.CourseHoleData>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT h._id, h.CourseTeeID, h.HoleNumber, h.Par, h.CourseReportedYardage" + 
                                         ", h.ActualYardage, t.TeeName "
                                         + "FROM [CourseTees] ct, [Holes] h, [Tees] t "
                                         + "WHERE ct._id = h.CourseTeeID "
                                         + "AND ct.TeeID = t._id "
                                         + "AND ct.CourseID = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = courseID });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        courseHoleDataList.Add(FromReaderCourseHoleData(r));
                    }
                }
                connection.Close();
            }
            return courseHoleDataList;
        }


        //public CourseHoles GetAllCourseHoles(int courseID)
        //{
        //    var tl = new CourseHoles();

        //    lock (locker)
        //    {
        //        connection = new SqliteConnection("Data Source=" + path);
        //        connection.Open();
        //        using (var command = connection.CreateCommand())
        //        {
        //            command.CommandText = "SELECT h._id, ct._id, h.HoleNumber, h.Par, h.CourseReportedYardage, h.ActualYardage "
        //                                 + "FROM [CourseTees] ct, [Holes] h "
        //                                 + "WHERE ct._id = h.CourseTeeID "
        //                                 + "AND ct.CourseID = ?";
        //            command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = courseID });
        //            var r = command.ExecuteReader();
        //            while (r.Read())
        //            {
        //                tl.CourseHolesList.Add(FromReaderCourseHole(r));
        //            }
        //        }
        //        connection.Close();
        //    }
        //    return tl;
        //}

        public IEnumerable<CourseTee> GetCourseHoles(int CourseID, int TeeID)
        {
            var tl = new List<CourseTee>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ct._id, ct.CourseID, ct.TeeID, ct.CourseReportedYardage "
                                         + "FROM [CourseTees] ct ";
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        tl.Add(FromReaderAllCourseTees(r));
                    }
                }
                connection.Close();
            }
            return tl;
        }

        //public CourseTee GetCourseTee(int id)
        //{
        //    var t = new CourseTee();
        //    lock (locker)
        //    {
        //        connection = new SqliteConnection("Data Source=" + path);
        //        connection.Open();
        //        using (var command = connection.CreateCommand())
        //        {
        //            command.CommandText = "SELECT [_id], [CourseID], [TeeID], [CourseReportedYardage] FROM [CourseTees] WHERE [_id] = ?";
        //            command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
        //            var r = command.ExecuteReader();
        //            while (r.Read())
        //            {
        //                t = FromReaderCourseTee(r);
        //                break;
        //            }
        //        }
        //        connection.Close();
        //    }
        //    return t;
        //}

        //public int SaveCourseTee(CourseTee item)
        //{
        //    int r;
        //    lock (locker)
        //    {
        //        if (item.ID != 0)
        //        {
        //            connection = new SqliteConnection("Data Source=" + path);
        //            connection.Open();
        //            using (var command = connection.CreateCommand())
        //            {
        //                command.CommandText = "UPDATE [CourseTees] SET [CourseID] = ?, [TeeID] = ?, [CourseReportedYardage] = ? WHERE [_id] = ?;";
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseID });
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseReportedYardage });
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.TeeID });
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.ID });
        //                r = command.ExecuteNonQuery();
        //            }
        //            connection.Close();
        //            return r;
        //        }
        //        else
        //        {
        //            connection = new SqliteConnection("Data Source=" + path);
        //            connection.Open();
        //            using (var command = connection.CreateCommand())
        //            {
        //                command.CommandText = "INSERT INTO [CourseTees] ([CourseID],[TeeID],[CourseReportedYardage]) VALUES (?,?,?)";
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseID });
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.TeeID });
        //                command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.CourseReportedYardage });
        //                r = command.ExecuteNonQuery();
        //            }
        //            connection.Close();
        //            return r;
        //        }

        //    }
        //}

        //public int DeleteCourseTee(int id)
        //{
        //    lock (locker)
        //    {
        //        int r;
        //        connection = new SqliteConnection("Data Source=" + path);
        //        connection.Open();
        //        using (var command = connection.CreateCommand())
        //        {
        //            command.CommandText = "DELETE FROM [CourseTees] WHERE [_id] = ?;";
        //            command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
        //            r = command.ExecuteNonQuery();
        //        }
        //        connection.Close();
        //        return r;
        //    }
        //}
        #endregion

    }
}