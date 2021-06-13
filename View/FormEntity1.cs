using BusinessLogic.BusinessLogics;
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
    public partial class FormEntity1 : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly Entity1Logic logic;
        private int? id;
        public FormEntity1(Entity1Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
