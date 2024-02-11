using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using iTextSharp.text;

namespace Course_work._Window_program
{
    /// <summary>
    /// Форма для розрахунку та додавання заказів
    /// 
    /// Form for ordering and adding orders
    /// </summary>
    public partial class FormForWork : Form
    {
        private bool isFormLoading = true;//Для визначення загружена форма чи ні, це щоб закази не загружались відразу
        private List<Root> myDeserializedClass;//Для роботи з API
        public FormForWork()
        {
            InitializeComponent();

            //Підключаюсь до API Нацбанку для зміну курсу грошей
            HttpWebRequest reqw = (HttpWebRequest)HttpWebRequest.Create("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string myJsonResponse = sr.ReadToEnd();
            myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
            foreach (var currency in myDeserializedClass)
            {
                comboBoxCurrency.Items.Add(currency.cc);
            }

            numericUpDownSections.Minimum = 1;
            numericUpDownSections.Maximum = 6;
            numericUpDownHeight.Minimum = 20;
            numericUpDownHeight.Maximum = 400;
            numericUpDownWidth.Minimum = 20;
            numericUpDownWidth.Maximum = 400;
            numericUpDownChambers.Minimum = 1;
            numericUpDownChambers.Maximum = 3;
            numericUpDownOpenSections.Minimum = 0;
            LoadData();//Підгружаю данні з бази

        }

        private void FormForWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            Window_programm_form.Instance.Close();
        }

        private void checkBoxYes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxYes.Checked == true) { checkBoxNo.Checked = false; }
        }

        private void checkBoxNo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNo.Checked == true) { checkBoxYes.Checked = false; }

        }

        private void labelTotalCash_TextChanged(object sender, EventArgs e)
        {
            labelSymbolCash.Location = new Point(labelTotalCash.Location.X + labelTotalCash.Width, labelSymbolCash.Location.Y);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            buttonCalculate_Click(sender, e);

            WindowOrder order = new WindowOrder();

            //Заповнюю об'єкт даними з форми
            order.Width = decimal.Parse(numericUpDownWidth.Text);
            order.Height = decimal.Parse(numericUpDownHeight.Text);
            order.GlassColor = comboBoxGlassColor.Text;
            order.FrameColor = comboBoxFrameColor.Text;
            order.FrameMaterial = comboBoxFrameMaterial.Text;
            order.GlassMaterial = comboBoxGlassMaterial.Text;
            order.WindowChambers = int.Parse(numericUpDownChambers.Text);
            order.NumberOfOpeningSections = int.Parse(numericUpDownOpenSections.Text);
            order.AddressOfOrder = textBoxAddressOfOrder.Text;
            order.DateOfOrder = dateTimePicker1.Value;
            order.OrderCompleted = checkBoxYes.Checked;
            order.TotalCash = decimal.Parse(labelTotalCash.Text);
            order.NumberOfSections = int.Parse(numericUpDownSections.Text);

            if (string.IsNullOrWhiteSpace(order.FrameMaterial) ||
                string.IsNullOrWhiteSpace(order.GlassMaterial) ||
                string.IsNullOrWhiteSpace(order.AddressOfOrder) ||
                order.Width == 0 ||
                order.Height == 0 ||
                order.WindowChambers == 0 ||
                order.TotalCash == 0)
            {
                MessageBox.Show("Please fill out all required fields.");
            }
            else
            {
                // Зберігаю объект order в базі даних
                using (var dbContext = new MyDbContext())
                {
                    dbContext.WindowOrders.Add(order);
                    dbContext.SaveChanges();
                }

                MessageBox.Show("The order was successfully saved.");
            }
            LoadData();//Оновлюю базу
        }
        private void LoadData()
        {
            using (var dbContext = new MyDbContext())
            {
                if (numericUpDownOpenSections.Value > numericUpDownSections.Value)
                {

                    numericUpDownOpenSections.Value = numericUpDownSections.Value;
                }
                // Завантаження даних в різні комбобокси
                var glassColors = dbContext.Materials
                    .Where(m => m.Category == "glass material")
                    .Select(m => m.Color)
                    .Distinct()
                    .ToList();
                comboBoxGlassColor.DataSource = glassColors;

                var frameColors = dbContext.Materials
                    .Where(m => m.Category == "frame material")
                    .Select(m => m.Color)
                    .Distinct()
                    .ToList();
                comboBoxFrameColor.DataSource = frameColors;

                var frameMaterials = dbContext.Materials
                    .Where(m => m.Category == "frame material")
                    .Select(m => m.Name)
                    .Distinct()
                    .ToList();
                comboBoxFrameMaterial.DataSource = frameMaterials;

                var glassMaterials = dbContext.Materials
                    .Where(m => m.Category == "glass material")
                    .Select(m => m.Name)
                    .Distinct()
                    .ToList();
                comboBoxGlassMaterial.DataSource = glassMaterials;

                var orders = dbContext.WindowOrders
                    .ToList();
                comboBoxViewOrders.DataSource = orders;
                comboBoxViewOrders.DisplayMember = "OrderId";
                isFormLoading = false;
            }
        }

        private void comboBoxViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoading)
            {
                WindowOrder selectedOrder = (WindowOrder)comboBoxViewOrders.SelectedItem;

                //Відображення заказів
                numericUpDownSections.Value = selectedOrder.NumberOfSections;
                numericUpDownWidth.Value = selectedOrder.Width;
                numericUpDownHeight.Value = selectedOrder.Height;
                comboBoxGlassColor.SelectedItem = selectedOrder.GlassColor;
                comboBoxFrameColor.SelectedItem = selectedOrder.FrameColor;
                comboBoxFrameMaterial.SelectedItem = selectedOrder.FrameMaterial;
                comboBoxGlassMaterial.SelectedItem = selectedOrder.GlassMaterial;
                numericUpDownChambers.Value = selectedOrder.WindowChambers;
                numericUpDownOpenSections.Value = selectedOrder.NumberOfOpeningSections;
                textBoxAddressOfOrder.Text = selectedOrder.AddressOfOrder;
                dateTimePicker1.Value = selectedOrder.DateOfOrder ?? DateTime.Now;
                checkBoxYes.Checked = selectedOrder.OrderCompleted;
                checkBoxNo.Checked = !selectedOrder.OrderCompleted;
                labelTotalCash.Text = selectedOrder.TotalCash.ToString();
                labelNumber.Text = selectedOrder.OrderId.ToString();
            }

        }

        private void numericUpDownSections_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownOpenSections.Maximum = numericUpDownSections.Value;
        }

        /// <summary>
        /// Розраховуємо загальну сумму вікна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            labelSymbolCash.Text = "UAH";            
                
            decimal costFrameMaterial = GetCostFrameMaterial(); 
            decimal costGlassMaterial = GetCostGlassMaterial(); 

            decimal totalCost;

            if (numericUpDownOpenSections.Value == 0)
            {
                totalCost = ((numericUpDownHeight.Value * numericUpDownWidth.Value) / 100 * costFrameMaterial +
                            ((numericUpDownHeight.Value * numericUpDownWidth.Value) / 100 * costGlassMaterial) * numericUpDownChambers.Value) *
                            numericUpDownSections.Value;
            }
            else
            {
                totalCost = ((numericUpDownHeight.Value * numericUpDownWidth.Value) / 100 * costFrameMaterial +
             ((numericUpDownHeight.Value * numericUpDownWidth.Value) / 100 * costGlassMaterial) * numericUpDownChambers.Value) *
             (numericUpDownSections.Value + 0.3m * numericUpDownOpenSections.Value);
            }

            labelTotalCash.Text = totalCost.ToString();
        }

        private decimal GetCostFrameMaterial()
        {
            using (var context = new MyDbContext())
            {
                var plasticType = context.PlasticTypes.FirstOrDefault();
                if (plasticType != null)
                {
                    return plasticType.Cost;
                }
                else
                {
                    throw new Exception("PlasticType not found in the database.");
                }
            }
        }

        private decimal GetCostGlassMaterial()
        {
            using (var context = new MyDbContext())
            {
                var glassType = context.GlassTypes.FirstOrDefault();
                if (glassType != null)
                {
                    return glassType.Cost;
                }
                else
                {
                    throw new Exception("GlassType not found in the database.");
                }
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Window_programm_form.Instance.Show();
            this.Hide();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCurrency = comboBoxCurrency.SelectedItem.ToString();

            Root selectedCurrencyRoot = myDeserializedClass.Find(r => r.cc == selectedCurrency);

            decimal priceInUAH = decimal.Parse(labelTotalCash.Text);
            decimal exchangeRate = (decimal)selectedCurrencyRoot.rate;
            decimal priceInSelectedCurrency = priceInUAH / exchangeRate;

            labelTotalCash.Text = priceInSelectedCurrency.ToString();
            labelSymbolCash.Text = selectedCurrencyRoot.cc;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text == "0")
            {
                MessageBox.Show("Please save your order first");
                return;
            }

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Create new PDF file
            string fileName = $"order{labelNumber.Text}.pdf";
            string filePath = Path.Combine(folderPath, fileName);
            var pdf = new iTextSharp.text.Document();
            var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdf, new FileStream(filePath, FileMode.Create));
            pdf.Open();

            var font = iTextSharp.text.FontFactory.GetFont("Times New Roman", 12);
            var boldFont = FontFactory.GetFont("Times-Bold",14);
            pdf.Add(new iTextSharp.text.Paragraph($"                                       Purchase/sale agreement", boldFont));
            pdf.Add(new iTextSharp.text.Paragraph($"Number of order: {labelNumber.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Width: {numericUpDownWidth.Value} mm" , font));
            pdf.Add(new iTextSharp.text.Paragraph($"Height: {numericUpDownHeight.Value} mm", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Glass Color: {comboBoxGlassColor.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Frame Color: {comboBoxFrameColor.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Frame Material: {comboBoxFrameMaterial.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Glass Material: {comboBoxGlassMaterial.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Window Chambers: {numericUpDownChambers.Value} pc", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Number Of Sections: {numericUpDownSections.Value} pc", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Number Of Opening Sections: {numericUpDownOpenSections.Value} pc", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Address Of Order: {textBoxAddressOfOrder.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Date Of Order: {dateTimePicker1.Value}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Order Completed: {checkBoxYes.Checked}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"Total Cash: {labelTotalCash.Text} {labelSymbolCash.Text}", font));
            pdf.Add(new iTextSharp.text.Paragraph($"FULL NAME:_____________________________________      Signature:___________ ", boldFont));

            pdf.Close();

            Process.Start(filePath);

        }



    }
}
