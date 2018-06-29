using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Collections;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using AutoMapper.Mappers;
using System.Dynamic;
using AutoMapper;

namespace AgileESync
{
    public class db
    {
        public db()
        {

        }

        public db(string dbPath)
        {
            dbConn = new SQLiteConnection(dbPath);
            dbCommand = new SQLiteCommand(dbConn);
        }

        private string _mensagem;
        private SQLiteConnection dbConn;
        private SQLiteCommand dbCommand;
        private SQLiteDataReader Reader;
        private SQLiteTransaction dbTransaction;

        private enum Entradas
        {
            enNADA, enFLD, enPKY, enIDX, enTOT, enDAT
        }

        public enum ModoDeProcessamento
        {
            mpTudo, mpSchema, mpDados
        }

        public SQLiteTransaction BeginTransaction()
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbTransaction = dbConn.BeginTransaction();

            return dbTransaction;
        }

        public void TransactionRoolBack(SQLiteTransaction t)
        {
            t.Rollback();
            dbConn.Close();
        }

        public void TransactionCommit(SQLiteTransaction t)
        {
            t.Commit();
            dbConn.Close();
        }

        public bool ExecutarComando(string comandoSQL)
        {
            _mensagem = "";
            try
            {
                // Abre o Banco de Dados
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                // Executa o comando SQL
                dbCommand.CommandText = comandoSQL;
                dbCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                return false;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public bool ExecutarComando(string comandoSQL, SQLiteTransaction t)
        {
            new SQLiteCommand(comandoSQL, t.Connection, t).ExecuteNonQuery();
            return true;
        }

        public DataTable LerNoBanco(string SqlCom)
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            DataTable dtResp = new DataTable();

            dbCommand.CommandText = SqlCom;
            Reader = dbCommand.ExecuteReader();
            dtResp.Load(Reader);

            Reader.Close();
            dbConn.Close();

            return dtResp;
        }

        public List<T> LerNoBanco<T>(string SqlCom)
        {
            List<T> retorno;

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCommand.CommandText = SqlCom;
            Reader = dbCommand.ExecuteReader();

            if (Reader.HasRows)
            {
                retorno = Mapper.DynamicMap<IDataReader, List<T>>(Reader);
            }
            else
            {
                retorno = new List<T>();
            }

            Reader.Close();
            dbConn.Close();

            return retorno;
        }

        public DataTable LerNoBanco(string SqlCom, SQLiteTransaction t)
        {
            DataTable dtResp = new DataTable();

            Reader = new SQLiteCommand(SqlCom, t.Connection, t).ExecuteReader();
            dtResp.Load(Reader);

            Reader.Close();

            return dtResp;
        }

        public bool TabelaExiste(string nomeDaTabela)
        {
            _mensagem = "";
            try
            {
                var result = LerNoBanco("select count(*) from sqlite_master where upper(type)='TABLE' and upper(name)='" + nomeDaTabela.ToUpper() + "'");

                // Executa o comando
                return Convert.ToInt32(result.Rows[0][0]) > 0;
            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                throw new Exception(ex.Message);
            }
            finally
            {
                // Fecha o Banco de Dados
                dbConn.Close();
            }
        }

        private bool IndiceExiste(string nomeDaTabela, string nomeDoIndice)
        {
            _mensagem = "";
            try
            {
                var result = LerNoBanco("select count(*) from sqlite_master where upper(type)='INDEX' and upper(tbl_name)='" + nomeDaTabela.ToUpper() + "' and upper(name)='" + nomeDoIndice.ToUpper() + "'");

                // Executa o comando
                return Convert.ToInt32(result.Rows[0][0]) > 0;

            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                throw new Exception(ex.Message);
            }
            finally
            {
                // Fecha o Banco de Dados
                dbConn.Close();
            }
        }

        public void DropTable(String nomeDaTabela)
        {
            ExecutarComando(String.Format("DROP TABLE IF EXISTS %s", nomeDaTabela));
        }

        public bool ProcessarTabelasDoDicionario(string prefixo, bool processarDados, ref BackgroundWorker bgw)
        {
            bool resultado = false;

            // Acessa os Assets da aplicação
            Type resourceType = Type.GetType("AgileESync.Properties.Resources");
            PropertyInfo[] resourceProps = resourceType.GetProperties();

            // Acessa os Assets da aplicação
            string nomeDaTabela = "";
            try
            {
                // Abre o Banco de Dados
                dbConn.Open();

                //Atualizando Splash
                bgw.ReportProgress(0, "Verificando banco de dados Movimento...");
                foreach (PropertyInfo info in resourceProps)
                {
                    string arquivo = info.Name;
                    object value = info.GetValue(null, null);  // object can be an image, a string whatever

                    // Verifica o nome do arquivo
                    if (!arquivo.Substring(0, 4).Equals(prefixo))
                        continue;

                    // Nome da tabela
                    nomeDaTabela = arquivo.Substring(4, arquivo.Length - 4);

                    //Abre o arquivo
                    StreamReader stream;

                    //Atualizando Splash
                    //Atualizando Splash
                    bgw.ReportProgress(0, String.Format("Verificando tabela {0}...", nomeDaTabela));

                    // convert string to stream
                    byte[] byteArray = Encoding.UTF8.GetBytes((string)value);
                    //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                    MemoryStream ms = new MemoryStream(byteArray);

                    stream = new StreamReader(ms);

                    //Processa os dados da tabela
                    if (!ProcessarTabela(nomeDaTabela, stream, (processarDados ? ModoDeProcessamento.mpTudo : ModoDeProcessamento.mpSchema), ref bgw))
                    {
                        // Encerra o processamento
                        stream.Close();
                        resultado = false;

                        break;
                    }

                    //Fecha o arquivo
                    stream.Close();

                }

            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                return false;
            }
            finally
            {
                // Fecha o Banco de Dados
                dbConn.Close();
            }

            return resultado;
        }

        public bool ProcessarTabela(String nomeDaTabela, StreamReader stream, ModoDeProcessamento modoDeProcessamento, ref BackgroundWorker bgw)
        {
            StringBuilder sb = new StringBuilder(1000);
            bool resultado = true;
            int bytesLidos = 0;
            int ultimoPercentual = 0;

            // Objeto para armazenar a estrutura da tabela
            List<EstruturaDoCampo> estruturaDaTabela = new List<EstruturaDoCampo>();

            // Indica se a tabela tem chave primária
            bool tabelaTemChavePrimaria = false;

            // Tamanho do arquivo
            long tamanhoDoArquivo;
            try
            {
                tamanhoDoArquivo = stream.BaseStream.Length;
            }
            catch (IOException ex)
            {
                tamanhoDoArquivo = 0;
            }

            try
            {
                // Tipo da entrada posicionada
                Entradas entrada = Entradas.enNADA;

                // Lê os dados do arquivo
                int numeroDaLinha = 0;
                while (stream.Peek() >= 0)
                {

                    // Incrementa número da linha
                    numeroDaLinha++;

                    // Obtém a linha do arquivo
                    String linha = stream.ReadLine().Trim();
                    if (linha.Length == 0)
                        continue;

                    // Atualiza o andamento
                    bytesLidos += linha.Length;
                    if (tamanhoDoArquivo > 0)
                    {
                        // Calcula o percentual atual
                        int percentual = (int)((double)bytesLidos / (double)tamanhoDoArquivo * 100.0);
                        if (percentual > 100)
                            percentual = 100;

                        // Verifica parâmetro de notificação
                        if (percentual != ultimoPercentual)
                        {
                            // Envia a notificação
                            bgw.ReportProgress(percentual, "");
                            // Armazena o último percentual
                            ultimoPercentual = percentual;
                        }

                    }

                    // Ignora linhas que sinalizam comentário
                    if (linha.Length >= 2 && linha.Substring(0, 2).Equals("//"))
                        continue;

                    // Estrutura de campos (*FLD:)
                    if (linha.Length >= 5 && linha.Substring(0, 5).Equals("*FLD:"))
                    {
                        // Verifica modo de processamento
                        if (modoDeProcessamento != ModoDeProcessamento.mpTudo && modoDeProcessamento != ModoDeProcessamento.mpSchema)
                            continue;

                        // Testa qual entrada está selecionada
                        if (entrada != Entradas.enNADA)
                        {
                            _mensagem = "Especificação dos campos (*FLD:) deve ser a primeira linha do arquivo e deve ser utilizada apenas uma vez.";
                            resultado = false;
                            break;
                        }

                        // Processa a cláusula de declaração dos campos da tabela
                        if (!ProcessarEstruturaDeCampos(nomeDaTabela, linha, estruturaDaTabela))
                        {
                            resultado = false;
                            break;
                        }

                        // Entrada processada
                        entrada = Entradas.enFLD;
                    }
                    else if (linha.Length >= 5 && linha.Substring(0, 5).Equals("*PKY:")) // Chave                                                                                                     // Primária
                    {
                        // Verifica modo de processamento
                        if (modoDeProcessamento != ModoDeProcessamento.mpTudo && modoDeProcessamento != ModoDeProcessamento.mpSchema)
                            continue;

                        // Testa qual entrada está selecionada
                        if (entrada != Entradas.enFLD)
                        {
                            _mensagem = "Especificação da chave primária (*PKY:) deve ser declarada logo após a entrada *FLD: e utilizada apenas uma vez.";
                            resultado = false;
                            break;
                        }

                        // Processa a cláusula de declaração da chave primária da
                        // tabela
                        if (!ProcessarChavePrimaria(nomeDaTabela, linha))
                        {
                            resultado = false;
                            break;
                        }

                        // Entrada processada
                        entrada = Entradas.enPKY;
                    }
                    else if (linha.Length >= 5 && linha.Substring(0, 5).Equals("*IDX:")) // Índice
                    {
                        // Verifica modo de processamento
                        if (modoDeProcessamento != ModoDeProcessamento.mpTudo && modoDeProcessamento != ModoDeProcessamento.mpSchema)
                            continue;

                        // Testa qual entrada está selecionada
                        if (entrada != Entradas.enFLD && entrada != Entradas.enPKY)
                        {
                            _mensagem = "Especificação dos índices (*IDX:) deve ser declarada logo após a entrada *FLD: ou *PKY: e utilizada apenas uma vez.";
                            resultado = false;
                            break;
                        }

                        // Processa a cláusula de declaração dos índices da tabela
                        if (!ProcessarIndices(nomeDaTabela, linha))
                        {
                            resultado = false;
                            break;
                        }

                        // Entrada processada
                        entrada = Entradas.enIDX;
                    }
                    else if (linha.Length >= 5 && linha.Substring(0, 5).Equals("*TOT:")) // Carga                                                                                                     // Total
                    {
                        // Verifica modo de processamento
                        if (modoDeProcessamento != ModoDeProcessamento.mpTudo && modoDeProcessamento != ModoDeProcessamento.mpDados)
                            break;

                        // Apaga os dados da tabela
                        if (!ExecutarComando(String.Format("DELETE FROM {0}", nomeDaTabela)))
                        {
                            resultado = false;
                            break;
                        }

                        // Entrada processada
                        entrada = Entradas.enTOT;
                    }

                }

                // Fecha o arquivo
                stream.Close();

                // Envia a notificação final

                // Libera os objetos locais
                sb.Length = 0;
            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                return false;
            }
            finally
            {

            }

            return resultado;
        }

        private string CreateTable(string nomeDaTabela, List<EstruturaDoCampo> estruturaDaTabela)
        {
            // Será criado um comando SQL CREATE TABLE
            StringBuilder sql = new StringBuilder(5000);
            sql.Append("CREATE TABLE ");
            sql.Append(nomeDaTabela);
            sql.Append("(");

            // Processa as linhas do arquivo
            bool primeiroCampo = true;
            string tipoDoCampo;
            int tamanho, decimais;
            foreach (EstruturaDoCampo campo in estruturaDaTabela)
            {
                // Se não for o primeiro campo, acrescenta "," ao comando SQL
                if (!primeiroCampo)
                    sql.Append(",");

                // Adiciona o nome do campo no comando SQL
                sql.Append(campo.Nome());

                // Adiciona o tipo e tamanho do campo no comando SQL
                tipoDoCampo = campo.Tipo();
                tamanho = campo.Tamanho();
                decimais = campo.Decimais();
                if (tipoDoCampo.Equals("A"))
                    sql.Append(String.Format(" VARCHAR2({0})", tamanho));
                else if (tipoDoCampo.Equals("D"))
                    sql.Append(" TIMESTAMP");
                else if (tipoDoCampo.Equals("I"))
                    sql.Append(" INTEGER");
                else if (tipoDoCampo.Equals("N"))
                    sql.Append(String.Format(" NUMERIC({0},{1})", tamanho, decimais));
                else
                    _mensagem = String.Format("Tipo do campo {0} não está previsto no sistema!", tipoDoCampo);

                // Adiciona a cláusula NOT NULL em todos os campos para que o
                // tratamento de valores dentro
                // da aplicação não encontre valores inválidos
                sql.Append(" NOT NULL");

                // Acrescenta a cláusula DEFAULT para não permitir valores nulos
                if (tipoDoCampo.Equals("A"))
                    sql.Append(" DEFAULT ''");
                else
                    sql.Append(" DEFAULT 0");

                // Não é mais o primeiro campo
                primeiroCampo = false;
            }

            // Fecha o comando SQL
            sql.Append(")");

            // String com o Comando SQL
            String comandoSQL = sql.ToString();
            sql.Length = 0;

            // Retorna o comando SQL
            return comandoSQL;
        }

        private void ChavePrimariaDaTabela(String nomeDaTabela, List<String> camposDaChavePrimaria)
        {

            try
            {

                // Executa o comando
                var dados = LerNoBanco(String.Format("PRAGMA table_info('{0}')", nomeDaTabela));

                // Verifica se há colunas
                if (dados.Columns.Count == 0)
                {
                    return;
                }

                // Interage pelos registros
                foreach (DataRow row in dados.Rows)
                {
                    // Nome do campo
                    String nomeDoCampo = row[1].ToString().ToUpper();

                    // Chave primária
                    int pk = Convert.ToInt32(row[5].ToString());

                    // Adiciona o campo na estrutura
                    if (pk > 0)
                        camposDaChavePrimaria.Add(nomeDoCampo);

                }

            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                throw new Exception(String.Format("Erro ao recuperar chave primária da tabela {0}. Erro: {1}", nomeDaTabela, ex.Message));
            }
            finally
            {

            }
        }

        private bool ProcessarChavePrimaria(string nomeDaTabela, string linha)
        {

            StringBuilder sb = new StringBuilder(250);
            int posLinha = 5; // Índice inicial de processamento
            int tamLinha = linha.Length; // Número de caracteres da linha
            String nomeDoCampo; // Nome do campo da chave primária

            // ArrayList para armazenamento do nome dos campos da chave primária
            List<String> novaChave = new List<String>();

            // Caracter da linha da estrutura dos campos
            char caracter;

            // Processa os caracteres
            while (posLinha <= tamLinha)
            {
                // Se estiver além do último caracter da linha, verifica necessidade
                // de acrescentar o ";" para facilitar o processamento
                if (posLinha == tamLinha)
                {
                    // Se o caracter já for o ";", encerra loop pois o campo já foi
                    // processado
                    if (linha[posLinha - 1] == ';')
                        break;

                    // Se não for o caracter ";", associa este caracter para que o
                    // campo seja processado
                    caracter = ';';
                }
                else
                    // Caracter da linha
                    caracter = linha[posLinha];
                
                //Verificando se a chave e composta
                if (caracter == '|')
                {
                    // Salva a informação do campo
                    nomeDoCampo = sb.ToString();

                    // Adiciona o campo na estrutura
                    novaChave.Add(nomeDoCampo);

                    // Limpa o StringBuilder
                    sb.Length = 0;

                    // Próximo caracter
                    posLinha++;

                    continue;
                }

                // Verifica mudança de campo ou informação do campo
                if (caracter == ';')
                {
                    // Salva a informação do campo
                    nomeDoCampo = sb.ToString();

                    // Adiciona o campo na estrutura
                    novaChave.Add(nomeDoCampo);

                    // Limpa o StringBuilder
                    sb.Length = 0;

                    // Próximo caracter
                    posLinha++;

                    continue;
                }

                // Adiciona o caracter no StringBuilder
                sb.Append(caracter);

                // Próximo caracter
                posLinha++;
            }

            // Se não houver campos informados na estrutura, retorna erro
            if (novaChave.Count == 0)
            {
                _mensagem = String.Format("Não há informações de campos para a chave primária da tabela {0}. Contate suporte técnico.", nomeDaTabela);
                return false;
            }

            // Verifica chave primária atual
            List<String> chaveAtual = new List<String>();
            ChavePrimariaDaTabela(nomeDaTabela, chaveAtual);
            bool criarChavePrimaria = false;
            if (chaveAtual.Count == 0)
                criarChavePrimaria = true;
            else
            {
                // Verifica se é o mesmo número de campos
                if (novaChave.Count != chaveAtual.Count)
                    criarChavePrimaria = true;
                else
                {
                    // Verifica se são os mesmos campos
                    for (int x = 0; x < novaChave.Count; x++)
                        if (!novaChave[x].Equals(chaveAtual[x]))
                        {
                            criarChavePrimaria = true;
                            break;
                        }
                }
            }

            // Verifica necessidade de criar a chave primária
            if (criarChavePrimaria)
            {
                // Se já houver uma chave primária para a tabela, remove-a
                if (IndiceExiste(nomeDaTabela, String.Format("PK_{0}", nomeDaTabela)))
                    if (!ExecutarComando(String.Format("DROP INDEX PK_{0}", nomeDaTabela)))
                        return false;

                // Campos da chave primária
                sb.Length = 0;
                foreach (string campoCP in novaChave)
                {
                    // Se não for o primeiro campo, adiciona vírgula
                    if (sb.Length > 0)
                        sb.Append(",");

                    // Adiciona o campo
                    sb.Append(campoCP);
                }

                // Executa o comando SQL
                if (!ExecutarComando(String.Format("CREATE UNIQUE INDEX PK_{0} ON {1} ({2})", nomeDaTabela, nomeDaTabela, sb.ToString())))
                    return false;
            }

            // Libera os objetos locais
            sb.Length = 0;

            // OK!
            return true;
        }

        private bool ProcessarEstruturaDeCampos(string nomeDaTabela, string linha, List<EstruturaDoCampo> estruturaDaTabela)
        {
            StringBuilder sb = new StringBuilder(1000);
            int posLinha = 5; // Índice inicial de processamento
            int tamLinha = linha.Length; // Número de caracteres da linha
            int tpInfo = 0; // 0=Nome do Campo, 1=Tipo do Campo, 2=Tamanho e
                            // Precisão
            int indiceCampo = 0; // Índice do campo em processamento

            // Informações do campo
            String nomeDoCampo = "", tipoDoCampo = "", tamanhoEDecimais = "";
            int tamanho = 0, decimais = 0;

            // Caracter da linha da estrutura dos campos
            char caracter;

            // Processa os caracteres
            while (posLinha <= tamLinha)
            {
                // Se estiver além do último caracter da linha, verifica necessidade
                // de acrescentar o "|" para facilitar o processamento
                if (posLinha == tamLinha)
                {
                    // Se o caracter já for o "|", encerra loop pois o campo já foi
                    // processado
                    if (linha[posLinha - 1] == '|')
                        break;

                    // Se não for o caracter "|", associa este caracter para que o
                    // campo seja processado
                    caracter = '|';
                }
                else
                    // Caracter da linha
                    caracter = linha[posLinha];

                // Verifica mudança de campo ou informação do campo
                if (caracter == '|' || caracter == ';')
                {
                    // Se o tipo de informação for maior que 2, há erro na estrutura
                    // dos campos
                    if (tpInfo > 2)
                    {
                        _mensagem = String.Format("Erro na especificação da estrutura dos campos da tabela {0}. Campo {1} está declarado com mais informações do que o padrão. Contate suporte técnico.",
                                nomeDaTabela, indiceCampo);
                        return false;
                    }

                    // Salva a informação do campo
                    switch (tpInfo)
                    {
                        case 0: // Nome do Campo
                            nomeDoCampo = sb.ToString();
                            break;

                        case 1: // Tipo do Campo
                            tipoDoCampo = sb.ToString();
                            break;

                        case 2: // Tamanho e Precisão
                            tamanhoEDecimais = sb.ToString();
                            break;
                    }

                    // Próximo tipo de informação
                    tpInfo++;

                    // Limpa o StringBuilder
                    sb.Length = 0;

                    // Se for uma informação de mudança de campo, processa próximo
                    // caracter
                    if (caracter == ';')
                    {
                        // Próximo caracter
                        posLinha++;

                        continue;
                    }

                    // Se alguma das informações estiver em branco, há erro na
                    // estrutura
                    if (nomeDoCampo.Length == 0 || tipoDoCampo.Length == 0 || tamanhoEDecimais.Length == 0)
                    {
                        _mensagem = String.Format("Tabela: {0} - Campo {1} tem informações incorretas. Contate suporte técnico.", nomeDaTabela, indiceCampo);
                        return false;
                    }

                    // Valida o tipo de dado
                    if (!tipoDoCampo.Equals("A") && !tipoDoCampo.Equals("D") && !tipoDoCampo.Equals("I")
                            && !tipoDoCampo.Equals("N"))
                    {
                        _mensagem = String.Format("Tabela: {0} - Campo {1} tem um tipo de dado não suportado: %s. Contate suporte técnico.", nomeDaTabela, indiceCampo, tipoDoCampo);
                        return false;
                    }

                    // Separa tamanho e precisão
                    if (tipoDoCampo.Equals("D") || tipoDoCampo.Equals("I"))
                    {
                        tamanho = 0;
                        decimais = 0;
                    }
                    else if (tipoDoCampo.Equals("A"))
                    {
                        try
                        {
                            tamanho = int.Parse(tamanhoEDecimais);
                        }
                        catch (Exception ex)
                        {
                            _mensagem = String.Format("Tabela: {0} - Campo {1} declarado com formato inválido para campos alfanuméricos: {2}. Contate suuporte técnico.", nomeDaTabela, indiceCampo,
                                    tamanhoEDecimais);
                            return false;
                        }
                        decimais = 0;
                    }
                    else if (tipoDoCampo.Equals("N"))
                    {
                        // Localiza a posição da vírgula
                        int posVirgula = tamanhoEDecimais.IndexOf(',');
                        if (posVirgula < 0)
                        {
                            _mensagem = String.Format("Tabela: {0} - Campo {1} declarado com formato inválido para campos decimais: {2}. Contate suuporte técnico.", nomeDaTabela, indiceCampo,
                                    tamanhoEDecimais);
                            return false;
                        }

                        // Separa o tamanho e decimais
                        try
                        {
                            tamanho = int.Parse(tamanhoEDecimais.Substring(0, posVirgula));
                            decimais = int.Parse(tamanhoEDecimais.Substring(posVirgula + 1));
                        }
                        catch (Exception ex)
                        {
                            _mensagem = String.Format("Tabela: {0} - Campo {1} declarado com formato inválido para campos decimais: {2}. Contate suuporte técnico.", nomeDaTabela, indiceCampo,
                                    tamanhoEDecimais);
                            return false;
                        }
                    }

                    // Adiciona o campo na estrutura
                    EstruturaDoCampo campo = new EstruturaDoCampo(nomeDoCampo, tipoDoCampo, tamanho, decimais, false);
                    estruturaDaTabela.Add(campo);

                    // Próximo campo
                    indiceCampo++;

                    // Reinicia tipo de informação
                    tpInfo = 0;

                    // Próximo caracter
                    posLinha++;

                    continue;
                }

                // Adiciona o caracter no StringBuilder
                sb.Append(caracter);

                // Próximo caracter
                posLinha++;
            }

            // Se não houver campos informados na estrutura, retorna erro
            if (estruturaDaTabela.Count == 0)
            {
                _mensagem = String.Format("Não há informações de campos para a tabela {0}. Contate suporte técnico.", nomeDaTabela);
                return false;
            }

            // Se a tabela não existir, executa comando CREATE TABLE a partir da
            // estrutura de campos declarada
            if (!TabelaExiste(nomeDaTabela))
            {
                // Comando CREATE TABLE
                String comandoSQL = CreateTable(nomeDaTabela, estruturaDaTabela);
                if (!ExecutarComando(comandoSQL))
                    return false;

                // Ok!
                return true;
            }

            // Recupera a estrutura atual da tabela
            List<EstruturaDoCampo> estruturaAtual = new List<EstruturaDoCampo>();
            EstruturaDaTabela(nomeDaTabela, out estruturaAtual);

            // Verifica se a tabela foi alterada
            bool tabelaAlterada = false;
            foreach (EstruturaDoCampo campoNE in estruturaDaTabela)
            {
                // Verifica se o campo já existe na estrutura atual
                indiceCampo = -1;
                for (int x = 0; x < estruturaAtual.Count; x++)
                {
                    if (estruturaAtual[x].Nome().Equals(campoNE.Nome().ToUpper()))
                    {
                        indiceCampo = x;
                        break;
                    }
                }

                // Se o campo não foi encontrado, indica que a tabela foi alterada
                if (indiceCampo < 0)
                {
                    tabelaAlterada = true;
                    break;
                }

                // Se o campo existir, verifica se foi alterado
                if (!campoNE.Tipo().Equals(estruturaAtual[indiceCampo].Tipo()) || campoNE.Tamanho() != estruturaAtual[indiceCampo].Tamanho()
                        || campoNE.Decimais() != estruturaAtual[indiceCampo].Decimais())
                {
                    tabelaAlterada = true;
                    break;
                }
            }

            // Retorna com sucesso se a tabela não foi alterada
            if (!tabelaAlterada)
                return true;

            // Apaga a tabela temporária
            if (!ExecutarComando(String.Format("DROP TABLE IF EXISTS NOVA_{0}", nomeDaTabela)))
                return false;

            // Tabela existe, cria uma tabela com a nova estrutura
            var CreateSQL = CreateTable(String.Format("NOVA_{0}", nomeDaTabela), estruturaDaTabela);
            if (!ExecutarComando(CreateSQL))
                return false;

            // Prepara a lista de campos para conversão
            sb.Length = 0;
            foreach (EstruturaDoCampo campoNE in estruturaDaTabela)
            {
                // Verifica se o campo já existe na estrutura atual
                indiceCampo = -1;
                for (int x = 0; x < estruturaAtual.Count; x++)
                {
                    if (estruturaAtual[x].Nome().Equals(campoNE.Nome().ToUpper()))
                    {
                        indiceCampo = x;
                        break;
                    }
                }

                // Continua se o campo não foi encontrado
                if (indiceCampo < 0)
                    continue;

                // Acrescenta o campo na lista
                if (sb.Length > 0)
                    sb.Append(",");
                sb.Append(campoNE.Nome());
            }

            // Insere os dados na nova tabela
            if (!ExecutarComando(String.Format("INSERT INTO NOVA_{0} ({1}) SELECT {2} FROM {3}", nomeDaTabela, sb.ToString(), sb.ToString(), nomeDaTabela)))
                return false;

            // Apaga a tabela anterior
            if (!ExecutarComando(String.Format("DROP TABLE {0}", nomeDaTabela)))
                return false;

            // Altera o nome da tabela
            if (!ExecutarComando(String.Format("ALTER TABLE NOVA_{0} RENAME TO {1}", nomeDaTabela, nomeDaTabela)))
                return false;

            // Libera os objetos locais
            sb.Length = 0;

            // Ok!
            return true;
        }

        private void EstruturaDaTabela(String nomeDaTabela, out List<EstruturaDoCampo> estruturaAtual)
        {
            estruturaAtual = new List<EstruturaDoCampo>();

            _mensagem = "";

            try
            {
                // Executa o comando
                var dados = LerNoBanco(String.Format("PRAGMA table_info('{0}')", nomeDaTabela));

                // Verifica se há colunas
                if (dados.Columns.Count == 0)
                {
                    return;
                }

                // Interage pelos registros
                foreach (DataRow row in dados.Rows)
                {
                    String nomeDoCampo = row[1].ToString().ToUpper();
                    String tipoDoCampo = row[2].ToString().ToUpper();
                    int pk = Convert.ToInt32(row[5]);
                    int tamanho = 0;
                    int decimais = 0;

                    // Verifica o tipo do campo
                    if (tipoDoCampo.StartsWith("VARCHAR")) // Alfanumérico
                    {
                        int posI = tipoDoCampo.IndexOf('(');
                        int posF = tipoDoCampo.IndexOf(')');
                        try
                        {
                            if (posI > 0 && posF > posI)
                                tamanho = int.Parse(tipoDoCampo.Substring(posI + 1, posF));
                        }
                        catch (Exception ex)
                        {
                            // Ignora
                        }

                        // Estabelece o tipo do campo
                        tipoDoCampo = "A";
                    }
                    else if (tipoDoCampo.StartsWith("INT")) // Inteiro
                    {
                        // Estabelece o tipo do campo
                        tipoDoCampo = "I";
                    }
                    else if (tipoDoCampo.StartsWith("DATE")) // Data
                    {
                        // Estabelece o tipo do campo
                        tipoDoCampo = "D";
                    }
                    else if (tipoDoCampo.StartsWith("TIME")) // Data e Hora
                    {
                        // Estabelece o tipo do campo
                        tipoDoCampo = "D";
                    }
                    else if (tipoDoCampo.StartsWith("NUMERIC")) // Numérico
                    {
                        int posI = tipoDoCampo.IndexOf('(');
                        int posV = tipoDoCampo.IndexOf(',');
                        int posF = tipoDoCampo.IndexOf(')');
                        try
                        {
                            if (posI > 0 && posV > posI)
                                tamanho = int.Parse(tipoDoCampo.Substring(posI + 1, posV));
                            if (posF > 0 && posF > posV)
                                decimais = int.Parse(tipoDoCampo.Substring(posV + 1, posF));
                        }
                        catch (Exception ex)
                        {
                            // Ignora
                        }

                        // Estabelece o tipo do campo
                        tipoDoCampo = "N";
                    }

                    // Adiciona o campo na estrutura
                    EstruturaDoCampo campo = new EstruturaDoCampo(nomeDoCampo, tipoDoCampo, tamanho, decimais, (pk > 0));
                    estruturaAtual.Add(campo);
                }

            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
            }
            finally
            {
                // Fecha o Banco de Dados
            }
        }

        private void CamposDoIndice(string nomeDoIndice, List<String> camposDoIndice)
        {
            try
            {
                // Executa o comando
                var dados = LerNoBanco(String.Format("PRAGMA index_info('{0}')", nomeDoIndice));

                // Verifica se há colunas
                if (dados.Columns.Count == 0)
                {
                    return;
                }

                // Interage pelos registros
                foreach (DataRow row in dados.Rows)
                {
                    // Nome do campo
                    String nomeDoCampo = row[2].ToString().ToUpper();

                    // Adiciona o campo na estrutura
                    camposDoIndice.Add(nomeDoCampo);

                }

            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                throw new Exception(String.Format("Erro ao recuperar índice {0}. Erro: {1}", nomeDoIndice, ex.Message));
            }
            finally
            {
                // Fecha o Banco de Dados
            }
        }

        private bool ProcessarIndices(string nomeDaTabela, string linha)
        {
            StringBuilder sb = new StringBuilder(250);
            int posLinha = 5; // Índice inicial de processamento
            int tamLinha = linha.Length; // Número de caracteres da linha
            int tpInfo = 0; // Tipo de informação: 0=Nome do Índice, 1=Campo do
                            // Índice
            String nomeDoCampo; // Nome do campo da chave primária

            // Nome do Índice
            String nomeDoIndice = "";

            // ArrayList para armazenamento do nome dos campos do índice
            List<String> novosCampos = new List<String>();

            // ArrayList para armazenamento dos nomes dos índices
            List<String> novosIndices = new List<String>();

            // Caracter da linha da estrutura dos campos
            char caracter;

            // Processa os caracteres
            if (linha.Length > 5)
            {
                while (posLinha <= tamLinha)
                {
                    // Se estiver além do último caracter da linha, verifica
                    // necessidade
                    // de acrescentar o "|" para facilitar o processamento
                    if (posLinha == tamLinha)
                    {
                        // Se o caracter já for o "|", encerra loop pois o campo já
                        // foi processado
                        if (linha[posLinha - 1] == '|')
                            break;

                        // Se não for o caracter "|", associa este caracter para que
                        // o campo seja processado
                        caracter = '|';
                    }
                    else
                        // Caracter da linha
                        caracter = linha[posLinha];

                    // Verifica mudança de índice
                    if (caracter == '|' || caracter == ';')
                    {
                        if (tpInfo == 0)
                            nomeDoIndice = sb.ToString();
                        else
                        {
                            // Salva a informação do campo
                            nomeDoCampo = sb.ToString();

                            // Adiciona o campo na estrutura
                            novosCampos.Add(nomeDoCampo);
                        }

                        // Limpa o StringBuilder
                        sb.Length = 0;

                        // Próximo caracter
                        posLinha++;

                        // Se for mudança de campo, continua
                        if (caracter == ';')
                        {
                            // Se o nome foi informado, sinaliza que as próximas
                            // informações serão campos
                            if (tpInfo == 0)
                                tpInfo++;

                            continue;
                        }

                        // Verifica se o nome do índice foi informado
                        if (nomeDoIndice.Length == 0)
                        {
                            _mensagem = String.Format("Nome do índice não foi informado na estrutura de índices da tabela {0}. Contate suporte técnico.", nomeDaTabela);
                            return false;
                        }

                        // Verifica campos do índice
                        if (novosCampos.Count == 0)
                        {
                            _mensagem = String.Format("Não há informações de campos para o índice {0} da tabela {1}. Contate suporte técnico.", nomeDoIndice, nomeDaTabela);
                            return false;
                        }

                        // Verifica índice atual
                        List<String> camposDoIndice = new List<String>();
                        CamposDoIndice(nomeDoIndice, camposDoIndice);
                        bool criarIndice = false;
                        if (camposDoIndice.Count == 0)
                            criarIndice = true;
                        else
                        {
                            // Verifica se é o mesmo número de campos
                            if (novosCampos.Count != camposDoIndice.Count)
                                criarIndice = true;
                            else
                            {
                                // Verifica se são os mesmos campos
                                for (int x = 0; x < novosCampos.Count; x++)
                                    if (!novosCampos[x].Equals(camposDoIndice[x]))
                                    {
                                        criarIndice = true;
                                        break;
                                    }
                            }
                        }

                        // Verifica necessidade de criar o índice
                        if (criarIndice)
                        {
                            // Se já houver um índice com o mesmo nome, remove o
                            // índice
                            if (IndiceExiste(nomeDaTabela, nomeDoIndice))
                                if (!ExecutarComando(String.Format("DROP INDEX {0}", nomeDoIndice)))
                                    return false;

                            // Comando SQL
                            sb.Length = 0;
                            sb.Append("CREATE INDEX ");
                            sb.Append(nomeDoIndice);
                            sb.Append(" ON ");
                            sb.Append(nomeDaTabela);
                            sb.Append(" (");

                            bool primeiroCampo = true;
                            foreach (String campoIndice in novosCampos)
                            {
                                // Se não for o primeiro campo, adiciona vírgula
                                if (!primeiroCampo)
                                    sb.Append(",");

                                // Adiciona o campo
                                sb.Append(campoIndice);
                                primeiroCampo = false;
                            }

                            // Fecha comando SQL
                            sb.Append(")");

                            // Executa o comando SQL
                            if (!ExecutarComando(sb.ToString()))
                                return false;
                        }

                        // Adiciona o índice na lista de índices da tabela
                        novosIndices.Add(nomeDoIndice);

                        // Reconfigura as variáveis para um novo índice
                        nomeDoIndice = "";
                        novosCampos.Clear();
                        tpInfo = 0;
                        sb.Length = 0;

                        continue;
                    }

                    // Adiciona o caracter no StringBuilder
                    sb.Append(caracter);

                    // Próximo caracter
                    posLinha++;
                }
            }

            // Verifica se há algum índice removido da estrutura
            List<String> indicesDaTabela = new List<String>();
            IndicesDaTabela(nomeDaTabela, indicesDaTabela);
            bool indiceRemovido;
            if (indicesDaTabela.Count > 0)
            {
                foreach (String nome in indicesDaTabela)
                {
                    // Verifica se o índice foi removido da estrutura
                    indiceRemovido = true;
                    if (novosIndices.Count > 0)
                    {
                        foreach (String novosIndice in novosIndices)
                            if (novosIndice.Equals(nome))
                            {
                                indiceRemovido = false;
                                break;
                            }
                    }

                    // Se foi removido, remove o índice da tabela
                    if (indiceRemovido)
                    {
                        if (IndiceExiste(nomeDaTabela, nome))
                            if (!ExecutarComando(String.Format("DROP INDEX {0}", nome)))
                                return false;
                    }
                }
            }

            // Libera os objetos locais
            sb.Length = 0;

            // OK!
            return true;
        }

        private void IndicesDaTabela(string nomeDaTabela, List<String> indicesDaTabela)
        {

            try
            {
                // Executa o comando
                var dados = LerNoBanco(String.Format("select upper(name) from sqlite_master where upper(type)='INDEX' and upper(tbl_name)='{0}'", nomeDaTabela.ToUpper()));

                // Verifica se há colunas
                if (dados.Columns.Count == 0)
                {
                    return;
                }

                // Interage pelos registros
                // Interage pelos registros
                foreach (DataRow row in dados.Rows)
                {
                    // Nome do campo
                    String nomeDoIndice = row[0].ToString().ToUpper();

                    // Ignora chave primária
                    if (!nomeDoIndice.StartsWith("PK_"))
                    {
                        // Adiciona o campo na estrutura
                        indicesDaTabela.Add(nomeDoIndice);
                    }

                }

                // Fecha o cursor
            }
            catch (Exception ex)
            {
                _mensagem = ex.Message;
                throw new Exception(String.Format("Erro ao recuperar índices da tabela {0}. Erro: {1}", nomeDaTabela, ex.Message));
            }
            finally
            {
                // Fecha o Banco de Dados

            }
        }

    }

    public class EstruturaDoCampo
    {
        private string _nome;
        private string _tipo;
        private int _tamanho;
        private int _decimais;
        private bool _pk;

        public EstruturaDoCampo(string nome, string tipo, int tamanho, int decimais, bool pk)
        {
            _nome = nome;
            _tipo = tipo;
            _tamanho = tamanho;
            _decimais = decimais;
            _pk = pk;
        }

        public string Nome()
        {
            return _nome;
        }

        public string Tipo()
        {
            return _tipo;
        }

        public int Tamanho()
        {
            return _tamanho;
        }

        public int Decimais()
        {
            return _decimais;
        }

        public bool PK()
        {
            return _pk;
        }

    }
}
