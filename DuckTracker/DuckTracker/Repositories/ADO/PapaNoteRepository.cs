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
    public class PapaNoteRepositoryADO : IPapaNoteRepository
    {
        public int Create(PapaDogNote note)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreatePapaDogNote";
                cmd.Parameters.AddWithValue("@Note", note.Note);
                cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);
                cmd.Parameters.AddWithValue("@PapaDogId", note.PapaDogId);

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteScalar();
                return System.Convert.ToInt32(cmd.Parameters["@Id"].Value);
            }
        }

        public IEnumerable<PapaDogNote> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<PapaDogNote> notes = new List<PapaDogNote>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPapaDogNotes";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PapaDogNote current = new PapaDogNote();

                        current.PapaDogNoteId = (int)dr["PapaDogNoteId"];
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        notes.Add(current);
                    }
                }
                return notes;
            }
        }

        public PapaDogNote GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPapaDogNoteById";
                cmd.Parameters.AddWithValue("@PapaDogNoteId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PapaDogNote current = new PapaDogNote();

                        current.PapaDogNoteId = (int)dr["PapaDogNoteId"];
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        return current;
                    }
                }
            }
            return null;
        }

        public IEnumerable<PapaDogNote> GetByPapaDogId(int papaId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<PapaDogNote> notes = new List<PapaDogNote>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPapaDogNotesByPapaId";

                cmd.Parameters.AddWithValue("@PapaDogId", papaId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PapaDogNote current = new PapaDogNote();

                        current.PapaDogNoteId = (int)dr["PapaDogNoteId"];
                        current.PapaDogId = (int)dr["PapaDogId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        notes.Add(current);
                    }
                }
                return notes;
            }
        }

        public int Update(PapaDogNote note)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePapaDogNote";
                cmd.Parameters.AddWithValue("@PapaDogNoteId", note.PapaDogNoteId);
                cmd.Parameters.AddWithValue("@Note", note.Note);
                cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return note.PapaDogNoteId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePapaDogNote";
                cmd.Parameters.AddWithValue("@PapaDogNoteId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}