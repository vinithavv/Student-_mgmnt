Login.aspx.cs

Using System.Data.SqlClient;
Using System.data;

Public partial class_Default:System.Web.UI.page
{
 SqlConnection con=new SqlConnection("server=.;uid=sa;pwd=admin123;database=studentdb");
 SqlCommand cmd;
 sqlDataReader rd;
 Protected void Button1_Click(Object Sender,EventArgs e)
 {
   cmd=new SqlCommand("select username,pwd from student where username='"+TextBox1.Text+"',pwd='"+TextBox2.Text+"'",con);
   con.Open();
   rd=cmd.ExecuteReader();
   if(rd.HasRows)
   {
     session["id"]=TextBox1.Text;
     Response.Redirect("~/student_reg.aspx");
     con.close();
   }
   else
   {
    Response.Write("invalid username and password");
   }
 }
}