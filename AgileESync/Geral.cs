using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Windows.Forms;
using System.Reflection;

namespace AgileESync
{
    public enum ERP
    {
        Harpia,
        Winthor,
        Agile,
        Protheus,
        SoftCom
    }

    public enum BancoDeDados
    {
        Oracle,
        MSSQLServer,
        MYSQL,
        Firebird
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }

    public static class Geral
    {
        //Forms
        public static frmClientes frmclientes;
        public static frmPrincipal frmprincipal;
        public static frmConfiguracao frmconfiguracao;
        public static frmGatilhos frmgatilhos;
        public static frmSplash frmSplash;
        public static frmQuerys frmQuerys;
        public static frmTabelas frmTabelas;
        public static frmCargaGeral frmCargaGeral;

        //Apis
        public static AgileECommerceApi agileapi;
        public static HarpiaApi harpiaapi;
        public static AgileE agilee;

        public static ERP erp;

        public static db banco;

        public static Dicionario dicionario;

        public static string AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string BancoDadosPath()
        {
            return "Data Source=" + System.IO.Path.Combine(Geral.AppPath, "AgileESync.db" + ";Version=3;");
        }

        public static void InstanciaApis()
        {
            Geral.harpiaapi = new AgileESync.HarpiaApi(Geral.HarpiaWMSConStr(Geral.frmconfiguracao.txtIP.Text, Geral.frmconfiguracao.txtPorta.Text, Geral.frmconfiguracao.txtInstancia.Text, Geral.frmconfiguracao.txtUsuario.Text, Geral.frmconfiguracao.txtSenha.Text));
            Geral.agileapi = new AgileECommerceApi(Geral.frmconfiguracao.txtApiUrl.Text, Geral.frmconfiguracao.txtToken.Text, Geral.frmconfiguracao.txtAccessKeyId.Text, Geral.frmconfiguracao.txtSecretAccessKey.Text, Geral.frmconfiguracao.cmbRegionEndpoint.Text, Geral.frmconfiguracao.txtBucketName.Text);
            Geral.agilee = new AgileE();

            //Testando conexao das Apis
            if (!Geral.harpiaapi.TestaConexao())
            {
                MessageBox.Show("Não foi possivel conectar ao Harpia!");
            }
        }

        public static string getAppConStr()
        {
            string constr = "";

            //Verificando Arquivo de Configuração
            switch (Geral.frmconfiguracao.cmbERP.Text)
            {
                case "Harpia":
                    constr = Geral.HarpiaWMSConStr(Geral.frmconfiguracao.txtIP.Text, Geral.frmconfiguracao.txtPorta.Text, Geral.frmconfiguracao.txtInstancia.Text, Geral.frmconfiguracao.txtUsuario.Text, Geral.frmconfiguracao.txtSenha.Text);
                    break;
            }

            return constr;
        }

        public static string getAppConStrEDI()
        {
            string constr = "";

            //Verificando Arquivo de Configuração
            switch (Geral.frmconfiguracao.cmbERP.Text)
            {
                case "Harpia":
                    constr = Geral.HarpiaWMSConStr(Geral.frmconfiguracao.txtIP.Text, Geral.frmconfiguracao.txtPorta.Text, Geral.frmconfiguracao.txtInstancia.Text, "ESTALO_EDI", "ESTALO_EDI");
                    break;
            }

            return constr;
        }

        public static string HarpiaWMSConStr(string IP, string Porta, string NomeInstancia, string Usuario, string Senha)
        {
            return string.Format("SERVER = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1}))(CONNECT_DATA = (SERVICE_NAME = {2}))); uid = {3}; pwd = {4};", IP, Porta, NomeInstancia, Usuario, Senha);
        }

        public static string DataTableToJson(DataTable dt)
        {
            DataSet ds = new DataSet();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ContractResolver = new LowercaseContractResolver()
            };

            ds.Tables.Add(dt);

            return JsonConvert.SerializeObject(ds, Formatting.None, settings);
        }

        public static string DataTableToJson(DataTable dt, bool singlerow)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ContractResolver = new LowercaseContractResolver()                
            };

            string json = JsonConvert.SerializeObject(dt, Formatting.None, settings);

            if (singlerow)
            {
                json = json.Remove(0, 1);
                json = json.Remove(json.Length - 1, 1);
            }

            return json;
        }

        public static List<AgileECommerceApi.AgileESyncJob> DataTableToSyncJob(DataTable dt)
        {
            List<AgileECommerceApi.AgileESyncJob> listSyncJob = new List<AgileECommerceApi.AgileESyncJob>();

            AgileECommerceApi.AgileESyncJob job;

            foreach (DataRow r in dt.Rows)
            {
                job = new AgileECommerceApi.AgileESyncJob();

                job.Id = r["ID"].ToString();
                job.Empresa = r["EMPRESA"].ToString();
                job.DataHora = r["DATAHORA"].ToString();
                job.Tabela = r["TABELA"].ToString();
                job.sql_where = r["SQL_WHERE"].ToString();
                job.sql_tipo = r["SQL_TIPO"].ToString();
                job.Status = r["STATUS"].ToString();

                listSyncJob.Add(job);
            }

            return listSyncJob;
        }

        public static List<T> ToListof<T>(this DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }

    }
}
