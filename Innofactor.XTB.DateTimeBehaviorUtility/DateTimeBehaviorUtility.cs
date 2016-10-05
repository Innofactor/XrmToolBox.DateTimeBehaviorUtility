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

namespace Innofactor.XTB.DateTimeBehaviorUtility
{
    public partial class DateTimeBehaviorUtility : PluginControlBase
    {
        public DateTimeBehaviorUtility()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
    }
}
