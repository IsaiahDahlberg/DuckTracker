using DuckTracker.Models.CreateModels;
using DuckTracker.Models.Query;
using DuckTracker.Models.Tables;
using DuckTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DuckTracker.Repositories.ADO
{
    public class MamaRepositoryADO : IMamaRepository
    {
        public int Create(CreateMamaDogModel mama)
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

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                return System.Convert.ToInt32(cmd.Parameters["@Id"].Value);
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
                cmd.Parameters.AddWithValue("@MamaDogId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MamaDogQuery current = new MamaDogQuery();

                        current.MamaDogId = (int)dr["MamaDogId"];
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
                        current.PuppyCount = string.IsNullOrEmpty(dr["PuppyCount"].ToString()) ? 0: (int)dr["PuppyCount"];
                        current.LitterCount = string.IsNullOrEmpty(dr["LitterCount"].ToString()) ? 0: (int)dr["LitterCount"];
                        current.BirthDate = (DateTime)dr["BirthDate"];

                        current.BirthDate.ToShortDateString();

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
                cmd.Parameters.AddWithValue("@MamaDogId", mama.MamaDogId);
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
                cmd.Parameters.AddWithValue("@MamaDogId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateHeatPrediction(CreateHeatModel prediction)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateHeatPrediction";
                cmd.Parameters.AddWithValue("@MamaDogId", prediction.MamaDogId);
                cmd.Parameters.AddWithValue("@Date", prediction.Date);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public HeatPrediction GetHeatPredictionByMamaDogId(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<MamaDogQuery> mamas = new List<MamaDogQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetHeatPredictionByMamaDogId";
                cmd.Parameters.AddWithValue("@MamaDogId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        HeatPrediction current = new HeatPrediction();

                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.HeatPredictionId = (int)dr["HeatPredictionId"];
                        current.Date = (DateTime)dr["Date"];

                        return current;
                    }
                }
                return null;
            }
        }

        public IEnumerable<UpComingInHeatQuery> GetUpComingHeatPredictions()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<UpComingInHeatQuery> list = new List<UpComingInHeatQuery>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUpComingHeatPredictions";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UpComingInHeatQuery current = new UpComingInHeatQuery();

                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.MamaName= dr["MamaName"].ToString();
                        current.Date = (DateTime)dr["Date"];

                        list.Add(current);
                    }
                }
                return list;
            }
        }
    }
}