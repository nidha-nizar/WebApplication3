using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class EmployeeBAL
    {
        public int Insert(employeschema objschema)
        {
            try
            {
                EmployeeDAL objDAL = new EmployeeDAL();
                return objDAL.InsertData(objschema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  DataTable BindGrid()
        {
            try
            {
                EmployeeDAL objDAL = new EmployeeDAL();
                return objDAL.BindGrid();
            }
            catch(Exception ex)
            {
                throw ex;            }
        }
        
        public DataTable GetById(int id)
        {
            try
            {
                EmployeeDAL objDAL = new EmployeeDAL();
                return objDAL.GetById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int update(employeschema objschema,int id)
        {
            try
            {
                EmployeeDAL objDAL = new EmployeeDAL();
                return objDAL.UpdateData(objschema,id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int delete(int id)
        {
            try
            {
                EmployeeDAL objDAL = new EmployeeDAL();
                return objDAL.DeleteData(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
  }
}