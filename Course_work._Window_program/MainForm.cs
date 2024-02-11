using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_work._Window_program
{
    /// <summary>
    /// Початкова форма, для входу до програми
    /// 
    /// Initial form, for entering the program
    /// </summary>
    public partial class Window_programm_form : Form
    {
        /// <summary>
        /// Для закриття форми при відкритті іншої 
        /// 
        /// To close a form when another is opened
        /// </summary>
        public static Window_programm_form Instance { get; private set; }

        public Window_programm_form()
        {
            InitializeComponent();
            Instance = this;

        }

        private void Window_programm_form_Load(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';

            //Приклад, Example

            //using (var context = new MyDbContext())
            //{
            //    ExampleData.Seed(context);
            //}
        }

        //Перехід до форми реєстрації
        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.Show();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання адреси каталога данного проекта
                string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\"));

                // Повний путь до файла
                string filePath = System.IO.Path.Combine(projectDirectory, "users.json");

                // Зчитування існуючик користувачів
                List<dynamic> users = new List<dynamic>();
                if (System.IO.File.Exists(filePath))
                {
                    string json = System.IO.File.ReadAllText(filePath);
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(json);
                }

                // Перевіряємо існування такогож логіну
                var user = users.FirstOrDefault(u => u.Login == textBoxLogin.Text);
                if (user == null)
                {
                    MessageBox.Show("A user with this login was not found.");
                    return;
                }

                // Перевірка пароля
                if (BCrypt.Net.BCrypt.Verify(textBoxPassword.Text, user.Password.ToString()))
                {
                // Якщо перевірка пройдена то відкриваємо нову форму в залежності від ролі
                if (user.Role == "Admin")
                {
                    FormForAdmin formForAdmin = new FormForAdmin();
                    formForAdmin.Show();
                }
                else
                {
                    FormForWork formForWork = new FormForWork();
                    formForWork.Show();
                }
                this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect password.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occurred: {ex.Message}");
            }
        }
    }
}
