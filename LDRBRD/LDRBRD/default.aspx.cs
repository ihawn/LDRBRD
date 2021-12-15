using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Configuration;

namespace LDRBRD
{
    public partial class _default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["azuredb"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();       
            UpdateData();
        }

        protected void NewEntry(object sender, EventArgs e)
        {
            ExecuteQuery("INSERT INTO table1 VALUES('" + username.Text + "', '"+ score.Text +"')");
            ClearTextFields();
            UpdateData();
        }

        protected void DeleteEntry(object sender, EventArgs e)
        {
            ExecuteQuery("DELETE FROM table1 WHERE username='" + username.Text + "'");
            ClearTextFields();
            UpdateData();
        }

        protected void UpdateEntry(object sender, EventArgs e)
        {
            ExecuteQuery("UPDATE table1 SET SCORE='" + score.Text + "' WHERE id=" + Convert.ToInt32(userupdateid.Text));
            ClearTextFields();
            UpdateData();
        }

        protected void ClearTextFields()
        {
            username.Text = "";
            score.Text = "";
        }

        protected void UpdateData()
        {
            SqlCommand cmd = ExecuteQuery("SELECT *, ROW_NUMBER() OVER( ORDER BY score desc) AS place FROM table1");

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        protected SqlCommand ExecuteQuery(String query)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            return cmd;
        }
    }
}