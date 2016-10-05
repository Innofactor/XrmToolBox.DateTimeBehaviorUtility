using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Innofactor.XTB.DateTimeBehaviorUtility
{
    public partial class DateTimeBehaviorUtility : PluginControlBase, IGitHubPlugin
    {
        public string RepositoryName { get { return "XrmToolBox.DateTimeBehaviorUtility"; } }

        public string UserName { get { return "Innofactor"; } }

        public DateTimeBehaviorUtility()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void DateTimeBehaviorUtility_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            btnLoadAttributes.Enabled = Service != null;
        }

        private void btnLoadAttributes_Click(object sender, EventArgs e)
        {
            LoadAttributes();
        }

        private void LoadAttributes()
        {
            var asyncinfo = new WorkAsyncInfo();
            asyncinfo.Message = "Loading DateTime attributes";
            WorkAsync(asyncinfo);
        }
    }
}
