using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormGame : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly GameLogic logic;
        private int? id;
        private Dictionary<int, string> gamePlayers;
        public FormGame(GameLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxMasterName.Text))
            {
                MessageBox.Show("Заполните имя ведущего", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker.Value == null)
            {
                MessageBox.Show("Заполните дату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gamePlayers == null)
            {
                MessageBox.Show("Заполните игроков", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new GameBindingModel
                {
                    Id = id,
                    GameName = textBoxName.Text,
                    MasterName = textBoxMasterName.Text,
                    DateGame = dateTimePicker.Value,
                    GamePlayers = gamePlayers
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    GameViewModel view = logic.Read(new GameBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.GameName;
                        textBoxMasterName.Text = view.MasterName;
                        dateTimePicker.Value = view.DateGame;
                        gamePlayers = view.GamePlayers;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                gamePlayers = new Dictionary<int, string>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (gamePlayers != null)
                {
                    dataGridViewCompFlower.Rows.Clear();
                    foreach (var pc in gamePlayers)
                    {
                        dataGridViewCompFlower.Rows.Add(new object[] { pc.Value });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGamePlayer>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (gamePlayers.ContainsKey(form.Id))
                {
                    gamePlayers[form.Id] = form.Nickname;
                }
                else
                {
                    gamePlayers.Add(form.Id, form.Nickname);
                }
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompFlower.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        gamePlayers.Remove(Convert.ToInt32(dataGridViewCompFlower.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompFlower.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormGamePlayer>();
                int id = Convert.ToInt32(dataGridViewCompFlower.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    gamePlayers[form.Id] = form.Nickname;
                    LoadData();
                }
            }
        }
    }
}
