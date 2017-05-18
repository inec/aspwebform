<%@ Page Language="C#" CodeFile="SamplePage.aspx.cs" 
    Inherits="SamplePage" AutoEventWireup="true" %>
<html>
<head runat="server" >
   <title>Code-Behind Page Model</title>
   <script
  src="https://code.jquery.com/jquery-1.12.4.min.js"
  integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ="
  crossorigin="anonymous"></script>
  <script>
     $(document).ready(function(){

console.log("t");

});

function ShowCurrentTime() {
            $.ajax({
                type: "POST",
                url: "test.aspx/GetCurrentTime",
                data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
          console.log(response.d);
        }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
       <asp:Label id="Label1" 
         runat="server" Text="Label" >
      </asp:Label>
      <br />
      <asp:Button id="Button1" 
         runat="server" 
         onclick="Button1_Click" 
         Text="Button" >
       </asp:Button>
    </div>
    <div>
            Your Name :
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <input id="btnGetTime" type="button" value="Show Current Time"
                onclick="ShowCurrentTime()" />
        </div>
  </form>
</body>
</html>