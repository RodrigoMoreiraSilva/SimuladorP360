using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SimuladorP360
{
    public partial class Simulador : System.Web.UI.Page
    {
        int idEmpresa;
        int idAluno;
        string idTurma;
        WsAluno.Cartao cartao = new WsAluno.Cartao();
        int numParcela;
        WsAluno.WsAluno wsAluno = new WsAluno.WsAluno();
        int idContaReceber;


        protected void obterValores()
        {
            idEmpresa = Convert.ToInt32(txbEmpresa.Text);
            idAluno = Convert.ToInt32(txbAluno.Text);
            idTurma = txbTurma.Text;//normal 93730 ///recorrente 93812
            numParcela = txbNumParcela.Text.Equals("") ? 0 : Convert.ToInt32(txbNumParcela.Text);
            idContaReceber = txbIdContaReceber.Text.Equals("") ? 0 : Convert.ToInt32(txbIdContaReceber.Text);


            cartao.TipoBandeiraBraspag = WsAluno.TipoBandeiraBraspag.Visa; //1
            cartao.Ativo = true;
            cartao.DataRegistro = DateTime.Now.Date;
            cartao.DataValidadeCartao = "12" + "/" + "2025";
            cartao.NomeBandeira = "VISA";
            cartao.NomeComprador = "Aluno Aluno";
            cartao.NomeImpressoCartao = "Aluno Aluno";
            cartao.NumeroCartao = txbNumCartao.Text.Equals("") ? "4012.8888.8888.1881" : txbNumCartao.Text;// "4111.1111.1111.1111";//"3782.822463.10005"; //4012888888881881
            cartao.NumeroCodigoSeguranca = "111";

            wsAluno.Url = "http://LocalHost:3000/WebService/WsAluno.asmx";
            wsAluno.Timeout = 100000000;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbmsg.Text = "";
            lbmsg.Visible = false;
        }

        //protected void IniciarTransacaoCartao_Click(object sender, EventArgs e)
        //{
        //    int idEmpresa = Convert.ToInt32(txbEmpresa.Text);
        //    int idAluno = Convert.ToInt32(txbAluno.Text);
        //    string idTurma = txbTurma.Text;//normal 93730 ///recorrente 93812
        //    WsAluno.Cartao cartao = new WsAluno.Cartao();
        //    int numParcela = txbNumParcela.Text.Equals("") ? 0 : Convert.ToInt32(txbNumParcela.Text);


        //    cartao.TipoBandeiraBraspag = WsAluno.TipoBandeiraBraspag.Visa; //1
        //    cartao.Ativo = true;
        //    cartao.DataRegistro = DateTime.Now.Date;
        //    cartao.DataValidadeCartao = "12" + "/" + "2021";
        //    cartao.NomeBandeira = "VISA";
        //    cartao.NomeComprador = "Stephany Akie";
        //    cartao.NomeImpressoCartao = "Stephany Akie";
        //    cartao.NumeroCartao = txbNumCartao.Text ?? "4012.8888.8888.1881";// "4111.1111.1111.1111";//"3782.822463.10005"; //4012888888881881
        //    cartao.NumeroCodigoSeguranca = "111";


        //    WsAluno.WsAluno wsAluno = new WsAluno.WsAluno();
        //    wsAluno.Url = "http://localhost:3000/WebService/WsAluno.asmx";
        //    wsAluno.Timeout = 1000000;

        //    var sucesso = string.Empty;

        //    if (numParcela == 0)//Botão "Pagar" Não envia parcela porque o intuito é pagar a parcela 1 se for recorrente ou o contrato todo se for normal
        //    {
        //        sucesso = wsAluno.PagarLinkPagamento(idEmpresa, idAluno, idTurma, cartao);
        //    }
        //    else
        //    {
        //        //Botão: (Parcela Vencida) ? "Pagar parcela" : "Trocar cartão" 
        //        //Se a parcela estiver vencida será paga. 
        //        //Se a parcela estiver a vencer trocará os dados do cartão desta parcela e das futuras
                
        //        //Contrato NÃO recorrente com P1 em atraso???

        //        sucesso = wsAluno.TrocarCartaoPagarVencidoLinkPagamento(idEmpresa, idAluno, idTurma, cartao, numParcela);
        //    }

        //    if (sucesso.Equals(""))
        //    {
        //        lbmsg.Text = "Transação realizada com sucesso.";
        //        lbmsg.Visible = true;
        //    }
        //    else
        //    {
        //        lbmsg.Text = string.Format("Retorno: {0}", sucesso);
        //        lbmsg.Visible = true;
        //    }
        //}

        public enum TipoBandeiraBraspag
        {

            Visa = 1,
            MasterCard = 2,
            AmericanExpress = 3,
            Dinners = 4,
            EloCredito = 9,
            HiperCard = 12,
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            obterValores();

            var sucesso = wsAluno.PagarLinkPagamento(idEmpresa, idAluno, idTurma, cartao);
        
            if (sucesso.Equals(""))
            {
                lbmsg.Text = "Transação realizada com sucesso.";
                lbmsg.Visible = true;
            }
            else
            {
                lbmsg.Text = string.Format("Retorno: {0}", sucesso);
                lbmsg.Visible = true;
            }
        }

        protected void btnPagarVencida_Click(object sender, EventArgs e)
        {
            obterValores();

            var sucesso = wsAluno.PagarParcelaEspecificaLinkPagamento(idEmpresa, idAluno, idTurma, cartao, numParcela, idContaReceber);

            if (sucesso.Equals(""))
            {
                lbmsg.Text = "Pagamento da parcela "+ numParcela +" realizado com sucesso.";
                lbmsg.Visible = true;
            }
            else
            {
                lbmsg.Text = string.Format("Retorno: {0}", sucesso);
                lbmsg.Visible = true;
            }
        }

        protected void btnTrocarCartao_Click(object sender, EventArgs e)
        {
            obterValores();

            var sucesso = wsAluno.TrocarCartaoLinkPagamento(idEmpresa, idAluno, idTurma, cartao, numParcela);

            if (sucesso.Equals(""))
            {
                lbmsg.Text = "Troca de cartão realizada com sucesso.";
                lbmsg.Visible = true;
            }
            else
            {
                lbmsg.Text = string.Format("Retorno: {0}", sucesso);
                lbmsg.Visible = true;
            }
        }

        protected void btnPagarBoleto_Click(object sender, EventArgs e)
        {
            obterValores();

            var sucesso = wsAluno.PagarBoletoVencidoCartao(idEmpresa, idAluno, idTurma, cartao, numParcela, idContaReceber);

            if (sucesso.Equals(""))
            {
                lbmsg.Text = "Boleto pago com sucesso.";
                lbmsg.Visible = true;
            }
            else
            {
                lbmsg.Text = string.Format("Retorno: {0}", sucesso);
                lbmsg.Visible = true;
            }
        }
    }
}