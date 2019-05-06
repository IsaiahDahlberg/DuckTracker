using DuckTracker.Models.Query;
using DuckTracker.Models.Tables;
using DuckTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuckTracker.Repositories.ADO
{
    public class MamaRepositoryADO : IMamaRepository
    {
        public int Create(MamaDog mama)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateMamaDog";
                cmd.Parameters.AddWithValue("@Name", mama.Name);
                cmd.Parameters.AddWithValue("@BirthDate", mama.BirthDate);
                cmd.Parameters.AddWithValue("@Breed", mama.Breed);

                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@CategoryID"].Value;
            }
        }

        public MamaDogQuery GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMamaDogById";
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MamaDogQuery current = new MamaDogQuery();

                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.Name = dr["Name"].ToString();
                        current.Breed = dr["Breed"].ToString();
                        current.PuppyCount = (int)dr["PuppyCount"];
                        current.LitterCount = (int)dr["LitterCount"];

                        return current;
                    }
                }
            }
            return null;
        }

        public IEnumerable<MamaDogQuery> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<MamaDogQuery> mamas = new List<MamaDogQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllMamaDogs";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MamaDogQuery current = new MamaDogQuery();

                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.Name = dr["Name"].ToString();
                        current.Breed = dr["Breed"].ToString();
                        current.PuppyCount = (int)dr["PuppyCount"];
                        current.LitterCount = (int)dr["LitterCount"];

                        mamas.Add(current);
                    }
                }
                return mamas;
            }
        }

        public int Update (MamaDog mama)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateMamaDog";
                cmd.Parameters.AddWithValue("@Id", mama.MamaDogId);
                cmd.Parameters.AddWithValue("@Name", mama.Name);
                cmd.Parameters.AddWithValue("@BirthDate", mama.BirthDate);
                cmd.Parameters.AddWithValue("@Breed", mama.Breed);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return mama.MamaDogId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteMamaDog";
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}