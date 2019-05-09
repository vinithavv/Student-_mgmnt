STUDENT_REGISRATION.aspx.cs

Using System.Data.SqlClient;
Using System.data;
Public partial class_Default:System.Web.UI.page
{
SqlConnection con=new SqlConnection("server=.;uid=sa;pwd=admin123;database=studentdb");
SqlCommand cmd;
sqlDataReader rd;
String path;
Protected void Page_Load(Object Sender,EventArgs e)
{
	if(!ISPOSTBACK)
	{
		for(int i=15;i<30;i++)
		{
			DropDownList1.Items.Add(i.ToString());
		}
		DropDownList1.Items.Insert(0,"...Select...");
	}
}
Protected void Button1_Click(Object Sender,EventArgs e)
{
	for(int i=0;i<CheckBoxList1.Item.Count;i++)
	{
	    if(CheckBoxList1.Items[i].Selected)
	    {
		String check=checkBoxList1.Items[i].Tostring();
	    }
	}	 
	for(int i=0;i<RadioButtonList1.Item.Count;i++)
        {
	   if(RadioButtonList1.Items[i].Selected)
	    {
		String check=RadioButtonList1.Items[i].Tostring();
	    }
	}	  
	if(FileUpload1.HasFile)
	{
	 path="~/pic/"+FileUpload1.FileName;
	 FileUpload1.SaveAs(MapPath(path));
	}
	cmd=new SqlCommand("insert into student values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+DropDownList1.Text+"','"+checkBoxList1.Text+"','"+RadioButtonList1.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"','"+TextBox5.Text+"','"+path+"')",con);
	con.Open();
	cmd.ExecuteNonQuery();
	con.close();
}
Protected void Button2_Click(Object Sender,EventArgs e)
{
	Response.Redirect("~/student_reg.aspx");
	TextBox1.Text=session["id"].ToString();
	cmd=new SqlCommand("update student set name=('"+TextBox2.Text+"'),age=('"+DropDownList1.Text+"'),qualification=('"+checkBoxList1.Text+"'),gender=('"+RadioButtonList1.Text+"'),username=('"+TextBox3.Text+"'),pwd=('"+TextBox4.Text+"'),confirm_pwd=('"+TextBox5.Text+"'),pic=('"+path+"')where student_id=('"+TextBox1.Text+"')",con);
	con.Open();
	cmd.ExecuteNonQuery();
	con.close();
}
Protected void Button3_Click(Object Sender,EventArgs e)
{
	Response.Redirect("~/student_reg.aspx");
	TextBox1.Text=session["id"].ToString();
	cmd=new SqlCommand("select * from student where student_id='"+TextBox1.Text+"'",con);
	con.Open();
	rd=cmd.ExecuteReader();
	if(rd.HasRows)
	{
	  rd.read();
	  TextBox2.Text=rd["name"].ToString();
	  DropDownList1.Text=rd["age"].ToString();
	  checkBoxList1.Text=rd["qualification"].ToString();
	  RadioButtonList1.Text=rd["gender"].ToString();
	  TextBox2.Text=rd["username"].ToString();
	  TextBox2.Text=rd["pwd"].ToString();
	  TextBox2.Text=rd["confirmpwd"].ToString();
	}
	else
	{
		Response.Write("not found");
	}

	con.close();
	
}
}


