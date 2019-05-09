using DuckTracker.Models.CreateModels;
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
    public class PapaRepositoryADO : IPapaRepository
    {
        public int Create(CreatePapaDogModel papa)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreatePapaDog";
                cmd.Parameters.AddWithValue("@Name", papa.Name);
                cmd.Parameters.AddWithValue("@BirthDate", papa.BirthDate);
                cmd.Parameters.AddWithValue("@Breed", papa.Breed);

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                return System.Convert.ToInt32(cmd.Parameters["@Id"].Value);
            }
        }

        public PapaDogQuery GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPapaDogById";
                cmd.Parameters.AddWithValue("@PapaDogId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PapaDogQuery current = new PapaDogQuery();

                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.Name = dr["Name"].ToString();
                        current.Breed = dr["Breed"].ToString();
                        current.PuppyCount = string.IsNullOrEmpty(dr["PuppyCount"].ToString()) ? 0 : (int)dr["PuppyCount"];
                        current.LitterCount = string.IsNullOrEmpty(dr["LitterCount"].ToString()) ? 0 : (int)dr["LitterCount"];
                        current.BirthDate = (DateTime)dr["BirthDate"];

                        return current;
                    }
                }
            }
            return null;
        }

        public IEnumerable<PapaDogQuery> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<PapaDogQuery> papas = new List<PapaDogQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPapaDogs";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PapaDogQuery current = new PapaDogQuery();

                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.Name = dr["Name"].ToString();
                        current.Breed = dr["Breed"].ToString();
                        current.PuppyCount = string.IsNullOrEmpty(dr["PuppyCount"].ToString()) ? 0 : (int)dr["PuppyCount"];
                        current.LitterCount = string.IsNullOrEmpty(dr["LitterCount"].ToString()) ? 0 : (int)dr["LitterCount"];
                        current.BirthDate = (DateTime)dr["BirthDate"];

                        papas.Add(current);
                    }
                }
                return papas;
            }
        }

        public int Update(PapaDog papa)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePapaDog";
                cmd.Parameters.AddWithValue("@PapaDogId", papa.PapaDogId);
                cmd.Parameters.AddWithValue("@Name", papa.Name);
                cmd.Parameters.AddWithValue("@BirthDate", papa.BirthDate);
                cmd.Parameters.AddWithValue("@Breed", papa.Breed);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return papa.PapaDogId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePapaDog";
                cmd.Parameters.AddWithValue("@PapaDogId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}