using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static AgileESync.AgileECommerceApi;
using Newtonsoft.Json.Linq;

namespace AgileESync
{
    public class HarpiaApi
    {
        private string _strcon;
        dbHarpia db;

        public HarpiaApi(string strcon)
        {
            _strcon = strcon;
            db = new dbHarpia(_strcon);
        }

        public bool TestaConexao()
        {
            bool didWork = false;
            try
            {
                db.Open();
                db.Close();
                didWork = true;
            }
            catch (Exception ex)
            { }
            return didWork;
        }

        public DataTable ExecutarQuery(string query)
        {
            DataTable dt = new DataTable();

            db.Open();

            dt = db.LerNoBanco(query);

            db.Close();

            return dt;

        }

        public void Open()
        {
            db.Open();
        }

        public void Close()
        {
            db.Close();
        }

        public void GravarNoBancoBulk(string query)
        {
            query = "BEGIN " + query + " END;";

            db.GravaNoBanco(query);
        }

        public void GravarNoBanco(string query)
        {
            db.Open();

            db.GravaNoBanco(query);

            db.Close();
        }

        public DataTable getSyncJob()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("   SELECT ID_PK Id, ");
            sb.AppendLine("          0 Empresa, ");
            sb.AppendLine("          DATA_REGISTRO DataHora, ");
            sb.AppendLine("          TABELA Tabela, ");
            sb.AppendLine("          SQL_WHERE SQL_WHERE, ");
            sb.AppendLine("          SQL_TIPO SQL_TIPO, ");
            sb.AppendLine("          STATUS STATUS ");
            sb.AppendLine("        FROM AGILE_ECOM_INT_ERP ");
            sb.AppendLine("       WHERE STATUS IN ('P', 'F') ");
            sb.AppendLine("    ORDER BY ID_PK "); 

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "AgileESyncJob";

            db.Close();

            return dt;
        }

        //Pedido
        public DataTable getData(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine(job.sql_query.Replace("\"", "'").Replace("1 = 1", job.sql_where));
            //sb.AppendLine("  AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = job.Tabela;

            db.Close();

            return dt;
        }

        //Pedido
        public DataTable getPedido(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_680 store_id,  ");
            sb.AppendLine("       NUM_PED_CONF_680 code,  ");
            sb.AppendLine("       CLI_FK_680 customer_id,  ");
            sb.AppendLine("       NVL(COND_COMER_FK_680, 'AA') payment_method_id,  ");
            sb.AppendLine("       TOT_MERC_680 products_price,  ");
            sb.AppendLine("       TOT_LIQ_680 total_order,  ");
            sb.AppendLine("       '' comments,  ");
            sb.AppendLine("       'received' status  ");
            sb.AppendLine(" FROM NF_SAIDA_680  ");
            sb.AppendLine("WHERE 1 = 1  ");
            sb.AppendLine("  AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Pedido";

            db.Close();

            return dt;
        }

        //PedidoItens
        public DataTable getPedidoItens(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT MERC_PF_687 product_id, ");
            sb.AppendLine("       PRC_COMER_687 unity_price, ");
            sb.AppendLine("       QTD_COMER_687 quantity, ");
            sb.AppendLine("       (QTD_COMER_687 * PRC_COMER_687) products_price, ");
            sb.AppendLine("       (QTD_COMER_687 * PRC_COMER_687) total_order, ");
            sb.AppendLine("       'regular' status ");
            sb.AppendLine("  FROM NF_SAIDA_MERC_687 ");
            sb.AppendLine("WHERE 1 = 1 ");
            sb.AppendLine("  AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PedidoItens";

            db.Close();

            return dt;
        }

        public DataTable getPedidoStatus(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ID, ");
            sb.AppendLine("       STORE_ID, ");
            sb.AppendLine("       CODE, ");
            sb.AppendLine("       STATUS ");
            sb.AppendLine("FROM ");
            sb.AppendLine("( ");
            sb.AppendLine("    SELECT E_491_PEDIDO_ORIG_620 id, ");
            sb.AppendLine("           E_491_EMPRESA_PF_620 store_id, ");
            sb.AppendLine("           NULL CODE, ");
            sb.AppendLine("           'waitfunds' status ");
            sb.AppendLine("        FROM PEDIDO_BLOQ_EMPRESA_558, CLIENTE_59, PROC_EDI_491_LIST_620 ");
            sb.AppendLine("       WHERE 1 = 1 ");
            sb.AppendLine("         AND E_491_EMPRESA_PF_620 = EMPRESA_DIGIT_PF_558 ");
            sb.AppendLine("         AND E_491_SEQ_PEDIDO_PK_620 = NUM_PEDIDO_ORIG_558 ");
            sb.AppendLine("         AND(CLI_FK_558 = CLI_PK_59) ");
            sb.AppendLine("         AND(STATUS_PEDIDO_BLOQ_558 <> 'L') ");
            sb.AppendLine("         AND DT_LIB_558 IS NULL ");
            sb.AppendLine("         AND CONSTIT_MOTIV_BLOQ_558 = 1 ");
            sb.AppendLine("    UNION ALL ");
            sb.AppendLine("    SELECT E_491_PEDIDO_ORIG_620 id, ");
            sb.AppendLine("           E_491_EMPRESA_PF_620 store_id, ");
            sb.AppendLine("           NUM_PED_CONF_PK_538 CODE, ");
            sb.AppendLine("           CASE WHEN SITUA_PED_CONF_538 = 1 THEN 'approved' WHEN  SITUA_PED_CONF_538 = 2 THEN 'picked' END status ");
            sb.AppendLine("       FROM PED_CONF_538, PROC_EDI_491_LIST_620 ");
            sb.AppendLine("      WHERE 1 = 1 ");
            sb.AppendLine("        AND EMPRESA_PF_538 = E_491_EMPRESA_PF_620 ");
            sb.AppendLine("        AND E_491_SEQ_PEDIDO_PK_620 = NUM_PEDIDO_ORIG_538 ");
            sb.AppendLine("    UNION ALL ");
            sb.AppendLine("    SELECT E_491_PEDIDO_ORIG_620 id, ");
            sb.AppendLine("           E_491_EMPRESA_PF_620 store_id, ");
            sb.AppendLine("           NULL CODE, ");
            sb.AppendLine("           'invoiced' status ");
            sb.AppendLine("       FROM NF_SAIDA_680, PROC_EDI_491_LIST_620 ");
            sb.AppendLine("      WHERE 1 = 1 ");
            sb.AppendLine("        AND EMPRESA_PF_680 = E_491_EMPRESA_PF_620 ");
            sb.AppendLine("        AND E_491_SEQ_PEDIDO_PK_620 = NUM_PEDIDO_ORIG_680 ");
            sb.AppendLine(") ");
            sb.AppendLine("WHERE 1 = 1 ");
            sb.AppendLine("  AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PedidoStatus";

            db.Close();

            return dt;
        }

        //Promocao
        public DataTable getPromocao()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT DISTINCT  ");
            sb.AppendLine("       PROM_PK_636 id,  ");
            sb.AppendLine("       DESCR_636 name,  ");
            sb.AppendLine("       PRZ_MEDIO_MAX_636 average_days,  ");
            sb.AppendLine("       0 addition,  ");
            sb.AppendLine("       0 discount,  ");
            sb.AppendLine("       DT_INI_636 start_datetime,  ");
            sb.AppendLine("       DT_FIN_636 end_datetime,  ");
            sb.AppendLine("       CASE WHEN SN_SOMA_DESC_MERC_636 = 'S' THEN 'true' else 'false' END modifiable  ");
            sb.AppendLine("FROM PROMOCAO_NORMAL_636  ");
            sb.AppendLine("WHERE DEFIN_PROM_636 = 'P'  ");
            sb.AppendLine("  AND DT_INI_636 <= SYSDATE  ");
            sb.AppendLine("  AND DT_FIN_636 >= SYSDATE  ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Promocao";

            db.Close();

            return dt;
        }

        public DataTable getPromocao(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT DISTINCT  ");
            sb.AppendLine("       PROM_PK_636 id,  ");
            sb.AppendLine("       DESCR_636 name,  ");
            sb.AppendLine("       PRZ_MEDIO_MAX_636 average_days,  ");
            sb.AppendLine("       0 addition,  ");
            sb.AppendLine("       0 discount,  ");
            sb.AppendLine("       EXTRACT(YEAR FROM DT_INI_636) || '-' || LPAD(EXTRACT(MONTH FROM DT_INI_636), 2, '0') || '-' || LPAD(EXTRACT(DAY FROM DT_INI_636), 2, '0') start_datetime,  ");
            sb.AppendLine("       EXTRACT(YEAR FROM DT_FIN_636) || '-' || LPAD(EXTRACT(MONTH FROM DT_FIN_636), 2, '0') || '-' || LPAD(EXTRACT(DAY FROM DT_FIN_636), 2, '0') end_datetime,  ");
            sb.AppendLine("       CASE WHEN SN_SOMA_DESC_MERC_636 = 'S' THEN 'true' else 'false' END modifiable  ");
            sb.AppendLine("FROM PROMOCAO_NORMAL_636  ");
            sb.AppendLine("WHERE DEFIN_PROM_636 = 'P'  ");
            sb.AppendLine("  AND DT_INI_636 <= SYSDATE  ");
            sb.AppendLine("  AND DT_FIN_636 >= SYSDATE  ");
            sb.AppendLine("  AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Promocao";

            db.Close();

            return dt;
        }

        //Promocao Loja
        public DataTable getPromocaoLoja()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_640 store_id, ");
            sb.AppendLine("       PROM_PF_640 promotion_id ");
            sb.AppendLine("  FROM PROMOCAO_NORMAL_636, PROMOCAO_NORMAL_EMPRESA_640 ");
            sb.AppendLine(" WHERE DEFIN_PROM_636 = 'P' ");
            sb.AppendLine("   AND PROM_PK_636 = PROM_PF_640 ");
            sb.AppendLine("   AND DT_INI_636 <= SYSDATE ");
            sb.AppendLine("   AND DT_FIN_636 >= SYSDATE ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PromocaoLoja";

            db.Close();

            return dt;
        }

        public DataTable getPromocaoLoja(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_640 store_id, ");
            sb.AppendLine("       PROM_PF_640 promotion_id ");
            sb.AppendLine("  FROM PROMOCAO_NORMAL_636, PROMOCAO_NORMAL_EMPRESA_640 ");
            sb.AppendLine(" WHERE DEFIN_PROM_636 = 'P' ");
            sb.AppendLine("   AND PROM_PK_636 = PROM_PF_640 ");
            sb.AppendLine("   AND DT_INI_636 <= SYSDATE ");
            sb.AppendLine("   AND DT_FIN_636 >= SYSDATE ");
            sb.AppendLine("  AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PromocaoLoja";

            db.Close();

            return dt;
        }

        //Promocao Produto
        public DataTable getPromocaoProduto()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT PROM_PF_645 promotion_id,  ");
            sb.AppendLine("        '99' || LPAD(MERC_PF_645, 8, '0') || LPAD(INVOL_PF_647, 3, '0') AS product_id, ");
            sb.AppendLine("       PRC_COMER_645 price, ");
            sb.AppendLine("       NVL(MAX_MIN_645, 0) min_order ");
            sb.AppendLine("FROM PROMOCAO_NORMAL_MERC_645 ");
            sb.AppendLine("JOIN PROMOCAO_NORMAL_MERC_INVOL_647 ");
            sb.AppendLine("  ON PROM_PF_647 = PROM_PF_645 ");
            sb.AppendLine(" AND MERC_PF_647 = MERC_PF_645 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PromocaoProduto";

            db.Close();

            return dt;
        }

        public DataTable getPromocaoProduto(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT PROM_PF_645 promotion_id,  ");
            sb.AppendLine("        '99' || LPAD(MERC_PF_645, 8, '0') || LPAD(INVOL_PF_647, 3, '0') AS product_id, ");
            sb.AppendLine("       PRC_COMER_645 price, ");
            sb.AppendLine("       NVL(MAX_MIN_645, 0) min_order ");
            sb.AppendLine("FROM PROMOCAO_NORMAL_MERC_645 ");
            sb.AppendLine("JOIN PROMOCAO_NORMAL_MERC_INVOL_647 ");
            sb.AppendLine("  ON PROM_PF_647 = PROM_PF_645 ");
            sb.AppendLine(" AND MERC_PF_647 = MERC_PF_645 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PromocaoProduto";

            db.Close();

            return dt;
        }

        //Promocao Grupo de Cliente
        public DataTable getPromocaoGrupoDeCliente()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT PROM_PF_908 promotion_id, ");
            sb.AppendLine("       GRUPO_CLI_PF_908 customer_group_id ");
            sb.AppendLine("  FROM PROMOCAO_NORMAL_GRUPOCLI_908 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PromocaoGrupoDeCliente";

            db.Close();

            return dt;
        }

        //Promocao Grupo de Cliente
        public DataTable getPromocaoGrupoDeCliente(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT PROM_PF_908 promotion_id, ");
            sb.AppendLine("       GRUPO_CLI_PF_908 customer_group_id ");
            sb.AppendLine("  FROM PROMOCAO_NORMAL_GRUPOCLI_908 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PromocaoGrupoDeCliente";

            db.Close();

            return dt;
        }

        //DifMercNegociacao
        public DataTable getDifMercNegociacao()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ID_NEG_PK_100 As id,  ");
            sb.AppendLine("       CASE WHEN TIPO_UNIV_100 = 1 THEN 'customer'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 3 THEN 'seller'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 6 THEN 'customer_group'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 7 THEN 'city'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 8 THEN 'state'  ");
            sb.AppendLine("        END As \"trigger\",  ");
            sb.AppendLine("       CASE WHEN TIPO_OCORR_100 = 1 THEN 'product'  ");
            sb.AppendLine("            WHEN TIPO_OCORR_100 = 2 THEN 'brand'  ");
            sb.AppendLine("            WHEN TIPO_OCORR_100 = 6 THEN 'all'  ");
            sb.AppendLine("        END target, ");
            sb.AppendLine("       DESCR_NEG_100 As \"name\" ");
            sb.AppendLine("  FROM CONF_NEG_COMER_100 ");
            sb.AppendLine(" WHERE TIPO_NEG_100 = '1' ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacao";

            db.Close();

            return dt;
        }

        //DifMercNegociacao
        public DataTable getDifMercNegociacao(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ID_NEG_PK_100 As id,  ");
            sb.AppendLine("       CASE WHEN TIPO_UNIV_100 = 1 THEN 'customer'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 3 THEN 'seller'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 6 THEN 'customer_group'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 7 THEN 'city'  ");
            sb.AppendLine("            WHEN TIPO_UNIV_100 = 8 THEN 'state'  ");
            sb.AppendLine("        END As \"trigger\",  ");
            sb.AppendLine("       CASE WHEN TIPO_OCORR_100 = 1 THEN 'product'  ");
            sb.AppendLine("            WHEN TIPO_OCORR_100 = 2 THEN 'brand'  ");
            sb.AppendLine("            WHEN TIPO_OCORR_100 = 6 THEN 'all'  ");
            sb.AppendLine("        END target, ");
            sb.AppendLine("       DESCR_NEG_100 As \"name\" ");
            sb.AppendLine("  FROM CONF_NEG_COMER_100 ");
            sb.AppendLine(" WHERE TIPO_NEG_100 = '1' ");
            sb.AppendLine("   AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacao";

            db.Close();

            return dt;
        }

        //DifMercNegociacao
        public DataTable getDifMercNegociacaoLoja()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine(" SELECT EMPRESA_PF_101 store_id, ");
            sb.AppendLine("        ID_NEG_PF_101 price_modificator_id ");
            sb.AppendLine("   FROM CONF_NEG_COMER_EMPRESA_101 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacaoLoja";

            db.Close();

            return dt;
        }

        //DifMercNegociacao
        public DataTable getDifMercNegociacaoLoja(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine(" SELECT EMPRESA_PF_101 store_id, ");
            sb.AppendLine("        ID_NEG_PF_101 price_modificator_id ");
            sb.AppendLine("   FROM CONF_NEG_COMER_EMPRESA_101 ");
            sb.AppendLine("  WHERE " + job.sql_where);
            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacaoLoja";

            db.Close();

            return dt;
        }

        //DifMercNegociacaoUniversos
        public DataTable getDifMercNegUniversos()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine(" Select ID_NEG_PF_103 price_modificator_id, ");
            sb.AppendLine("       ID_UNIV_PK_103 object_id  ");
            sb.AppendLine("        END As object_id  ");
            sb.AppendLine("  FROM CONF_NEG_COMER_UNIV_103 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacaoUniversos";

            db.Close();

            return dt;
        }

        //DifMercNegociacaoUniversos
        public DataTable getDifMercNegUniversos(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine(" SELECT ID_NEG_PF_103 PRICE_MODIFICATOR_ID,  ");
            sb.AppendLine("        CASE WHEN TIPO_UNIV_100 = 1 THEN TO_NUMBER(ID_UNIV_PK_103) ");
            sb.AppendLine("             WHEN TIPO_UNIV_100 = 3 THEN TO_NUMBER(ID_UNIV_PK_103) ");
            sb.AppendLine("             WHEN TIPO_UNIV_100 = 6 THEN TO_NUMBER(ID_UNIV_PK_103) ");
            sb.AppendLine("             WHEN TIPO_UNIV_100 = 7 THEN TO_NUMBER(ID_UNIV_PK_103) ");
            sb.AppendLine("             WHEN TIPO_UNIV_100 = 8 THEN TO_NUMBER((SELECT COD_UF_IBGE_265 FROM ESTADOS_265 WHERE ESTAD_PK_265 = ID_UNIV_PK_103)) ");
            sb.AppendLine("       END OBJECT_ID ");
            sb.AppendLine(" FROM CONF_NEG_COMER_UNIV_103 ");
            sb.AppendLine(" JOIN CONF_NEG_COMER_100 ");
            sb.AppendLine("   ON ID_NEG_PK_100 = ID_NEG_PF_103 ");
            sb.AppendLine("WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacaoUniversos";

            db.Close();

            return dt;
        }

        //DifMercNegociacaoOcorrencias
        public DataTable getDifMercNegOcorrencias()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("  SELECT ID_NEG_PF_102 price_modificator_id, ");
            sb.AppendLine("        ID_OCORR_PK_102 object_id, ");
            sb.AppendLine("        NVL(SOMA_102, 0) addition, ");
            sb.AppendLine("        NVL(DESC_102, 0) discount ");
            sb.AppendLine("   FROM CONF_NEG_COMER_OCORR_102 ");
            sb.AppendLine("   JOIN CONF_NEG_COMER_100 ");
            sb.AppendLine("     ON ID_NEG_PK_100 = ID_NEG_PF_102 ");
            sb.AppendLine("    AND TIPO_NEG_100 = '1' ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacaoOcorrencias";

            db.Close();

            return dt;
        }

        //DifMercNegociacaoOcorrencias
        public DataTable getDifMercNegOcorrencias(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("  SELECT ID_NEG_PF_102 price_modificator_id, ");
            sb.AppendLine("        ID_OCORR_PK_102 object_id, ");
            sb.AppendLine("        NVL(SOMA_102, 0) addition, ");
            sb.AppendLine("        NVL(DESC_102, 0) discount ");
            sb.AppendLine("   FROM CONF_NEG_COMER_OCORR_102 ");
            sb.AppendLine("   JOIN CONF_NEG_COMER_100 ");
            sb.AppendLine("     ON ID_NEG_PK_100 = ID_NEG_PF_102 ");
            sb.AppendLine("    AND TIPO_NEG_100 = '1' ");
            sb.AppendLine("  WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "DifMercNegociacaoOcorrencias";

            db.Close();

            return dt;
        }

        //Lojas 
        public DataTable getLojas()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PK_226 id, ");
            sb.AppendLine("       RAZAO_SOCIAL_226 name, ");
            sb.AppendLine("       CASE WHEN LENGTH(CNPJ_226) = 14 THEN 'CNPJ' ELSE 'CPF' END document_type, ");
            sb.AppendLine("       CNPJ_226 document, ");
            sb.AppendLine("       EMAIL_EMPRESA_226 email ");
            sb.AppendLine("  FROM EMPRESA_226 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Lojas";

            db.Close();

            return dt;
        }

        //Lojas 
        public DataTable getLojas(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PK_226 id, ");
            sb.AppendLine("       RAZAO_SOCIAL_226 name, ");
            sb.AppendLine("       CASE WHEN LENGTH(CNPJ_226) = 14 THEN 'CNPJ' ELSE 'CPF' END document_type, ");
            sb.AppendLine("       CNPJ_226 document, ");
            sb.AppendLine("       EMAIL_EMPRESA_226 email ");
            sb.AppendLine("  FROM EMPRESA_226 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Lojas";

            db.Close();

            return dt;
        }

        //Tabela Clientes
        public DataTable getClientes()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine("TO_CHAR(CLI_PK_59) codigo, ");
            sb.AppendLine("DESCR_59 nome, ");
            sb.AppendLine("RAZAO_SOCIAL_59 razaosocial, ");
            sb.AppendLine("CASE WHEN LENGTH(CNPJ_CPF_59) = 14 THEN CNPJ_CPF_59 ELSE '' END  cnpj, ");
            sb.AppendLine("CASE WHEN LENGTH(CNPJ_CPF_59) <> 14 THEN CNPJ_CPF_59 ELSE '' END  cpf, ");
            sb.AppendLine("CASE WHEN LENGTH(CNPJ_CPF_59) = 14 THEN 'PJ' ELSE 'PF' END  tipo, ");
            sb.AppendLine("'' inscricaoestadual, ");
            sb.AppendLine("END_59 endereco, ");
            sb.AppendLine("NUM_END_COMER_59 numero, ");
            sb.AppendLine("BAIRRO_59 bairro, ");
            sb.AppendLine("ESTAD_FK_54 uf, ");
            sb.AppendLine("CIDAD_54 cidade, ");
            sb.AppendLine("CEP_LOGRAD_59 cep, ");
            sb.AppendLine("to_date(DT_CADASTRO_59, 'DD/MM/YYYY') datanascimento, ");
            sb.AppendLine("DDD1_59 || ' ' || TEL1_59 telfixo, ");
            sb.AppendLine("DDD2_59 || ' ' || TEL2_59 telcomercial, ");
            sb.AppendLine("DDD3_59 || ' ' || TEL3_59 telcelular, ");
            sb.AppendLine("EMAIL_59 email ");
            sb.AppendLine("FROM CLIENTE_59, CIDAD_54, CLIENTE_EMPRESA_63 ");
            sb.AppendLine("WHERE ");
            sb.AppendLine("CEP_PK_54 = CEP_FK_59 ");
            sb.AppendLine("and CLI_PK_59 = CLI_PF_63 ");
            sb.AppendLine("and TIPO_EMPRESA_63 = 'P' ");
            sb.AppendLine("AND ROWNUM < 501");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Clientes";

            db.Close();

            return dt;
        }

        public DataTable getClientes(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine("EMPRESA_PF_63 store_id, "); 
            sb.AppendLine("TO_CHAR(CLI_PK_59) id, ");
            sb.AppendLine("TO_CHAR(CLI_PK_59) code, ");
            sb.AppendLine("DESCR_59 name, ");
            sb.AppendLine("RAZAO_SOCIAL_59 company, ");
            sb.AppendLine("CASE WHEN LENGTH(CNPJ_CPF_59) = 14 THEN 'CNPJ' ELSE 'CPF' END  document_type, ");
            sb.AppendLine("CNPJ_CPF_59 document, ");
            sb.AppendLine("END_59 street, ");
            sb.AppendLine("NUM_END_COMER_59 \"number\", ");
            sb.AppendLine("BAIRRO_59 neighborhood, ");
            sb.AppendLine("IBGE_UF_ID_54 state_id, ");
            sb.AppendLine("ESTAD_FK_54 state, ");
            sb.AppendLine("CEP_PK_54 city_id, ");
            sb.AppendLine("CIDAD_54 city, ");
            sb.AppendLine("CEP_LOGRAD_59 zipcode, "); 
            sb.AppendLine("'BR' country, ");
            sb.AppendLine("TRIM(DDD1_59)  work_prefix,"); //state_id
            sb.AppendLine("TRIM(TEL1_59) work_number, ");
            sb.AppendLine("TRIM(DDD3_59) cellphone_prefix, ");
            sb.AppendLine("TRIM(TEL3_59) cellphone_number, ");
            sb.AppendLine("ROTA_FK_63 route_id, ");
            sb.AppendLine("GRUPO_CLI_FK_59 customer_group_id, ");
            sb.AppendLine("EMAIL_59 email ");
            sb.AppendLine("FROM CLIENTE_59, CIDAD_54, CLIENTE_EMPRESA_63 ");
            sb.AppendLine("WHERE ");
            sb.AppendLine("CEP_PK_54 = CEP_FK_59 ");
            sb.AppendLine("and CLI_PK_59 = CLI_PF_63 ");
            sb.AppendLine("and TIPO_EMPRESA_63 = 'P' ");
            sb.AppendLine("AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Clientes";

            db.Close();

            return dt;
        }

        //Tabela ClientesLoja
        public DataTable getClientesLoja()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_63 store_id, ");
            sb.AppendLine("       CLI_PF_63 customer_id ");
            sb.AppendLine("  FROM CLIENTE_EMPRESA_63 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "ClientesLoja";

            db.Close();

            return dt;
        }

        public DataTable getClientesLoja(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_63 store_id, ");
            sb.AppendLine("       CLI_PF_63 customer_id ");
            sb.AppendLine("  FROM CLIENTE_EMPRESA_63 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "ClientesLoja";

            db.Close();

            return dt;
        }

        //Tabela PerfilClientes
        public DataTable getPerfisClientes()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT  ");
            sb.AppendLine("    GRUPO_CLI_PK_324 id, ");
            sb.AppendLine("    GRUPO_CLI_PK_324 code, ");
            sb.AppendLine("    DESCR_324 name ");
            sb.AppendLine(" FROM GRUPO_CLI_324 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PerfisClientes";

            db.Close();

            return dt;
        }

        public DataTable getPerfisClientes(AgileESyncJob job)
        {         
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ");
            sb.AppendLine("    GRUPO_CLI_PK_324 id, ");
            sb.AppendLine("    GRUPO_CLI_PK_324 code, ");
            sb.AppendLine("       DESCR_324 name ");
            sb.AppendLine("  FROM GRUPO_CLI_324 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "PerfisClientes";

            db.Close();

            return dt;
        }

        //Tabela Rotas
        public DataTable getRotas()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT  ");
            sb.AppendLine("       ROTA_PK_675 id, ");
            sb.AppendLine("       ROTA_PK_675 code, ");
            sb.AppendLine("       DESCR_675 name, ");
            sb.AppendLine("       CASE PER_675 ");
            sb.AppendLine("         WHEN 'D' THEN 2 ");
            sb.AppendLine("         WHEN 'S' THEN 10 ");
            sb.AppendLine("         WHEN 'Q' THEN 20 ");
            sb.AppendLine("         WHEN 'M' THEN 30 ");
            sb.AppendLine("         ELSE 40 ");
            sb.AppendLine("       END deadline ");
            sb.AppendLine("  FROM ROTA_675 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Rotas";

            db.Close();

            return dt;
        }

        public DataTable getRotas(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT  ");
            sb.AppendLine("       ROTA_PK_675 id, ");
            sb.AppendLine("       ROTA_PK_675 code, ");
            sb.AppendLine("       DESCR_675 name, ");
            sb.AppendLine("       CASE PER_675 ");
            sb.AppendLine("         WHEN 'D' THEN 2 ");
            sb.AppendLine("         WHEN 'S' THEN 10 ");
            sb.AppendLine("         WHEN 'Q' THEN 20 ");
            sb.AppendLine("         WHEN 'M' THEN 30 ");
            sb.AppendLine("         ELSE 40 ");
            sb.AppendLine("       END deadline ");
            sb.AppendLine("  FROM ROTA_675 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Rotas";

            db.Close();

            return dt;
        }

        //Tabela Condicoes Comerciais
        public DataTable getCondComer()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT  ");
            sb.AppendLine("       COND_COMER_PK_85 code, ");
            sb.AppendLine("       DESCR_85 name, ");
            sb.AppendLine("       'boleto' type, ");
            sb.AppendLine("       NVL(PRZ_INI_85, 0) start_days, ");
            sb.AppendLine("       NVL(INTERVALO_DT_D_85, 0) interval, ");
            sb.AppendLine("       NVL(NUM_TIT_85, 0) installments, ");
            sb.AppendLine("       0 average_days, "); 
            sb.AppendLine("       CASE WHEN  ");
            sb.AppendLine("          NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0) ");
            sb.AppendLine("        < 0 THEN ");
            sb.AppendLine("          ABS(NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0)) ");
            sb.AppendLine("       ELSE 0 END discount, ");
            sb.AppendLine("       CASE WHEN ");
            sb.AppendLine("          NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0) ");
            sb.AppendLine("        > 0 THEN ");
            sb.AppendLine("          NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0) ");
            sb.AppendLine("       ELSE 0 END addition ");
            sb.AppendLine("  FROM COND_COMER_85, DIRETRIZ_TABELA_PRECO_ATC_216 ");
            sb.AppendLine(" WHERE EMPRESA_PF_216 = 1 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "CondComer";

            db.Close();

            return dt;
        }

        public DataTable getCondComer(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT  ");
            sb.AppendLine("       '000000000000000000000' id, ");
            sb.AppendLine("       COND_COMER_PK_85 code, ");
            sb.AppendLine("       DESCR_85 name, "); 
            sb.AppendLine("       'boleto' type, ");
            sb.AppendLine("       NVL(PRZ_INI_85, 0) start_days, ");
            sb.AppendLine("       NVL(INTERVALO_DT_D_85, 0) interval, ");
            sb.AppendLine("       NVL(NUM_TIT_85, 0) installments, ");
            sb.AppendLine("       0 average_days, ");
            sb.AppendLine("       CASE WHEN  ");
            sb.AppendLine("          NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0) ");
            sb.AppendLine("        < 0 THEN ");
            sb.AppendLine("          ABS(NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0)) ");
            sb.AppendLine("       ELSE 0 END discount, ");
            sb.AppendLine("       CASE WHEN ");
            sb.AppendLine("          NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 ");
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0) ");
            sb.AppendLine("        > 0 THEN ");
            sb.AppendLine("          NVL( ");
            sb.AppendLine("              CASE ESCOLH_PRC_85 ");
            sb.AppendLine("                 WHEN 'A' THEN PERC_RECORREC_CADASTRO_216 ");
            sb.AppendLine("                 WHEN 'B' THEN PERC_RECORREC_PRZ1_216 ");
            sb.AppendLine("                 WHEN 'C' THEN PERC_RECORREC_PRZ2_216 ");
            sb.AppendLine("                 WHEN 'D' THEN PERC_RECORREC_PRZ3_216 ");
            sb.AppendLine("                 WHEN 'E' THEN PERC_RECORREC_PRZ4_216 "); 
            sb.AppendLine("                 WHEN 'F' THEN PERC_RECORREC_PRZ5_216 ");
            sb.AppendLine("              END, ");
            sb.AppendLine("            0) ");
            sb.AppendLine("       ELSE 0 END addition ");
            sb.AppendLine("  FROM COND_COMER_85, DIRETRIZ_TABELA_PRECO_ATC_216 ");
            sb.AppendLine(" WHERE EMPRESA_PF_216 = 1 AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());

            dt.Rows[0]["average_days"] = CalcPrzMedio(int.Parse(dt.Rows[0]["installments"].ToString()), int.Parse(dt.Rows[0]["start_days"].ToString()), int.Parse(dt.Rows[0]["interval"].ToString()));
            dt.Rows[0]["id"] = ConvertStrIntoNumber(dt.Rows[0]["code"].ToString());

            dt.TableName = "CondComer";

            db.Close();

            return dt;
        }

        private static string ConvertStrIntoNumber(string str)
        {
            string convertedstr = "";

            foreach (char c in str)
            {
                int unicode = c;
                convertedstr = convertedstr + unicode.ToString().PadLeft(4, '0');                
            }

            return convertedstr;
        }

        private static string ConvertNumberIntoStr(string number)
        {
            return Convert.ToChar(int.Parse(number.Substring(0, 2))).ToString() + Convert.ToChar(int.Parse(number.Substring(2, 2))).ToString();
        }

        private decimal CalcPrzMedio(int installments, int? start_days, int? interval)
        {
            decimal avg = 0;

            for (int i = 1; i <= installments; i++)
            {
                if (i == 1)
                    avg += (start_days.HasValue ? start_days.Value : 0);
                else
                {
                    avg += i * (interval.HasValue ? interval.Value : 0);
                }

            }

            avg = avg / installments;

            return Math.Round(avg);
        }

        //Tabela Marcas
        public DataTable getMarcas()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ID_MARCA_PK_1290 id, ");
            sb.AppendLine("       NOME_1290 name ");
            sb.AppendLine("  FROM MARCA_1290 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Marcas";

            db.Close();

            return dt;
        }

        public DataTable getMarcas(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT ID_MARCA_PK_1290 id, ");
            sb.AppendLine("       NOME_1290 name ");
            sb.AppendLine("  FROM MARCA_1290 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Marcas";

            db.Close();

            return dt;
        }

        //Tabela Categorias
        public DataTable getCategorias()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT F1.FAMILIA_PK_291 id, ");
            sb.AppendLine("       F1.DESCR_291 name, ");
            sb.AppendLine("       (SELECT F2.FAMILIA_PK_291 FROM FAMILIA_MERC_291 F2 WHERE F2.CONTA_291 = (CASE WHEN LENGTH(F1.CONTA_291) = 10 THEN SUBSTRB(F1.CONTA_291, 1, 8) WHEN LENGTH(F1.CONTA_291) = 8 THEN SUBSTRB(F1.CONTA_291, 1, 5) WHEN LENGTH(F1.CONTA_291) = 5 THEN SUBSTRB(F1.CONTA_291, 1, 2) END) ) parent_id ");
            sb.AppendLine("FROM FAMILIA_MERC_291 F1 ");
            sb.AppendLine("ORDER BY CONTA_291 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Marcas";

            db.Close();

            return dt;
        }

        public DataTable getCategorias(AgileESyncJob job)
        {
            string In = "";
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT F1.FAMILIA_PK_291 id, ");
            sb.AppendLine("       F1.DESCR_291 name, ");
            sb.AppendLine("       (SELECT F2.FAMILIA_PK_291 FROM FAMILIA_MERC_291 F2 WHERE F2.CONTA_291 = (CASE WHEN LENGTH(F1.CONTA_291) = 10 THEN SUBSTRB(F1.CONTA_291, 1, 8) WHEN LENGTH(F1.CONTA_291) = 8 THEN SUBSTRB(F1.CONTA_291, 1, 5) WHEN LENGTH(F1.CONTA_291) = 5 THEN SUBSTRB(F1.CONTA_291, 1, 2) END) ) parent_id ");
            sb.AppendLine("FROM FAMILIA_MERC_291 F1 ");
            sb.AppendLine("WHERE " + job.sql_where);
            sb.AppendLine("ORDER BY CONTA_291 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Marcas";

            db.Close();

            //Verificando se a categoria tem um pai
            while (dt.Rows[0]["parent_id"].ToString().Length > 0)
            {
                In += dt.Rows[0]["id"].ToString() + "," + dt.Rows[0]["parent_id"].ToString() + ",";
                dt = getCategoria(dt.Rows[0]["parent_id"].ToString());
            }

            if (In.Length > 0)
            {
                In = In.Remove(In.Length - 1, 1);
                return getCategorias(In);
            }
            else
                return dt;
        }

        //private recuperando Categorias IN
        private DataTable getCategoria(string idCategoria)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT F1.FAMILIA_PK_291 id, ");
            sb.AppendLine("       F1.DESCR_291 name, ");
            sb.AppendLine("       (SELECT F2.FAMILIA_PK_291 FROM FAMILIA_MERC_291 F2 WHERE F2.CONTA_291 = (CASE WHEN LENGTH(F1.CONTA_291) = 10 THEN SUBSTRB(F1.CONTA_291, 1, 8) WHEN LENGTH(F1.CONTA_291) = 8 THEN SUBSTRB(F1.CONTA_291, 1, 5) WHEN LENGTH(F1.CONTA_291) = 5 THEN SUBSTRB(F1.CONTA_291, 1, 2) END) ) parent_id ");
            sb.AppendLine("FROM FAMILIA_MERC_291 F1 ");
            sb.AppendLine("WHERE F1.FAMILIA_PK_291 = " + idCategoria + " ");
            sb.AppendLine("ORDER BY CONTA_291 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Marcas";

            db.Close();

            return dt;
        }

        //private recuperando Categorias IN
        private DataTable getCategorias(string In)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT F1.FAMILIA_PK_291 id, ");
            sb.AppendLine("       F1.DESCR_291 name, ");
            sb.AppendLine("       (SELECT F2.FAMILIA_PK_291 FROM FAMILIA_MERC_291 F2 WHERE F2.CONTA_291 = (CASE WHEN LENGTH(F1.CONTA_291) = 10 THEN SUBSTRB(F1.CONTA_291, 1, 8) WHEN LENGTH(F1.CONTA_291) = 8 THEN SUBSTRB(F1.CONTA_291, 1, 5) WHEN LENGTH(F1.CONTA_291) = 5 THEN SUBSTRB(F1.CONTA_291, 1, 2) END) ) parent_id ");
            sb.AppendLine("FROM FAMILIA_MERC_291 F1 ");
            sb.AppendLine("WHERE F1.FAMILIA_PK_291 IN (" + In + ")");
            sb.AppendLine("ORDER BY CONTA_291 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Marcas";

            db.Close();

            return dt;
        }

        //Tabela Produtos
        public DataTable getProdutos()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT MERC_PF_468 id, "); 
            sb.AppendLine("       MERC_PF_468 code, ");
            sb.AppendLine("       DESCR_461 || DESCR2_461 name, ");
            sb.AppendLine("       (SELECT M2.ID_MARCA_PK_1290  ");
            sb.AppendLine("          FROM MARCA_1290 M2 ");
            sb.AppendLine("         WHERE M2.NOME_1290 = M1.MARC_MERC_461 ");
            sb.AppendLine("           AND ROWNUM = 1) brand_id, ");
            sb.AppendLine("       FAMILIA_PK_291 departament_id, ");
            sb.AppendLine("       REF_FABRIC_478 sku, ");
            sb.AppendLine("       (SELECT ID_BAR_PK_481 FROM MERC_INVOL_ID_COD_BAR_481 WHERE MERC_PF_481 =  M1.MARC_MERC_461 AND INVOL_PF_481 = 1 AND ROWNUM = 1) ean, ");
            sb.AppendLine("       '[''' ||  DESCR_FOTO_461 || ''']' images, ");
            sb.AppendLine("       CASE WHEN MERC_FUNCIO_468 = 'A' THEN 'active' else 'inactive' END status, ");
            sb.AppendLine("       CASE WHEN LENGTH(DEFIN_MERC_461) > 0 THEN('Concepção: ' || DEFIN_MERC_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(CONSTIT_MERC_461) > 0 THEN('Formulação: ' || CONSTIT_MERC_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(ORIG_MERC_461) > 0 THEN('Origem: ' || ORIG_MERC_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_DEP_461) > 0 THEN('Temperatura estocagem no armazém: ' || TEMPERAT_DEP_461 || '<br>')  ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Temperatura estocagem no cliente: ' || TEMPERAT_CLI_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Vida útil: ' || PRZ_VALID_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Mercado alvo: ' || PUBLICO_OBJETIVO_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Utilização: ' || INDICACAO_UTIL_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Proposta de venda: ' || PROV_OFERTA_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_DEP_461) > 0 THEN('Dados complementares: ' || INFORM_COMPL_461) ELSE '' END description1 ");
            sb.AppendLine("  FROM MERC_EMPRESA_468, ");
            sb.AppendLine("       MERCADORIA_461 M1, ");
            sb.AppendLine("       FAMILIA_MERC_291, ");
            sb.AppendLine("       MERC_FABRIC_478, ");
            sb.AppendLine("       FABRICANTE_271 ");
            sb.AppendLine(" WHERE EMPRESA_PF_468 = 1 ");
            sb.AppendLine("       AND MERC_PK_461 = MERC_PF_468 ");
            sb.AppendLine("       AND TIPO_UTIL_461 = 'C' ");
            sb.AppendLine("       AND ENVIA_POCKET_461 = 'S' ");
            sb.AppendLine("       AND FAMILIA_PK_291 = FAMILIA_FK_461 ");
            sb.AppendLine("       AND EMPRESA_PF_478 = EMPRESA_PF_468 ");
            sb.AppendLine("       AND MERC_PF_478 = MERC_PK_461 ");
            sb.AppendLine("       AND FABRIC_PK_271 = FABRIC_PF_478 ");
            sb.AppendLine("       AND TIPO_CONSTIT_468 = 1 ");
            sb.AppendLine("       AND TIPO_FABRIC_478 = 'P' ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Produtos";

            db.Close();

            return dt;
        }

        public DataTable getProdutos(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT MERC_PF_468 id, ");
            sb.AppendLine("       MERC_PF_468 code, ");
            sb.AppendLine("       DESCR_461 || DESCR2_461 name, ");
            //sb.AppendLine("       (SELECT M2.ID_MARCA_PK_1290  ");
            //sb.AppendLine("          FROM MARCA_1290 M2 ");
            //sb.AppendLine("         WHERE TRIM(M2.NOME_1290) = TRIM(M1.MARC_MERC_461) ");
            //sb.AppendLine("           AND ROWNUM = 1) brand_id, ");
            sb.AppendLine("       202 brand_id, ");
            sb.AppendLine("       FAMILIA_PK_291 departament_id, ");
            sb.AppendLine("       REF_FABRIC_478 sku, ");
            sb.AppendLine("       (SELECT ID_BAR_PK_481 FROM MERC_INVOL_ID_COD_BAR_481 WHERE MERC_PF_481 = MERC_PF_468 AND INVOL_PF_481 = 1 AND ROWNUM = 1) ean, ");
            sb.AppendLine("       '[''' ||  DESCR_FOTO_461 || ''']' images, ");
            sb.AppendLine("       CASE WHEN MERC_FUNCIO_468 = 'A' THEN 'active' else 'inactive' END status, ");
            sb.AppendLine("       CASE WHEN LENGTH(DEFIN_MERC_461) > 0 THEN('Concepção: ' || DEFIN_MERC_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(CONSTIT_MERC_461) > 0 THEN('Formulação: ' || CONSTIT_MERC_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(ORIG_MERC_461) > 0 THEN('Origem: ' || ORIG_MERC_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_DEP_461) > 0 THEN('Temperatura estocagem no armazém: ' || TEMPERAT_DEP_461 || '<br>')  ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Temperatura estocagem no cliente: ' || TEMPERAT_CLI_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Vida útil: ' || PRZ_VALID_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Mercado alvo: ' || PUBLICO_OBJETIVO_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Utilização: ' || INDICACAO_UTIL_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_CLI_461) > 0 THEN('Proposta de venda: ' || PROV_OFERTA_461 || '<br>') ELSE '' END || ");
            sb.AppendLine("       CASE WHEN LENGTH(TEMPERAT_DEP_461) > 0 THEN('Dados complementares: ' || INFORM_COMPL_461) ELSE '' END description1 ");
            sb.AppendLine("  FROM MERC_EMPRESA_468, ");
            sb.AppendLine("       MERCADORIA_461 M1, ");
            sb.AppendLine("       FAMILIA_MERC_291, ");
            sb.AppendLine("       MERC_FABRIC_478, ");
            sb.AppendLine("       FABRICANTE_271 ");
            sb.AppendLine(" WHERE EMPRESA_PF_468 = 1 ");
            sb.AppendLine("       AND MERC_PK_461 = MERC_PF_468 ");
            sb.AppendLine("       AND TIPO_UTIL_461 IN ('C', 'R') ");
            //sb.AppendLine("       AND ENVIA_POCKET_461 = 'S' ");
            sb.AppendLine("       AND FAMILIA_PK_291 = FAMILIA_FK_461 ");
            sb.AppendLine("       AND EMPRESA_PF_478 = EMPRESA_PF_468 ");
            sb.AppendLine("       AND MERC_PF_478 = MERC_PK_461 ");
            sb.AppendLine("       AND FABRIC_PK_271 = FABRIC_PF_478 ");
            sb.AppendLine("       AND TIPO_CONSTIT_468 = 1 ");
            sb.AppendLine("       AND TIPO_FABRIC_478 = 'P' ");

            sb.AppendLine("       AND " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Produtos";

            db.Close();

            return dt;
        }

        //Embalagens
        public DataTable getEmbalagens()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT merc_pf_479 AS parent_id, ");
            sb.AppendLine("       '99' || LPAD(merc_pf_479, 8, '0') || LPAD(invol_pk_479, 3, '0') AS id, ");
            sb.AppendLine("       tipo_479 AS unity, ");
            sb.AppendLine("       qtd_479 AS multiply, ");
            sb.AppendLine("       tipo_479 || '/' || qtd_479 name, ");
            sb.AppendLine("       NVL(ACRESCIMO_479, 0) addition, ");
            sb.AppendLine("       NVL(DESCONTO_479, 0) discount, ");
            sb.AppendLine("       'active' status ");
            sb.AppendLine("  FROM merc_invol_479 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Embalagens";

            db.Close();

            return dt;
        }

        public DataTable getEmbalagens(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT merc_pf_479 AS parent_id, ");
            sb.AppendLine("       '99' || LPAD(merc_pf_479, 8, '0') || LPAD(invol_pk_479, 3, '0') AS id, ");
            sb.AppendLine("       tipo_479 AS unity, ");
            sb.AppendLine("       qtd_479 AS multiple, ");
            sb.AppendLine("       tipo_479 || '/' || qtd_479 name, ");
            sb.AppendLine("       NVL(ACRESCIMO_479, 0) addition, ");
            sb.AppendLine("       NVL(DESCONTO_479, 0) discount, ");
            sb.AppendLine("       'active' status ");
            sb.AppendLine("  FROM merc_invol_479 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Embalagens";

            db.Close();

            return dt;
        }

        //Embalagens
        //TIPO_UTIL_461 (sells_without_stock)
        public DataTable getEstoque()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_468 store_id, ");
            sb.AppendLine("       MERC_PF_468 product_id, ");
            sb.AppendLine("       (NVL(saldo_estoq_468, 0) ");
            sb.AppendLine("        - NVL(saldo_danif_468, 0) ");
            sb.AppendLine("        - NVL(saldo_merc_composto_468, 0) ");
            sb.AppendLine("        - NVL(saldo_furt_468, 0)) stock_quantity, ");
            sb.AppendLine("        'false' sells_without_stock, ");
            sb.AppendLine("        'true' active ");
            sb.AppendLine("  FROM merc_empresa_468 ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Estoques";

            db.Close();

            return dt;
        }

        public DataTable getEstoque(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_468 store_id, ");
            sb.AppendLine("       MERC_PF_468 product_id, ");
            sb.AppendLine("       ((NVL(saldo_estoq_468, 0) ");
            sb.AppendLine("        - NVL(saldo_danif_468, 0) ");
            sb.AppendLine("        - NVL(saldo_merc_composto_468, 0) ");
            sb.AppendLine("        - NVL(saldo_furt_468, 0))) stock_quantity, ");
            sb.AppendLine("        'false' sells_without_stock, ");
            sb.AppendLine("        'true' active ");
            sb.AppendLine("  FROM merc_empresa_468 ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Estoques";

            db.Close();

            return dt;
        }

        //Precos
        public DataTable getPreco()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_468 store_id,  ");
            sb.AppendLine("       MERC_PF_468 product_id,  ");
            sb.AppendLine("       PRC_COMER_468 regular_price  ");
            sb.AppendLine("  FROM MERC_EMPRESA_468  ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Precos";

            db.Close();

            return dt;
        }

        public DataTable getPreco(AgileESyncJob job)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT EMPRESA_PF_468 store_id,  ");
            sb.AppendLine("       MERC_PF_468 product_id,  ");
            sb.AppendLine("       PRC_COMER_468 regular_price ");
            sb.AppendLine("  FROM MERC_EMPRESA_468  ");
            sb.AppendLine(" WHERE " + job.sql_where);

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Precos";

            db.Close();

            return dt;
        }

        public DataTable getTabelas()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine("SELECT TABLE_NAME ");
            sb.AppendLine("  FROM ALL_TABLES ");
            sb.AppendLine(" WHERE OWNER = 'ESTALO_DBA' ");
            sb.AppendLine("ORDER BY TABLE_NAME ");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Tabelas";

            db.Close();

            return dt;
        }

        public DataTable getCampos(string chave)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();

            sb.AppendLine(@"SELECT COLUNAS.COLUMN_ID AS ID, ");
            sb.AppendLine(@"    COLUNAS.COLUMN_NAME AS COLUNA ");
            sb.AppendLine(@"FROM ");
            sb.AppendLine(@"    USER_TABLES TABELA, ");
            sb.AppendLine(@"    USER_TAB_COLUMNS COLUNAS ");
            sb.AppendLine(@"WHERE TABELA.TABLE_NAME = COLUNAS.TABLE_NAME ");
            sb.AppendLine(@"  AND TABELA.TABLE_NAME = '" + chave + "'");

            db.Open();

            dt = db.LerNoBanco(sb.ToString());
            dt.TableName = "Campos";

            db.Close();

            return dt;
        }

        public void updateSyncJobStatus(string Id)
        {
            db.Open();
            db.GravaNoBanco(string.Format("UPDATE AGILE_ECOM_INT_ERP SET SN_ENVIADO = 'S' WHERE ID_PK = {0}", Id));
            db.Close();
        }

        public void updateSyncJobStatus(AgileESyncJob job)
        {
            if (job.Status == "S")
            {
                job.Json_Envio = "";
                job.Json_Retorno = "";
            }

            db.Open();
            db.GravaNoBanco(string.Format("UPDATE AGILE_ECOM_INT_ERP SET Status = '{0}', JSON_ENVIO = '{1}', JSON_RETORNO = '{2}', URL = '{3}', LOG = '{4}', DATA_ENVIO = SYSDATE, CODIGO_RETORNO = '{5}' WHERE ID_PK = {6}", job.Status, job.Json_Envio, job.Json_Retorno, job.Url, job.Log, job.Codigo_Retorno, job.Id));
            db.Close();
        }

        public string GerarGatilho(string tabela_erp, string tabela_agileecommerce, string[] campos, string[] camposchave, ref string nomegatilho)
        {
            int count_campos = 1;
            string sql_where = "";

            StringBuilder sb = new StringBuilder();
            sb.Length = 0;

            nomegatilho = "ESTALO_DBA.TR_ESYNC_" + tabela_agileecommerce;

            string nomegatilho_sem_usuario = "TR_ESYNC_" + tabela_agileecommerce;

            foreach (string campo in camposchave)
            {
                sql_where += "'TO_CHAR(" + campo + ") = ' || CHR(39) || :new." + campo + " || CHR(39) || ' AND ' || ";
            }

            sql_where = sql_where.Remove(sql_where.Length - 14, 14);

            sb.AppendLine(@"CREATE OR REPLACE TRIGGER " + nomegatilho);
            sb.AppendLine(@"AFTER UPDATE OR INSERT OR DELETE ");
            sb.AppendLine(@"ON ESTALO_DBA." + tabela_erp + " REFERENCING NEW AS New OLD AS Old");
            sb.AppendLine(@"FOR EACH ROW ");
            sb.AppendLine(@"DECLARE");
            sb.AppendLine(@" ");
            sb.AppendLine(@"BEGIN ");
            sb.AppendLine(@"      IF INSERTING OR ");

            foreach (string campo in campos)
            {
                sb.AppendLine(@"  (");
                sb.AppendLine(@"     ((:OLD." + campo + " IS NULL) AND (:NEW." + campo + " IS NOT NULL)) OR ");
                sb.AppendLine(@"     ((:OLD." + campo + " IS NOT NULL) AND (:NEW." + campo + " IS NULL))  OR ");
                sb.AppendLine(@"     ((:OLD." + campo + " <> :NEW." + campo + ")) ");
                if (count_campos != campos.Count())
                    sb.Append(@"  ) OR");

                count_campos++;
            }

            sb.AppendLine(@"  ) THEN ");
            sb.AppendLine(@" ");
            sb.AppendLine(@"    IF INSERTING THEN");
            sb.AppendLine(@"      INSERT INTO AGILE_ECOM_INT_ERP (DATA_REGISTRO, TABELA, SQL_WHERE, SQL_TIPO, STATUS) VALUES (sysdate, '" + tabela_agileecommerce + "', (" + sql_where + "), 'I', 'P');");
            sb.AppendLine(@"    END IF;");
            sb.AppendLine(@" ");
            sb.AppendLine(@"    IF UPDATING THEN");
            sb.AppendLine(@"      INSERT INTO AGILE_ECOM_INT_ERP (DATA_REGISTRO, TABELA, SQL_WHERE, SQL_TIPO, STATUS) VALUES (sysdate, '" + tabela_agileecommerce + "', (" + sql_where + "), 'U', 'P');");
            sb.AppendLine(@"    END IF;");
            sb.AppendLine(@" ");
            sb.AppendLine(@"  END IF; ");
            sb.AppendLine(@" ");
            sb.AppendLine(@"  IF DELETING THEN");
            sb.AppendLine(@"    INSERT INTO AGILE_ECOM_INT_ERP (DATA_REGISTRO, TABELA, SQL_WHERE, SQL_TIPO, STATUS) VALUES (sysdate, '" + tabela_agileecommerce + "', (" + sql_where + "), 'D', 'P');");
            sb.AppendLine(@"  END IF;");
            sb.AppendLine(@" ");
            sb.AppendLine(@" EXCEPTION");
            sb.AppendLine(@"     WHEN OTHERS THEN ");
            sb.AppendLine(@"        NULL;");
            sb.AppendLine(@" END " + nomegatilho_sem_usuario + "; ");
            sb.AppendLine(@"");

            return sb.ToString();
        }

        public bool InternalizaPedido(AgileECommerceApi.Pedido pedido)
        {
            bool didWork = false;
            string r = "";


            objInternalizaPedido i = new objInternalizaPedido(_strcon, Geral.getAppConStrEDI());

            i.Internaliza("1", "1", "1", "1", pedido, ref r);

            return didWork;
        }

    }

    public class objEDI8
    {
        public objEDI8(string ConStr)
        {
            _ConStr = ConStr;

        }

        public static System.Globalization.CultureInfo CultureBR = new System.Globalization.CultureInfo("pt-BR"); // Configurações regionais Português/Brasil
        public static System.Globalization.CultureInfo CultureUS = new System.Globalization.CultureInfo("en-US"); // Configurações regionais Inglês/Estados Unidos

        public string EMPRESA_DIGIT_PF_EDI8;
        public int SEQ_PEDIDO_EDI_PF_EDI8;
        public int MERC_PF_EDI8;
        public int INVOLUCRO_EDI8;
        public string TIPO_NEGOCIACAO_EDI8;
        public double QTD_PEDIDA_EDI8;
        public double QTD_INVOLUCRO_EDI8;
        public double PRECO_COMER_EDI8;
        public double PRECO_FABRICA_EDI8;
        public int PRZ_COMER_EDI8;
        public double DIF_PRECO_TABELA_EDI8;
        public double DESC_MERC_EDI8;
        public double DESC_MAX_EDI8;
        public double DESC_MERC_LIQ_EDI8;
        public double DESC_COMER_EDI8;
        public string OBSERVACAO_EDI8;

        public double DESC_APLICAOD_EDI8;
        private string SqlCom;
        private string _ConStr;
        private dbHarpia dbFenix;

        private DataTable ReadedTable;

        public void INSERT()
        {
            SqlCom = "INSERT INTO PEDIDO_EMPRESA_MERC_EDI8 " + "(EMPRESA_DIGIT_PF_EDI8, SEQ_PEDIDO_EDI_PF_EDI8, MERC_PF_EDI8, INVOLUCRO_EDI8, TIPO_NEGOCIACAO_EDI8, QTD_PEDIDA_EDI8, QTD_INVOLUCRO_EDI8, PRECO_COMER_EDI8, PRECO_FABRICA_EDI8, PRZ_COMER_EDI8, DIF_PRECO_TABELA_EDI8, DESC_MERC_EDI8, DESC_MAX_EDI8, DESC_MERC_LIQ_EDI8, DESC_COMER_EDI8, DESC_APLICAOD_EDI8, OBSERVACAO_EDI8) " + " VALUES " + "(" + this.EMPRESA_DIGIT_PF_EDI8 + ", " + this.SEQ_PEDIDO_EDI_PF_EDI8 + ", " + this.MERC_PF_EDI8 + ", " + this.INVOLUCRO_EDI8 + ", '" + this.TIPO_NEGOCIACAO_EDI8 + "', " + this.QTD_PEDIDA_EDI8.ToString().Replace(",", ".") + ", " + this.QTD_INVOLUCRO_EDI8.ToString().Replace(",", ".") + ", " + this.PRECO_COMER_EDI8.ToString().Replace(",", ".") + ", " + this.PRECO_FABRICA_EDI8.ToString().Replace(",", ".") + ", " + this.PRZ_COMER_EDI8 + ", " + this.DIF_PRECO_TABELA_EDI8.ToString().Replace(",", ".") + ", " + this.DESC_MERC_EDI8.ToString().Replace(",", ".") + ", " + this.DESC_MAX_EDI8.ToString().Replace(",", ".") + ", " + this.DESC_MERC_LIQ_EDI8.ToString().Replace(",", ".") + ", " + this.DESC_COMER_EDI8.ToString().Replace(",", ".") + ", " + this.DESC_APLICAOD_EDI8.ToString().Replace(",", ".") + ", '" + this.OBSERVACAO_EDI8 + "' )";

            Open();
            dbFenix.GravaNoBanco(SqlCom);
            Close();
        }

        private void Open()
        {
            dbFenix = new dbHarpia(_ConStr);
            dbFenix.Open();
        }

        private void Close()
        {
            dbFenix.Close();
        }

        /// <summary>
        /// Formata um valor de acordo com um número de casas decimais especificado
        /// </summary>
        /// <param name="valor">Valor a ser formatado</param>
        /// <param name="nroDecimais">Número de decimais</param>
        /// <returns>String contendo o valor formatado</returns>
        public static string FormataValor(decimal valor, int nroDecimais)
        {
            string formato = "###,##0";
            string decimais = ".";

            // Formata casas decimais
            if (nroDecimais > 0)
                decimais = decimais.PadRight(nroDecimais + 1, '0');

            // Retorna o valor
            return string.Format(CultureUS, "{0:" + formato + decimais + "}", valor);
        }

        /// <summary>
        /// Formata um valor de acordo com um número de casas decimais especificado
        /// </summary>
        /// <param name="valor">Valor a ser formatado</param>
        /// <param name="nroDecimais">Número de decimais</param>
        /// <returns>String contendo o valor formatado</returns>
        public static string FormataValor(double valor, int nroDecimais)
        {
            return FormataValor((decimal)valor, nroDecimais);
        }

    }

    public class objEDI7
    {
        public objEDI7(string ConStr)
        {
            _ConStr = ConStr;

        }

        public string EMPRESA_DIGIT_PF_EDI7;
        public string SEQ_PEDIDO_EDI_PK_EDI7;
        public int VENDEDOR_FK_EDI7;
        public string MODO_DIGITA_EDI7;
        public string EMPRESA_FATURA_PF_EDI7;
        public int CLIENTE_FK_EDI7;
        public string CONDCOMER_FK_EDI7;
        public int MODO_ATEND_FK_EDI7;
        public string PEDIDO_PROG_EDI7;
        public string SN_REPASSE_EDI7;
        public int PORTADOR_FK_EDI7;
        public string TIPO_COMER_EDI7;
        public int PROMO_FK_EDI7;
        public System.DateTime DT_PEDIDO_PROG_EDI7;
        public string TIT_CARTEIRA_EDI7;
        public System.DateTime DT_INI_DIGITA_EDI7;
        public System.DateTime DT_FIN_DIGITA_EDI7;
        public string SN_DESC_MERC_EDI7;
        public string MSG_PEDIDO_CONF_EDI7;
        public string MSG_NF_EDI7;
        public string MSG_ROMANEIO_EDI7;
        public string MSG_PEDIDO_CONF_PAD_EDI7;
        public string DESC_MODO_COMER_EDI7;
        public string NUM_PEDIDO_ORIG_EDI7;
        public int TRANSPORTADORA_EDI7;
        public int ROTA_EDI7;
        public int TIPO_ENTR_EDI7;

        public string EMPRESA_LOGIST_PF_EDI7;
        private string SqlCom;
        private string _ConStr;
        private dbHarpia dbFenix;

        private DataTable ReadedTable;

        private void Open()
        {
            dbFenix = new dbHarpia(_ConStr);
            dbFenix.Open();
        }

        private void Close()
        {
            dbFenix.Close();
        }

        public void INSERT()
        {
            SqlCom = "INSERT INTO PEDIDO_EMPRESA_EDI7 " + "(EMPRESA_DIGIT_PF_EDI7, SEQ_PEDIDO_EDI_PK_EDI7, VENDEDOR_FK_EDI7, MODO_DIGITA_EDI7, EMPRESA_FATURA_PF_EDI7, CLIENTE_FK_EDI7, CONDCOMER_FK_EDI7, MODO_ATEND_FK_EDI7, PEDIDO_PROG_EDI7, SN_REPASSE_EDI7, PORTADOR_FK_EDI7, TIPO_COMER_EDI7, PROMO_FK_EDI7, DT_PEDIDO_PROG_EDI7, TIT_CARTEIRA_EDI7, DT_INI_DIGITA_EDI7, DT_FIN_DIGITA_EDI7, SN_DESC_MERC_EDI7, MSG_PEDIDO_CONF_EDI7, MSG_NF_EDI7, MSG_ROMANEIO_EDI7, MSG_PEDIDO_CONF_PAD_EDI7, DESC_MODO_COMER_EDI7, NUM_PEDIDO_ORIG_EDI7, TRANSPORTADORA_EDI7, ROTA_EDI7, EMPRESA_LOGIST_PF_EDI7, TIPO_ENTR_EDI7) " + " VALUES " + "('" + this.EMPRESA_DIGIT_PF_EDI7 + "', '" + this.SEQ_PEDIDO_EDI_PK_EDI7 + "', " + this.VENDEDOR_FK_EDI7 + ", '" + this.MODO_DIGITA_EDI7 + "', '" + this.EMPRESA_FATURA_PF_EDI7 + "', " + this.CLIENTE_FK_EDI7 + ", '" + this.CONDCOMER_FK_EDI7 + "', '" + this.MODO_ATEND_FK_EDI7 + "', '" + this.PEDIDO_PROG_EDI7 + "', '" + this.SN_REPASSE_EDI7 + "', " + this.PORTADOR_FK_EDI7 + ", '" + this.TIPO_COMER_EDI7 + "', " + this.PROMO_FK_EDI7 + ", TO_DATE('" + this.DT_PEDIDO_PROG_EDI7 + "', 'DD/MM/YYYY HH24:MI:SS'), '" + this.TIT_CARTEIRA_EDI7 + "', TO_DATE('" + this.DT_INI_DIGITA_EDI7 + "', 'DD/MM/YYYY HH24:MI:SS'), TO_DATE('" + this.DT_FIN_DIGITA_EDI7 + "', 'DD/MM/YYYY HH24:MI:SS'), '" + this.SN_DESC_MERC_EDI7 + "', '" + this.MSG_PEDIDO_CONF_EDI7 + "', '" + this.MSG_NF_EDI7 + "', '" + this.MSG_ROMANEIO_EDI7 + "', '" + this.MSG_PEDIDO_CONF_PAD_EDI7 + "', '" + this.DESC_MODO_COMER_EDI7 + "', '" + this.NUM_PEDIDO_ORIG_EDI7 + "', " + this.TRANSPORTADORA_EDI7 + ", " + this.ROTA_EDI7 + ", '" + this.EMPRESA_LOGIST_PF_EDI7 + "', " + this.TIPO_ENTR_EDI7.ToString() + ")";

            Open();
            dbFenix.GravaNoBanco(SqlCom);
            Close();
        }

    }

    public class objEDI620
    {
        string _ConStr;
        private StringBuilder SqlCom = new StringBuilder();
        private dbHarpia dbFenix;


        public objEDI620(string ConStr)
        {
            _ConStr = ConStr;
        }

        public string E_491_CLI_PF_620;
        public string E_491_EMPRESA_PF_620;
        public string E_491_COND_COMER_FK_620;
        public int E_491_NAT_OPER_FK_620;
        public string E_491_DESCR_ARQ_620;
        public string E_491_HR_INI_620;
        public string E_491_HR_FIN_620;
        public string E_491_ID_BAR_DEPOSIT_620;
        public string E_491_ID_BAR_FABRIC_620;
        public DateTime E_491_DT_PEDIDO_620;
        public string E_491_ID_BAR_CONTATO_620;
        public double E_491_QTD_TOT_RECUS_620;
        public double E_491_QTD_TOT_ATEND_620;
        public int E_491_MERC_RECUSADOS_620;
        public int E_491_MERC_ATEND_620;
        public string E_491_ARQ_FALTA_620;
        public string E_491_ARQ_PED_CONF_620;
        public string E_491_PEDIDO_ORIG_620;
        public int E_491_SEQ_PEDIDO_PK_620;
        public double E_491_VLR_TOT_RECUSADO_620;
        public double E_491_VLR_TOT_ATENDIDO_620;
        public string E_491_MOTIV_BLOQ_620;
        public string E_491_REP_VEND_620;
        public string PEDIDO_CLI_491;
        public string E_491_EMPRESA_FATUR_620;
        public string E_491_AMBIENTE_620;
        public string E_491_ENVIA_PALM_620;
        public string E_491_GRAVA_RETORN_620;
        public string E_491_PEDIDO_PROC_620;
        public DateTime E_491_DT_PROC_620;
        public string E_491_ORIGEM_620;

        private void Open()
        {
            dbFenix = new dbHarpia(_ConStr);
            dbFenix.Open();
        }

        private void Close()
        {
            dbFenix.Close();
        }

        public void INSERT()
        {

            SqlCom.Length = 0;
            SqlCom.Append("INSERT INTO PROC_EDI_491_LIST_620 (E_491_HR_INI_620, E_491_HR_FIN_620, E_491_DT_PEDIDO_620, ");
            SqlCom.Append("E_491_QTD_TOT_RECUS_620, E_491_QTD_TOT_ATEND_620, E_491_MERC_RECUSADOS_620, ");
            SqlCom.Append("E_491_MERC_ATEND_620, E_491_ARQ_FALTA_620, E_491_ARQ_PED_CONF_620, E_491_PEDIDO_ORIG_620, E_491_SEQ_PEDIDO_PK_620, ");
            SqlCom.Append("E_491_VLR_TOT_RECUSADO_620, E_491_VLR_TOT_ATENDIDO_620, E_491_MOTIV_BLOQ_620, E_491_REP_VEND_620, PEDIDO_CLI_491, ");
            SqlCom.Append("E_491_EMPRESA_FATUR_620, E_491_AMBIENTE_620, E_491_ENVIA_PALM_620, E_491_GRAVA_RETORN_620, E_491_PEDIDO_PROC_620, ");
            SqlCom.Append("E_491_CLI_PF_620, E_491_EMPRESA_PF_620, E_491_COND_COMER_FK_620, E_491_NAT_OPER_FK_620, E_491_ORIGEM_620) ");
            SqlCom.Append("values (");
            SqlCom.Append(string.Format("'{0}', '{1}', TO_DATE('{2}', 'DD/MM/YYYY HH24:MI:SS'), ", E_491_HR_INI_620, E_491_HR_FIN_620, E_491_DT_PEDIDO_620));
            SqlCom.Append(string.Format("{0}, {1}, {2}, ", E_491_QTD_TOT_RECUS_620, E_491_QTD_TOT_ATEND_620, E_491_MERC_RECUSADOS_620));
            SqlCom.Append(string.Format("{0}, '{1}', '{2}', '{3}', {4}, ", E_491_MERC_ATEND_620, E_491_ARQ_FALTA_620, E_491_ARQ_PED_CONF_620, E_491_PEDIDO_ORIG_620, E_491_SEQ_PEDIDO_PK_620));
            SqlCom.Append(string.Format("{0}, {1}, '{2}', {3}, '{4}', ", E_491_VLR_TOT_RECUSADO_620, E_491_VLR_TOT_ATENDIDO_620, E_491_MOTIV_BLOQ_620, E_491_REP_VEND_620, PEDIDO_CLI_491));
            SqlCom.Append(string.Format("{0}, 3, '{1}', '{2}', NULL, ", E_491_EMPRESA_FATUR_620, E_491_ENVIA_PALM_620, E_491_GRAVA_RETORN_620));
            SqlCom.Append(string.Format("{0}, {1}, '{2}', {3}, '{4}')", E_491_CLI_PF_620, E_491_EMPRESA_PF_620, E_491_COND_COMER_FK_620, E_491_NAT_OPER_FK_620, E_491_ORIGEM_620));

            Open();
            dbFenix.GravaNoBanco(SqlCom.ToString());
            Close();

        }

        public void Update620()
        {
            SqlCom.Length = 0;
            SqlCom.Append(string.Format("UPDATE PROC_EDI_491_LIST_620 SET E_491_SEQ_PEDIDO_PK_620 = {0}, E_491_PEDIDO_PROC_620 = '{1}' WHERE E_491_PEDIDO_ORIG_620 = '{2}' AND E_491_CLI_PF_620 = {3}", E_491_SEQ_PEDIDO_PK_620, E_491_PEDIDO_PROC_620, E_491_PEDIDO_ORIG_620, E_491_CLI_PF_620));

            Open();
            dbFenix.GravaNoBanco(SqlCom.ToString());
            Close();
        }

    }

    public class objInternalizaPedido
    {
        string[] ReturnEDIPedido;
        string _ConStr, _ConStrEDI, _ReturnEDIPedido;
        objEDI7 EDI7;
        objEDI8 EDI8;
        objEDI620 EDI620;
        dbHarpia dbFenixConsulta;
        dbHarpia dbFenix;
        dbHarpia dbFenixEDI;
        int x;
        DataSet dsRetorno = new DataSet();

        public objInternalizaPedido(string ConStr, string ConStrEDI)
        {
            _ConStr = ConStr;
            _ConStrEDI = ConStrEDI;
            dbFenix = new dbHarpia(_ConStr);
            dbFenixEDI = new dbHarpia(_ConStrEDI);
            dbFenixConsulta = new dbHarpia(_ConStr);
            EDI7 = new objEDI7(_ConStr);
            EDI8 = new objEDI8(_ConStr);
            EDI620 = new objEDI620(_ConStr);
        }

        //Tipos de MsgDeRetorno
        //D - PEDIDO DUPLICADO
        //I - PEDIDO IMPORTADO
        //F - FALHA NA INTERNALIZACAO
        //U - FALHA NO UPDATE DA 620
        //L - FALHA NA LEITURA DA 620

        public DataSet Internaliza(string Empresa, string Usuario, string EmpresaERP, string UsuarioERP, AgileECommerceApi.Pedido pedido, ref string Msg)
        {
            DataTable CliRota63 = new DataTable();
            DataTable DoesPedidoExist620 = new DataTable();
            DataTable Cli59 = new DataTable();

            try
            {
                dbFenixConsulta.Open();
                DoesPedidoExist620 = dbFenixConsulta.LerNoBanco("SELECT * FROM PROC_EDI_491_LIST_620 WHERE E_491_EMPRESA_PF_620 = " + EmpresaERP + " AND E_491_CLI_PF_620 = " + pedido.customer.code + " AND E_491_PEDIDO_ORIG_620 = '" + pedido.instance_id + "'");
                dbFenixConsulta.Close();
            }
            catch (Exception ex)
            {
                Msg = "L;FALHA NA LEITURA DA 620";
                return dsRetorno;
            }

            if (DoesPedidoExist620.Rows.Count > 0)
            {
                Msg = "D;PEDIDO DUPLICADO";
                return dsRetorno;
            }

            //Populando a tabela 620
            //PK 
            EDI620.E_491_CLI_PF_620 = pedido.customer.code;
            EDI620.E_491_EMPRESA_PF_620 = pedido.store_id;
            EDI620.E_491_SEQ_PEDIDO_PK_620 = Convert.ToInt32(dbFenix.NextValueID("DIRETRIZ_SEQUENCIAIS_215", "SEQ_PEDIDO_PROC_EDI_OLD_215", "WHERE EMPRESA_PF_215 = " + pedido.store_id, 1));
            //Outros campos
            EDI620.PEDIDO_CLI_491 = pedido.seller_id.PadLeft(5, '0') + EDI620.E_491_SEQ_PEDIDO_PK_620.ToString().PadLeft(7, '0');
            EDI620.E_491_COND_COMER_FK_620 = pedido.payment.payment_method.code;
            EDI620.E_491_NAT_OPER_FK_620 = 510201;
            EDI620.E_491_DESCR_ARQ_620 = "";
            EDI620.E_491_HR_INI_620 = DateTime.Now.TimeOfDay.ToString().Substring(0,8);
            EDI620.E_491_HR_FIN_620 = DateTime.Now.TimeOfDay.ToString().Substring(0,8);
            EDI620.E_491_ID_BAR_DEPOSIT_620 = "";
            EDI620.E_491_ID_BAR_FABRIC_620 = "";
            EDI620.E_491_DT_PEDIDO_620 = pedido.datetime;
            EDI620.E_491_PEDIDO_ORIG_620 = pedido.id;
            EDI620.E_491_REP_VEND_620 = pedido.seller_id;
            EDI620.E_491_DT_PROC_620 = DateTime.Now;
            EDI620.E_491_EMPRESA_FATUR_620 = pedido.store_id;
            EDI620.E_491_GRAVA_RETORN_620 = "S"; //DEFAULT = 'S'
            EDI620.E_491_PEDIDO_PROC_620 = "N";
            EDI620.E_491_ENVIA_PALM_620 = "N";
            EDI620.E_491_ORIGEM_620 = "ECOMMERCE";

            EDI620.INSERT();

            try
            {
                dbFenixConsulta.Open();
                CliRota63 = dbFenixConsulta.LerNoBanco("SELECT ROTA_FK_63, PORT_FK_63, EMPRESA_LOG_FK_63 FROM CLIENTE_EMPRESA_63 WHERE EMPRESA_PF_63 = " + pedido.store_id + " AND CLI_PF_63 = " + EDI620.E_491_CLI_PF_620 + "");
                dbFenixConsulta.Close();
            }
            catch (Exception ex)
            {
                //Gravar log de erro
                if (!System.IO.Directory.Exists(@"C:\inetpub\wwwroot\log"))
                    System.IO.Directory.CreateDirectory(@"C:\inetpub\wwwroot\log");

                System.IO.StreamWriter log = new System.IO.StreamWriter(@"C:\inetpub\wwwroot\log\" + String.Format("{0:ddMMyyyy}", DateTime.Now) + @".log", true, System.Text.Encoding.GetEncoding(1252));

                // Grava o log
                log.WriteLine(string.Format("{0}: WSCL.objInternalizaPedido().dbFenixConsulta - {1}", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex.Message));

                // Fecha o arquivo de Log
                log.Close();
            }
            //Fazendo internalizacao do pedido no fenix.
            EDI7.EMPRESA_DIGIT_PF_EDI7 = pedido.store_id;
            EDI7.SEQ_PEDIDO_EDI_PK_EDI7 = EDI620.E_491_SEQ_PEDIDO_PK_620.ToString();
            EDI7.VENDEDOR_FK_EDI7 = Convert.ToInt32(pedido.seller_id);
            EDI7.MODO_DIGITA_EDI7 = "S";
            EDI7.EMPRESA_FATURA_PF_EDI7 = pedido.store_id;
            EDI7.CLIENTE_FK_EDI7 = int.Parse(pedido.customer.code);
            EDI7.CONDCOMER_FK_EDI7 = pedido.payment.payment_method.code;
            EDI7.MODO_ATEND_FK_EDI7 = 510201;

            EDI7.PEDIDO_PROG_EDI7 = "N";
            EDI7.SN_REPASSE_EDI7 = "N";
            EDI7.TIPO_COMER_EDI7 = "N";
            EDI7.PROMO_FK_EDI7 = 0;
            EDI7.DT_PEDIDO_PROG_EDI7 = DateTime.Now;
            EDI7.TIT_CARTEIRA_EDI7 = "N";
            EDI7.DT_INI_DIGITA_EDI7 = DateTime.Now;
            EDI7.DT_FIN_DIGITA_EDI7 = DateTime.Now;
            EDI7.SN_DESC_MERC_EDI7 = "N";

            try
            {
                EDI7.MSG_PEDIDO_CONF_EDI7 = pedido.comments;
            }
            catch
            {
                EDI7.MSG_PEDIDO_CONF_EDI7 = "";
            }

            EDI7.MSG_NF_EDI7 = "EDI/AgileEcommerce";
            EDI7.MSG_ROMANEIO_EDI7 = "";
            EDI7.MSG_PEDIDO_CONF_PAD_EDI7 = "00";
            EDI7.TRANSPORTADORA_EDI7 = 1;

            //Incluindo rota e portador do cliente.
            try
            {
                if (CliRota63.Rows.Count > 0)
                {
                    EDI7.ROTA_EDI7 = Convert.ToInt32(CliRota63.Rows[0]["ROTA_FK_63"]);
                    EDI7.PORTADOR_FK_EDI7 = Convert.ToInt32(CliRota63.Rows[0]["PORT_FK_63"]);
                    EDI7.EMPRESA_LOGIST_PF_EDI7 = CliRota63.Rows[0]["EMPRESA_LOG_FK_63"].ToString();
                }
                else
                {
                    EDI7.ROTA_EDI7 = 999;
                    EDI7.PORTADOR_FK_EDI7 = 999;
                    EDI7.EMPRESA_LOGIST_PF_EDI7 = pedido.store_id;
                }
            }
            catch (Exception ex)
            {
                EDI7.ROTA_EDI7 = 999;
                EDI7.PORTADOR_FK_EDI7 = 999;
            }

            string PedNum = pedido.instance_id;

            //EDI7.NUM_PEDIDO_ORIG_EDI7 = UsuarioERP + PedNum.Substring(PedNum.Length - 4, 4);
            EDI7.NUM_PEDIDO_ORIG_EDI7 = pedido.id;
            EDI7.DESC_MODO_COMER_EDI7 = "0";
            

            EDI7.INSERT();

            foreach (var item in pedido.products)
            {
                EDI8.EMPRESA_DIGIT_PF_EDI8 = pedido.store_id; 
                EDI8.SEQ_PEDIDO_EDI_PF_EDI8 = Convert.ToInt32(EDI7.SEQ_PEDIDO_EDI_PK_EDI7);
                EDI8.MERC_PF_EDI8 = int.Parse(item.id.ToString().Substring(2, 8));  //'99' || LPAD(merc_pf_479, 8, '0') || LPAD(invol_pk_479, 3, '0') AS id
                EDI8.INVOLUCRO_EDI8 = int.Parse(item.id.ToString().Substring(10, 3));
                EDI8.TIPO_NEGOCIACAO_EDI8 = "P";
                EDI8.QTD_PEDIDA_EDI8 = Convert.ToDouble(item.pivot.quantity * item.multiple);
                EDI8.QTD_INVOLUCRO_EDI8 = Convert.ToDouble(item.pivot.quantity);
                //EDI8.QTD_BRINDES_EDI8 = 0
                EDI8.PRECO_COMER_EDI8 = Convert.ToDouble(item.pivot.unity_price / item.multiple);
                EDI8.PRECO_FABRICA_EDI8 = 0;
                EDI8.PRZ_COMER_EDI8 = 999;
                EDI8.DIF_PRECO_TABELA_EDI8 = Convert.ToDouble(item.regular_price);
                EDI8.DESC_MERC_EDI8 = 0;
                EDI8.DESC_MAX_EDI8 = 0;
                EDI8.DESC_MERC_LIQ_EDI8 = 0;
                EDI8.DESC_APLICAOD_EDI8 = 0;
                EDI8.OBSERVACAO_EDI8 = "";

                EDI8.INSERT();
            }

            try
            {
                //Chamando a Procedure de Internalizacao.
                _ReturnEDIPedido = dbFenixEDI.P_PCV_EDI_PEDIDO(pedido.store_id, Convert.ToInt32(EDI7.SEQ_PEDIDO_EDI_PK_EDI7));
            }
            catch (Exception ex)
            {
                //Log.GravaLogErro(ex.ToString(), "FenixLib.Internaliza().dbFenix.EDI.P_PCV_EDI_PEDIDO()");
                Msg = "F;FALHA NA INTERNALIZACAO";
                return dsRetorno;
            }

            ReturnEDIPedido = _ReturnEDIPedido.Split(';');

            //Atualizando a 620 com o numero do pedido retornado.
            try
            {
                EDI620.E_491_SEQ_PEDIDO_PK_620 = Convert.ToInt32(ReturnEDIPedido[1]);
                EDI620.E_491_PEDIDO_PROC_620 = "S";
                EDI620.Update620();
            }
            catch (Exception ex)
            {
                //Log.GravaLogErro(ex.ToString(), "FenixLib.Internaliza().EDI620.Update620()");
                Msg = "U;FALHA NO UPDATE DA 620";
                return dsRetorno;
            }

            try
            {
                dsRetorno = dbFenixEDI.P_EDI_PCA_RETORNO(EDI620.E_491_CLI_PF_620, EDI620.E_491_EMPRESA_PF_620, EDI620.E_491_SEQ_PEDIDO_PK_620.ToString(), Empresa, Usuario, EDI620.E_491_PEDIDO_ORIG_620, ReturnEDIPedido[2]);
            }
            catch (Exception ex)
            {
                //Log.GravaLogErro(ex.ToString(), "FenixLib.Internaliza().dbFenix.EDI.P_EDI_PCA_RETORNO()");
                Msg = "O;FALHA NA LEITURA DO RETORNO";
                return dsRetorno;
            }

            Msg = "I;PEDIDO INTERNALIZADO COM SUCESSO";

            return dsRetorno;
        }
    }



}
