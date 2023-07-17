<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giftcard.aspx.cs" Inherits="TawaGCWeb.giftcard" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Gift card activity system</title>
    <link rel="SHORTCUT ICON" href="http://www.99ranch.com/images/Image.ico" type="image/x-icon">
    
    <style>
        html{background: grey;}
         body {border: 1px solid black;width: 80%;margin: 5px auto;background-color:whitesmoke;padding-top:20px;}
         h3 {font-family: Times New Roman;font-size: 150%;margin-right:10%; }
         h4 {color: blue;font-family: verdana;font-size: 200%;margin-left:15px;}
         p  {margin-left:15px;}
         p.footer {position : relative;bottom : 0;height : 40px; margin-top : 40px;margin-left : 35%;}
         p.lasttime{font-family: Times New Roman;font-size: 100%;margin-right:10%;text-align:right; }


         .gridview {
    font-family: Arial;
    background-color: #FFFFFF;
    border: solid 1px #CCCCCC;
}

.gridview td  {
    padding: 5px 50px 5px 5px;
}

.gridview th {
    padding: 5px 50px 5px 5px;
    text-align: left;
}

.gridview th a{
    color: #003300;
    text-decoration: none;
}

.gridview th a:hover{
    color: #003300;
    text-decoration: underline;
}

.gridview td a{
    color: #003300;
    text-decoration: none;
}

.gridview td a:hover {
    color: red;
    text-decoration:underline;     
}

.gridViewHeader {
    background-color: #0066CC;
    color: #FFFFFF;
    text-align: left;
}

.gridViewRow {
    background-color: #99CCFF;
    color: #000000;
    font-family: "Times New Roman";
    font-size: 75%;
}

.gridViewAltRow {
    background-color: #FFFFFF;
    font-family: "Times New Roman";
    font-size: 16px;
}


/* Of course, this doesn't work with IE6. Works fine with Firefox, though. */
.gridview tr.gridViewRow:hover td, .gridview tr.gridViewAltRow:hover td {
    background-color: #CCCCCC;
    color: #000000; 
}


#divGridView {
    margin-top: 1.5em;
}

     </style>
</head>
    <body>
            <h3 align="right">       <B>Name</B>:<asp:Label ID="nameLabel" runat="server"></asp:Label> | <a href="/logout.aspx">Logout</a></h3>
            <p class="lasttime" >Database Last Update: <asp:Label ID="ldtLabel" runat="server" Text=""></asp:Label></p>
            <p><BR /></p>
            <h4><B>Enter Gift Card # for Inquiry<br />
                </B></h4>
        <form id="form1" runat="server">
            <p align =" left"><asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></p>
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview" GridLines="None">
    <HeaderStyle CssClass="gridViewHeader" />
    <RowStyle CssClass="gridViewRow" />
    <AlternatingRowStyle CssClass="gridViewAltRow" />
    <PagerStyle CssClass="gridViewPager" />
             </asp:GridView>
       </form>
        <p class="footer" >2018 (c) Tawa Group </p>
        </body>
        </html>