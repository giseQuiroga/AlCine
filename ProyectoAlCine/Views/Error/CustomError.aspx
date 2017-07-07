<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomError.aspx.cs" Inherits="Pluspetrol.Siga.UI.WebUserControls.Error.CustomError1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Siga</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/reset.css" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/text.css" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/grilla.css" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/content.css" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/JQuery/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/JQuery/jquery-ui.structure.css" />
    <link rel="stylesheet" type="text/css" media="all" href="~/css/JQuery/jquery-ui.theme.css" />
    <script src="~/Scripts/JQuery/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="~/Scripts/JQuery/jquery-ui.js" type="text/javascript"></script>
    <link href="~/css/SIGA.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/Plugins/moment.min.js" type="text/javascript"></script>
    <script src="~/js/master.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="loading" class="loading" runat="server">
        <div id="divErrorMessage" style="width: 500px; height: 150px;" align="right">
            <h2 align="left">
                Se produjo un error al realizar la acción. <br/>
                Por favor intente nuevamente.</h2>
            <asp:Button ID="btnGoHome" runat="server" Text="Home" style="font-size:16px" CssClass="button" ClientIDMode="Static"
                onclick="btnGoHome_Click" />
        </div>
    </div>
    <div class="container_12">
        <div class="grid_12 ">
            <div class="headerImage">
                <img src="../../css/images/barra-header.jpg" alt="Pluspetrol" width="968" height="72" /></div>
            <div class="headerMenu">
                <table style="width: 100%" border="0" cellpadding="0" cellspacing="0" class="tablaNavCont">
                    <tr>
                        <td>
                            <table style="width: 100%" border="0" cellpadding="0" cellspacing="0" class="tablaNav">
                                <tr>
                                    <td>
                                        <a href="/">
                                            <asp:Image ID="btnHome" ImageUrl="~/css/images/icon-home.jpg" Width="31" runat="server"
                                                Height="28" AlternateText="Home" ToolTip="Home" />
                                        </a>
                                    </td>
                                    <td>
                                        <a href="mailTo:helpdesk@pluspetrol.net">
                                            <asp:Image ID="btnMail" ImageUrl="~/css/images/icon-mail.jpg" Width="31" runat="server"
                                                Height="28" AlternateText="Email" ToolTip="Email" /></a>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnHelp" ImageUrl="~/css/images/icon-help.jpg" Width="31" runat="server"
                                            Height="28" AlternateText="Ayuda" CausesValidation="false" OnClick="btnHelp_Click"
                                            ToolTip="Ayuda" />
                                    </td>
                                    <!-- end .grid_12 -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- end .grid_3 -->
                                    <td class="headerText">
                                        Usuario: <span>
                                            <label id="lblUser" runat="server">
                                            </label>
                                        </span>&nbsp;&nbsp;Grupo: <span>
                                            <label id="lblGroup" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="clear">
            &nbsp;</div>
        <%--<div>
            Se produjo un error al realizar la acción. Por favor intente nuevamente.
        </div>--%>
    </div>
    </form>
</body>
</html>
