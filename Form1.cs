using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Csharp_quanlithongtin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAB1-MAY26\MISASME2022;Initial Catalog=QuanLyThongTin;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        private void openCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            openCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
                throw;
            }
            CloseCon();
            return check;
        }
        private DataTable Red(string cmd)
        {
            openCon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            CloseCon();
            return dt;
        }
        private void load()
        {
            DataTable dt = Red("SELECT * FROM quanlythongtin");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}