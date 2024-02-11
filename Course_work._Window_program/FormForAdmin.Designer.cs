namespace Course_work._Window_program
{
    partial class FormForAdmin
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
            this.labelHello = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();
            this.labelMaterialsTextBox = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelDescriptionMaterial = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.buttonEdite = new System.Windows.Forms.Button();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.labelChooseTable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHello.Location = new System.Drawing.Point(154, 30);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(593, 23);
            this.labelHello.TabIndex = 0;
            this.labelHello.Text = "Hello admin, welcome to the program for calculating window products";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(153, 53);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(594, 20);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Here you can add new products, products of your company and set a price for them";
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonReturn.Location = new System.Drawing.Point(778, 504);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(137, 51);
            this.buttonReturn.TabIndex = 2;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonAdd.Location = new System.Drawing.Point(610, 431);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(137, 51);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add Product";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonDeleteProduct.Location = new System.Drawing.Point(610, 504);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(137, 51);
            this.buttonDeleteProduct.TabIndex = 4;
            this.buttonDeleteProduct.Text = "Delete Product";
            this.buttonDeleteProduct.UseVisualStyleBackColor = false;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // dataGridViewTables
            // 
            this.dataGridViewTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTables.Location = new System.Drawing.Point(33, 112);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.RowHeadersWidth = 62;
            this.dataGridViewTables.RowTemplate.Height = 28;
            this.dataGridViewTables.Size = new System.Drawing.Size(882, 222);
            this.dataGridViewTables.TabIndex = 5;
            this.dataGridViewTables.SelectionChanged += new System.EventHandler(this.dataGridViewTables_SelectionChanged);
            // 
            // labelMaterialsTextBox
            // 
            this.labelMaterialsTextBox.AutoSize = true;
            this.labelMaterialsTextBox.Location = new System.Drawing.Point(51, 346);
            this.labelMaterialsTextBox.Name = "labelMaterialsTextBox";
            this.labelMaterialsTextBox.Size = new System.Drawing.Size(234, 20);
            this.labelMaterialsTextBox.TabIndex = 11;
            this.labelMaterialsTextBox.Text = "Enter data to add new material :";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(51, 372);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(77, 20);
            this.labelCategory.TabIndex = 14;
            this.labelCategory.Text = "Category:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(51, 405);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "Name:";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(51, 437);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(50, 20);
            this.labelColor.TabIndex = 16;
            this.labelColor.Text = "Color:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(51, 469);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(46, 20);
            this.labelCost.TabIndex = 17;
            this.labelCost.Text = "Cost:";
            // 
            // labelDescriptionMaterial
            // 
            this.labelDescriptionMaterial.AutoSize = true;
            this.labelDescriptionMaterial.Location = new System.Drawing.Point(51, 495);
            this.labelDescriptionMaterial.Name = "labelDescriptionMaterial";
            this.labelDescriptionMaterial.Size = new System.Drawing.Size(93, 20);
            this.labelDescriptionMaterial.TabIndex = 18;
            this.labelDescriptionMaterial.Text = "Description:";
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(144, 366);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(418, 26);
            this.textBoxCategory.TabIndex = 19;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(144, 399);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(418, 26);
            this.textBoxName.TabIndex = 20;
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(144, 431);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(418, 26);
            this.textBoxColor.TabIndex = 21;
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(144, 463);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(418, 26);
            this.textBoxCost.TabIndex = 22;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(144, 495);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(418, 60);
            this.richTextBoxDescription.TabIndex = 23;
            this.richTextBoxDescription.Text = "";
            // 
            // buttonEdite
            // 
            this.buttonEdite.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonEdite.Location = new System.Drawing.Point(610, 366);
            this.buttonEdite.Name = "buttonEdite";
            this.buttonEdite.Size = new System.Drawing.Size(137, 51);
            this.buttonEdite.TabIndex = 36;
            this.buttonEdite.Text = "Edit Product";
            this.buttonEdite.UseVisualStyleBackColor = false;
            this.buttonEdite.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(368, 78);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(491, 28);
            this.comboBoxTables.TabIndex = 37;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // labelChooseTable
            // 
            this.labelChooseTable.AutoSize = true;
            this.labelChooseTable.Location = new System.Drawing.Point(29, 86);
            this.labelChooseTable.Name = "labelChooseTable";
            this.labelChooseTable.Size = new System.Drawing.Size(235, 20);
            this.labelChooseTable.TabIndex = 38;
            this.labelChooseTable.Text = "Select the table you want to edit";
            // 
            // FormForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(941, 567);
            this.Controls.Add(this.labelChooseTable);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.buttonEdite);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.textBoxColor);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.labelDescriptionMaterial);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelMaterialsTextBox);
            this.Controls.Add(this.dataGridViewTables);
            this.Controls.Add(this.buttonDeleteProduct);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelHello);
            this.Name = "FormForAdmin";
            this.Text = "FormForAdmin";
            this.Load += new System.EventHandler(this.FormForAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.Label labelMaterialsTextBox;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelDescriptionMaterial;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Button buttonEdite;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label labelChooseTable;
    }
}