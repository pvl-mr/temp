
namespace View
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxMasterName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewCompFlower = new System.Windows.Forms.DataGridView();
            this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompFlower)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(155, 69);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(427, 22);
            this.textBoxName.TabIndex = 3;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(155, 185);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(427, 22);
            this.dateTimePicker.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(227, 544);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(151, 52);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(428, 544);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(148, 52);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxMasterName
            // 
            this.textBoxMasterName.Location = new System.Drawing.Point(155, 130);
            this.textBoxMasterName.Name = "textBoxMasterName";
            this.textBoxMasterName.Size = new System.Drawing.Size(427, 22);
            this.textBoxMasterName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ведущий";
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.btnUpdate);
            this.groupBoxComponents.Controls.Add(this.btnDelete);
            this.groupBoxComponents.Controls.Add(this.btnChange);
            this.groupBoxComponents.Controls.Add(this.btnAdd);
            this.groupBoxComponents.Controls.Add(this.dataGridViewCompFlower);
            this.groupBoxComponents.Location = new System.Drawing.Point(30, 227);
            this.groupBoxComponents.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxComponents.Size = new System.Drawing.Size(592, 310);
            this.groupBoxComponents.TabIndex = 10;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Компоненты";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(426, 227);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 46);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(426, 157);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 44);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(428, 92);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(131, 48);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(428, 22);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewCompFlower
            // 
            this.dataGridViewCompFlower.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCompFlower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompFlower.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnComponent,
            this.ColumnId});
            this.dataGridViewCompFlower.Location = new System.Drawing.Point(29, 34);
            this.dataGridViewCompFlower.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCompFlower.Name = "dataGridViewCompFlower";
            this.dataGridViewCompFlower.RowHeadersVisible = false;
            this.dataGridViewCompFlower.RowHeadersWidth = 51;
            this.dataGridViewCompFlower.Size = new System.Drawing.Size(362, 252);
            this.dataGridViewCompFlower.TabIndex = 0;
            // 
            // ColumnComponent
            // 
            this.ColumnComponent.HeaderText = "Игрок";
            this.ColumnComponent.MinimumWidth = 15;
            this.ColumnComponent.Name = "ColumnComponent";
            this.ColumnComponent.Width = 350;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.MinimumWidth = 6;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            this.ColumnId.Width = 125;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 626);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxMasterName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormGame";
            this.Text = "FormEntity1";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompFlower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxMasterName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewCompFlower;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
    }
}