using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.IO;
using DataLib;

namespace BussinesLayer
{
    public static class Tools
    {
        public static List<PeriodosReporte> generaPeriodosERP(string modalidad, int anoIni, int mesini, int mesfin, int anoFin, string funcion, int IdEscenario, string nombreSerie, string DIVISOR)
        {
            Conexion conn = new Conexion();
            int mes = mesini;
            double sldo;
            List<PeriodosReporte> periodos = new List<PeriodosReporte>();

            for (mes = mesini; mes <= mesfin; mes++)
            {
                string sql = "select " + funcion + "(" + anoIni + "," + mes + ", " + DIVISOR + ") sldo from dual ";
                DataTable dt = (DataTable)conn.Query(sql, Conexion.TipoDato.Table);
                sldo = Convert.ToDouble(dt.Rows[0][0]);
                periodos.Add(new PeriodosReporte(anoIni, mes, sldo, nombreSerie));
            }

            return periodos;
        }
    }

    public class PeriodosReporte
    {
        int ano;
        int mes;
        double valor;
        string nombreSerie;

        public string NombreSerie
        {
            get { return nombreSerie; }
            set { nombreSerie = value; }
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public PeriodosReporte(int pano, int pmes, double pvalor, string pnombreSerie)
        {
            this.ano = pano;
            this.mes = pmes;
            this.valor = pvalor;
            nombreSerie = pnombreSerie;
        }

        public string getTituloCorto()
        {
            string DscMes = "";
            switch (mes)
            {
                case 1: DscMes = "Ene"; break;
                case 2: DscMes = "Feb"; break;
                case 3: DscMes = "Mar"; break;
                case 4: DscMes = "Abr"; break;
                case 5: DscMes = "May"; break;
                case 6: DscMes = "Jun"; break;
                case 7: DscMes = "Jul"; break;
                case 8: DscMes = "Ago"; break;
                case 9: DscMes = "Sep"; break;
                case 10: DscMes = "Oct"; break;
                case 11: DscMes = "Nov"; break;
                case 12: DscMes = "Dic"; break;
            }
            return DscMes;
        }

    }
}
