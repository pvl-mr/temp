using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using BusinessLogic.Enums;
using System;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormPlayer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly PlayerLogic logic;
        private readonly GameLogic gameLogic;
        private int? id;
        public FormPlayer(PlayerLogic logic, GameLogic glogic)
        {
            InitializeComponent();
            this.logic = logic;
            gameLogic = glogic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNickname.Text))
            {
                MessageBox.Show("Заполните ник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxScore.Text))
            {
                MessageBox.Show("Заполните баллы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            try
            {
                logic.CreateOrUpdate(new PlayerBindingModel
                {
                    Id = id,
                    Nickname = textBoxNickname.Text,
                    Score = Convert.ToInt32(textBoxScore.Text),
                    Type = (BusinessLogic.Enums.PlayerType)comboBoxType.SelectedValue,
                    DateDeath = dateTimePicker.Value,
                    GameId = comboBoxGame.SelectedItem.
                });;
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

        private void FormPlayer_Load(object sender, EventArgs e)
        {
            comboBoxType.DataSource = Enum.GetValues(typeof(PlayerType));
            var listClients = gameLogic.Read(null);
            foreach (var client in listClients)
            {
                comboBoxGame.DataSource = listClients;
                comboBoxGame.DisplayMember = "GameName";
                comboBoxGame.ValueMember = "Id";
                comboBoxGame.SelectedItem = null;
            }
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new PlayerBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxNickname.Text = view.Nickname;
                        textBoxScore.Text = view.Score.ToString();
                        dateTimePicker.Value = view.DateDeath;
                        textBoxNickname.Text = view.Nickname;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
