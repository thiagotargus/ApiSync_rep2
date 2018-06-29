using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileESync
{
    public static class AgileESyncConfig
    {
        static string[] ComponentesConfig = { "System.Windows.Forms.TextBox", "System.Windows.Forms.ComboBox" };

        public class Configuracao
        {
            public string Chave { get; set; }
            public string Valor { get; set; }
        }

        public static string GetConfigFromDataBase(string chave)
        {
            db banco = new db(Geral.BancoDadosPath());

            var configuracao = banco.LerNoBanco<Configuracao>("Select * from Configuracao");

            return configuracao.Where(x => x.Chave == chave).FirstOrDefault().Valor;
        }

        public static void SetConfigToDataBase(string chave, String valor)
        {
            db banco = new db(Geral.BancoDadosPath());

            var configuracao = banco.LerNoBanco<Configuracao>("Select * from Configuracao");

            if (configuracao.Where(x => x.Chave == chave).Count() > 0)
            {
                banco.ExecutarComando("UPDATE Configuracao SET VALOR = '" + valor + "' WHERE Chave = '" + chave + "'");
            }
            else
            {
                banco.ExecutarComando("INSERT INTO Configuracao (Chave, Valor) Values ('" + chave + "', '" + valor + "')");
            }
        }

        public static void CarregarConfig(Form frm)
        {
            
            var appSettings = ConfigurationManager.AppSettings;

            foreach (Control item in frm.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    foreach (Control gbItem in item.Controls)
                    {
                        if (ComponentesConfig.Where(x => x == gbItem.GetType().ToString()).Count() > 0)
                        {
                            //if (appSettings.Count > 0)
                            //{
                                //gbItem.Text = appSettings[gbItem.Name];
                                gbItem.Text = GetConfigFromDataBase(gbItem.Name);
                            //}
                        }
                    }                       
                }
            }

        }

        public static void SalvarConfig(Form frm)
        {
            foreach (Control item in frm.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    foreach (Control gbItem in item.Controls)
                    {
                        if (ComponentesConfig.Where(x => x == gbItem.GetType().ToString()).Count() > 0)
                        {
                            //AddUpdateAppSettings(gbItem.Name, gbItem.Text);
                            SetConfigToDataBase(gbItem.Name, gbItem.Text);
                        }
                    }
                }
            }
        }

        public static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {

                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
        }

        public static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Não encontrado";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error lendo configuração!");
            }
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error salvando configuração!");
            }
        }
    }
}
