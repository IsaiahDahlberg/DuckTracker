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
    public class LitterRepositoryADO : ILitterRepository
    {
        public int Create (Litter litter)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateLitter";
                cmd.Parameters.AddWithValue("@MamaDogId", litter.MamaDogId);
                cmd.Parameters.AddWithValue("@PapaDogId", litter.PapaDogId);
                cmd.Parameters.AddWithValue("@BirthDate", litter.BirthDate);
                cmd.Parameters.AddWithValue("@PuppyCount", litter.PuppyCount);

                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@Id"].Value;
            }
        }


        public IEnumerable<LitterQuery> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<LitterQuery> litters = new List<LitterQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllLitters";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterQuery current = new LitterQuery();

                        current.LitterId = (int)dr["LitterId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.MamaDogName = dr["MamaDogName"].ToString();
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.PapaDogName = dr["PapaDogName"].ToString();
                        current.BirthDate = (DateTime)dr["BirthDate"];
                        current.PuppyCount = (int)dr["PuppyCount"];

                        current.BirthDate.ToShortDateString();

                        litters.Add(current);
                    }
                }
                return litters;
            }
        }

        public LitterQuery GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {         
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLitterById";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterQuery current = new LitterQuery();

                        current.LitterId = (int)dr["LitterId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.MamaDogName = dr["MamaDogName"].ToString();
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.PapaDogName = dr["PapaDogName"].ToString();
                        current.BirthDate = (DateTime)dr["BirthDate"];
                        current.PuppyCount = (int)dr["PuppyCount"];

                        return current;
                    }
                }
            }
            return null;
        }


        public IEnumerable<LitterQuery> GetByMamaId(int mamaId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<LitterQuery> litters = new List<LitterQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLittersByMamaId";
                cmd.Parameters.AddWithValue("@MamaDogId", mamaId);
                
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterQuery current = new LitterQuery();

                        current.LitterId = (int)dr["LitterId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.MamaDogName = dr["MamaDogName"].ToString();
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.PapaDogName = dr["PapaDogName"].ToString();
                        current.BirthDate = (DateTime)dr["BirthDate"];
                        current.PuppyCount = (byte)dr["PuppyCount"];

                        litters.Add(current);
                    }
                }
                return litters;
            }
        }


        public IEnumerable<LitterQuery> GetByPapaId(int papaId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<LitterQuery> litters = new List<LitterQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLittersByPapaId";
                cmd.Parameters.AddWithValue("@PapaDogId", papaId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterQuery current = new LitterQuery();

                        current.LitterId = (int)dr["LitterId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.MamaDogName = dr["MamaDogName"].ToString();
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.PapaDogName = dr["PapaDogName"].ToString();
                        current.BirthDate = (DateTime)dr["BirthDate"];
                        current.PuppyCount = (int)dr["PuppyCount"];

                        litters.Add(current);
                    }
                }
                return litters;
            }
        }

        public int Update(Litter litter)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateLitter";
                cmd.Parameters.AddWithValue("@LitterId", litter.LitterId);
                cmd.Parameters.AddWithValue("@MamaDogId", litter.MamaDogId);
                cmd.Parameters.AddWithValue("@PapaDogId", litter.PapaDogId);
                cmd.Parameters.AddWithValue("@BirthDate", litter.BirthDate);
                cmd.Parameters.AddWithValue("@PuppyCount", litter.PuppyCount);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return litter.LitterId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteLitter";
                cmd.Parameters.AddWithValue("@LitterId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}