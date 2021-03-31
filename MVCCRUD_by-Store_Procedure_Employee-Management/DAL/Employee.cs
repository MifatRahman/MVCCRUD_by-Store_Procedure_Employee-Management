using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCCRUD_by_Store_Procedure_Employee_Management.DAL
{
    public class Employee
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        public int AddEmployee(Models.Employee e1) 
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_Addemp",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno",e1.Eno);
            cmd.Parameters.AddWithValue("@ename",e1.Ename);
            cmd.Parameters.AddWithValue("@sal",e1.Salary);
            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public int DeleteEmployee(Models.Employee e1) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_Deleteemp",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno",e1.Eno);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int UpdateEmployee(Models.Employee e1) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_Updateemp",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno",e1.Eno);
            cmd.Parameters.AddWithValue("@ename",e1.Ename);
            cmd.Parameters.AddWithValue("@sal",e1.Salary);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Models.Employee> GetEmployee() 
        {
            List<Models.Employee> li = new List<Models.Employee>();
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_getemp",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                while (dr.Read()) 
                {
                    Models.Employee e1 = new Models.Employee();
                    e1.Eno = int.Parse(dr[0].ToString());
                    e1.Ename = dr[1].ToString();
                    e1.Salary = double.Parse(dr[2].ToString());
                    li.Add(e1);
                }

            }
            return li;
        }
        public Models.Employee SearchEmp(Models.Employee e1) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_searchemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno", e1.Eno);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                if (dr.Read()) 
                {
                    e1.Ename =dr[0].ToString();
                    e1.Salary = double.Parse(dr[1].ToString());
                }
            }
            con.Close();
            return e1;
        }
    }
}