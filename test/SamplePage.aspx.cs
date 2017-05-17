using System;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Text;
public partial class SamplePage : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Clicked at " + DateTime.Now.ToString();
    }

     [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            var client = new HttpClient();
string url="https://jsonplaceholder.typicode.com"; //jsonObject.ToString()
       var content = new StringContent("title=foo&body=bar&userId=1",
        Encoding.UTF8, "application/json");
var result = client.PostAsync(url, content).Result;
return result.Content.ToString();
//  return "Hello " + name + Environment.NewLine + "The Current Time is: "                + DateTime.Now.ToString();
        }
}