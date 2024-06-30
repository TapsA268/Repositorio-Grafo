<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPresentacion.aspx.cs" Inherits="WebGrafo.FormPresentacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Grafo Web</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Grafo en web</h1>

            Agregar Vertice<br />
            <br />
            &nbsp;Nombre:                 
            <asp:TextBox ID="TextBox1" runat="server" Width="164px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;               
            Edad:                 
            <asp:TextBox ID="TextBox2" runat="server" Width="44px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                
            <asp:Button ID="Button1" runat="server" Text="Agregar vertice" OnClick="Button1_Click" />
            <br />
            <br />
            Conectar a:            
            <br />
            <br />
            Origen:                 
            <asp:TextBox ID="TextBox3" runat="server" Width="44px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;            
            Destino:                
            <asp:TextBox ID="TextBox4" runat="server" Width="44px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;               
            Costo:                
            <asp:TextBox ID="TextBox5" runat="server" Width="44px"></asp:TextBox>
            <br />
            <br />
            Resultados:               
            <asp:TextBox ID="TextBox6" runat="server" Width="350px"></asp:TextBox>
            <br />
            <br />
            Vértices:                            
            <asp:DropDownList ID="DropDownList1" runat="server" Height="39px" Width="328px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp; Aristas:                
            <asp:DropDownList ID="DropDownList2" runat="server" Height="39px" Width="322px">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Agregar arista" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;               
            <asp:Button ID="Button3" runat="server" Text="Mostrar Aristas del vertice" OnClick="Button3_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;               
            <asp:Button ID="Button4" runat="server" Text="Recorrer DFS" OnClick="Button4_Click" />
            &nbsp;&nbsp;&nbsp;                
            <asp:Button ID="Button5" runat="server" Text="Recorrer BFS" OnClick="Button5_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;               
            <asp:Button ID="Button6" runat="server" Text="Busqueda Topológica" OnClick="Button6_Click" />
            <br />
            <br />
            Recorridos y búsqueda
            <br />
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-dark" Height="39px" Width="220px">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
