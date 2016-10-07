<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="PagedResultsVB.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>WebForm1</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
    <FORM id="Form1" method="post" runat="server">
      <H2>Paged Results Sample</H2>
      <P>
        <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
          <TR>
            <TD align="left" width="50%">
              <asp:linkbutton id="btnPrevious" runat="server">< Previous</asp:linkbutton></TD>
            <TD align="right" width="50%">
              <asp:linkbutton id="btnNext" runat="server">Next ></asp:linkbutton></TD>
          </TR>
          <TR>
            <TD align="center" width="100%" colSpan="2">
              <asp:datagrid id="dgLeagueResults" runat="server" AllowCustomPaging="True" PageSize="5" AllowPaging="True">
                <PagerStyle Visible="False"></PagerStyle>
              </asp:datagrid></TD>
          </TR>
        </TABLE>
      </P>
    </FORM>
  </body>
</HTML>
