using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class SamplePage : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Clicked at " + DateTime.Now.ToString();
    }

     [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
}