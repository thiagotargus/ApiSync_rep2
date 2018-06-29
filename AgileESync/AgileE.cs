using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using static AgileESync.AgileECommerceApi;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AgileESync
{
    public class AgileE
    {
        HarpiaApi harpiaapi;

        public class Tabela
        {
            //Teste Sync Rep2
            public string TABLE_NAME { get; set; }
        }

        public class Campo
        {
            public decimal ID { get; set; }
            public string COLUNA { get; set; }
        }

        public DataTable ExecutarQuery(string query)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.ExecutarQuery(query);
                    break;
            }

            return dt;
        }

        public void GerarNoBanco(string query)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    harpiaapi.GravarNoBanco(query);
                    break;
            }

        }

        public void Open()
        {

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    harpiaapi.Open();
                    break;
            }

        }

        public void Close()
        {

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    harpiaapi.Close();
                    break;
            }

        }

        public void GravarNoBancoBulk(string query)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    harpiaapi.GravarNoBancoBulk(query);
                    break;
            }

        }

        public bool setPedido(AgileECommerceApi.Pedido pedido)
        {
            bool didWork = false;

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    didWork = harpiaapi.InternalizaPedido(pedido);
                    break;
            }

            return didWork;
        }

        public DataTable getData(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getData(job);
                    break;
            }

            return dt;
        }

        public DataTable getPedidoStatus(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPedidoStatus(job);
                    break;
            }

            return dt;
        }

        public DataTable getPedido(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPedido(job);
                    break;
            }

            return dt;
        }

        public DataTable getPedidoItens(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPedidoItens(job);
                    break;
            }

            return dt;
        }

        public DataTable getPromocaoGrupoDeCliente()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocaoGrupoDeCliente();
                    break;
            }

            return dt;
        }

        public DataTable getPromocaoGrupoDeCliente(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocaoGrupoDeCliente(job);
                    break;
            }

            return dt;
        }

        //PromocaoProduto
        public DataTable getPromocaoProduto()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocaoProduto();
                    break;
            }

            return dt;
        }

        public DataTable getPromocaoProduto(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocaoProduto(job);
                    break;
            }

            return dt;
        }

        //Promocao Loja
        public DataTable getPromocaoLoja()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocaoLoja();
                    break;
            }

            return dt;
        }

        public DataTable getPromocaoLoja(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocaoLoja(job);
                    break;
            }

            return dt;
        }

        //Difirenttes Mercados Ocorrencia
        public DataTable getPromocoes()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocao();
                    break;
            }

            return dt;
        }

        public DataTable getPromocoes(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPromocao(job);
                    break;
            }

            return dt;
        }


        //Difirenttes Mercados Ocorrencia
        public DataTable getDifMercNegOcorrencias()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegOcorrencias();
                    break;
            }

            return dt;
        }

        public DataTable getDifMercNegOcorrencias(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegOcorrencias(job);
                    break;
            }

            return dt;
        }

        //Difirenttes Mercados Loja
        public DataTable getDifMercNegociacaoUnivereso()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegUniversos();
                    break;
            }

            return dt;
        }

        public DataTable getDifMercNegociacaoUnivereso(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegUniversos(job);
                    break;
            }

            return dt;
        }

        //Difirenttes Mercados Loja
        public DataTable getDifMercNeg(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegUniversos();
                    break;
            }

            return dt;
        }

        //Difirenttes Mercados Loja
        public DataTable getDifMercNegociacaoLoja()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegociacaoLoja();
                    break;
            }

            return dt;
        }

        public DataTable getDifMercNegociacaoLoja(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegociacaoLoja(job);
                    break;
            }

            return dt;
        }

        //Difirenttes Mercados.
        public DataTable getDifMercNegociacao()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegociacao();
                    break;
            }

            return dt;
        }

        public DataTable getDifMercNegociacao(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch(Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getDifMercNegociacao(job);
                    break;
            }

            return dt;
        }

        public DataTable getClientes()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getClientes();
                    break;

            }

            return dt;
        }

        public DataTable getClientes(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getClientes(job);
                    break;

            }

            return dt;
        }

        public DataTable getClientesLoja()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getClientesLoja();
                    break;

            }

            return dt;
        }

        public DataTable getClientesLoja(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getClientesLoja(job);
                    break;

            }

            return dt;
        }

        public DataTable getPerfisClientes()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPerfisClientes();
                    break;

            }

            return dt;
        }

        public DataTable getPerfisClientes(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPerfisClientes(job);
                    break;

            }

            return dt;
        }

        public DataTable getRotas()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getRotas();
                    break;

            }

            return dt;
        }

        public DataTable getRotas(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getRotas(job);
                    break;

            }

            return dt;
        }

        public DataTable getCondComer()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getCondComer();
                    break;

            }

            return dt;
        }

        public DataTable getCondComer(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getCondComer(job);
                    break;

            }

            return dt;
        }

        public DataTable getMarca()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getMarcas();
                    break;

            }

            return dt;
        }

        public DataTable getMarca(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getMarcas(job);
                    break;

            }

            return dt;
        }

        public DataTable getCategoria()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getCategorias();
                    break;

            }

            return dt;
        }

        public DataTable getCategoria(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getCategorias(job);
                    break;

            }

            return dt;
        }

        public DataTable getProduto()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getProdutos();
                    break;

            }

            return dt;
        }

        public DataTable getProduto(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getProdutos(job);
                    break;

            }

            return dt;
        }

        public DataTable getEmbalagem()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getEmbalagens();
                    break;

            }

            return dt;
        }

        public DataTable getEmbalagem(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getEmbalagens(job);
                    break;

            }

            return dt;
        }

        public DataTable getEstoque()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getEstoque();
                    break;

            }

            return dt;
        }

        public DataTable getEstoque(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getEstoque(job);
                    break;

            }

            return dt;
        }

        public DataTable getPreco()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPreco();
                    break;

            }

            return dt;
        }

        public DataTable getPreco(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getPreco(job);
                    break;

            }

            return dt;
        }

        public DataTable getLoja()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getLojas();
                    break;

            }

            return dt;
        }

        public DataTable getLoja(AgileESyncJob job)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getLojas(job);
                    break;

            }

            return dt;
        }

        public DataTable getTabelas()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getTabelas();
                    break;

            }

            return dt;
        }

        public DataTable getCampos(string chave)
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getCampos(chave);
                    break;
            }

            return dt;
        }

        public string getGatilho(string tabela_erp, string tabela_agileecommerce, string[] campos, string[] camposchave, ref string nomegatilho)
        {
            string retorno = "";

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    retorno = harpiaapi.GerarGatilho(tabela_erp, tabela_agileecommerce, campos, camposchave, ref nomegatilho);
                    break;

            }

            return retorno;
        }

        public DataTable getSyncJob()
        {
            DataTable dt = new DataTable();

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    dt = harpiaapi.getSyncJob();
                    break;

            }

            return dt;
        }

        public void updateSyncJobStatus(string Id)
        {

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    harpiaapi.updateSyncJobStatus(Id);
                    break;

            }

        }

        public void updateSyncJobStatus(AgileECommerceApi.AgileESyncJob job)
        {
            //Verificando se existe um erro no Job e tentando fazer o ajuste de forma automatica.
            try
            {
                if (job.Status == "E")
                {
                    string jsonRetorno = job.Json_Retorno.Remove(0, 1);
                    jsonRetorno = jsonRetorno.Remove(jsonRetorno.Length - 1, 1);

                    dynamic jRetorno = JObject.Parse(jsonRetorno);

                    foreach (JProperty property in jRetorno)
                    {
                        if (property.Name == "error") //Verificando Property Erro
                        {
                            dynamic jErrors = JObject.Parse(property.Value.ToString());

                            foreach (JProperty erro in jErrors)
                            {
                                //Verificando se a propriedade é invalida
                                if (erro.Value.ToString().Contains("is invalid"))
                                {
                                    string IDValue = doRetrivePropertyValue(job.Json_Envio, erro.Name);

                                    //Criando linha na tabela de controle para enviar o registro que foi identificando como invalido no retorno.

                                }
                            }
                        }
                    }
                }
            }
            catch { }

            switch (Geral.erp)
            {
                case ERP.Harpia:
                    HarpiaApi harpiaapi = new HarpiaApi(Geral.getAppConStr());
                    harpiaapi.updateSyncJobStatus(job);
                    break;
            }
        }

        private string doRetrivePropertyValue(string jsonEnvio, string propertyname)
        {
            string propertyvalue = "";

            jsonEnvio = jsonEnvio.Remove(0, 1);
            jsonEnvio = jsonEnvio.Remove(jsonEnvio.Length - 1, 1);

            dynamic jRetorno = JObject.Parse(jsonEnvio);

            foreach (JProperty property in jRetorno)
            {
                if (property.Name == propertyname) 
                {
                    propertyvalue = property.Value.ToString();
                }
            }

            return propertyvalue;
        }

        public AgileECommerceApi.AgileESyncJob doJob(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            //if (job.Tabela.EndsWith("Cliente"))
            //    TrataJob_59(job, ref bgw);

            //if (job.Tabela.EndsWith("ClienteLoja"))
            //    TrataJob_ClienteLoja(job, ref bgw);

            //if (job.Tabela.EndsWith("PerfilCliente"))
            //    TrataJob_PerfilCliente(job, ref bgw);

            //if (job.Tabela.EndsWith("Rota"))
            //    TrataJob_Rota(job, ref bgw);

            //if (job.Tabela.EndsWith("CondicaoComercial"))
            //    TrataJob_CondicaoComercial(job, ref bgw);

            //if (job.Tabela.EndsWith("Marca"))
            //    TrataJob_Marca(job, ref bgw);

            //if (job.Tabela.EndsWith("Categoria"))
            //    TrataJob_Categoria(job, ref bgw);

            //if (job.Tabela.EndsWith("Produto"))
            //    TrataJob_Produto(job, ref bgw);

            //if (job.Tabela.EndsWith("Embalagem"))
            //    TrataJob_Embalagem(job, ref bgw);

            //if (job.Tabela.EndsWith("Estoque"))
            //    TrataJob_Estoque(job, ref bgw);

            //if (job.Tabela.EndsWith("Loja"))
            //    TrataJob_Loja(job, ref bgw);

            //if (job.Tabela.EndsWith("Preco"))
            //    TrataJob_Preco(job, ref bgw);

            //if (job.Tabela.EndsWith("DifMercNegociacao"))
            //    TrataJob_DifMercNogocioacao(job, ref bgw);

            //if (job.Tabela.EndsWith("DifMercNegLoja"))
            //    TrataJob_DifMercNogocioacaoLoja(job, ref bgw);

            //if (job.Tabela.EndsWith("DifMercNegUni"))
            //{
            //    TrataJob_DifMercNegocioacaoUniverso(job, ref bgw);
            //}

            //if (job.Tabela.EndsWith("DifMercNegOcorrencia"))
            //{
            //    TrataJob_DifMercNegOcorrencia(job, ref bgw);
            //}

            //if (job.Tabela.EndsWith("Promocao"))
            //    TrataJob_Promocao(job, ref bgw);

            //if (job.Tabela.EndsWith("PromocaoLoja"))
            //    TrataJob_PromocaoLoja(job, ref bgw);

            //if (job.Tabela.EndsWith("PromocaoProduto"))
            //    TrataJob_PromocaoProduto(job, ref bgw);

            //if (job.Tabela.EndsWith("PromocaoGrupoCliente"))
            //    TrataJob_PromocaoGrupoCliente(job, ref bgw);

            //if (job.Tabela.EndsWith("PedidoStatus"))
            //    TrataJob_PedidoStatus(job, ref bgw);

            return TrataJob(job, ref bgw);
        }

        private void TrataJob_59(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "DEL_59")
                {
                    //Deletando o cliente na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Clientes>("delete", Geral.DataTableToJson(this.getClientes(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Cliente ID " + job.Chave);
                }
                else
                {
                    //Inserindo o cliente na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Clientes>("insert", Geral.DataTableToJson(this.getClientes(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo Cliente ID " + job.Chave);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_PerfilCliente(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            //Verificando se o Perfil do Cliente já existe na Plataforma
            //var retorno = Geral.agileapi.ReceberDados<AgileECommerceApi.Perfilcliente>("select", "code=" + job.Chave);

            try
            {
                if (job.sql_tipo == "D")
                {
                    //Deletando o PefilCliente na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Perfilcliente>("delete", Geral.DataTableToJson(this.getPerfisClientes(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando PerfilCliente WHERE " + job.sql_where);
                }
                else
                {                        
                    //Inserindo/Atualizando o PefilCliente na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Perfilcliente>("insert", Geral.DataTableToJson(this.getPerfisClientes(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo PerfilCliente WHERE " + job.sql_where);
                }
                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Rota(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.sql_tipo == "D")
                {
                    //Deletando o rota na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Rota>("delete", Geral.DataTableToJson(this.getRotas(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Rota WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a rota na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Rotas>("insert", Geral.DataTableToJson(this.getRotas(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Nova Rota WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_CondicaoComercial(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando o getCondComer na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.FormaPagamento>("delete", Geral.DataTableToJson(this.getCondComer(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando CondComer WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a getCondComer na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.FormasPagamento>("insert", Geral.DataTableToJson(this.getCondComer(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Nova CondComer WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Marca(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Marca>("delete", Geral.DataTableToJson(this.getMarca(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Marca WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Marca>("insert", Geral.DataTableToJson(this.getMarca(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Nova Marca WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Categoria(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Categoria>("delete", Geral.DataTableToJson(this.getCategoria(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Categoria WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Categoria>("insert", Geral.DataTableToJson(this.getCategoria(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Nova Categoria WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Produto(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Produto>("delete", Geral.DataTableToJson(this.getProduto(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Produto WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Produto>("insert", Geral.DataTableToJson(this.getProduto(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo Produto WHERE " + job.sql_where);
                }

                //Fazendo Upload da Imagem do produto.
                if (job.Status == "S")
                {
                    Produto p = JsonConvert.DeserializeObject<Produto>(job.Json_Envio.Remove(job.Json_Envio.Length - 1, 1).Remove(0, 1));

                    foreach (string img in p.images)
                    {
                        //Verificando se o arquivo existe
                        string filepath = Geral.frmconfiguracao.txtImagensPath.Text + (Geral.frmconfiguracao.txtImagensPath.Text.EndsWith(@"\") ? "" : @"\") + img;

                        if (System.IO.File.Exists(filepath))
                            Geral.agileapi.EnviarArquivos(filepath);
                    }
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_Embalagem(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Embalagem>("delete", Geral.DataTableToJson(this.getEmbalagem(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Embalagem WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Embalagem>("insert", Geral.DataTableToJson(this.getEmbalagem(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Nova Embalagem WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Estoque(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Estoque>("delete", Geral.DataTableToJson(this.getEstoque(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Estoque WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Estoque>("insert", Geral.DataTableToJson(this.getEstoque(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo Estoque WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Loja(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Loja>("delete", Geral.DataTableToJson(this.getLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Loja WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Loja>("insert", Geral.DataTableToJson(this.getLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Nova Loja WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch { }
        }

        private void TrataJob_Preco(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Preco>("delete", Geral.DataTableToJson(this.getPreco(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Preço WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Preco>("insert", Geral.DataTableToJson(this.getPreco(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo Preço WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch(Exception ex)
            {

            }
        }

        private void TrataJob_DifMercNogocioacao(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegociacao>("delete", Geral.DataTableToJson(this.getDifMercNegociacao(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando DifMerc Negociacao WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegociacao>("insert", Geral.DataTableToJson(this.getDifMercNegociacao(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo DifMerc Negociacao WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_DifMercNogocioacaoLoja(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegociacaoLoja>("delete", Geral.DataTableToJson(this.getDifMercNegociacaoLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando DifMerc Negociacao WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegociacaoLoja>("insert", Geral.DataTableToJson(this.getDifMercNegociacaoLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo DifMerc Negociacao WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_DifMercNegocioacaoUniverso(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegociacaoUniverso>("delete", Geral.DataTableToJson(this.getDifMercNegociacaoUnivereso(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando DifMerc Universo WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegociacaoUniverso>("insert", Geral.DataTableToJson(this.getDifMercNegociacaoUnivereso(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo DifMerc Univereso WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_DifMercNegOcorrencia(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegOcorrencia>("delete", Geral.DataTableToJson(this.getDifMercNegOcorrencias(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando DifMerc Ocorrencia WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.DifMercNegOcorrencias>("insert", Geral.DataTableToJson(this.getDifMercNegOcorrencias(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo DifMerc Ocorrencia WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_ClienteLoja(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.ClienteLoja>("delete", Geral.DataTableToJson(this.getClientesLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando DifMerc Ocorrencia WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.ClienteLoja>("insert", Geral.DataTableToJson(this.getClientesLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Novo DifMerc Ocorrencia WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_Promocao(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Promocao>("delete", Geral.DataTableToJson(this.getPromocoes(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Promocao WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Promocao>("insert", Geral.DataTableToJson(this.getPromocoes(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Promocao WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_PromocaoLoja(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.PromocaoLoja>("delete", Geral.DataTableToJson(this.getPromocaoLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando PromocaoLoja WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.PromocaoLoja>("insert", Geral.DataTableToJson(this.getPromocaoLoja(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo PromocaoLoja WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_PromocaoProduto(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.PromocaoProduto>("delete", Geral.DataTableToJson(this.getPromocaoProduto(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando PromocaoProduto WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.PromocaoProduto>("insert", Geral.DataTableToJson(this.getPromocaoProduto(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo PromocaoProduto WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private void TrataJob_PromocaoGrupoCliente(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.PromocaoGrupoCliente>("delete", Geral.DataTableToJson(this.getPromocaoGrupoDeCliente(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando PromocaoGrupoCliente WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.PromocaoGrupoCliente>("insert", Geral.DataTableToJson(this.getPromocaoGrupoDeCliente(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo PromocaoGrupoCliente WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        private AgileECommerceApi.AgileESyncJob TrataJob(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            //Verificando o Job
            var tabela = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas").Where(x => x.Nome == job.Tabela).FirstOrDefault(); 

            if (tabela == null)
            {
                System.Windows.Forms.MessageBox.Show("Tabela : " + job.Tabela + " não configurada!");
                return job;
            }

            job.Url_Metodo = tabela.Url;
            job.sql_query = tabela.Query;

            try
            {
                job.Json_Envio = Geral.DataTableToJson(this.getData(job), true);

                Geral.agileapi.EnviarDadosV2(ref job);
                bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - " + job.sql_tipo + " " +  job.Tabela + " WHERE " + job.sql_where);

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }

            return job;
        }

        public void TrataJob_Pedido(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                if (job.Tabela == "D")
                {
                    //Deletando a Marca na plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Pedido>("delete", Geral.DataTableToJson(this.getPedido(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Deletando Pedido WHERE " + job.sql_where);
                }
                else
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Pedido>("insert", Geral.DataTableToJson(this.getPedido(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Inserindo Pedido WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }

        public void TrataJob_PedidoStatus(AgileECommerceApi.AgileESyncJob job, ref BackgroundWorker bgw)
        {
            try
            {
                {
                    //Inserindo a Marca na Plataforma
                    Geral.agileapi.EnviarDados<AgileECommerceApi.Pedido>("insert", Geral.DataTableToJson(this.getPedidoStatus(job), true), ref job);
                    bgw.ReportProgress(0, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Atualizando Pedido WHERE " + job.sql_where);
                }

                updateSyncJobStatus(job);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
