using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Data.Odbc;
using System.Data;

namespace DataLib
{
    public class Conexion
    {
        string mstrConnectionStringORACLE;
        string mstrConnectionStringODBC;
        string mstrConnectionStringMSSQL;
        string motorBD;

        OracleConnection cnConexionT;
        OracleTransaction transaction;

        public Conexion()
        {
            motorBD = System.Configuration.ConfigurationManager.AppSettings["motorBD"];
            string strUsuario = System.Configuration.ConfigurationManager.AppSettings["user id"];
            string strPassword = System.Configuration.ConfigurationManager.AppSettings["password"];
            string strServidor = System.Configuration.ConfigurationManager.AppSettings["Data Source"];

            //motorBD = "Oracle";
            //string strUsuario = "ASCIITECH79";
            //string strPassword = "linaza09";
            //string strServidor = "PRODUCCION";

            switch (motorBD)
            {
                case "SqlServer":
                    clsConnectionSqlSrv(strUsuario, strPassword, strServidor, "");
                    break;
                case "Oracle":
                    clsConnectionOra(strUsuario, strPassword, strServidor);
                    break;
                case "ODBC":
                    clsConnectionODBC(strUsuario, strPassword, strServidor);
                    break;
                case "ODAC":
                    clsConnectionODAC(strUsuario, strPassword, strServidor);
                    break;
            }
        }


        public Conexion(string modi)
        {
            motorBD = System.Configuration.ConfigurationManager.AppSettings["motorBDNIIF"];
            string strUsuario = System.Configuration.ConfigurationManager.AppSettings["useridNIIF"];
            string strPassword = System.Configuration.ConfigurationManager.AppSettings["passwordNIIF"];
            string strServidor = System.Configuration.ConfigurationManager.AppSettings["DataSourceNIIF"];

            //motorBD = "Oracle";
            //string strUsuario = "NIIF_DESARROLLO";
            //string strPassword = "a";
            //string strServidor = "NIFF";

            switch (motorBD)
            {
                case "SqlServer":
                    clsConnectionSqlSrv(strUsuario, strPassword, strServidor, "");
                    break;
                case "Oracle":
                    clsConnectionOra(strUsuario, strPassword, strServidor);
                    break;
                case "ODBC":
                    clsConnectionODBC(strUsuario, strPassword, strServidor);
                    break;
                case "ODAC":
                    clsConnectionODAC(strUsuario, strPassword, strServidor);
                    break;
            }
        }


        public void clsConnectionOra(string strUsuario, string strPassword, string strServidor)
        {
            mstrConnectionStringORACLE = "Data Source = " + strServidor + "; User Id = " + strUsuario + "; Password = " + strPassword + ";";
        }

        public void clsConnectionODAC(string strUsuario, string strPassword, string strServidor)
        {
            mstrConnectionStringORACLE = "Data Source = " + strServidor + "; User Id = " + strUsuario + "; Password = " + strPassword + ";";
        }

        public void clsConnectionODBC(string strUsuario, string strPassword, string strServidor)
        {
            mstrConnectionStringODBC = "DSN=" + strServidor + ";UID=" + strUsuario + ";PWD=" + strPassword + ";";
        }

        public void clsConnectionSqlSrv(string strUsuario, string strPassword, string strServidor, string nombreBD)
        {
            mstrConnectionStringMSSQL = "Data Source = " + strServidor + "; Initial Catalog= " + nombreBD + "; User Id = " + strUsuario + "; Password = " + strPassword + ";";
        }

        //Enumeraciones
        public enum TipoDato
        {
            Table,
            View,
            DataSet,
            DataReader,
            RecordSet
        }

        public string getConnectionStringSQL()
        {
            return mstrConnectionStringMSSQL;
        }

        public string getConnectionStringOra()
        {
            return mstrConnectionStringORACLE;
        }

        //public bool Queryt(string strSQL)
        //{
        //    if (cnConexionT == null)
        //        cnConexionT = new OracleConnection(mstrConnectionStringORACLE);

        //    ConnectionState state = cnConexionT.State;
        //    if (state == ConnectionState.Closed)
        //    {
        //        cnConexionT.Open();
        //        transaction = cnConexionT.BeginTransaction(IsolationLevel.ReadCommitted);
        //    }

        //    try
        //    {
        //        OracleCommand cmComando = new OracleCommand(strSQL, cnConexionT);
        //        cmComando.Transaction = transaction;
        //        cmComando.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Rollback();
        //        throw ex;
        //        return false;
        //    }

        //    return (true);
        //}

        public void Commit()
        {
            transaction.Commit();
            cnConexionT.Close();
            cnConexionT.Dispose();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        //Ejecuta el query, retorna el numero de datos afectados
        public int Query(string strSQL)
        {
            int query = 0;
            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    SqlCommand cmComandoSQL = new SqlCommand(strSQL, cnConexionSQL);
                    cnConexionSQL.Open();
                    query = cmComandoSQL.ExecuteNonQuery();
                    cnConexionSQL.Close();
                    cnConexionSQL.Dispose();
                    cmComandoSQL.Dispose();
                    break;

                case "Oracle":
                    OracleConnection cnConexion = new OracleConnection(mstrConnectionStringORACLE);
                    OracleCommand cmComando = new OracleCommand(strSQL, cnConexion);
                    cnConexion.Open();

                    try
                    {
                        query = cmComando.ExecuteNonQuery();
                        cnConexion.Close();
                        cnConexion.Dispose();
                        cmComando.Dispose();
                    }

                    catch (Exception error)
                    {
                        transaction.Rollback();
                        Console.WriteLine(error.ToString());
                        Console.WriteLine("ERROR. Se hizo Rollback en la base de datos");
                    }

                    break;

                case "ODBC":
                    OdbcConnection cnConexionOdbc = new OdbcConnection(mstrConnectionStringODBC);
                    OdbcCommand cmComandoOdbc = new OdbcCommand(strSQL, cnConexionOdbc);
                    cnConexionOdbc.Open();

                    try
                    {
                        query = cmComandoOdbc.ExecuteNonQuery();
                    }
                    catch (Exception error)
                    {
                        string strError = error.Message;
                        string sqlError = strSQL;

                        strSQL = strSQL.Replace("'", "@");
                        strError = strError.Replace("'", "@");

                        string sql = "insert into pf_pila_errores values( (select nvl(max(cnsctvo),1) from pf_pila_errores), sysdate, '" + strError + "', '" + strSQL + "')";
                        cmComandoOdbc.CommandText = sql;
                        cmComandoOdbc.ExecuteNonQuery();
                        throw new Exception();
                    }


                    cnConexionOdbc.Close();
                    cnConexionOdbc.Dispose();
                    cmComandoOdbc.Dispose();
                    break;

            }

            return query;
        }

        //Ejecuta el query, retorna el numero de datos afectados
        public OdbcConnection getConectionODBC()
        {
            OdbcConnection cnConexionOdbc = new OdbcConnection(mstrConnectionStringODBC);
            cnConexionOdbc.Open();
            return cnConexionOdbc;
        }

        //Ejecuta el query y retorna datos en el tipo que se requiera
        public object Query(string strSQL, TipoDato eTipoDato)
        {
            object query = new object();
            DataSet dtsTemp = new DataSet();
            DataTable dttTemp = new DataTable();
            DataView dtvTemp = new DataView();

            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    SqlCommand cmComandoSQL = new SqlCommand(strSQL, cnConexionSQL);
                    SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                    SqlDataReader dtrTempSQL;

                    cnConexionSQL.Open();
                    cmComandoSQL.CommandType = CommandType.Text;
                    dtaAdaptadorSQL.SelectCommand = cmComandoSQL;

                    switch (eTipoDato)
                    {
                        case TipoDato.DataSet:
                            dtaAdaptadorSQL.Fill(dtsTemp, "Temp");
                            query = dtsTemp;
                            break;
                        case TipoDato.Table:
                            dtaAdaptadorSQL.Fill(dttTemp);
                            query = dttTemp;
                            break;
                        case TipoDato.View:
                            dtaAdaptadorSQL.Fill(dttTemp);
                            dttTemp.TableName = "Temp";
                            dtvTemp.Table = dttTemp;
                            query = dtvTemp;
                            break;
                        case TipoDato.RecordSet:
                            dtrTempSQL = cmComandoSQL.ExecuteReader();
                            query = dtrTempSQL;
                            break;
                    }

                    cnConexionSQL.Close();
                    cnConexionSQL.Dispose();
                    cmComandoSQL.Dispose();
                    dtaAdaptadorSQL.Dispose();
                    dtrTempSQL = null;
                    break;
                case "Oracle":
                    OracleConnection cnConexion = new OracleConnection(mstrConnectionStringORACLE);

                    OracleCommand cmComandoORA = new OracleCommand(strSQL, cnConexion);
                    OracleDataAdapter dtaAdaptadorORA = new OracleDataAdapter();
                    OracleDataReader dtrTempORA;

                    cnConexion.Open();

                    OracleGlobalization SessionGlob = cnConexion.GetSessionInfo();
                    SessionGlob.NumericCharacters = ",.";
                    SessionGlob.DateFormat = "dd/mm/yyyy";
                    cnConexion.SetSessionInfo(SessionGlob);

                    cmComandoORA.CommandType = CommandType.Text;
                    dtaAdaptadorORA.SelectCommand = cmComandoORA;

                    switch (eTipoDato)
                    {
                        case TipoDato.DataSet:
                            dtaAdaptadorORA.Fill(dtsTemp, "Temp");
                            query = dtsTemp;
                            break;
                        case TipoDato.Table:
                            dtaAdaptadorORA.Fill(dttTemp);
                            query = dttTemp;
                            break;
                        case TipoDato.View:
                            dtaAdaptadorORA.Fill(dttTemp);
                            dttTemp.TableName = "Temp";
                            dtvTemp.Table = dttTemp;
                            query = dtvTemp;
                            break;
                        case TipoDato.RecordSet:
                            dtrTempORA = cmComandoORA.ExecuteReader();
                            query = dtrTempORA;
                            break;
                    }

                    cnConexion.Close();
                    cnConexion.Dispose();
                    cmComandoORA.Dispose();
                    dtaAdaptadorORA.Dispose();
                    dtrTempORA = null;
                    break;

                case "ODBC":

                    OdbcConnection cnConexionOdbc = new OdbcConnection(mstrConnectionStringODBC);
                    OdbcCommand cmComandoOdbc = new OdbcCommand(strSQL, cnConexionOdbc);
                    OdbcDataAdapter dtaAdaptadorOdbc = new OdbcDataAdapter();
                    OdbcDataReader dtrTempOdbc;

                    cnConexionOdbc.Open();

                    cmComandoOdbc.CommandType = CommandType.Text;
                    dtaAdaptadorOdbc.SelectCommand = cmComandoOdbc;

                    switch (eTipoDato)
                    {
                        case TipoDato.DataSet:
                            dtaAdaptadorOdbc.Fill(dtsTemp, "Temp");
                            query = dtsTemp;
                            break;
                        case TipoDato.Table:
                            dtaAdaptadorOdbc.Fill(dttTemp);
                            query = dttTemp;
                            break;
                        case TipoDato.View:
                            dtaAdaptadorOdbc.Fill(dttTemp);
                            dttTemp.TableName = "Temp";
                            dtvTemp.Table = dttTemp;
                            query = dtvTemp;
                            break;
                        case TipoDato.RecordSet:
                            dtrTempOdbc = cmComandoOdbc.ExecuteReader();
                            query = dtrTempOdbc;
                            break;
                    }

                    cnConexionOdbc.Close();
                    cnConexionOdbc.Dispose();
                    cmComandoOdbc.Dispose();
                    dtaAdaptadorOdbc.Dispose();
                    dtrTempORA = null;
                    break;
            }

            dtsTemp.Dispose();
            dttTemp.Dispose();
            dtvTemp.Dispose();
            return query;
        }

        //public object Queryt(string strSQL, TipoDato eTipoDato)
        //{
        //    object query = new object();
        //    DataSet dtsTemp = new DataSet();
        //    DataTable dttTemp = new DataTable();
        //    DataView dtvTemp = new DataView();

        //    switch (motorBD)
        //    {
        //        case "SqlServer":
        //            SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
        //            SqlCommand cmComandoSQL = new SqlCommand(strSQL, cnConexionSQL);
        //            SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
        //            SqlDataReader dtrTempSQL;

        //            cnConexionSQL.Open();
        //            cmComandoSQL.CommandType = CommandType.Text;
        //            dtaAdaptadorSQL.SelectCommand = cmComandoSQL;

        //            switch (eTipoDato)
        //            {
        //                case TipoDato.DataSet:
        //                    dtaAdaptadorSQL.Fill(dtsTemp, "Temp");
        //                    query = dtsTemp;
        //                    break;
        //                case TipoDato.Table:
        //                    dtaAdaptadorSQL.Fill(dttTemp);
        //                    query = dttTemp;
        //                    break;
        //                case TipoDato.View:
        //                    dtaAdaptadorSQL.Fill(dttTemp);
        //                    dttTemp.TableName = "Temp";
        //                    dtvTemp.Table = dttTemp;
        //                    query = dtvTemp;
        //                    break;
        //                case TipoDato.RecordSet:
        //                    dtrTempSQL = cmComandoSQL.ExecuteReader();
        //                    query = dtrTempSQL;
        //                    break;
        //            }

        //            cnConexionSQL.Close();
        //            cnConexionSQL.Dispose();
        //            cmComandoSQL.Dispose();
        //            dtaAdaptadorSQL.Dispose();
        //            dtrTempSQL = null;
        //            break;

        //        case "Oracle":

        //            OracleCommand cmComandoORA = new OracleCommand(strSQL, cnConexionT);
        //            OracleDataAdapter dtaAdaptadorORA = new OracleDataAdapter();
        //            OracleDataReader dtrTempORA;
                    

        //            try
        //            {
        //                OracleGlobalization SessionGlob = cnConexionT.GetSessionInfo();
        //                SessionGlob.NumericCharacters = ",.";
        //                SessionGlob.DateFormat = "dd/mm/yyyy";
        //                cnConexionT.SetSessionInfo(SessionGlob);

        //                cmComandoORA.CommandType = CommandType.Text;
        //                dtaAdaptadorORA.SelectCommand = cmComandoORA;

        //                switch (eTipoDato)
        //                {
        //                    case TipoDato.DataSet:
        //                        dtaAdaptadorORA.Fill(dtsTemp, "Temp");
        //                        query = dtsTemp;
        //                        break;
        //                    case TipoDato.Table:
        //                        dtaAdaptadorORA.Fill(dttTemp);
        //                        query = dttTemp;
        //                        break;
        //                    case TipoDato.View:
        //                        dtaAdaptadorORA.Fill(dttTemp);
        //                        dttTemp.TableName = "Temp";
        //                        dtvTemp.Table = dttTemp;
        //                        query = dtvTemp;
        //                        break;
        //                    case TipoDato.RecordSet:
        //                        dtrTempORA = cmComandoORA.ExecuteReader();
        //                        query = dtrTempORA;
        //                        break;
        //                }

        //                cmComandoORA.Dispose();
        //                dtaAdaptadorORA.Dispose();
        //                dtrTempORA = null;
        //                break;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        case "ODBC":
        //            OdbcConnection cnConexionOdbc = new OdbcConnection(mstrConnectionStringODBC);
        //            OdbcCommand cmComandoOdbc = new OdbcCommand(strSQL, cnConexionOdbc);
        //            OdbcDataAdapter dtaAdaptadorOdbc = new OdbcDataAdapter();
        //            OdbcDataReader dtrTempOdbc;

        //            cnConexionOdbc.Open();

        //            cmComandoOdbc.CommandType = CommandType.Text;
        //            dtaAdaptadorOdbc.SelectCommand = cmComandoOdbc;

        //            switch (eTipoDato)
        //            {
        //                case TipoDato.DataSet:
        //                    dtaAdaptadorOdbc.Fill(dtsTemp, "Temp");
        //                    query = dtsTemp;
        //                    break;
        //                case TipoDato.Table:
        //                    dtaAdaptadorOdbc.Fill(dttTemp);
        //                    query = dttTemp;
        //                    break;
        //                case TipoDato.View:
        //                    dtaAdaptadorOdbc.Fill(dttTemp);
        //                    dttTemp.TableName = "Temp";
        //                    dtvTemp.Table = dttTemp;
        //                    query = dtvTemp;
        //                    break;
        //                case TipoDato.RecordSet:
        //                    dtrTempOdbc = cmComandoOdbc.ExecuteReader();
        //                    query = dtrTempOdbc;
        //                    break;
        //            }

        //            cnConexionOdbc.Close();
        //            cnConexionOdbc.Dispose();
        //            cmComandoOdbc.Dispose();
        //            dtaAdaptadorOdbc.Dispose();
        //            dtrTempORA = null;
        //            break;
        //    }

        //    dtsTemp.Dispose();
        //    dttTemp.Dispose();
        //    dtvTemp.Dispose();
        //    return query;
        //}

        public object Query(string strSQL, TipoDato eTipoDato, OdbcCommand cmComandoOdbc)
        {
            object query = new object();
            DataSet dtsTemp = new DataSet();
            DataTable dttTemp = new DataTable();
            DataView dtvTemp = new DataView();

            OdbcDataAdapter dtaAdaptadorOdbc = new OdbcDataAdapter();
            OdbcDataReader dtrTempOdbc;

            dtaAdaptadorOdbc.SelectCommand = cmComandoOdbc;

            switch (eTipoDato)
            {
                case TipoDato.DataSet:
                    dtaAdaptadorOdbc.Fill(dtsTemp, "Temp");
                    query = dtsTemp;
                    break;
                case TipoDato.Table:
                    dtaAdaptadorOdbc.Fill(dttTemp);
                    query = dttTemp;
                    break;
                case TipoDato.View:
                    dtaAdaptadorOdbc.Fill(dttTemp);
                    dttTemp.TableName = "Temp";
                    dtvTemp.Table = dttTemp;
                    query = dtvTemp;
                    break;
                case TipoDato.RecordSet:
                    dtrTempOdbc = cmComandoOdbc.ExecuteReader();
                    query = dtrTempOdbc;
                    break;
            }


            dtsTemp.Dispose();
            dttTemp.Dispose();
            dtvTemp.Dispose();
            return query;
        }


        public class InParameter
        {
            public string nombre;
            public object valor;
            public SqlDbType tipoSqlServer;
            public OracleDbType tipoOra;
            public OdbcType tipoODBC;

            public InParameter(string Nombre, object Valor, SqlDbType? TipoSqlServer, OracleDbType? TipoOra, OdbcType? TipoOdbc)
            {
                nombre = Nombre;
                valor = Valor;
                if (TipoSqlServer != null)
                {
                    tipoSqlServer = (SqlDbType)TipoSqlServer;
                }
                else
                {
                    if (TipoOra != null)
                    {
                        tipoOra = (OracleDbType)TipoOra;
                    }
                    else
                    {
                        if (TipoOdbc != null)
                        {
                            tipoODBC = (OdbcType)TipoOdbc;
                        }

                    }
                }
            }
        }

        public class OutParameter
        {
            public string nombre;
            public object valor;
            public SqlDbType tipoSqlServer;
            public OracleDbType tipoOra;
            public OdbcType tipoODBC;
            public int tamano;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Nombre">Nombre del parámetro</param>
            /// <param name="Tipo">Tipo de dato</param>
            /// <param name="Tamano">Opcional, determina el tamaño máximo para las cadenas</param>
            /// 
            public OutParameter(string Nombre, SqlDbType? TipoSqlServer, OracleDbType? TipoOra, OdbcType? TipoOdbc, int Tamano)
            {
                nombre = Nombre;
                tamano = Tamano;

                if (TipoSqlServer != null)
                {
                    tipoSqlServer = (SqlDbType)TipoSqlServer;
                }
                else
                {
                    if (TipoOra != null)
                    {
                        tipoOra = (OracleDbType)TipoOra;
                    }
                    else
                    {
                        if (TipoOdbc != null)
                        {
                            tipoODBC = (OdbcType)TipoOdbc;
                        }
                    }

                }
            }
        }

        public object GetOutParameter(List<OutParameter> parametrosSalida, string nombreParametro)
        {
            OutParameter parametroSalida = parametrosSalida.Find(delegate(OutParameter outParam) { return outParam.nombre == "nombreParametro"; });
            return parametroSalida.valor;
        }

        public Object ExecuteProc(string nombreEsquema, string nombrePaquete, string nombreProcedimiento, List<InParameter> parametrosEntrada, ref List<OutParameter> parametrosSalida, TipoDato eTipoDato)
        {
            object result = new object();
            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    cnConexionSQL.Open();
                    SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                    SqlCommand cmComandoSQL = new SqlCommand();
                    cmComandoSQL.Connection = cnConexionSQL;
                    cmComandoSQL.CommandText = nombreProcedimiento;
                    cmComandoSQL.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoSQL.Parameters.Add(param.nombre, param.tipoSqlServer).Value = param.valor;
                    }
                    foreach (OutParameter param in parametrosSalida)
                    {
                        SqlParameter sqlPm = new SqlParameter(param.nombre, param.tipoSqlServer, param.tamano);
                        sqlPm.Direction = ParameterDirection.Output;
                        cmComandoSQL.Parameters.Add(sqlPm);
                    }

                    dtaAdaptadorSQL.SelectCommand = cmComandoSQL;
                    switch (eTipoDato)
                    {
                        case TipoDato.DataReader:
                            SqlDataReader dtrTemp;
                            dtrTemp = cmComandoSQL.ExecuteReader();
                            result = dtrTemp;
                            break;
                        case TipoDato.DataSet:
                            DataSet dtsTemp = new DataSet();
                            dtaAdaptadorSQL.Fill(dtsTemp, "Temp");
                            result = dtsTemp;
                            break;
                        case TipoDato.Table:
                            DataTable dttTemp = new DataTable();
                            dtaAdaptadorSQL.Fill(dttTemp);
                            result = dttTemp;
                            break;
                        case TipoDato.View:
                            DataTable dttTemp2 = new DataTable();
                            dtaAdaptadorSQL.Fill(dttTemp2);
                            DataView dtvTemp = new DataView();
                            dtvTemp.Table = dttTemp2;
                            result = dtvTemp;
                            break;
                    }
                    cnConexionSQL.Close();
                    break;
                case "Oracle":
                    OracleConnection cnConexionOracle = new OracleConnection(mstrConnectionStringORACLE);

                    cnConexionOracle.Open();

                    OracleDataAdapter dtaAdaptadorOracle = new OracleDataAdapter();
                    OracleCommand cmComandoOracle = new OracleCommand();

                    cmComandoOracle.Connection = cnConexionOracle;
                    string textoComando = "";
                    if (!string.IsNullOrEmpty(nombreEsquema))
                    {
                        textoComando += nombreEsquema + ".";
                    }
                    if (!string.IsNullOrEmpty(nombrePaquete))
                    {
                        textoComando += nombrePaquete + ".";
                    }
                    textoComando += nombreProcedimiento;
                    cmComandoOracle.CommandText = textoComando;
                    cmComandoOracle.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoOracle.Parameters.Add(param.nombre, param.tipoOra).Value = param.valor;
                    }
                    foreach (OutParameter param in parametrosSalida)
                    {
                        OracleParameter opm = new OracleParameter(param.nombre, param.tipoOra, param.tamano);
                        opm.Direction = ParameterDirection.Output;
                        cmComandoOracle.Parameters.Add(opm);
                    }

                    dtaAdaptadorOracle.SelectCommand = cmComandoOracle;
                    switch (eTipoDato)
                    {
                        case TipoDato.DataReader:
                            OracleDataReader dtrTemp;
                            dtrTemp = cmComandoOracle.ExecuteReader();
                            result = dtrTemp;
                            break;
                        case TipoDato.DataSet:
                            DataSet dtsTemp = new DataSet();
                            dtaAdaptadorOracle.Fill(dtsTemp, "Temp");
                            result = dtsTemp;
                            break;
                        case TipoDato.Table:
                            DataTable dttTemp = new DataTable();
                            dtaAdaptadorOracle.Fill(dttTemp);
                            result = dttTemp;
                            break;
                        case TipoDato.View:
                            DataTable dttTemp2 = new DataTable();
                            dtaAdaptadorOracle.Fill(dttTemp2);
                            DataView dtvTemp = new DataView();
                            dtvTemp.Table = dttTemp2;
                            result = dtvTemp;
                            break;
                    }
                    cnConexionOracle.Close();
                    break;

                case "ODBC":

                    OdbcConnection cnConexionOdbc = new OdbcConnection(mstrConnectionStringODBC);
                    cnConexionOdbc.Open();
                    OdbcDataAdapter dtaAdaptadorOdbc = new OdbcDataAdapter();
                    OdbcCommand cmComandoOdbc = new OdbcCommand();
                    cmComandoOdbc.Connection = cnConexionOdbc;

                    string textoComandoOdbc = "";

                    if (!string.IsNullOrEmpty(nombreEsquema))
                    {
                        textoComandoOdbc += nombreEsquema + ".";
                    }
                    if (!string.IsNullOrEmpty(nombrePaquete))
                    {
                        textoComandoOdbc += nombrePaquete + ".";
                    }
                    textoComandoOdbc += nombreProcedimiento;
                    cmComandoOdbc.CommandText = textoComandoOdbc;
                    cmComandoOdbc.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoOdbc.Parameters.Add(param.nombre, param.tipoODBC).Value = param.valor;
                    }

                    foreach (OutParameter param in parametrosSalida)
                    {
                        OdbcParameter opm = new OdbcParameter(param.nombre, param.tipoODBC, param.tamano);
                        opm.Direction = ParameterDirection.Output;
                        cmComandoOdbc.Parameters.Add(opm);
                    }

                    dtaAdaptadorOdbc.SelectCommand = cmComandoOdbc;
                    switch (eTipoDato)
                    {
                        case TipoDato.DataReader:
                            OdbcDataReader dtrTemp;
                            dtrTemp = cmComandoOdbc.ExecuteReader();
                            result = dtrTemp;
                            break;
                        case TipoDato.DataSet:
                            DataSet dtsTemp = new DataSet();
                            dtaAdaptadorOdbc.Fill(dtsTemp, "Temp");
                            result = dtsTemp;
                            break;
                        case TipoDato.Table:
                            DataTable dttTemp = new DataTable();
                            dtaAdaptadorOdbc.Fill(dttTemp);
                            result = dttTemp;
                            break;
                        case TipoDato.View:
                            DataTable dttTemp2 = new DataTable();
                            dtaAdaptadorOdbc.Fill(dttTemp2);
                            DataView dtvTemp = new DataView();
                            dtvTemp.Table = dttTemp2;
                            result = dtvTemp;
                            break;
                    }
                    cnConexionOdbc.Close();
                    break;
            }
            return result;
        }



    }
}
