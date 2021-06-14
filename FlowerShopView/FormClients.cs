﻿using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ClientLogic logic;
        public FormClients(ClientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                    Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new ClientBindingModel { Id = id });
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

        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridViewClients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
