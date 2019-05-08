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
    public class MamaNoteRepositoryADO : IMamaNoteRepository
    {
        public int Create(MamaDogNote note)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateMamaDogNote";
                cmd.Parameters.AddWithValue("@Note", note.Note);
                cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);
                cmd.Parameters.AddWithValue("@MamaDogId", note.MamaDogId);

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));           
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;
           
                conn.Open();
                cmd.ExecuteScalar();
                return System.Convert.ToInt32(cmd.Parameters["@Id"].Value);
            }
        }

        public IEnumerable<MamaDogNote> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<MamaDogNote> notes = new List<MamaDogNote>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllMamaDogNotes"; 

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MamaDogNote current = new MamaDogNote();

                        current.MamaDogNoteId = (int)dr["MamaDogNoteId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];
                        
                        notes.Add(current);
                    }
                }
                return notes;
            }
        }

        public MamaDogNote GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMamaDogNoteById";
                cmd.Parameters.AddWithValue("@MamaDogNoteId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MamaDogNote current = new MamaDogNote();

                        current.MamaDogNoteId = (int)dr["MamaDogNoteId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        return current;
                    }
                }              
            }
            return null;
        }

        public IEnumerable<MamaDogNote> GetByMamaDogId(int mamaId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<MamaDogNote> notes = new List<MamaDogNote>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMamaDogNotesByMamaId";

                cmd.Parameters.AddWithValue("@MamaDogId", mamaId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MamaDogNote current = new MamaDogNote();

                        current.MamaDogNoteId = (int)dr["MamaDogNoteId"];
                        current.MamaDogId = (int)dr["MamaDogId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        notes.Add(current);
                    }
                }
                return notes;
            }
        }

        public int Update(MamaDogNote note)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateMamaDogNote";
                cmd.Parameters.AddWithValue("@MamaDogNoteId", note.MamaDogNoteId);
                cmd.Parameters.AddWithValue("@Note", note.Note);
                cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return note.MamaDogNoteId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteMamaDogNote";
                cmd.Parameters.AddWithValue("@MamaDogNoteId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}