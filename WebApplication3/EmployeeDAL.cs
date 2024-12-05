using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebApplication3
{
    public class EmployeeDAL
    {
        SqlConnection con=new SqlConnection("Data Source=NIDHA\\SQLEXPRESS;Initial Catalog=modeltier;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        public int InsertData(employeschema objschema)
        {
            try
            {
                using(cmd=new SqlCommand("reg_store",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", objschema.Name);
                    cmd.Parameters.AddWithValue("@para", "ADD");
                    cmd.Parameters.AddWithValue("@address", objschema.Address);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(objschema.Age));
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            

        }
        public DataTable BindGrid()
        {
            using(cmd=new SqlCommand("reg_store",con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@para", "Get_For_Grid");
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
        }
        public DataTable GetById(int id)
        {
            using (cmd = new SqlCommand("reg_store", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@para", "get_by_id");
                    cmd.Parameters.AddWithValue("@id", id);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;


                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        public int UpdateData(employeschema objSchema,int id)
        {
            try
            {
                using(cmd=new SqlCommand("reg_store",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@para", "update");
                    cmd.Parameters.AddWithValue("@name", objSchema.Name);
                    cmd.Parameters.AddWithValue("@address", objSchema.Address);
                    cmd.Parameters.AddWithValue("@age",Convert.ToInt32( objSchema.Age));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteData(int id)
        {
            try
            {
                using (cmd = new SqlCommand("reg_store", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@para", "DELETE");
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}