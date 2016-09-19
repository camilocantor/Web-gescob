using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.OracleClient;
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

            if (anoIni == anoFin)
            {
                for (mes = mesini; mes <= mesfin; mes++)
                {
                    string sql = "select " + funcion + "(" + anoIni + "," + mes + ", " + DIVISOR + ") sldo from dual ";
                    DataTable dt = (DataTable)conn.Query(sql, Conexion.TipoDato.Table);
                    sldo = Convert.ToDouble(dt.Rows[0][0]);
                    periodos.Add(new PeriodosReporte(anoIni, mes, sldo, nombreSerie));
                }
            }

            else if (anoIni <= anoFin)
            {
                for (mes = mesini; mes <= 12; mes++)
                {
                    string sql = "select " + funcion + "(" + anoIni + "," + mes + ") sldo from dual ";
                    DataTable dt = (DataTable)conn.Query(sql, Conexion.TipoDato.Table);
                    sldo = Convert.ToDouble(dt.Rows[0][0]);
                    periodos.Add(new PeriodosReporte(anoIni, mes, sldo, nombreSerie));
                }

                for (mes = 1; mes <= mesfin; mes++)
                {
                    string sql = "select " + funcion + "(" + anoFin + "," + mes + ") sldo from dual ";
                    DataTable dt = (DataTable)conn.Query(sql, Conexion.TipoDato.Table);
                    sldo = Convert.ToDouble(dt.Rows[0][0]);
                    periodos.Add(new PeriodosReporte(anoFin, mes, sldo, nombreSerie));
                }
            }
            return periodos;
        }
    }

    public class PeriodosReporte
    {
        int ano;
        int mes;
        double utilidad;
        double total_pasivo;
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

        public double TotalBalance()
        {
            return (total_pasivo + total_patrimonio + utilidad);
        }

        public double Total_pasivo
        {
            get { return total_pasivo; }
            set { total_pasivo = value; }
        }
        double total_patrimonio;

        public double Total_patrimonio
        {
            get { return total_patrimonio; }
            set { total_patrimonio = value; }
        }

        public double Utilidad
        {
            get { return utilidad; }
            set { utilidad = value; }
        }

        public int getAno()
        {
            return ano;
        }

        public int getMes()
        {
            return mes;
        }

        public PeriodosReporte(int pano, int pmes)
        {
            this.ano = pano;
            this.mes = pmes;
        }

        public PeriodosReporte(int pano, int pmes, double pvalor, string pnombreSerie)
        {
            this.ano = pano;
            this.mes = pmes;
            this.valor = pvalor;
            nombreSerie = pnombreSerie;
        }

        public string getColumna()
        {
            return "campo_" + ano + "_" + mes;
        }

        public string getTitulo()
        {
            string DscMes = "";
            switch (mes)
            {
                case 1: DscMes = "Enero"; break;
                case 2: DscMes = "Febrero"; break;
                case 3: DscMes = "Marzo"; break;
                case 4: DscMes = "Abril"; break;
                case 5: DscMes = "Mayo"; break;
                case 6: DscMes = "Junio"; break;
                case 7: DscMes = "Julio"; break;
                case 8: DscMes = "Agosto"; break;
                case 9: DscMes = "Septiembre"; break;
                case 10: DscMes = "Octubre"; break;
                case 11: DscMes = "Noviembre"; break;
                case 12: DscMes = "Diciembre"; break;
            }
            return DscMes + "/" + ano;
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
            return DscMes + "/" + ano;
        }

        public string getTituloCorto2()
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
