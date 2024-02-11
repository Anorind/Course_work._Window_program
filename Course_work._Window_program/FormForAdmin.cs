using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Course_work._Window_program
{
    /// <summary>
    /// Форма для роботи адміністратора в якій ми можемо додавати нові матеріали і т.д.
    /// 
    /// Form for the administrator's work in which we can add new materials, etc.
    /// </summary>
    public partial class FormForAdmin : Form
    {
        public static FormForAdmin Instance { get; private set; }
        private MyDbContext _context; //Для підключення до бази даних
        private dynamic _selectedItem; //Для зміни елементів в DataGridView
        public FormForAdmin()
        {
            InitializeComponent();
            _context = new MyDbContext();
            Instance = this;
        }

        private void FormForAdmin_Load(object sender, EventArgs e)
        {
            LoadComboBoxTables();
            LoadDataGridView(comboBoxTables.Items[0].ToString());
        }
        private void LoadComboBoxTables()
        {
            comboBoxTables.Items.Add("Materials");
            comboBoxTables.Items.Add("GlassType");
            comboBoxTables.Items.Add("PlasticType");
            comboBoxTables.SelectedIndex = 0;
        }


        private void LoadDataGridView(string tableName)
        {
            switch (tableName)
            {
                case "Materials":
                    dataGridViewTables.DataSource = _context.Materials.ToList();
                    break;
                case "GlassType":
                    dataGridViewTables.DataSource = _context.GlassTypes.ToList();
                    break;
                case "PlasticType":
                    dataGridViewTables.DataSource = _context.PlasticTypes.ToList();
                    break;
            }
            if (tableName == "GlassType")
            {
                dataGridViewTables.Columns["MaterialId"].ReadOnly = true;
                dataGridViewTables.Columns["GlassTypeId"].ReadOnly = true;
            }
            else if (tableName == "PlasticType")
            {
                dataGridViewTables.Columns["MaterialId"].ReadOnly = true;
                dataGridViewTables.Columns["PlasticTypeId"].ReadOnly = true;
            }
        }
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            ClearTextBoxes();

            LoadDataGridView(selectedTable);
            labelMaterialsTextBox.Text = $"Enter data to add new {selectedTable}:";
        }

        private void dataGridViewTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                _selectedItem = dataGridViewTables.SelectedRows[0].DataBoundItem;
                if (comboBoxTables.SelectedItem.ToString() == "Materials")
                {
                    textBoxCategory.Text = _selectedItem.Category;
                    textBoxCategory.Enabled = true;
                }
                else if (comboBoxTables.SelectedItem.ToString()== "GlassType")
                {
                    textBoxCategory.Text = "glass material";
                    textBoxCategory.Enabled = false;
                }
                else if (comboBoxTables.SelectedItem.ToString() == "PlasticType")
                {
                    textBoxCategory.Text = "frame material";
                    textBoxCategory.Enabled = false;
                }
                textBoxName.Text = _selectedItem.Name;
                textBoxColor.Text = _selectedItem.Color;
                textBoxCost.Text = _selectedItem.Cost.ToString();
                richTextBoxDescription.Text = _selectedItem.Description;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            switch (selectedTable)
            {
                case "Materials":
                    _selectedItem.Category = textBoxCategory.Text;
                    _selectedItem.Name = textBoxName.Text;
                    _selectedItem.Color = textBoxColor.Text;
                    _selectedItem.Cost = decimal.Parse(textBoxCost.Text);
                    _selectedItem.Description = richTextBoxDescription.Text;
                    break;
                case "GlassType":
                    var materialForGlassType = _context.Materials.Find(_selectedItem.MaterialId);
                    materialForGlassType.Name = textBoxName.Text;
                    materialForGlassType.Color = textBoxColor.Text;
                    materialForGlassType.Cost = decimal.Parse(textBoxCost.Text);
                    materialForGlassType.Description = richTextBoxDescription.Text;

                    _selectedItem.Name = textBoxName.Text;
                    _selectedItem.Cost = decimal.Parse(textBoxCost.Text);
                    _selectedItem.Color = textBoxColor.Text;
                    _selectedItem.Description = richTextBoxDescription.Text;
                    break;
                case "PlasticType":
                    var materialForPlasticType = _context.Materials.Find(_selectedItem.MaterialId);
                    materialForPlasticType.Name = textBoxName.Text;
                    materialForPlasticType.Color = textBoxColor.Text;
                    materialForPlasticType.Cost = decimal.Parse(textBoxCost.Text);
                    materialForPlasticType.Description = richTextBoxDescription.Text;

                    _selectedItem.Name = textBoxName.Text;
                    _selectedItem.Cost = decimal.Parse(textBoxCost.Text);
                    _selectedItem.Color = textBoxColor.Text;
                    _selectedItem.Description = richTextBoxDescription.Text;
                    break;
            }
            _context.SaveChanges();
            LoadDataGridView(selectedTable);
            ClearTextBoxes();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            switch (selectedTable)
            {
                case "Materials":
                    var newMaterial = new Material
                    {
                        Category = textBoxCategory.Text,
                        Name = textBoxName.Text,
                        Color = textBoxColor.Text,
                        Cost = decimal.Parse(textBoxCost.Text),
                        Description = richTextBoxDescription.Text
                    };

                    _context.Materials.Add(newMaterial);
                    if (newMaterial.Category == "glass material")
                    {
                        var newGT = new GlassType
                        {
                            Name = newMaterial.Name,
                            Cost = newMaterial.Cost,
                            Color = newMaterial.Color,
                            Description = newMaterial.Description,
                            MaterialId = newMaterial.MaterialId
                        };
                        _context.GlassTypes.Add(newGT);
                        break;
                    }
                    else if (newMaterial.Category == "frame material")
                    {
                        var newPT = new PlasticType
                        {
                            Name = newMaterial.Name,
                            Cost = newMaterial.Cost,
                            Color = newMaterial.Color,
                            Description = newMaterial.Description,
                            MaterialId = newMaterial.MaterialId
                        };
                        _context.PlasticTypes.Add(newPT);
                        break;
                    }
                    break;
                case "GlassType":
                    var newMaterialForGlassType = new Material
                    {
                        Category = textBoxCategory.Text,
                        Name = textBoxName.Text,
                        Color = textBoxColor.Text,
                        Cost = decimal.Parse(textBoxCost.Text),
                        Description = richTextBoxDescription.Text
                    };
                    _context.Materials.Add(newMaterialForGlassType);
                    _context.SaveChanges();

                    var newGlassType = new GlassType
                    {
                        Name = textBoxName.Text,
                        Cost = decimal.Parse(textBoxCost.Text),
                        Color = textBoxColor.Text,
                        Description = richTextBoxDescription.Text,
                        MaterialId = newMaterialForGlassType.MaterialId 
                    };
                    _context.GlassTypes.Add(newGlassType);
                    break;
                case "PlasticType":
                    var newMaterialForPlasticType = new Material
                    {
                        Category = textBoxCategory.Text,
                        Name = textBoxName.Text,
                        Color = textBoxColor.Text,
                        Cost = decimal.Parse(textBoxCost.Text),
                        Description = richTextBoxDescription.Text
                    };
                    _context.Materials.Add(newMaterialForPlasticType);
                    _context.SaveChanges(); 

                    var newPlasticType = new PlasticType
                    {
                        Name = textBoxName.Text,
                        Cost = decimal.Parse(textBoxCost.Text),
                        Color = textBoxColor.Text,
                        Description = richTextBoxDescription.Text,
                        MaterialId = newMaterialForPlasticType.MaterialId 
                    };
                    _context.PlasticTypes.Add(newPlasticType);
                    break;
            }
            _context.SaveChanges();
            LoadDataGridView(selectedTable);
            ClearTextBoxes();
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            switch (selectedTable)
            {
                case "Materials":
                    _context.Materials.Remove((Material)_selectedItem);
                    break;
                case "GlassType":
                    _context.Materials.Remove(_context.Materials.Find(_selectedItem.MaterialId));
                    _context.GlassTypes.Remove((GlassType)_selectedItem);
                    break;
                case "PlasticType":
                    _context.Materials.Remove(_context.Materials.Find(_selectedItem.MaterialId));
                    _context.PlasticTypes.Remove((PlasticType)_selectedItem);
                    break;
            }
            _context.SaveChanges();
            LoadDataGridView(selectedTable);
            ClearTextBoxes();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Window_programm_form.Instance.Show();
            this.Hide();

        }
        private void ClearTextBoxes()
        {
            textBoxCategory.Clear();
            textBoxName.Clear();
            textBoxColor.Clear();
            textBoxCost.Clear();
            richTextBoxDescription.Clear();
        }

    }
}
