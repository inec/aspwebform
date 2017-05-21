using System;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Net;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Web;
using System.Web.Script;
using System.Web.Script.Serialization;

public partial class SamplePage : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Clicked at " + DateTime.Now.ToString();
    }

[System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
          return SimplePostRequest(name);
}

public static string SimplePostRequest(string jstr)
{
    string str;
    string postData = "title=L34";
    postData = postData + "&body=bar";
    postData = postData + "&userId=L36&L38Name="+jstr;

var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new
{

    api_key = "my key",
    id="id",
    pId=0,
    app="Brioins",
    token="",
    isS=true,
    expiry="2017-10-11T14:37:39.1234123-09:00",
    messages=new {},
    OPEN=new {a="dddddddd",session="0132"},
    tDate="0001-01-01T00:00:00",
    action = "categories",
    store_id = "my store"
});

    var data = Encoding.UTF8.GetBytes(json);
    var url="http://jsonplaceholder.typicode.com/posts";
    var myRequest = WebRequest.CreateHttp(url);
    myRequest.Method = "POST";
  //  myRequest.ContentType = "application/x-www-form-urlencoded";
    myRequest.ContentType = " application/json";
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
       dataStream.Close();
        theResponse.Close();
    }
return str;
}

}