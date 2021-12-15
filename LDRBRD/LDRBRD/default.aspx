<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LDRBRD._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>

                <tr>
                    <td>Username</td>
                    <td><asp:TextBox ID="username" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Score</td>
                    <td><asp:TextBox ID="score" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="NewEntry" />
                        <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="DeleteEntry" />
                        <asp:Button ID="Button3" runat="server" Text="Update" OnClick="UpdateEntry" />
                    </td>
                </tr>

                <tr>
                    <td>Update which user?</td>
                    <td><asp:TextBox ID="userupdateid" runat="server"></asp:TextBox></td>
                </tr>

            </table>

            <br />
            <asp:GridView ID="Gridview1" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>
