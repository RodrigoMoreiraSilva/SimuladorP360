<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulador.aspx.cs" Inherits="SimuladorP360.Simulador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbCodEmpresa" runat="server" Text="Cód. Empresa: "></asp:Label><br />
            <asp:TextBox ID="txbEmpresa" runat="server"></asp:TextBox><br />
            <asp:Label ID="lbCodAluno" runat="server" Text="Cód. Aluno: "></asp:Label><br />
            <asp:TextBox ID="txbAluno" runat="server"></asp:TextBox><br />
            <asp:Label ID="lbCodTurma" runat="server" Text="Cód. Turma: "></asp:Label><br />
            <asp:TextBox ID="txbTurma" runat="server"></asp:TextBox><br />
            <asp:Label ID="lbNumParcela" runat="server" Text="Num. Parcela: "></asp:Label><br />
            <asp:TextBox ID="txbNumParcela" runat="server"></asp:TextBox><br />
            <asp:Label ID="lbNumCartao" runat="server" Text="Num. Cartão: "></asp:Label><br />
            <asp:TextBox ID="txbNumCartao" MaxLength="16" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblIdContaReceber" runat="server" Text="IdContaReceber: "></asp:Label><br />
            <asp:TextBox ID="txbIdContaReceber" MaxLength="16" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="btnPagar_Click" /><br /><br />
            <asp:Button ID="btnPagarVencida" runat="server" Text="Pagar Específica" OnClick="btnPagarVencida_Click" /><br /><br />
            <asp:Button ID="btnTrocarCartao" runat="server" Text="Trocar Cartão" OnClick="btnTrocarCartao_Click" /><br /><br />
            <asp:Button ID="btnPagarBoleto" runat="server" Text="Pagar Boleto" OnClick="btnPagarBoleto_Click" /><br />

            <%--<asp:Button ID="IniciarTransacaoCartao" runat="server" Text="Iniciar a transação com cartão" OnClick="IniciarTransacaoCartao_Click" />--%>
            <br /><br />
            <asp:Label ID="lbmsg" runat="server" Visible ="false"></asp:Label>
        </div>
    </form>
</body>
</html>
