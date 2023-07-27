using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Home : System.Web.UI.Page
{


    MySqlConnection con = new MySqlConnection("Data Source=localhost;Database=sys;User ID=root;Password=12345678");
    protected void Page_Load(object sender, EventArgs e)
    {
        btnupdate.Style.Add("display", "none");
        SetData();
    }
    public void SetData()
    {
        TextBox textBoxBookId = DetailControl.FindControl("txtBookId") as TextBox;
        string myTextBoxBookId = textBoxBookId.Text;

        TextBox textBoxBookname = DetailControl.FindControl("txtBookname") as TextBox;
        string myTextBoxBookname = textBoxBookname.Text;

        TextBox textBoxAuthorName = DetailControl.FindControl("txtAuthorname") as TextBox;
        string myTextBoxAuthorName = textBoxAuthorName.Text;

        TextBox textBoxQuantity = DetailControl.FindControl("txtQuantity") as TextBox;
        string myTextBoxQuantity = textBoxQuantity.Text;

        if (myTextBoxBookId != "")
        {
            txtBookId.Text = myTextBoxBookId;
            txtBookname.Text = myTextBoxBookname;
            txtAuthorname.Text = myTextBoxAuthorName;
            txtQuantity.Text = myTextBoxQuantity;
            btnadd.Style.Add("display", "none");
            btnupdate.Style.Add("display", "block");
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            string str = "insert into Books values(" + txtBookId.Text + ",'" + txtBookname.Text + "','" + txtAuthorname.Text + "','" + txtQuantity.Text + "')";
            MySqlCommand cmd = new MySqlCommand(str);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            lblmsg.Text = "Record Inserted Successfully";
            con.Close();
            DetailControl.display();
        }
        catch( Exception ex)
        {
            throw ex;
        }
        cleartxt();
    }

    protected void lnkselect_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["id"] = btn.CommandArgument;
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select * from Books", con);
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

        btnadd.Style.Add("display", "none");
        btnupdate.Style.Add("display", "block");
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
        string str = "update Books set BookId=" + txtBookId.Text + ", BookName='" + txtBookname.Text + "' , AuthorName='" + txtAuthorname.Text + "', Quantity=" + txtQuantity.Text + " where BookId='" + Session["id"] + "'";
        MySqlCommand cmd = new MySqlCommand(str);
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        lblmsg.Text = "Record Updated Successfully";
        con.Close();
        cleartxt();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        DetailControl.display();
    }

    public void cleartxt()
    {
        txtBookId.Text = "";
        txtBookname.Text = "";
        txtAuthorname.Text = "";
        txtQuantity.Text = "";
        btnupdate.Style.Add("display", "none");
        btnadd.Style.Add("display", "block");
        Session["id"] = 0;
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartxt();
    }

}