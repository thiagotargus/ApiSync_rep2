using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Amazon.S3.Model;
using Amazon.S3;

namespace AgileESync
{
    public class AgileECommerceApi
    {
        private string _urlbase;
        private string _token;

        private string _awsAccessKeyId;
        private string _awsSecretAccessKey;
        private string _awsRegionEndpoint;
        private string _awsBucketName;

        public AgileECommerceApi(string urlbase, string token)
        {
            _urlbase = urlbase;
            _token = token;
        }

        public AgileECommerceApi(string urlbase, string token, string awsAccessKeyId, string awsSecretAccessKey, string awsRegionEndpoint, string awsBucketName)
        {
            _urlbase = urlbase;
            _token = token;
            _awsAccessKeyId = awsAccessKeyId;
            _awsSecretAccessKey = awsSecretAccessKey;
            _awsRegionEndpoint = awsRegionEndpoint;
            _awsBucketName = awsBucketName;
        }

        // Classes

        public class MetodoUrl
        {
            public string objTipo { get; set; }
            public string urlTipo { get; set; }
            public string url { get; set; }
        }    

        public class MetodosUrl
        {
            public MetodosUrl ()
            {
                metodos = new List<MetodoUrl>();

                //Metodos Tabela Clientes
                metodos.Add(new MetodoUrl { objTipo = (string)(new Clientes().ToString()), urlTipo = "select", url = "customers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Clientes().ToString()), urlTipo = "insert", url = "customers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Clientes().ToString()), urlTipo = "update", url = "customers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Clientes().ToString()), urlTipo = "delete", url = "customers" });

                //Metodos Tabela PerfisClientes
                metodos.Add(new MetodoUrl { objTipo = (string)(new PerfisClientes().ToString()), urlTipo = "select", url = @"customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PerfisClientes().ToString()), urlTipo = "insert", url = @"customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PerfisClientes().ToString()), urlTipo = "update", url = @"customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PerfisClientes().ToString()), urlTipo = "delete", url = @"customers/groups" });


                //Metodos Tabela ClientesLoja
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClientesLoja().ToString()), urlTipo = "select", url = "customers/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClientesLoja().ToString()), urlTipo = "insert", url = "customers/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClientesLoja().ToString()), urlTipo = "update", url = "customers/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClientesLoja().ToString()), urlTipo = "delete", url = "customers/stores" });

                //Metodos Tabela PerfisClientesLoja
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClienteLoja().ToString()), urlTipo = "select", url = @"customers/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClienteLoja().ToString()), urlTipo = "insert", url = @"customers/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClienteLoja().ToString()), urlTipo = "update", url = @"customers/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new ClienteLoja().ToString()), urlTipo = "delete", url = @"customers/stores" });

                //Metodos Tabela PerfiLCliente
                metodos.Add(new MetodoUrl { objTipo = (string)(new Perfilcliente().ToString()), urlTipo = "select", url = @"customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Perfilcliente().ToString()), urlTipo = "insert", url = @"customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Perfilcliente().ToString()), urlTipo = "update", url = @"customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Perfilcliente().ToString()), urlTipo = "delete", url = @"customers/groups" });

                //Metodos Tabela Rotas
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rotas().ToString()), urlTipo = "select", url = "routes" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rotas().ToString()), urlTipo = "insert", url = "routes" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rotas().ToString()), urlTipo = "update", url = "routes" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rotas().ToString()), urlTipo = "delete", url = "routes" });

                //Metodos Tabela Rota
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rota().ToString()), urlTipo = "select", url = "routes" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rota().ToString()), urlTipo = "insert", url = "routes" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rota().ToString()), urlTipo = "update", url = "routes" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Rota().ToString()), urlTipo = "delete", url = "routes" });

                //Metodos Formas Pagamento
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormasPagamento().ToString()), urlTipo = "select", url = "payments/methods" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormasPagamento().ToString()), urlTipo = "insert", url = "payments/methods" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormasPagamento().ToString()), urlTipo = "update", url = "payments/methods" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormasPagamento().ToString()), urlTipo = "delete", url = "payments/methods" });

                //Metodos Formas Pagamento
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormaPagamento().ToString()), urlTipo = "select", url = "payments/methods" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormaPagamento().ToString()), urlTipo = "insert", url = "payments/methods" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormaPagamento().ToString()), urlTipo = "update", url = "payments/methods" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new FormaPagamento().ToString()), urlTipo = "delete", url = "payments/methods" });

                //Metodos Marcas
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marca().ToString()), urlTipo = "select", url = "brands" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marca().ToString()), urlTipo = "insert", url = "brands" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marca().ToString()), urlTipo = "update", url = "brands" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marca().ToString()), urlTipo = "delete", url = "brands" });

                //Metodos Marcas
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marcas().ToString()), urlTipo = "select", url = "brands" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marcas().ToString()), urlTipo = "insert", url = "brands" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marcas().ToString()), urlTipo = "update", url = "brands" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Marcas().ToString()), urlTipo = "delete", url = "brands" });

                //Metodos Categorias
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categoria().ToString()), urlTipo = "select", url = "departaments" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categoria().ToString()), urlTipo = "insert", url = "departaments" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categoria().ToString()), urlTipo = "update", url = "departaments" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categoria().ToString()), urlTipo = "delete", url = "departaments" });

                //Metodos Categorias
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categorias().ToString()), urlTipo = "select", url = "departaments" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categorias().ToString()), urlTipo = "insert", url = "departaments" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categorias().ToString()), urlTipo = "update", url = "departaments" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Categorias().ToString()), urlTipo = "delete", url = "departaments" });


                //Metodos Produtos
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produto().ToString()), urlTipo = "select", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produto().ToString()), urlTipo = "insert", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produto().ToString()), urlTipo = "update", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produto().ToString()), urlTipo = "delete", url = "products" });

                //Metodos Produtos
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produtos().ToString()), urlTipo = "select", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produtos().ToString()), urlTipo = "insert", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produtos().ToString()), urlTipo = "update", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Produtos().ToString()), urlTipo = "delete", url = "products" });

                //Metodos Embalagem
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagem().ToString()), urlTipo = "select", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagem().ToString()), urlTipo = "insert", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagem().ToString()), urlTipo = "update", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagem().ToString()), urlTipo = "delete", url = "products" });

                //Metodos Embalagem
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagens().ToString()), urlTipo = "select", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagens().ToString()), urlTipo = "insert", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagens().ToString()), urlTipo = "update", url = "products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Embalagens().ToString()), urlTipo = "delete", url = "products" });

                //Metodos Estoque
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoque().ToString()), urlTipo = "select", url = "products/stocks" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoque().ToString()), urlTipo = "insert", url = "products/stocks" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoque().ToString()), urlTipo = "update", url = "products/stocks" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoque().ToString()), urlTipo = "delete", url = "products/stocks" });

                //Metodos Estoque
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoques().ToString()), urlTipo = "select", url = "products/stocks" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoques().ToString()), urlTipo = "insert", url = "products/stocks" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoques().ToString()), urlTipo = "update", url = "products/stocks" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Estoques().ToString()), urlTipo = "delete", url = "products/stocks" });

                //Metodos Loja
                metodos.Add(new MetodoUrl { objTipo = (string)(new Loja().ToString()), urlTipo = "select", url = "stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Loja().ToString()), urlTipo = "insert", url = "stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Loja().ToString()), urlTipo = "update", url = "stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Loja().ToString()), urlTipo = "delete", url = "stores" });

                //Metodos Loja
                metodos.Add(new MetodoUrl { objTipo = (string)(new Lojas().ToString()), urlTipo = "select", url = "stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Lojas().ToString()), urlTipo = "insert", url = "stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Lojas().ToString()), urlTipo = "update", url = "stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Lojas().ToString()), urlTipo = "delete", url = "stores" });

                //Metodos Preços
                metodos.Add(new MetodoUrl { objTipo = (string)(new Preco().ToString()), urlTipo = "select", url = "products/prices" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Preco().ToString()), urlTipo = "insert", url = "products/prices" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Preco().ToString()), urlTipo = "update", url = "products/prices" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Preco().ToString()), urlTipo = "delete", url = "products/prices" });

                //Metodos Preços
                metodos.Add(new MetodoUrl { objTipo = (string)(new Precos().ToString()), urlTipo = "select", url = "products/prices" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Precos().ToString()), urlTipo = "insert", url = "products/prices" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Precos().ToString()), urlTipo = "update", url = "products/prices" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Precos().ToString()), urlTipo = "delete", url = "products/prices" });

                //Metodos DifMercNegociacao
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacao().ToString()), urlTipo = "select", url = "products/prices/modificators" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacao().ToString()), urlTipo = "insert", url = "products/prices/modificators" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacao().ToString()), urlTipo = "update", url = "products/prices/modificators" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacao().ToString()), urlTipo = "delete", url = "products/prices/modificators" });

                //Metodos DifMercNegociacao
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoes().ToString()), urlTipo = "select", url = "products/prices/modificators" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoes().ToString()), urlTipo = "insert", url = "products/prices/modificators" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoes().ToString()), urlTipo = "update", url = "products/prices/modificators" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoes().ToString()), urlTipo = "delete", url = "products/prices/modificators" });

                //Metodos DifMercNegociacao
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoLoja().ToString()), urlTipo = "select", url = "products/prices/modificators/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoLoja().ToString()), urlTipo = "insert", url = "products/prices/modificators/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoLoja().ToString()), urlTipo = "update", url = "products/prices/modificators/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoLoja().ToString()), urlTipo = "delete", url = "products/prices/modificators/stores" });

                //Metodos DifMercNegociacao
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoesLoja().ToString()), urlTipo = "select", url = "products/prices/modificators/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoesLoja().ToString()), urlTipo = "insert", url = "products/prices/modificators/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoesLoja().ToString()), urlTipo = "update", url = "products/prices/modificators/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacoesLoja().ToString()), urlTipo = "delete", url = "products/prices/modificators/stores" });


                //Metodos DifMercUniverso
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniverso().ToString()), urlTipo = "select", url = "products/prices/modificators/triggers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniverso().ToString()), urlTipo = "insert", url = "products/prices/modificators/triggers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniverso().ToString()), urlTipo = "update", url = "products/prices/modificators/triggers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniverso().ToString()), urlTipo = "delete", url = "products/prices/modificators/triggers" });

                //Metodos DifMercUniversos
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniversos().ToString()), urlTipo = "select", url = "products/prices/modificators/triggers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniversos().ToString()), urlTipo = "insert", url = "products/prices/modificators/triggers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniversos().ToString()), urlTipo = "update", url = "products/prices/modificators/triggers" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegociacaoUniversos().ToString()), urlTipo = "delete", url = "products/prices/modificators/triggers" });


                //Metodos DifMercUniverso 
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencia().ToString()), urlTipo = "select", url = "products/prices/modificators/targets" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencia().ToString()), urlTipo = "insert", url = "products/prices/modificators/targets" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencia().ToString()), urlTipo = "update", url = "products/prices/modificators/targets" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencia().ToString()), urlTipo = "delete", url = "products/prices/modificators/targets" });

                //Metodos DifMercUniversos
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencias().ToString()), urlTipo = "select", url = "products/prices/modificators/targets" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencias().ToString()), urlTipo = "insert", url = "products/prices/modificators/targets" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencias().ToString()), urlTipo = "update", url = "products/prices/modificators/targets" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new DifMercNegOcorrencias().ToString()), urlTipo = "delete", url = "products/prices/modificators/targets" });

                //Metodos Promocoes
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocao().ToString()), urlTipo = "select", url = "promotions" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocao().ToString()), urlTipo = "insert", url = "promotions" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocao().ToString()), urlTipo = "update", url = "promotions" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocao().ToString()), urlTipo = "delete", url = "promotions" });

                //Metodos Promocoes
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocoes().ToString()), urlTipo = "select", url = "promotions" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocoes().ToString()), urlTipo = "insert", url = "promotions" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocoes().ToString()), urlTipo = "update", url = "promotions" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Promocoes().ToString()), urlTipo = "delete", url = "promotions" });

                //Metodos Promocoes Loja
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoLoja().ToString()), urlTipo = "select", url = "promotions/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoLoja().ToString()), urlTipo = "insert", url = "promotions/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoLoja().ToString()), urlTipo = "update", url = "promotions/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoLoja().ToString()), urlTipo = "delete", url = "promotions/stores" });

                //Metodos Promocoes Loja
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesLoja().ToString()), urlTipo = "select", url = "promotions/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesLoja().ToString()), urlTipo = "insert", url = "promotions/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesLoja().ToString()), urlTipo = "update", url = "promotions/stores" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesLoja().ToString()), urlTipo = "delete", url = "promotions/stores" });

                //Metodos Promocao Produtos
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProduto().ToString()), urlTipo = "select", url = "promotions/products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProduto().ToString()), urlTipo = "insert", url = "promotions/products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProduto().ToString()), urlTipo = "update", url = "promotions/products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProduto().ToString()), urlTipo = "delete", url = "promotions/products" });

                //Metodos Promocao Produtos
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProdutos().ToString()), urlTipo = "select", url = "promotions/products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProdutos().ToString()), urlTipo = "insert", url = "promotions/products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProdutos().ToString()), urlTipo = "update", url = "promotions/products" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoProdutos().ToString()), urlTipo = "delete", url = "promotions/products" });

                //Metodos PromocaoGrupoCliente
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoGrupoCliente().ToString()), urlTipo = "select", url = "promotions/customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoGrupoCliente().ToString()), urlTipo = "insert", url = "promotions/customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoGrupoCliente().ToString()), urlTipo = "update", url = "promotions/customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocaoGrupoCliente().ToString()), urlTipo = "delete", url = "promotions/customers/groups" });

                //Metodos PromocaoGrupoCliente
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesGrupoCliente().ToString()), urlTipo = "select", url = "promotions/customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesGrupoCliente().ToString()), urlTipo = "insert", url = "promotions/customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesGrupoCliente().ToString()), urlTipo = "update", url = "promotions/customers/groups" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new PromocoesGrupoCliente().ToString()), urlTipo = "delete", url = "promotions/customers/groups" });

                //Metodos Pedidos
                metodos.Add(new MetodoUrl { objTipo = (string)(new Pedido().ToString()), urlTipo = "select", url = "orders" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new Pedido().ToString()), urlTipo = "insert", url = "orders" });

                //Metodos Pedidos
                metodos.Add(new MetodoUrl { objTipo = (string)(new List<Pedido>().ToString()), urlTipo = "select", url = "orders" });
                metodos.Add(new MetodoUrl { objTipo = (string)(new List<Pedido>().ToString()), urlTipo = "insert", url = "orders" });
            }

            public List<MetodoUrl> metodos { get; set; }
        }

        public class AgileESyncJob
        {
            public string Id { get; set; }
            public string Empresa { get; set; }
            public string DataHora { get; set; }
            public string Tabela { get; set; }
            public string Chave { get; set; }
            public string sql_query { get; set; }
            public string sql_where { get; set; }
            public string sql_tipo { get; set; }
            public string IdPlataforma { get; set; }
            public string SN_Atualizou { get; set; }
            public string Url { get; set; }
            public string Status { get; set; }
            public string Json_Envio { get; set; }
            public string Json_Retorno { get; set; }
            public string Log { get; set; }
            public string Url_Metodo { get; set; }
            public string Job_Tipo { get; set; }
            public string Codigo_Retorno { get; set; }
        }

        //Pedido

        public class Pedido
        {
            public string id { get; set; }
            public string instance_id { get; set; }
            public string customer_id { get; set; }
            public string store_id { get; set; }
            public string seller_id { get; set; }
            public string payment_method_id { get; set; }
            public string delivery_method_id { get; set; }
            public string coupon_id { get; set; }
            public string code { get; set; }
            public DateTime datetime { get; set; }
            public int delivery_time { get; set; }
            public string comments { get; set; }
            public decimal store_value { get; set; }
            public decimal total_order { get; set; }
            public string status { get; set; }
            public DateTime created_at { get; set; }
            public Cliente customer { get; set; }
            public string delivery_method { get; set; }
            public Payment payment { get; set; }
            public List<Product> products { get; set; }
            public Loja store { get; set; }
        }

        //Fim Pedido

        //Itens Pedido Inicio

        public class ItemPedido
        {
            public long instance_id { get; set; }
            public long order_id { get; set; }
            public long product_id { get; set; }
            public object store_id { get; set; }
            public object coupon_id { get; set; }
            public double unity_price { get; set; }
            public int quantity { get; set; }
            public decimal products_price { get; set; }
            public decimal discount_value { get; set; }
            public decimal coupon_value { get; set; }
            public decimal delivery_price { get; set; }
            public decimal packing_price { get; set; }
            public decimal warranty_price { get; set; }
            public decimal marketplace_value { get; set; }
            public decimal store_value { get; set; }
            public decimal total_order { get; set; }
            public decimal extra_warranty_time { get; set; }
            public object metadata { get; set; }
            public int gift { get; set; }
            public string status { get; set; }
        }

        //Itens Pedido Fim       

        public class Pedidos
        {
            public List<Pedido> pedidos;
        }

        //Pivot

        public class Pivot
        {
            public long order_id { get; set; }
            public long product_id { get; set; }
            public decimal unity_price { get; set; }
            public int quantity { get; set; }
            public decimal products_price { get; set; }
            public decimal discount_value { get; set; }
            public decimal coupon_value { get; set; }
            public decimal delivery_price { get; set; }
            public decimal packing_price { get; set; }
            public decimal warranty_price { get; set; }
            public decimal marketplace_value { get; set; }
            public decimal store_value { get; set; }
            public decimal total_order { get; set; }
            public decimal extra_warranty_time { get; set; }
            public object metadata { get; set; }
            public int gift { get; set; }
            public string status { get; set; }
        }

        public class PaymentMethod
        {
            public int id { get; set; }
            public object payment_gateway_id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public bool active { get; set; }
        }

        public class Payment
        {
            public long id { get; set; }
            public int payment_method_id { get; set; }
            public long order_id { get; set; }
            public string status { get; set; }
            public PaymentMethod payment_method { get; set; }
        }

        public class Pacotes
        {
            public List<Pacote> pacotes;
        }

        //Pacote
        public class Pacote
        {
            public int? current_page { get; set; }
            public object data { get; set; }
            public string first_page_url { get; set; }
            public int? from { get; set; }
            public int? last_page { get; set; }
            public string last_page_url { get; set; }
            public string next_page_url { get; set; }
            public string path { get; set; }
            public int? per_page { get; set; }
            public string prev_page_url { get; set; }
            public int? to { get; set; }
            public int? total { get; set; }
        }

        //Lojas
        public class Loja
        {
            public string id { get; set; }
            public string name { get; set; }
            public string document_type { get; set; }
            public string document { get; set; }
            public string email { get; set; }
        }

        public class Lojas
        {
            public List<Loja> lojas { get; set; }
        }

        //Produto
        public class Produto
        {
            public string id { get; set; }
            public string brand_id { get; set; }
            public string departament_id { get; set; }
            public string name { get; set; }
            public string description1 { get; set; }
            public List<string> images { get; set; }
            public string status { get; set; }
        }

        public class Produtos
        {
            public List<Produto> produtos { get; set; }
        }

        public class Product
        {
            public long id { get; set; }
            public long instance_id { get; set; }
            public object store_id { get; set; }
            public int? parent_id { get; set; }
            public object brand_id { get; set; }
            public object departament_id { get; set; }
            public object slug_id { get; set; }
            public object code { get; set; }
            public object sku { get; set; }
            public object ean { get; set; }
            public string unity { get; set; }
            public object type { get; set; }
            public string name { get; set; }
            public object slug { get; set; }
            public object short_description { get; set; }
            public object description1 { get; set; }
            public object description2 { get; set; }
            public object description3 { get; set; }
            public decimal weight { get; set; }
            public decimal width { get; set; }
            public decimal height { get; set; }
            public decimal length { get; set; }
            public decimal multiple { get; set; }
            public decimal min_stock { get; set; }
            public decimal min_order { get; set; }
            public decimal stock_quantity { get; set; }
            public decimal regular_price { get; set; }
            public decimal promotion_price { get; set; }
            public decimal special_price { get; set; }
            public decimal sale_price { get; set; }
            public decimal addition { get; set; }
            public decimal discount { get; set; }
            public Pivot pivot { get; set; }
        }

        //Embalagem
        public class Embalagem
        {
            public string id { get; set; }
            public string parent_id { get; set; }
            public string name { get; set; }
            public string unity { get; set; }
            public string multiply { get; set; }
            public string addition { get; set; }
            public string discount { get; set; }
            public string status { get; set; }
        }

        public class Embalagens
        {
            public List<Embalagem> embalagens { get; set; }
        }

        //Estoque do Produto
        public class Estoque
        {
            public int product_id { get; set; }
            public int store_id { get; set; }
            public int min_stock { get; set; }
            public int stock_quantity { get; set; }
            public int sells_without_stock { get; set; }
            public int active { get; set; }
        }

        public class Estoques
        {
            public List<Estoque> estoques { get; set; }
        }

        //Preco
        public class Preco
        {
            public int product_id { get; set; }
            public int store_id { get; set; }
            public int customer_group_id { get; set; }
            public int payment_method_id { get; set; }
            public int regular_price { get; set; }
            public int sale_price { get; set; }
            public int addition { get; set; }
            public int discount { get; set; }
            public int min_order { get; set; }
            public int average_days { get; set; }
            public DateTime start_datetime { get; set; }
            public DateTime end_datetime { get; set; }
            public int active { get; set; }
        }

        public class Precos
        {
            public List<Preco> precos { get; set; }
        }

        //Cliente
        public class Cliente
        {
            public string id { get; set; }
            public string code { get; set; }
            public string store_id { get; set; }
            public string customer_group_id { get; set; }
            public string payment_method_id { get; set; }
            public string route_id { get; set; }
            public string document_type { get; set; }
            public string document { get; set; }
            public string name { get; set; }
            public string company { get; set; }
            public string email { get; set; }
            public string street { get; set; }
            public string neighborhood { get; set; }
            public string number { get; set; }
            public string complement { get; set; }
            public string reference { get; set; }
            public string city_id { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string state_id { get; set; }
            public int zipcode { get; set; }
            public int? cellphone_prefix { get; set; }
            public int? cellphone_number { get; set; }
            public int? work_prefix { get; set; }
            public int? work_number { get; set; }
        }

        public class Clientes
        {
            public List<Cliente> clientes { get; set; }
        }


        // PerfilCliente
        public class Perfilcliente
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public int active { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string deleted_at { get; set; }
        }

        public class PerfisClientes
        {
            public List<Perfilcliente> perfisclientes { get; set; }
        }

        //Cliente Loja
        public class ClienteLoja
        {
            public string customer_id { get; set; }
            public string store_id { get; set; }
        }

        //Cliente Loja
        public class ClientesLoja
        {
            public List<ClienteLoja> clientesloja { get; set; }
        }

        //Rotas
        public class Rota
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public int deadline { get; set; }
            public int active { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object deleted_at { get; set; }
        }

        public class Rotas
        {
            public List<Rota> rotas { get; set; }
        }

        //Condições de Pagamento
        public class FormaPagamento
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public int? start_days { get; set; }
            public int? interval { get; set; }
            public int? installments { get; set; }
            public decimal? average_days { get; set; }
            public decimal? discount { get; set; }
            public decimal? addition { get; set; }
            public int active { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object deleted_at { get; set; }
        }

        public class FormasPagamento
        {
            public List<FormaPagamento> formaspagamento { get; set; }
        }

        public class Marca
        {
            public string id { get; set; }
            public string name { get; set; }
            public int active { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object deleted_at { get; set; }
        }

        public class Marcas
        {
            public List<Marca> marcas { get; set; }
        }

        public class Categoria
        {
            public string id { get; set; }
            public object parent_id { get; set; }
            public string name { get; set; }
            public int active { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object deleted_at { get; set; }
        }

        public class Categorias
        {
            public List<Marca> categorias { get; set; }
        }

        public class DifMercNegociacao
        {
            public int id { get; set; }
            public string name { get; set; }
            public string trigger { get; set; }
            public string target { get; set; }
        }

        public class DifMercNegociacoes
        {
            public List<DifMercNegociacao> difmercnogocioacoes { get; set; }
        }

        //DifMerc Lojas
        public class DifMercNegociacaoLoja
        {
            public int price_modificator_id { get; set; }
            public string store_id { get; set; }
        }

        //DifMerc Lojas
        public class DifMercNegociacoesLoja
        {
            public List<DifMercNegociacaoLoja> difmercnogociacoloja { get; set; }
        }

        //DifMerc Universos
        public class DifMercNegociacaoUniverso
        {
            public int price_modificator_id { get; set; }
            public string store_id { get; set; }
        }

        //DifMerc Lojas
        public class DifMercNegociacaoUniversos
        {
            public List<DifMercNegociacaoUniverso> difmercnegociacaouniverso { get; set; }
        }

        //DifMerc Ocorrencias
        public class DifMercNegOcorrencia
        {
            public int price_modificator_id { get; set; }
            public string object_id { get; set; }
            public double addition { get; set; }
            public double discount { get; set; }
        }

        public class DifMercNegOcorrencias
        {
            public List<DifMercNegOcorrencia> difmercnegocorrencia { get; set; }
        }

        //Promocao
        public class Promocao
        {
            public int id { get; set; }
            public string name { get; set; }
            public double addition { get; set; }
            public double discount { get; set; }
            public int average_days { get; set; }
            public string start_datetime { get; set; }
            public string end_datetime { get; set; }
            public int modifiable { get; set; }
        }

        public class Promocoes
        {
            public List<Promocao> promocoes { get; set; }
        }

        //Promocao Loja
        public class PromocaoLoja
        {
            public int promotion_id { get; set; }
            public int store_id { get; set; }
        }

        public class PromocoesLoja
        {
            public List<PromocaoLoja> promocoesloja { get; set; }
        }

        public class PromocaoProduto
        {
            public int promotion_id { get; set; }
            public int product_id { get; set; }
            public string price { get; set; }
            public string min_order { get; set; }
        }

        public class PromocaoProdutos
        {
            public List<PromocaoProduto> promocaoprodutos { get; set; }
        }

        public class PromocaoGrupoCliente
        {
            public int promotion_id { get; set; }
            public int customer_group_id { get; set; }
        }

        public class PromocoesGrupoCliente
        {
            public List<PromocaoGrupoCliente> promocoesgrupocliente { get; set; }
        }

        public class ProdutoImagem
        {
            public string id_produto { get; set; }
            public string imagem { get; set; }
        }

        //A partir daqui só metodos
        public string EnviarDadosV2(ref AgileESyncJob job)
        {
            bool imageSent = false;

            job.Url = _urlbase + @"/" + job.Url_Metodo;

            var client = new RestClient(job.Url);

            var request = new RestRequest();

            if (job.sql_tipo == "I" || job.sql_tipo == "U")
                request.Method = Method.POST;

            //trantando json para Produtos por causa do campo imagens
            if (job.Tabela.StartsWith("Produto"))
            {
                job.Json_Envio = job.Json_Envio.Replace("\"['", "[\"").Replace("']\"", "\"]");
            }

            //trantando json para true/false
            job.Json_Envio = job.Json_Envio.Replace("\"true\"", "true").Replace("\"false\"", "false");

            // easily add HTTP Headers
            request.AddHeader("Authorization", _token);
            request.AddParameter("application/json", job.Json_Envio, ParameterType.RequestBody);

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            try
            {
                //Trantando regra para o Job ProdutoImagem
                if (job.Tabela == "ProdutoImagem")
                {
                    //Enviando a imagem para o servidor
                    imageSent = EnviarArquivos(JsonConvert.DeserializeObject<ProdutoImagem>(job.Json_Envio).imagem);

                    if (imageSent == false)
                    {
                        job.Status = "E";
                        job.Log = "Arquivo da Imagem não localizado";
                        return "";
                    }
                }

                var response = client.Execute(request);
                var content = response.Content;

                job.Json_Retorno = content;

                job.Codigo_Retorno = response.StatusCode.ToString();

                //Verificando se houve erro no retorno.
                if (response.StatusCode.ToString().ToLower() == "ok"
                 || response.StatusCode.ToString().ToLower() == "created")
                {
                    job.Status = "S";
                }
                else
                {
                    job.Status = "E";
                }

                return content;
            }
            catch (Exception ex)
            {
                job.Status = "F";
                job.Log = ex.Message;
                return "";
            }

        }

        //A partir daqui só metodos
        public string EnviarDados<T>(string urlTipo, string json, ref AgileESyncJob job)
        {
            MetodosUrl metodosurl = new MetodosUrl();

            string metodo = metodosurl.metodos.Where(x => x.objTipo == typeof(T).ToString() && x.urlTipo == urlTipo).Select(x => x.url).FirstOrDefault();

            job.Url = _urlbase + @"/" + metodo;
         
            var client = new RestClient(_urlbase + @"/" + metodo);

            var request = new RestRequest();

            if (urlTipo == "insert")
                request.Method = Method.POST;

            if (urlTipo == "update")
            {
                request.Method = Method.PUT;
            }

            if (urlTipo == "delete")
            {
                request.Method = Method.DELETE;
            }

            //trantando json para Produtos por causa do campo imagens
            if (typeof(T).Name.StartsWith("Produto"))
            {
                json = json.Replace("\"['", "[\"").Replace("']\"", "\"]");
            }

            //trantando json para true/false
            json = json.Replace("\"true\"", "true").Replace("\"false\"", "false");

            job.Json_Envio = json;

            // easily add HTTP Headers
            request.AddHeader("Authorization", _token);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            try
            {
                var response = client.Execute(request);
                var content = response.Content;

                job.Json_Retorno = content;

                //Verificando se houve erro no retorno.
                if (content.ToLower().Contains("error"))
                {
                    job.Status = "E";
                }
                else
                {
                    job.Status = "S";
                }

                return content;
            }
            catch (Exception ex)
            {
                job.Status = "F";
                job.Log = ex.Message;
                return "";
            }

        }

        public T ReceberDados<T>(string urlTipo, string filtro, ref AgileESyncJob job)
        {
            MetodosUrl metodosurl = new MetodosUrl();

            string metodo = metodosurl.metodos.Where(x => x.objTipo == typeof(T).ToString() && x.urlTipo == urlTipo).Select(x => x.url).FirstOrDefault();
            //?code=05&purge=1
            var client = new RestClient(_urlbase + @"/" + metodo + (filtro.Length > 0 ? "?" + filtro : "") + (filtro.Length > 0 ? "&purge=1" : ""));

            var request = new RestRequest(Method.GET);

            // easily add HTTP Headers
            request.AddHeader("Authorization", _token);

            // execute the request
            var response = client.Execute(request);
            var content = response.Content;

            content = content.Replace(":[]", ":null");
            
            //content = content.Replace("\"data\":[", "\"data\":\"[");
            //content = content.Replace("],\"first_page_url", "]\",\"first_page_url");

            var returned_pacote = JsonConvert.DeserializeObject<Pacote>(content);

            return JsonConvert.DeserializeObject<T>((returned_pacote.data == null ? "" : returned_pacote.data.ToString().Replace("[", "").Replace("]", "")));
        }

        public T ReceberDados<T>(string urlTipo, string filtro)
        {
            MetodosUrl metodosurl = new MetodosUrl();

            string metodo = metodosurl.metodos.Where(x => x.objTipo == typeof(T).ToString() && x.urlTipo == urlTipo).Select(x => x.url).FirstOrDefault();
            //?code=05&purge=1
            var client = new RestClient(_urlbase + @"/" + metodo + (filtro.Length > 0 ? "?" + filtro : "") + (filtro.Length > 0 ? "&purge=1" : ""));

            var request = new RestRequest(Method.GET);

            // easily add HTTP Headers
            request.AddHeader("Authorization", _token);

            // execute the request
            var response = client.Execute(request);
            var content = response.Content;

            content = content.Replace(":[]", ":null");

            //content = content.Replace("\"data\":[", "\"data\":\"[");
            //content = content.Replace("],\"first_page_url", "]\",\"first_page_url");

            var returned_pacote = JsonConvert.DeserializeObject<Pacote>(content);

            return JsonConvert.DeserializeObject<T>((returned_pacote.data == null ? "" : returned_pacote.data.ToString()));
        }

        public bool EnviarArquivos(string img)
        {
            string filepath = Geral.frmconfiguracao.txtImagensPath.Text + (Geral.frmconfiguracao.txtImagensPath.Text.EndsWith(@"\") ? "" : @"\") + img;

            if (!System.IO.File.Exists(filepath))
            {
                try
                {
                    using (new NetworkConnection(Geral.frmconfiguracao.txtImagensPath.Text, new System.Net.NetworkCredential("thiago", "821110")))
                    {

                    }
                }
                catch { }
            }

            if (!System.IO.File.Exists(filepath))
            {
                return false;
            }

            var client = new AmazonS3Client(_awsAccessKeyId, _awsSecretAccessKey, Amazon.RegionEndpoint.GetBySystemName(_awsRegionEndpoint));

            try
            {
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = _awsBucketName,
                    FilePath = filepath,
                    ContentType = "text/plain"
                };

                PutObjectResponse response = client.PutObject(putRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                return false;
                //if (amazonS3Exception.ErrorCode != null &&
                //    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                //    ||
                //    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                // {
                //     throw new Exception("Check the provided AWS Credentials.");
                // }
                // else
                // {
                //     throw new Exception("Error occurred: " + amazonS3Exception.Message);
                // }
            }

            return true;
        }

        public List<Pedido> PedidosPendentes()
        {
            List<Pedido> pedidospendentes = new List<Pedido>();

            pedidospendentes = ReceberDados<List<Pedido>>("select", "");

            return pedidospendentes;
        }

    }
}
