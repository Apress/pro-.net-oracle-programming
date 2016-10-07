<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="true" Inherits="PagedResults.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>WebForm1</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
      <H2>Paged Results Sample</H2>
      <P>
        <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
          <TR>
            <TD align="left" width="50%"><asp:linkbutton id="btnPrevious" runat="server">< Previous</asp:linkbutton></TD>
            <TD align="right" width="50%"><asp:linkbutton id="btnNext" runat="server">Next ></asp:linkbutton></TD>
          </TR>
          <TR>
            <TD align="center" width="100%" colSpan="2"><asp:datagrid id="dgLeagueResults" runat="server" AllowCustomPaging="True" PageSize="5" AllowPaging="True">
                <PagerStyle Visible="False"></PagerStyle>
              </asp:datagrid></TD>
          </TR>
        </TABLE>
      </P>
    </form>
  </body>
</HTML>
