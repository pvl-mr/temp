using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGames>();
            form.ShowDialog();
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPlayers>();
            form.ShowDialog();
        }
    }
}
