using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer
{
    public class PlotArea
    {
        string javaScript = "";
        string div;
        int consecutivo;

        public int Consecutivo
        {
            get { return consecutivo; }
            set { consecutivo = value; }
        }

        public string Div
        {
            get { return div; }
            set { div = value; }
        }

        public string JavaScript
        {
            get { return javaScript; }
            set { javaScript = value; }
        }

        public PlotArea(int tpograf, int cnsctvo, string title, string fuente, string regional, int ano_ini, List<List<PeriodosReporte>> listaSeries, bool useTimeSeries, int idEscenario, string tooltip, bool solomes, string url, int tipoGrafico, string SYMBOLO , string leyenda_y)
        {
            string xAxis = "";

            if (regional == null)
                regional = fuente;

            string nombreSerie1="";

            string data_serie1 = "";
            int cont = 0;

            foreach (List<PeriodosReporte> lsta_p in listaSeries)
            {
                foreach (PeriodosReporte p in lsta_p)
                {
                    if (data_serie1 != "")
                        data_serie1 += ",";                    

                    if (cont == 0)
                    {
                        if (xAxis != "")
                            xAxis += ",";
                    }

                    data_serie1 += p.Valor.ToString().Replace(",", ".") + " ";

                    if (cont == 0)
                    {
                        if (solomes)
                            xAxis += "'" + p.getTituloCorto2() + "'";
                        else
                            xAxis += "'" + p.getTituloCorto() + "'";
                    }
                    nombreSerie1 = p.NombreSerie;
                }
                cont++;
            }

            char c = '"';

            javaScript = "<script type=" + c + "text/javascript" + c + ">";
            javaScript += "$(function () {";
            javaScript += "    $('#container').highcharts({";
            javaScript += "        chart: {";

            if (tpograf == 1)
                javaScript += "            type: 'column',";

            if (tpograf == 2)
                javaScript += "            type: 'pie',";

            javaScript += "            margin: 85,";
            javaScript += "            options3d: {";
            javaScript += "                enabled: true,";
            //-----------------------------------------------------------------------------------------
            if (tpograf == 1)
            {
                if (listaSeries.Count >= 1)
                {
                    javaScript += "                alpha: 10,";
                    javaScript += "                beta: 25,";
                    javaScript += "                depth: 70";
                }

                else
                {
                    javaScript += "                alpha: 15,";
                    javaScript += "                beta: 15,";
                    javaScript += "                depth: 40,";
                    javaScript += "                viewDistance: 25";
                }
            }
            if (tpograf == 2)
            {
                javaScript += "                alpha: 45,";
                javaScript += "                beta: 0,";
            }
            //----------------------------------------
            javaScript += "            }";
            javaScript += "       },";
            javaScript += "       title: {";
            javaScript += "            text: 'ELECTRIFICADORA DEL HUILA S.A E.S.P'";
            javaScript += "        },";
            javaScript += "       subtitle: {";
            javaScript += "            text: 'Indicadores Financieros'";
            javaScript += "        },";
            javaScript += "       tooltip: {";
            javaScript += "            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'";
            javaScript += "        },";
            javaScript += "        plotOptions: {";
            //-----------------------------------------------------------------------------------------
            if (tpograf == 1)
            {
                javaScript += "            column: {";
                javaScript += "                depth: 25,";
                javaScript += "            }";
            }
            if (tpograf == 2)
            {
                javaScript += "            pie: {";
                javaScript += "                allowPointSelect: true,";
                javaScript += "                cursor: 'pointer',";
                javaScript += "                depth: 35,";
                javaScript += "                dataLabels: {";
                javaScript += "                   enabled: true,";
                javaScript += "                   format: '{point.name}'";
                javaScript += "                }";
                javaScript += "            }";
            }
            //----------------------------------------
            javaScript += "        },";
            javaScript += "        xAxis: {";
            javaScript += "            categories:  [" + xAxis + "]";
            javaScript += "        },";
            javaScript += "yAxis: {";
            javaScript += "opposite: true,";
            javaScript += "allowDecimals: false,";
            javaScript += "min: 0,";
            javaScript += "title: {text: '" + leyenda_y + "'}";
            javaScript += " },";
            javaScript += " tooltip: { valueSuffix: ' Millones de Pesos' },";
            javaScript += " credits: {  enabled: false },";

            var y = -10;
            
            // series --> DATOS 
            javaScript += " series: [";
            foreach (List<PeriodosReporte> lsta_p in listaSeries)
            {
                data_serie1 = "";
                nombreSerie1 = "";
                foreach (PeriodosReporte p in lsta_p)
                {
                    if (data_serie1 != "")
                        data_serie1 += ",";
                    data_serie1 += p.Valor.ToString().Replace(",", ".") + " ";
                    nombreSerie1 = p.NombreSerie;
                }

                javaScript += "{name: '" + nombreSerie1 + "', data: [" + data_serie1 + "],";

                if (SYMBOLO == "")
                    javaScript += "dataLabels: {enabled: true, y: " + y.ToString() + "}";
                else 
                    javaScript += "dataLabels: {enabled: true, y: " + y.ToString() + ", format: '" + SYMBOLO + "'}";              
            
                javaScript += "   },";             
               
                y = y -20;
            }

            javaScript += "]";
            javaScript += "    });";
            javaScript += "});";
            javaScript += "       </script>";

            if (useTimeSeries)
                div += "<div id='container_" + cnsctvo + "' style='border: 3px coral solid;width: 950px; height: 400px; margin:1 auto'></div>";
            else
                div += "<div id='container_" + cnsctvo + "' style='border: 2px coral solid;width: 400px; height: 250px; margin:1 auto;text-align: left'></div>";          		            

            consecutivo = cnsctvo;
        }
    }
}
