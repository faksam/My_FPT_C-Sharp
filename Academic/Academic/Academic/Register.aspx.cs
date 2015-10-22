using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
//using System.Configuration;


namespace Academic
{
    public partial class Register : System.Web.UI.Page
    {
        
      //  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
          // con.Open();


        }

        SqlConnection con = new SqlConnection("Data Source=FABULOUS;Initial Catalog=Login1;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Button1_Click(object sender, EventArgs e)
        {
            
           /* cmd = new SqlCommand("insert into user1 VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + DropDownList2.SelectedItem + "','" + TextBox8.Text + "','" + DropDownList3.SelectedItem + "');", con);

            SqlConnection conn = new SqlConnection(ConnectionString);
            

           // SqlCommand cmd = new SqlCommand("insert into user1 (FirstName, LastName, UserName, Password, DoB, Gender, PhoneNo, Location) "+
                  //      " VALUES (@FirstName, @LastName, @UserName, @Password, @DoB, @Gender, @PhoneNo, @Location)", conn);
                        

         /*   String fn = TextBox1.Text;
            String ln = TextBox2.Text;
            String un = TextBox3.Text;
            String pw = TextBox4.Text;
            String fpw = TextBox5.Text;
            String day = TextBox6.Text;
            String mp = TextBox8.Text;

           if (String.IsNullOrEmpty(rn) || String.IsNullOrEmpty(fn))
            {
                MessageBox.Show("your Boxs are Empty");
                return;
            }
            
            
             if (CheckBox1.Checked == true)
            {
            try
            { */

              //  SqlCommand cmd = new SqlCommand("insert into user1 VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + DropDownList2.SelectedItem + "','" + TextBox8.Text + "','" + DropDownList3.SelectedItem + "');", con);
                //SqlConnection sqlconn = new SqlConnection(connectionString);
               // sqlconn.Open();
                
              /*  string sqlInsert = "insert into Class values(@FirstName,@LastName,@UserName,@Password,@DoB,@Gender,@PhoneNo,@Location)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlconn);
            
               
                cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
                cmd.Parameters.AddWithValue("@UserName", TextBox3.Text);
              //  cmd.Parameters.AddWithValue("@emailAddress", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Password", TextBox4.Text);
                 cmd.Parameters.AddWithValue("@DoB", TextBox6.Text);
                cmd.Parameters.AddWithValue("@Gender", DropDownList2.SelectedItem);
                cmd.Parameters.AddWithValue("@PhoneNo", TextBox8.Text);
                cmd.Parameters.AddWithValue("@Location", DropDownList3.SelectedItem);



                conn.Open();
               
               cmd.ExecuteNonQuery();

               Label1.Text = "Information is Registered!";
               // conn.Close();



            */
                

                
             con.Open();
             cmd = new SqlCommand("insert into user1 VALUES(@FirstName,@LastName,@UserName,@Password,@DoB,@Gender,@PhoneNo,@Location)", con);

             cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
             cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
             cmd.Parameters.AddWithValue("@UserName", TextBox3.Text);
             //  cmd.Parameters.AddWithValue("@emailAddress", TextBox4.Text);
             cmd.Parameters.AddWithValue("@Password", TextBox4.Text);
             cmd.Parameters.AddWithValue("@DoB", TextBox6.Text);
             cmd.Parameters.AddWithValue("@Gender", DropDownList2.SelectedItem);
             cmd.Parameters.AddWithValue("@PhoneNo", TextBox8.Text);
             cmd.Parameters.AddWithValue("@Location", DropDownList3.SelectedItem);


            cmd.ExecuteNonQuery();
                Label1.Text = "Information is Registered!";
            con.Close();

           
          
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from user1 where UserName ='" + TextBox3.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label2.Text = "UserName is already Exist";
                this.Label2.ForeColor = Color.Red;
            }
            else
            {
                Label2.Text = "UserName is available";
            }
        }
    }
}