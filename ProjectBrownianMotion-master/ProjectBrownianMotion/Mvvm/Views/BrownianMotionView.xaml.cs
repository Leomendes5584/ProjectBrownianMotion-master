using Aurigma.GraphicsMill.AjaxControls;
using Microsoft.Maui.Controls;
using ProjectBrownianMotion.Mvvm.Models;

namespace ProjectBrownianMotion.Mvvm.Views;

public partial class BrownianMotionView : ContentPage {

    public BrownianMotionView() {
        InitializeComponent();
    }

    //M�todo que ir� retornar o gr�fico ap�s o click do usu�rio no bot�o.
    private void GerarSimulacaoClicked(object sender, EventArgs e) {
        double precoInicial;
        double votatilidade;
        double retorno;
        int dias;

        // Realiza a convers�o dos valores das entradas, verificando se s�o v�lidos
        if (!double.TryParse(precoInicialEntry.Text, out precoInicial) ||
            !double.TryParse(votatilidadeEntry.Text, out votatilidade) ||
            !double.TryParse(retornoEntry.Text, out retorno) ||
            !int.TryParse(diasEntry.Text, out dias)) {
            // Se a convers�o falhar, exibe uma mensagem para o usu�rio ou tome outra a��o adequada.
            return;
        }

        var brownianMotion = new BrownianMotion {
            PrecoInicial = precoInicial,
            Votatilidade = votatilidade,
            MediaRetorno = retorno,
            TempoDuracaoDias = dias
        };

        //Realizando valida��es para n�o quebrar a aplica��o por valores nulos na mesma. 
        if (brownianMotion.PrecoInicial != 0 && brownianMotion.Votatilidade != 0 && brownianMotion.TempoDuracaoDias != 0 && brownianMotion.MediaRetorno != 0) {
            var prices = brownianMotion.GenerateBrownnMotion();
            DrawableGraphic.Drawable = new DrawableGraphic(prices);
        }
    }

}

