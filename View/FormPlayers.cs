using BusinessLogic.BindingModels;
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
    public partial class FormPlayers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly PlayerLogic logic;
        private int? id;
        public FormPlayers(PlayerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPlayer>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPlayer>();
                form.Id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new PlayerBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormPlayers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewComponents.DataSource = list;
                    dataGridViewComponents.Columns[0].Visible = true;
                    dataGridViewComponents.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewComponents.Columns[3].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
