using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class DetailControl : System.Web.UI.UserControl
{
    MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=sys;User ID=root;Password=12345678");

    public Int32 BookId = 0;
    public string Bookname = "";
    public string Authorname = "";
    public Int32 Quantity = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        display();
    }
   
    public void display()
    {
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select * from Books");
        DataTable dt = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        cmd.Connection = con;
        adp.SelectCommand = cmd;
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();
    }

  

    protected void lnkuserselect_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["id"] = btn.CommandArgument;
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select * from Books where BookId='" + Session["id"] + "'", con);
        DataTable dt = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
        cmd.Connection = con;
        adp.SelectCommand = cmd;
        adp.Fill(dt);
        if (dt.Rows.Count >= 0)
        {
            txtBookId.Text = dt.Rows[0]["BookId"].ToString();
            txtBookname.Text = dt.Rows[0]["BookName"].ToString();
            txtAuthorname.Text = dt.Rows[0]["AuthorName"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
        }
        con.Close();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        display();
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["id"] = btn.CommandArgument;
        con.Open();
        MySqlCommand cmd = new MySqlCommand("delete from Books where BookId='" + Session["id"] + "'");
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        lblmsg.Text = "Record Deleted";
        con.Close();
        display();
    }




}