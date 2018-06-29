using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileESync
{
    public class Dicionario
    {
        db banco;

        private string[] tabelasplataforma = new string[] { "Filial|Filiais|FIL|filiais|01",
                                                            "Rota|Rotas|ROT|rotas|02",
                                                            "FormaPagamento|Formas de Pagamento|FPG|formaspagamento|03",
                                                            "Segmento|Segmentos|SEG|segmentos|04",
                                                            "UF|UFs|UFS|ufs|05",
                                                            "Cidade|Cidades|CID|cidades|06",
                                                            "Cliente|Clientes|CLI|clientes|07",
                                                            "ClienteFilial|Clientes x Filiais|CFI|clientes/filiais|08",
                                                            "ClienteFormaPagamento|Clientes x Formas de Pagamento|CFP|clientes/formaspagamento|09",
                                                            "ClienteRota|Clientes x Rotas|CRO|clientes/rotas|10",
                                                            "ClienteVendedor|Clientes x Vendedores|CVE|clientes/vendedores|11",
                                                            "Marca|Marcas|MAR|marcas|12",
                                                            "Departamento|Departamentos|DEP|departamentos|13",
                                                            "Produto|Produtos|PRO|produtos|14",
                                                            "Embalagem|Produtos x Embalagens|||15",
                                                            "ProdutoFilial|Produtos x Filiais|PRF|produtos/filiais|16",
                                                            "ProdutoImagem|Produtos x Imagens|PRI|produtos/imagens|17",
                                                            "ProdutoDepartamento|Produtos x Departamentos|PDE|produtos/departamentos|18",
                                                            "Precificador|Precificadores|PRE|precificadores|19",
                                                            "PrecificadorFilial|Precificadores x Filiais|PFI|precificadores/filiais|20",
                                                            "PrecificadorUniverso|Precificadores x Universos|PUN|precificadores/universos|21",
                                                            "PrecificadorOcorrencia|Precificadores x Ocorrências|POC|precificadores/ocorrencias|22",
                                                            "Promocao|Promoções|PRM|promocoes|23",
                                                            "PromocaoFilial|Promoções x Filiais|PMF|promocoes/filiais|24",
                                                            "PromocaoProduto|Promoções x Produtos|PMP|promocoes/produtos|25",
                                                            "PromocaoSegmento|Promoções x Segmentos|PMS|PMS|26" };

        public Dicionario()
        {
            banco = new db(Geral.BancoDadosPath());
        }

        public class Tabelas
        {
            public string Nome { get; set; }
            public string NomeERP { get; set; }
            public string Query { get; set; }
            public string Filtro { get; set; }
            public string Ordenacao { get; set; }
            public string Url { get; set; }
            public string Descricao { get; set; }
            public string Modulo { get; set; }
        }

        public class Campos
        {
            public string Tabela { get; set; }
            public string Campo { get; set; }
            public string CampoERP { get; set; }
            public string Tipo { get; set; }
            public string Tamanho { get; set; }
            public string Precisao { get; set; }
            public string MascaraERP { get; set; }
        }

        public class Gatilhos
        {
            public string TabelaNome { get; set; }
            public string Nome { get; set; }
            public string TabelaNomeERP { get; set; }
            public string GatilhoNome { get; set; }
            public string GatilhoScript { get; set; }
        }

        public class GatilhoCampos
        {
            public string TabelaNome { get; set; }
            public string CampoNome { get; set; }
            public string CampoTipo { get; set; }
        }

        public void VerificaTabelas()
        {
            var tabelas = banco.LerNoBanco<Tabelas>("Select * from Tabelas");

            foreach (var tabelaplataforma in tabelasplataforma)
            {
                string[] tabelaplataforma_splited = tabelaplataforma.Split('|');

                string nome_tabela = tabelaplataforma_splited[0];
                string descricao_tabela = tabelaplataforma_splited[1];
                string modulo_tabela = tabelaplataforma_splited[2];
                string url_tabela = tabelaplataforma_splited[3];
                string ordenacao_tabela = tabelaplataforma_splited[4];

                var tabela = tabelas.Where(x => x.Nome == nome_tabela).FirstOrDefault();

                if (tabela == null)
                {
                    banco.ExecutarComando("INSERT INTO Tabelas (Nome, Descricao, Modulo, Ordenacao, Url) Values ('" + nome_tabela + "', '"+ descricao_tabela + "', '" + modulo_tabela + "', " + ordenacao_tabela + ", '" + url_tabela + "')");
                }
                else
                {
                    banco.ExecutarComando("UPDATE Tabelas SET Descricao = '" + descricao_tabela + "', Modulo = '" + modulo_tabela + "', Ordenacao = " + ordenacao_tabela + " WHERE Nome = '" + nome_tabela + "'");
                }    
            }                   
        }

    }
}
