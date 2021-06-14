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
    public partial class FormGames : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly GameLogic logic;
        private int? id;
        public FormGames(GameLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGame>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewGames.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormGame>();
                form.Id = Convert.ToInt32(dataGridViewGames.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewGames.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridViewGames.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new GameBindingModel { Id = id });
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

        private void FormGames_Load(object sender, EventArgs e)
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
                    dataGridViewGames.DataSource = list;
                    dataGridViewGames.Columns[0].Visible = true;
                    dataGridViewGames.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewGames.Columns[3].Visible = true;
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
