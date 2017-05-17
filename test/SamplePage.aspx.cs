using System;
using System.Web;
using System.Web.UI;
using System.Web.Http;
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

string url="https://jsonplaceholder.typicode.com"; //jsonObject.ToString()
            var content = new StringContent("title=foo&body=bar&userId=1", Encoding.UTF8, "application/json");
var result = client.PostAsync(url, content).Result;
return result.toString();
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "                + DateTime.Now.ToString();
        }
}