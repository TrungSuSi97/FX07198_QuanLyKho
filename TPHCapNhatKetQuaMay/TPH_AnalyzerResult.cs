using NDesk.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration.Install;
using System.Reflection;
using System.Threading;
using log4net;

namespace TPHCapNhatKetQuaMay
{
    partial class TPH_AnalyzerResult : ServiceBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private static int _exitCode;

        public TPH_AnalyzerResult()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        private void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: TPH.Lab.Middleware.Connector [OPTIONS]");
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        private void Install()
        {
            ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
            _logger.InfoFormat("Install successful");
        }

        private void Uninstall()
        {
            ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
            _logger.InfoFormat("Uninstall successful");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.Error(e.ExceptionObject.ToString());
        }
    }
}
