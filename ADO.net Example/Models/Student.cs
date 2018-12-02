using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ADO.net_Example.Models
{
    public class Student
    {
        string connectionString = @"Data Source=LAPTOP-CILN0DIS;Initial Catalog=Test;Integrated Security=True";        

        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Student", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int InsertStudent(string StudentName, string Gender, int Age)
        {            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Insert into Student (Student_Name, Student_Age, Student_Gender) values(@studname, @studage , @gender)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", StudentName);
                cmd.Parameters.AddWithValue("@studage", Age);
                cmd.Parameters.AddWithValue("@gender", Gender);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteStudent(int StudentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();                
                SqlCommand cmd = new SqlCommand("Delete from Student where Student_ID=@studid", con);
                cmd.Parameters.AddWithValue("@studid", StudentID);
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetStudentByID(int StudentID)
        {
            DataTable dt = new DataTable();            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Student where Student_ID=@studid", con);
                cmd.Parameters.AddWithValue("@studid", StudentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int UpdateStudent(int StudentID, string StudentName, string Gender, int Age)
        {            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Student SET Student_Name=@studname, Student_Age=@studage , Student_Gender=@gender where Student_ID=@studid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", StudentName);
                cmd.Parameters.AddWithValue("@studage", Age);
                cmd.Parameters.AddWithValue("@gender", Gender);
                cmd.Parameters.AddWithValue("@studid", StudentID);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}