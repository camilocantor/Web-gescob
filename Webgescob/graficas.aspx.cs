using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLayer;

namespace WebNif
{
    public partial class graficas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<List<PeriodosReporte>> listaSeries = new List<List<PeriodosReporte>>();

            //List<PeriodosReporte> serie = Tools.generaPeriodosERP("MENSUAL", AnoIni, MesIni, MesFin, AnoFin, funcion, IdIndicador, nom_serie + "-" + AnoIni, DIVISOR);
            List<PeriodosReporte> serie = Tools.generaPeriodosERP("MENSUAL", 2016, 01, 09, 2016, "CAL_ROA", 5, "ROA(%)" + "-" + 2016, "1");
            listaSeries.Add(serie);

            //PlotArea p = new PlotArea(tpograf, cnsctvo_grfca, nombre, "ElectroHuila S.A E.S.P", null, AnoIni, listaSeries, true, IdIndicador, "Periodo", true, "verGraficaCta.aspx", GRAFICO, symbolo, leyenda_y);
            // tpograf = 1 column, 2 tort
            PlotArea p = new PlotArea(1, 0, "ROA(%)", "ElectroHuila S.A E.S.P", null, 2016, listaSeries, true, 5, "Periodo", true, "verGraficaCta.aspx", 0, "{point.y:.2f}%", "Porcentaje");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "plotScript_" + p.Consecutivo, p.JavaScript, false);
        }
    }
}