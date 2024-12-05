using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Webemploye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        public void InsertData()
        {
            employeschema objschema = new employeschema();
            objschema.Name = Textname.Text;
            objschema.Address = Textadd.Text;
            objschema.Age =Convert.ToInt32( Textage.Text);
            EmployeeBAL objbal = new EmployeeBAL();
            int result = objbal.Insert(objschema);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "SUBMIT")
            {

                InsertData();
                BindGrid();
                Textname.Text = "";
                Textage.Text = "";
                Textadd.Text = "";
            }
            else
            {

                UpdateData();
                BindGrid();
                Textname.Text = "";
                Textadd.Text = "";
                Textage.Text = "";
                Button1.Text = "SUBMIT";

            }
        }
        public void UpdateData()
        {
            employeschema objschema = new employeschema();
            objschema.Name = Textname.Text;
            objschema.Address = Textadd.Text;
            objschema.Age =Convert.ToInt32( Textage.Text);
            EmployeeBAL objbal = new EmployeeBAL();
            int id = Convert.ToInt32(TextBox1.Text);
            int result = objbal.update(objschema,id);

        }
        private void BindGrid()
        {
            try
            {
                EmployeeBAL objBal = new EmployeeBAL();
                GridView1.DataSource = objBal.BindGrid();
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
                EmployeeBAL objBAL = new EmployeeBAL();
                DataTable dt = new DataTable();
                dt = objBAL.GetById(id);
                if (dt.Rows.Count > 0)
                {
                    Textname.Text = dt.Rows[0][1].ToString();
                    Textadd.Text = dt.Rows[0][2].ToString();
                    Textage.Text = dt.Rows[0][3].ToString();
                    TextBox1.Text = dt.Rows[0][0].ToString();
                    Button1.Text = "update";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
                EmployeeBAL objBAL = new EmployeeBAL();
             
                int result = objBAL.delete( id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            BindGrid();
        }
    }
}