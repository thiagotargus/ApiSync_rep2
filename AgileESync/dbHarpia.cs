using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;

namespace AgileESync
{
    public class dbHarpia
    {
        public OracleConnection Connection = new OracleConnection();
        public OracleCommand Command = new OracleCommand();
        public OracleDataReader Reader;
        public OracleTransaction Transaction;

        private string _ConnectionString;

        public dbHarpia(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            Connection.ConnectionString = ConnectionString;
        }

        public DataTable LerNoBanco(string SqlCom)
        {
            DataTable dtResp = new DataTable();

            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = SqlCom;
            Reader = Command.ExecuteReader();
            dtResp.Load(Reader);

            return dtResp;
        }

        public void GravaNoBanco(string SqlCom)
        {
            Command.Connection = Connection;
            Command.CommandText = SqlCom;
            Command.ExecuteNonQuery();

        }



        public void BeginTransaction()
        {
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void GravaTransaction(string SqlCom)
        {

            new OracleCommand(SqlCom, Connection, Transaction).ExecuteNonQuery();

        }

        public void TransactionRoolBack()
        {
            Transaction.Rollback();
            Connection.Close();
        }

        public void TransactionCommit()
        {
            Transaction.Commit();
            Connection.Close();
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }

        public int NextValueID(string TableName, string FieldName, string Where, int Increment)
        {

            Command.Parameters.Clear();

            int intReturn = 0;
            OracleParameter ReturnParam = new OracleParameter("vl_NameField", OracleType.Number);
            ReturnParam.Direction = ParameterDirection.ReturnValue;

            Command.CommandText = "F_NEXT_ID_COLUNA";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("pp_NameTable", OracleType.VarChar).Value = TableName;
            Command.Parameters.Add("pp_NameField", OracleType.VarChar).Value = FieldName;
            Command.Parameters.Add("pp_varchar_011", OracleType.VarChar).Value = Where;
            Command.Parameters.Add(ReturnParam);

            Open();
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
            intReturn = Convert.ToInt32(ReturnParam.Value.ToString());
            Close();


            return intReturn;
        }

        public void P_FECHAR_AVARIG_SIMPLES(string EmpresaCod, string PedNum)
        {
            Command.Parameters.Clear();

            Command.CommandText = "P_FECHAR_AVERIG_SIMPLES";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("pi_nempresa", OracleType.Number).Value = EmpresaCod;
            Command.Parameters.Add("pi_nprenota", OracleType.VarChar).Value = PedNum;

            Open();
            Command.ExecuteNonQuery();
            Close();

        }

        public void P_CONV_ATIVA_REG_RECEPCAO(string Empresa, string Usuario, string Protocolo, string Endereco)
        {
            Command.Parameters.Clear();

            Command.CommandText = "P_CONV_ATIVA_REG_RECEPCAO";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("PP_EMPRESA", OracleType.Number).Value = Convert.ToInt32(Empresa);
            Command.Parameters.Add("PP_USUARIO", OracleType.Number).Value = Convert.ToInt32(Usuario);
            Command.Parameters.Add("PP_PROTOCOLO", OracleType.Number).Value = Convert.ToInt32(Protocolo);
            Command.Parameters.Add("PP_ENDERECO", OracleType.VarChar).Value = Endereco;

            Open();
            Command.Connection = Connection;
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Close();
        }

        public string P_CAD_CLI_SIMPLES(string CliCPF, string CliNome, string CliEndereco, string CliNumeroEndereco, string CliBairro, string CliCidade, string CliUf, string CliCEP, string CliDDDTelefone, string CliTelefone,
                                        string CliDDDCelular, string CliTelefoneCelular, string CliFrete, string CliEmail)
        {
            string CodCliFenix = null;

            Command.Parameters.Clear();

            Command.CommandText = "P_CAD_CLI_SIMPLES";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("pi_CPFSoNumeros", OracleType.VarChar).Value = CliCPF;
            Command.Parameters.Add("pi_Nome", OracleType.VarChar).Value = CliNome;
            Command.Parameters.Add("pi_Endereco", OracleType.VarChar).Value = CliEndereco;
            Command.Parameters.Add("pi_NumeroEndereco", OracleType.VarChar).Value = CliNumeroEndereco;
            Command.Parameters.Add("pi_Bairro", OracleType.VarChar).Value = CliBairro;
            Command.Parameters.Add("pi_Cidade", OracleType.VarChar).Value = CliCidade;
            Command.Parameters.Add("pi_UF", OracleType.VarChar).Value = CliUf;
            Command.Parameters.Add("pi_CEP", OracleType.VarChar).Value = CliCEP;
            Command.Parameters.Add("pi_Telefone", OracleType.VarChar).Value = CliTelefone;
            Command.Parameters.Add("pi_TelefoneCelular", OracleType.VarChar).Value = CliTelefoneCelular;
            Command.Parameters.Add("pi_Email", OracleType.VarChar).Value = CliEmail;
            Command.Parameters.Add("pi_CobraTarifaBanc", OracleType.VarChar).Value = CliFrete;
            Command.Parameters.Add("pi_CodCliReferencia", OracleType.Number).Value = Convert.ToInt32("167347");
            //Código Cliente Referência do Fenix

            //Parametro de saída
            Command.Parameters.Add("po_CodCliFenix", OracleType.Number).Direction = ParameterDirection.Output;

            Open();
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
            CodCliFenix = Command.Parameters["po_CodCliFenix"].Value.ToString();
            Close();

            return CodCliFenix;
        }

        public string P_PCV_EDI_PEDIDO(string Empresa, int PedSeq)
        {
            string CodigoRetornoFenix = null;
            string MsgRetFenix = null;
            string MsgRetDescr = "";

            Command.Parameters.Clear();

            Command.CommandText = "P_PCV_EDI_PEDIDO";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("pp_number_001", OracleType.Number).Value = Convert.ToInt32(Empresa);
            Command.Parameters.Add("pp_pedidoseq", OracleType.Number).Value = PedSeq;

            //Parametro de saída
            Command.Parameters.Add("pp_number_038", OracleType.Int16).Direction = ParameterDirection.Output;
            Command.Parameters.Add("pp_varchar_148", OracleType.VarChar, 100).Direction = ParameterDirection.Output;

            Open();
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
            CodigoRetornoFenix = Command.Parameters["pp_number_038"].Value.ToString();
            MsgRetFenix = Command.Parameters["pp_varchar_148"].Value.ToString();
            Close();

            switch (CodigoRetornoFenix)
            {
                case "0":
                    MsgRetDescr = "INF - Pedido atendido totalmente/parcialmente.";
                    break;
                case "1":
                    MsgRetDescr = "ERR - Pedido com promoção não cadastrada.";
                    break;
                case "2":
                    MsgRetDescr = "ALE - Pedido não atingiu a quantidade limite de empresa.'";
                    break;
                case "3":
                    MsgRetDescr = "ALE - Pedido não atingiu a quantidade limite de itens.";
                    break;
                case "4":
                    MsgRetDescr = "ALE - Pedido com valor bruto da Pedido menor que mínimo permitido na tabelas comerciais.";
                    break;
                case "5":
                    MsgRetDescr = "ALE - Pedido especial com valor bruto menor que o valor mínimo permitido.";
                    break;
                case "6":
                    MsgRetDescr = "ALE - Pedido normal com valor bruto menor que o valor mínimo permitido.";
                    break;
                case "7":
                    MsgRetDescr = "ATE - Houve faltas no Pedido.";
                    break;
                case "8":
                    MsgRetDescr = "ALE - Pedido bloqueado.";
                    break;
                case "9":
                    MsgRetDescr = "ALE - Não encontrou a guias de separação manipulada no Pedido.";
                    break;
                case "10":
                    MsgRetDescr = "INF - Pedido encaminhado para aprovação comercial.";
                    break;
                case "-1":
                    MsgRetDescr = "ERR - Pedido não atendida. Dados da Pedido no nº %s inconsistente.";
                    break;
                case "-2":
                    MsgRetDescr = "ALE - Pedido nº %s com empresa de digitação não cadastrada.";
                    break;
                case "-3":
                    MsgRetDescr = "ALE - Pedido nº %s com modo de atendimento não cadastrado.";
                    break;
                case "-4":
                    MsgRetDescr = "ALE - Pedido nº %s com usuário não cadastrado.";
                    break;
                case "-5":
                    MsgRetDescr = "ALE - Pedido do Cliente nº %s com cliente não cadastrado.";
                    break;
                case "-6":
                    MsgRetDescr = "ALE - Pedido nº %s com roteiro do cliente não cadastrada.";
                    break;
                case "-7":
                    MsgRetDescr = "ALE - Pedido nº %s com tabelas comerciais não cadastrada.";
                    break;
                case "-8":
                    MsgRetDescr = "ALE - Pedido nº %s com agente portador não cadastrado.";
                    break;
                case "-9":
                    MsgRetDescr = "ERR - Pedido nº %s com promoção não cadastrada.";
                    break;
                case "-10":
                    MsgRetDescr = "ALE - Pedido nº %s com colaborador não cadastrado.";
                    break;
                case "-11":
                    MsgRetDescr = "ALE - Pedido do Cliente nº %s totalmente rejeitado. Todos as mercadorias são inválidos.";
                    break;
                case "-12":
                    MsgRetDescr = "ALE - Pedido programada nº %s inválido para venda invertida.";
                    break;
                case "-13":
                    MsgRetDescr = "ALE - Pedido nº %s com modalidade de atendimento inválida para venda invertida.";
                    break;
                case "-14":
                    MsgRetDescr = "ALE - Pedido nº %s contém mercadoria(s) inexistente(s) na empresa logística.";
                    break;
                case "-17":
                    MsgRetDescr = "ERR - Roteiro para Pedido com retirada de mercadoria não definido.";
                    break;
                case "-18":
                    MsgRetDescr = "ERR - Transportador/Roteiro para Pedido não encontrado.";
                    break;
                case "-19":
                    MsgRetDescr = "ERR - Existem mercadorias na Pedido do cliente %s com embalagem inválida.";
                    break;
                case "-20":
                    MsgRetDescr = "ALE - Pedido do Cliente nº %s contém mercadoria(s) com fabricante(es) inexistentes.";
                    break;
            }

            return CodigoRetornoFenix + ";" + MsgRetFenix + ";" + MsgRetDescr;
        }

        public DataSet P_EDI_PCA_RETORNO(string E_491_CLI_PF_620, string E_491_EMPRESA_PF_620, string E_491_SEQ_PEDIDO_PK_620, string Empresa, string Usuario, string NumPed, string FirstReturnMsg)
        {
            StringBuilder SqlCom = new StringBuilder();
            DataSet dsResp = new DataSet();
            DataTable dtResp2 = new DataTable();
            DataTable dtResp = new DataTable();
            string ParamWhereIn = string.Format("E_491_CLI_PF_620 = {0} AND E_491_EMPRESA_PF_620 = {1} AND E_491_SEQ_PEDIDO_PK_620 = {2}", E_491_CLI_PF_620, E_491_EMPRESA_PF_620, E_491_SEQ_PEDIDO_PK_620);

            Command.Parameters.Clear();

            Command.CommandText = "P_EDI_PCA_RETORNO";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("pp_setoreswhere", OracleType.VarChar).Value = ParamWhereIn;

            Open();
            Command.Connection = Connection;
            Command.ExecuteNonQuery();

            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
            Command.Parameters.Clear();

            SqlCom.Length = 0;
            SqlCom.Append("SELECT '" + Empresa + "' As PK_EMPRESA, '" + Usuario + "' As PK_USUARIO, '" + NumPed + "' As PK_RET_PEDIDOORIGINAL, TO_CHAR(" + E_491_SEQ_PEDIDO_PK_620 + ") As RET_PEDIDORETAGUARDA , EP319_PEDIDO_CLIENTE As RET_PEDIDOCLIENTE, ");
            SqlCom.Append("EP319_DT_FATURAMENTO As RET_DATAFATURAMENTO, EP319_ID_SIT_PEDIDO_FK As RET_SITUACAO, ");
            SqlCom.Append("CASE EP319_ID_SIT_PEDIDO_FK ");
            SqlCom.Append("WHEN '0' THEN 'Faturado Total!' ");
            SqlCom.Append("WHEN '1' THEN 'Pedido bloqueado totalmente por rejeição a nivel de cabeçalho e excluido do bloqueio!' ");
            SqlCom.Append("WHEN '2' THEN 'Analise de Credito!' ");
            SqlCom.Append("WHEN '3' THEN 'Pedido bloqueado totalmente por rejeição a nivel de item!' ");
            SqlCom.Append("WHEN '4' THEN 'Faturado Parcial!' ");
            SqlCom.Append("WHEN '5' THEN 'Fatura Mínima!' ");
            SqlCom.Append("WHEN '6' THEN 'Erro no Recebimento do Pedido!' ");
            SqlCom.Append("WHEN '7' THEN 'Pedido Bloqueado por Diferença de Preços. Aguardando Aprovação Comercial!' ");
            SqlCom.Append("END As RET_SITUACAODESCR, ");
            SqlCom.Append("EP319_OBS_CREDITO As RET_OBSERVACAO, '" + FirstReturnMsg + "' As RET_MSG ");
            SqlCom.Append("FROM RETORNO_EDIP68 ");

            Command.CommandText = SqlCom.ToString();
            Reader = Command.ExecuteReader();
            dtResp.Load(Reader);
            dtResp.TableName = "RETORNO_CABECALHO";
            dsResp.Tables.Add(dtResp);

            SqlCom.Length = 0;
            SqlCom.Append("SELECT '" + Empresa + "' As PK_EMPRESA, '" + Usuario + "' As PK_USUARIO, '" + NumPed + "' As PK_REI_PEDIDOORIGINAL, TO_CHAR(EP320_PEDIDO_CLIENTE) As PK_REI_PEDIDOCLIENTE, TO_CHAR(EP320_MERC_PF) As PK_REI_MERCADORIA, ");
            SqlCom.Append("DESCR_461 || DESCR2_461 As REI_MERCADORIADESCR, EP320_MOTIVO_BLOQ_FK As REI_MOTIVOBLOQ, ");
            SqlCom.Append("CASE EP320_MOTIVO_BLOQ_FK ");
            SqlCom.Append("WHEN 'A' THEN 'Cliente Inexistente' ");
            SqlCom.Append("WHEN 'B' THEN 'Agente Comercial Inexistente' ");
            SqlCom.Append("WHEN 'C' THEN 'Ag Portador Inexistente' ");
            SqlCom.Append("WHEN 'D' THEN 'Estouro de Crédito' ");
            SqlCom.Append("WHEN 'E' THEN 'Restrição de Crédito' ");
            SqlCom.Append("WHEN 'F' THEN 'Tab Bloq Inexistente' ");
            SqlCom.Append("WHEN 'G' THEN 'Mercadoria Inexistente' ");
            SqlCom.Append("WHEN 'H' THEN 'Saldo de Volume Indisponível' ");
            SqlCom.Append("WHEN 'I' THEN 'Merc Fora da Promoção' ");
            SqlCom.Append("WHEN 'J' THEN 'Psic em Nota Branca' ");
            SqlCom.Append("WHEN 'K' THEN 'Mercadoria fora Origem da Coleta' ");
            SqlCom.Append("WHEN 'L' THEN 'Restrição de Fabric Fornec' ");
            SqlCom.Append("WHEN 'M' THEN 'Restrição de Quantidade' ");
            SqlCom.Append("WHEN 'N' THEN 'Restrição dias de Estoq' ");
            SqlCom.Append("WHEN 'O' THEN 'Saldo do Estoque' ");
            SqlCom.Append("WHEN 'P' THEN 'Mercadoria sem Prazo' ");
            SqlCom.Append("WHEN 'Q' THEN 'Cliente sem CNPJ' ");
            SqlCom.Append("WHEN 'R' THEN 'Fatura Mínima' ");
            SqlCom.Append("WHEN 'S' THEN 'Restrição de Venda' ");
            SqlCom.Append("WHEN 'T' THEN 'Mercadoria Inativada' ");
            SqlCom.Append("WHEN 'U' THEN 'Val Ped Superior Permitido' ");
            SqlCom.Append("WHEN 'V' THEN 'Qtde Ideal' ");
            SqlCom.Append("WHEN 'W' THEN 'Qtde Psic Superior Permitido' ");
            SqlCom.Append("WHEN 'X' THEN 'Com Restrição para Inventário' ");
            SqlCom.Append("WHEN 'Y' THEN 'Volume Indisponível' ");
            SqlCom.Append("WHEN 'Z' THEN 'Volume com Diverg de Saldo' ");
            SqlCom.Append("ELSE 'Outros' ");
            SqlCom.Append("END As REI_MOTIVOBLOQDESCR, ");
            SqlCom.Append("EP320_QTD_CORT As REI_QTDECORTE ");
            SqlCom.Append("FROM RETORNO_MERC_EDIP69, MERCADORIA_461 ");
            SqlCom.Append("WHERE MERC_PK_461 = EP320_MERC_PF ");

            Command.CommandText = SqlCom.ToString();
            Reader = Command.ExecuteReader();
            dtResp2.Load(Reader);
            dtResp2.TableName = "RETORNO_ITENS";
            dsResp.Tables.Add(dtResp2);

            Close();

            return dsResp;
        }

        public decimal P_SALDO_CREDITO_REP_VEND(string Empresa, string UsuarioERP, DateTime DtInicial, DateTime DtFinal, string Tipo)
        {
            decimal SaldoFlex = 0;

            Command.Parameters.Clear();

            Command.CommandText = "P_SALDO_CREDITO_REP_VEND";
            Command.CommandType = CommandType.StoredProcedure;

            //Parametros de Entrada
            Command.Parameters.Add("pp_empresa", OracleType.VarChar).Value = Empresa;
            Command.Parameters.Add("pp_repvend", OracleType.Number).Value = Convert.ToInt16(UsuarioERP);
            Command.Parameters.Add("pp_dtinicial", OracleType.DateTime).Value = DtInicial;
            Command.Parameters.Add("pp_dtfinal", OracleType.DateTime).Value = DtFinal;
            Command.Parameters.Add("pp_tipo", OracleType.Number).Value = Convert.ToInt16(Tipo);

            //Parametro de saída
            Command.Parameters.Add("pp_saldo", OracleType.Number).Direction = ParameterDirection.Output;

            Open();
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
            SaldoFlex = Convert.ToDecimal(Command.Parameters["pp_saldo"].Value);
            Close();

            return SaldoFlex;
        }

    }
}
