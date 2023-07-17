<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TawaGCWeb.Login1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<style>
        html{background: grey;}
         body {border: 1px solid black;width: 80%;margin: 5px auto;background-color:whitesmoke;padding-top:20px;}
         h3 {font-family: Times New Roman;font-size: 150%;margin-left:10%; }
         h4 {color: blue;font-family: verdana;font-size: 200%;margin-left:15px;}
         p.footer {position : absolute;bottom : 0;height : 40px; margin-top : 40px;margin-left : 35%;}
     </style>
</head>
<body>
<h3><asp:Label ID="verLabel" runat="server" Text=""></asp:Label></h3><BR /><BR /><BR /><BR /><BR />
 <form id="Logon" method="post" runat="server">
 <div align=center>
   <asp:Label ID="Label2" runat="server" >Username:</asp:Label>
      <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox><br><br /><br />
      <asp:Label ID="Label3" runat="server" >Password:</asp:Label>
      <asp:TextBox ID="txtPassword" runat="server" TextMode=Password></asp:TextBox><br><br><br /><br />
      <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click"></asp:Button><br>
      <asp:Label ID="errorLabel" runat="server" ForeColor=#ff3300></asp:Label><br>
      <asp:CheckBox ID="chkPersist" runat="server" Text="Remember me" />
      </div>
    </form>
    <p class="footer" >2018 (c) Tawa Group </p>
</body>
</html>

