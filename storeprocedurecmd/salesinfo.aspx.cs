using DBL;
using storeprocedurecmd.layer.BAL;
using storeprocedurecmd.layer.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace storeprocedurecmd
{
    public partial class salesinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void display()
        {
             Bal obbl=new Bal();
            GridView1.DataSource = obbl.dispall("pro_sales");
            GridView1.DataBind();
        }
        void clear()
        {
            txtid.Text= string.Empty;
            productname.Text= string.Empty;
            unit.Text= string.Empty;
            cost.Text= string.Empty;
        }
        protected void btninsert_Click(object sender, EventArgs e)
        {
            Bal obbl=new Bal();
             salesProperty saleob=new salesProperty();
            saleob.product_name = productname.Text;
            saleob.unit = int.Parse(unit.Text);
             saleob.cost=int.Parse(cost.Text);
            obbl.insert_sales("pro_sales", saleob);
            Response.Write("data has been stored");
             display();
            clear();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Bal obbl = new Bal();
            salesProperty saleob = new salesProperty();
             saleob.s_id=int.Parse(txtid.Text);
            saleob.unit = int.Parse(unit.Text);
            saleob.cost = int.Parse(cost.Text);
            obbl.update_sales("pro_sales", saleob);
            Response.Write("data has been updated");
            display();
            clear();

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            #region  bal info
            // Bal obbl = new Bal();
            // salesProperty saleob = new salesProperty();
            //int id = int.Parse(txtid.Text);
            // obbl.delete_sales("pro_sales",id);
            // Response.Write("data has been deleted");
            // display();
            #endregion
            foreach (GridViewRow rr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)rr.FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                  //  GridViewRow row = GridView1.Rows[e.RowIndex];
                    Bal obbl = new Bal();
                    Label ob = (Label)rr.FindControl("Label1");
                    int sid = int.Parse(ob.Text);
                   int h=  obbl.delete_sales("pro_sales", sid);
                    Response.Write("data has been deleted"+h);
                    display();

                }
                else
                {
                    chk.Checked = false;
                }
            }
        }

        protected void btndispall_Click(object sender, EventArgs e)
        {
            Bal obbl = new Bal();
           
            GridView1.DataSource = obbl.dispall("pro_sales") ;
            GridView1.DataBind();
            Response.Write("data displayed");
            RadioButton1.Checked = false;
            RadioButton2.Checked=false;
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Bal obbl = new Bal();
            salesProperty saleob = new salesProperty();
            int id = int.Parse(txtid.Text);
             DataTable dt= obbl.search("pro_sales", id);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Write("data find");
            clear();
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
              foreach(GridViewRow rr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)rr.FindControl("CheckBox1");
                 if(CheckBox2.Checked==true)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


           // delete without check box selecting

             GridViewRow row = GridView1.Rows[e.RowIndex];
            Bal obbl = new Bal();
            salesProperty saleob = new salesProperty();
            // int id = int.Parse(txtid.Text);
            Label ob = (Label)row.FindControl("Label1");
            int sid = int.Parse(ob.Text);
            obbl.delete_sales("pro_sales", sid);
            Response.Write("data has been deleted");
            display();

           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rr = GridView1.SelectedRow;
            Label lid = (Label)rr.FindControl("Label1");
            Label lpname = (Label)rr.FindControl("Label2");
            Label lunit = (Label)rr.FindControl("Label3");
            Label lcost = (Label)rr.FindControl("Label4");

             txtid.Text = lid.Text;
             productname.Text = lpname.Text;
            unit.Text = lunit.Text;
            cost.Text = lcost.Text;
          
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            display();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            display();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow rr = GridView1.Rows[e.RowIndex];
            TextBox tid = (TextBox)rr.FindControl("TextBox1");
          //   TextBox tpname = (TextBox)rr.FindControl("TextBox2");
            TextBox tunit = (TextBox)rr.FindControl("TextBox3");
            TextBox tcost = (TextBox)rr.FindControl("TextBox4");
              Bal ob=new Bal();
            salesProperty sl = new salesProperty();
              sl.s_id=int.Parse(tid.Text);
              sl.unit=int.Parse(tunit.Text);
              sl.cost=int.Parse(tcost.Text);
            ob.update_sales("pro_sales",sl);
            GridView1.EditIndex = -1;
            display();
            Response.Write("data updated");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
             
            SqlConnection con = new SqlConnection(Gcon_.gcon);
            string query = "select * from sales order by product_name asc";
            SqlDataAdapter adt = new SqlDataAdapter(query, con);
             DataTable dt=new DataTable(); 
             adt.Fill(dt);
             GridView1.DataSource= dt;
             GridView1.DataBind();
            //display();
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Gcon_.gcon);
            string query = "select * from sales order by product_name desc";
            SqlDataAdapter adt = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
           // display();
        }
    }
}