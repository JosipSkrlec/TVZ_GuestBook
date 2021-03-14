using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;


public class SQLManipulator : MonoBehaviour
{
    private string conn;
    private string sqlQuery;

    IDbConnection dbconn;
    IDbCommand dbcmd;

    public static List<Note> ListOfNotes;

    private void Awake()
    {
        ListOfNotes = new List<Note>();

        // put do baze podataka
        conn = "URI=file:" + Application.dataPath + "/SQL/Users.s3db";

        // tests
        //InsertNote("Ivan", "3-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2, 3);
        //InsertNote("Ante", "4-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1, 4);
        //InsertNote("Ivan", "3-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2, 3);
        //InsertNote("Dalibor", "5-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3, 2);
        //InsertNote("Matija", "6-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2, 1);
        //InsertNote("Ivana", "7-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2, 1);
        //InsertNote("Sanja", "8-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 4, 3);
        //InsertNote("Marija", "9-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 2, 1);
        //InsertNote("Sonja", "10-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 1, 2);
        //InsertNote("Davorka", "11-Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 3, 3);

        SaveNotesToList();

    }


    public void InsertNote(string username, string content, int pinID, int fontID)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into Notes (Username, Content, PinID, FontID) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", username, content, pinID, fontID);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();

        }
    }
    public void DeleteNote(int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Delete from Notes WHERE ID=\"{0}\"", id);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    public void SaveNotesToList()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM Notes";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string username = reader.GetString(1);
                string content = reader.GetString(2);
                int pinID = reader.GetInt32(3);
                int fontID = reader.GetInt32(4);

                Note note = new Note(id, username, content, pinID, fontID);
                ListOfNotes.Add(note);

                //string.Format("insert into Notes (Username, Content, PinID, FontID) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", username, content, pinID, fontID);                
                //Debug.Log("value= " + id + "  username =" + username + "  content =" + content + "   pinID =" + pinID + "   fontID =" + fontID);
            }

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;

        }
    }

    // HELPERS
    public List<Note> GetNotes()
    {
        return ListOfNotes;
    }
    



    //private void Updatevalue(string name, string email, string address, int id)
    //{
    //    using (dbconn = new SqliteConnection(conn))
    //    {

    //        dbconn.Open(); //Open connection to the database.
    //        dbcmd = dbconn.CreateCommand();
    //        sqlQuery = string.Format("UPDATE Usersinfo set Name=\"{0}\", Email=\"{1}\", Address=\"{2}\" WHERE ID=\"{3}\" ", name, email, address, id);// table name
    //        dbcmd.CommandText = sqlQuery;
    //        dbcmd.ExecuteScalar();
    //        dbconn.Close();
    //    }
    //}
}
