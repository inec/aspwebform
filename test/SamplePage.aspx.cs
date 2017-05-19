using System;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Net;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;


public partial class SamplePage : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Clicked at " + DateTime.Now.ToString();
    }

[System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {

              String jstr="{\"Id\":\"123\",\"DateOfRegistration\":\"2012-10-21T00:00:00+05:30\",\"Status\":0}";
            
            /*var client = new HttpClient();
            string url="https://jsonplaceholder.typicode.com/posts"; 
              var content = new StringContent(jstr,        Encoding.UTF8, "application/json");
                var result =client.PostAsync(url, content).Result;
            return result.ToString();*/
          return SimplePostRequest(name);
}

public static string SimplePostRequest(string jstr)
{
    string str;
    string postData = "title=L34";
    postData = postData + "&body=bar";
    postData = postData + "&userId=L36&L38Name="+jstr;
  // postData=jstr; 
    var data = Encoding.UTF8.GetBytes(postData);

    var myRequest = WebRequest.CreateHttp("http://jsonplaceholder.typicode.com/posts");
    myRequest.Method = "POST";
    myRequest.ContentType = "application/x-www-form-urlencoded";
    myRequest.ContentLength = data.Length;
    myRequest.UserAgent = "WebRequestDemo";

    //we need to write our post data to the request stream
    using (var stream = myRequest.GetRequestStream())
    {
        stream.Write(data, 0, data.Length);
        stream.Close();
    }

    using (var theResponse = myRequest.GetResponse())
    {
        var dataStream = theResponse.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        object objResponse = reader.ReadToEnd();
        str=objResponse.ToString();
        //var myUser = JsonConvert.DeserializeObject<User>(objResponse.ToString());
        dataStream.Close();
        theResponse.Close();
    }
return str;
}

}