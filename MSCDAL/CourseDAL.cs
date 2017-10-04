using System;
using System.Collections.Generic;
using MSCCommon;
using System.Data;
using System.Data.SqlClient;

namespace MSCDAL
{
    public class CourseDAL
    {
        static readonly CourseDAL _courseDAL = new CourseDAL();
        private CourseDAL() { }
        public static CourseDAL GetInstance { get { return _courseDAL; } }
        public static Course Get(long id)
        {
            Course _course = new Course();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetCourseById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _course.id = Convert.ToInt32(reader["Id"]);
                        _course.name = Convert.ToString(reader["Name"]);
                        _course.targetExam = Convert.ToString(reader["TargetExam"]);
                        _course.targetYear = Convert.ToString(reader["TargetYear"]);
                        _course.isDelete = Convert.ToBoolean(reader["isDelete"]);
                        _course.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _course.status = 200;
                        _course.message = _course.name + " (" + _course.name + ")" + " Course found.";
                        _course.isError = false;
                    }
                }
                else
                {
                    _course.status = 400;
                    _course.message = "No Course Found.";
                    _course.isError = true;
                }
                con.Close();
            }
            return _course;
        }
        public static List<Course> GetAll()
        {
            List<Course> CourseList = new List<Course>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Course _course = new Course();
                        _course.id = Convert.ToInt32(reader["Id"]);
                        _course.name = Convert.ToString(reader["Name"]);
                        _course.targetExam = Convert.ToString(reader["TargetExam"]);
                        _course.targetYear = Convert.ToString(reader["TargetYear"]);
                        _course.subjectIds = Convert.ToString(reader["SubjectIds"]);
                        _course.isDelete = Convert.ToBoolean(reader["isDelete"]);
                        _course.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _course.status = 200;
                        _course.message = _course.name + " Course found.";
                        _course.isError = false;
                        CourseList.Add(_course);
                    }
                }
                con.Close();
            }
            return CourseList;
        }
        public static Response Create(Course course)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", course.name));
                cmd.Parameters.Add(new SqlParameter("@TargetExam", course.targetExam));
                cmd.Parameters.Add(new SqlParameter("@TargetYear", course.targetYear));
                cmd.Parameters.Add(new SqlParameter("@SubjectIds", course.subjectIds));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Course Created Successfully";
                _response.isError = false;
            }
            return _response;
        }
        public static Response Update(Course Course)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _response.status = 200;
                        _response.message = "Course updated successfully";
                        _response.isError = false;
                    }
                }
                con.Close();
            }
            return _response;
        }
        public static Response Delete(int id)
        {
            Response response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DeleteGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response.status = 200;
                        response.message = "Login successfully";
                        response.isError = false;
                    }
                }
                con.Close();
            }
            return response;
        }
        public static void SyncCourses(Course Course)
        {
        }
    }
}
