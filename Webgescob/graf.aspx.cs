using System;
using System.Web.UI;
using System.Data;
using DataLib;
using System.Web.UI.DataVisualization.Charting;

namespace WebNif
{
    public partial class graf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            graficos_inicio();
        }

        protected void graficos_inicio()
        {
            // Grafico 1
            Conexion cn1 = new Conexion();
            string sql1 = "select periodo, interes from erp_plan_pagos where ERP_PRESTAMO_ID=128 order by periodo";
            DataTable dt1 = (DataTable)cn1.Query(sql1, Conexion.TipoDato.Table);

            string[] x1 = new string[dt1.Rows.Count];
            int[] y1 = new int[dt1.Rows.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                x1[i] = dt1.Rows[i][0].ToString();
                y1[i] = Convert.ToInt32(dt1.Rows[i][1]);
            }

            Chart1.Series[0].Points.DataBindXY(x1, y1);
            Chart1.Series[0].ChartType = SeriesChartType.Bar;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Titles[0].Text = "Grafico Interes";
            Chart1.Legends[0].Enabled = true;
            Chart1.Palette = ChartColorPalette.Pastel;


            // Grafico 2
            Conexion cn2 = new Conexion();
            string sql2 = "select periodo, nuevocapital from erp_plan_pagos where ERP_PRESTAMO_ID=128 order by periodo";
            DataTable dt2 = (DataTable)cn2.Query(sql2, Conexion.TipoDato.Table);

            string[] x2 = new string[dt2.Rows.Count];
            int[] y2 = new int[dt2.Rows.Count];

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                x2[i] = dt2.Rows[i][0].ToString();
                y2[i] = Convert.ToInt32(dt2.Rows[i][1]);
            }

            Chart2.Series[0].Points.DataBindXY(x2, y2);
            Chart2.Series[0].ChartType = SeriesChartType.Column;
            Chart2.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
            Chart2.Legends[0].Enabled = true;


            // Grafico 3
            Conexion cn3 = new Conexion();
            string sql3 = "select periodo, sobretasa from erp_plan_pagos where ERP_PRESTAMO_ID=128 order by periodo";
            DataTable dt3 = (DataTable)cn3.Query(sql3, Conexion.TipoDato.Table);

            string[] x3 = new string[dt3.Rows.Count];
            int[] y3 = new int[dt3.Rows.Count];

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                x3[i] = dt3.Rows[i][0].ToString();
                y3[i] = Convert.ToInt32(dt3.Rows[i][1]);
            }

            Chart3.Series[0].Points.DataBindXY(x3, y3);
            Chart3.Series[0].ChartType = SeriesChartType.Pie;
            Chart3.ChartAreas["ChartArea3"].Area3DStyle.Enable3D = true;
            Chart3.Legends[0].Enabled = true;

            //// Grafico 4 - mi cuenta
            //Chart4.Series[0].Points.DataBindXY(x3, y3);
            //Chart4.Series[0].ChartType = SeriesChartType.Pie;
            //Chart4.ChartAreas["ChartArea4"].Area3DStyle.Enable3D = true;
            //Chart4.Legends[0].Enabled = true;

        }



    }
}