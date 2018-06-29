using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileESync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Geral.frmprincipal == null)
                Geral.frmprincipal = new frmPrincipal();

            if (Geral.frmconfiguracao == null)
                Geral.frmconfiguracao = new frmConfiguracao();

            if (Geral.frmSplash == null)
                Geral.frmSplash = new frmSplash();

            if (Geral.frmQuerys == null)
                Geral.frmQuerys = new frmQuerys();

            if (Geral.frmTabelas == null)
                Geral.frmTabelas = new frmTabelas();

            Application.Run(Geral.frmprincipal);
        }
    }
}
