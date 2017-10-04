using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCCommon;
using System.Data;
using System.Data.SqlClient;

namespace MSCDAL
{
    public class BatchDAL
    {

        static readonly BatchDAL _batchDAL = new BatchDAL();
        private BatchDAL() { }
        public static BatchDAL GetInstance { get { return _batchDAL; } }
        public static Batch Get(int id)
        {
            Batch _batch = new Batch();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetBatchById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _batch.id = Convert.ToInt32(reader["Id"]);
                        _batch.name = Convert.ToString(reader["Name"]);
                        _batch.description = Convert.ToString(reader["Description"]);
                        _batch.gradeId = Convert.ToInt32(reader["GradeId"]);
                        _batch.isDelete = Convert.ToBoolean(reader["IsDelete"]);
                        _batch.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _batch.status = 200;
                        _batch.message = _batch.name + " (" + _batch.name + ")" + " Batch found.";
                        _batch.isError = false;
                    }
                }
                else
                {
                    _batch.status = 400;
                    _batch.message = "No Batch Found.";
                    _batch.isError = true;
                }
                con.Close();
            }
            return _batch;
        }
        public static List<Batch> GetAll()
        {
            List<Batch> BatchList = new List<Batch>();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetAllBatch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Batch _batch = new Batch();
                        _batch.id = Convert.ToInt32(reader["Id"]);
                        _batch.name = Convert.ToString(reader["Name"]);
                        _batch.description = Convert.ToString(reader["Description"]);
                        _batch.gradeId = Convert.ToInt32(reader["GradeId"]);
                        _batch.gradeName = Convert.ToString(reader["GradeName"]);
                        _batch.isDelete = Convert.ToBoolean(reader["isDelete"]);
                        _batch.createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                        _batch.status = 200;
                        _batch.message = _batch.name + " (" + _batch.name + ")" + " Batch found.";
                        _batch.isError = false;
                        BatchList.Add(_batch);
                    }
                }
                con.Close();
            }
            return BatchList;
        }
        public static Response Create(Batch batch)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateBatch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", batch.name));
                cmd.Parameters.Add(new SqlParameter("@Description", batch.description));
                cmd.Parameters.Add(new SqlParameter("@GradeId", batch.gradeId));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                _response.status = 200;
                _response.message = "Batch Created Successfully";
                _response.isError = false;
            }
            return _response;
        }
        public static Response Update(Batch batch)
        {
            Response _response = new Response();
            string cs = ConnectionDAL.GetConnectionString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UpdateBatch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _response.status = 200;
                        _response.message = "Login successfully";
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
                SqlCommand cmd = new SqlCommand("DeleteBatch", con);
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
        public static void SyncBatchs(Batch Batch)
        {
        }
    }
}
