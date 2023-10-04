using DBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace storeprocedurecmd.layer.DAL
{
    public class Dal
    {
        SqlConnection con = new SqlConnection(Gcon_.gcon);
        SqlCommand cmd ;
        SqlDataAdapter adapter ;
        DataTable dt =new DataTable();


        public int insert_sales(string s_p,salesProperty entity)
        {
            int status = 0;
            try
            {
                if(con.State== System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd=con.CreateCommand();// connection asign to command 
                 cmd.CommandText=s_p;
                 cmd.Parameters.AddWithValue("@product_name",entity.product_name);
                cmd.Parameters.AddWithValue("@unit",entity.unit);
                cmd.Parameters.AddWithValue("@cost",entity.cost);
                cmd.Parameters.AddWithValue("@action","insert");
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                adapter=new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                status = 1;
            }
            catch (SqlException ex)
            {
                status = 0;
                throw ex;
            }
            catch(Exception ee) 
            { 
            status = 0;
            throw ee;
            }
             finally
            {
                dt.Reset();
                con.Dispose();
                cmd.Dispose();
                adapter.Dispose();
            }
            return status;
        }

        public int update_sales(string s_p, salesProperty entity)
        {
            int status = 0;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = con.CreateCommand();// connection asign to command 
                cmd.CommandText = s_p;
                // cmd.Parameters.AddWithValue(" @product_name", entity.product_name);
                cmd.Parameters.AddWithValue("@id", entity.s_id);
                cmd.Parameters.AddWithValue("@unit", entity.unit);
                cmd.Parameters.AddWithValue("@cost", entity.cost);
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                status = 1;
            }
            catch (SqlException ex)
            {
                status = 0;
                throw ex;
            }
            catch (Exception ee)
            {
                status = 0;
                throw ee;
            }
            finally
            {
                dt.Reset();
                con.Dispose();
                cmd.Dispose();
                adapter.Dispose();
            }
            return status;
        }

        public int delete_sales(string s_p, int id)
        {
            int status = 0;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = con.CreateCommand();// connection asign to command 
                cmd.CommandText = s_p;
                cmd.Parameters.AddWithValue("@id",id );
               
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                status = 1;
            }
            catch (SqlException ex)
            {
                status = 0;
                throw ex;
            }
            catch (Exception ee)
            {
                status = 0;
                throw ee;
            }
            finally
            {
                dt.Reset();
                con.Dispose();
                cmd.Dispose();
                adapter.Dispose();
            }
            return status;
        }

        public DataTable dispall(string s_p)
        {
           // int status = 0;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = con.CreateCommand();// connection asign to command 
                cmd.CommandText = s_p;
                cmd.Parameters.AddWithValue("@action", "all");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
               // status = 1;
            }
            catch (SqlException ex)
            {
               // status = 0;
                throw ex;
            }
            catch (Exception ee)
            {
               // status = 0;
                throw ee;
            }
            finally
            {
               // dt.Reset();
                con.Dispose();
                cmd.Dispose();
                adapter.Dispose();
            }
            return dt;
         }

        public DataTable search_sales(string s_p,int id)
        {
            //int status = 0;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = con.CreateCommand();// connection asign to command 
                cmd.CommandText = s_p;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
               // status = 1;
            }
            catch (SqlException ex)
            {
               // status = 0;
                throw ex;
            }
            catch (Exception ee)
            {
               // status = 0;
                throw ee;
            }
            finally
            {
               // dt.Reset();
                con.Dispose();
                cmd.Dispose();
                adapter.Dispose();
            }
            return dt;
        }
    }
}