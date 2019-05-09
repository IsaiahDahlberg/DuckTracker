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
    public class LitterNoteRepository : ILitterNoteRepository
    {

        public int Create(LitterNote note)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateLitterNote";
                cmd.Parameters.AddWithValue("@Note", note.Note);
                cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);
                cmd.Parameters.AddWithValue("@LitterId", note.LitterId);

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteScalar();
                return System.Convert.ToInt32(cmd.Parameters["@Id"].Value);
            }
        }

        public IEnumerable<LitterNote> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<LitterNote> notes = new List<LitterNote>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllLitterNotes";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterNote current = new LitterNote();

                        current.LitterNoteId = (int)dr["LitterNoteId"];
                        current.LitterId = (int)dr["LitterId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        notes.Add(current);
                    }
                }
                return notes;
            }
        }

        public LitterNote GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLitterNoteById";
                cmd.Parameters.AddWithValue("@LitterNoteId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterNote current = new LitterNote();

                        current.LitterNoteId = (int)dr["LitterNoteId"];
                        current.LitterId = (int)dr["LitterId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        return current;
                    }
                }
            }
            return null;
        }

        public IEnumerable<LitterNote> GetByLitterId(int litterId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                List<LitterNote> notes = new List<LitterNote>();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLitterNotesByLitterId";

                cmd.Parameters.AddWithValue("@LitterId", litterId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LitterNote current = new LitterNote();

                        current.LitterNoteId = (int)dr["LitterNoteId"];
                        current.LitterId = (int)dr["LitterId"];
                        current.Note = dr["Note"].ToString();
                        current.NoteTitle = dr["NoteTitle"].ToString();
                        current.DateCreated = (DateTime)dr["DateCreated"];

                        notes.Add(current);
                    }
                }
                return notes;
            }
        }

        public int Update(LitterNote note)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateLitterNote";
                cmd.Parameters.AddWithValue("@LitterNoteId", note.LitterNoteId);
                cmd.Parameters.AddWithValue("@Note", note.Note);
                cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return note.LitterNoteId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteLitterNote";
                cmd.Parameters.AddWithValue("@LitterNoteId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}