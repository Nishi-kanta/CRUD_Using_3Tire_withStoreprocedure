using DBL;
using storeprocedurecmd.layer.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace storeprocedurecmd.layer.BAL
{
    public class Bal
    {

        public int insert_sales(string s_p,salesProperty entity)
        {
            int s = 0;
            try
            {
                Dal obdl = new Dal();
                 obdl.insert_sales(s_p,entity);
            }
            catch(Exception ex)
            {
                s = 0;
                throw ex;

            }
            return s;
        }
        public int update_sales(string s_p, salesProperty entity)
        {
            int s = 0;
            try
            {
                Dal obdl = new Dal();
                obdl.update_sales(s_p, entity);
            }
            catch (Exception ex)
            {
                s = 0;
                throw ex;

            }
            return s;
        }
        public int delete_sales(string s_p,int id)
        {
            int s = 0;
            try
            {
                Dal obdl = new Dal();
             s=obdl.delete_sales(s_p,id);
            }
            catch (Exception ex)
            {
                s = 0;
                throw ex;

            }
            return s;
        }
        public DataTable dispall(string s_p)
        {
           // int s = 0;
            try
            {
                Dal obdl = new Dal();
             return   obdl.dispall(s_p);

            }
            catch (Exception ex)
            {
               // s = 0;
                throw ex;

            }
           // return s;
        }
        public DataTable search(string s_p, int id)
        {
           // int s = 0;
            try
            {
                Dal obdl = new Dal();
                DataTable dt= obdl.search_sales(s_p, id);
                return dt;
            }
            catch (Exception ex)
            {
              //  s = 0;
                throw ex;

            }
          //  return s;
        }
    }
}