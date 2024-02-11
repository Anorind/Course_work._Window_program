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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            textBoxPhoneNumber.KeyPress += (s, args) =>
            {
                if (!char.IsDigit(args.KeyChar) && !char.IsControl(args.KeyChar))
                {
                    args.Handled = true; // відміна ввода символа для вводу телефона
                }
            };
            textBoxPassword.PasswordChar = '*';
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // Перевірка на заповненість полів
            if (string.IsNullOrWhiteSpace(textBoxRole.Text) ||
                string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSurname.Text) ||
                string.IsNullOrWhiteSpace(textBoxMale.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            // Перевірка на існування такогож логіну
            string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\"));
            string filePath = System.IO.Path.Combine(projectDirectory, "users.json");
            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);
                var existingUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(json);
                foreach (var existingUser in existingUsers)
                {
                    if (existingUser.Login == textBoxLogin.Text)
                    {
                        //Якщо логіни не співпадають то робить поле червоним та з часом біліє
                        MessageBox.Show("This login already exists. Please choose a different login.");
                        textBoxLogin.Clear();
                        textBoxLogin.BackColor = System.Drawing.Color.Red;

                        Timer timer = new Timer();
                        timer.Interval = 6; 
                        timer.Tick += (s, args) =>
                        {
                            textBoxLogin.BackColor = System.Drawing.Color.FromArgb(Math.Min(textBoxLogin.BackColor.R + 1, 255),
                                                                    Math.Min(textBoxLogin.BackColor.G + 1, 255),
                                                                    Math.Min(textBoxLogin.BackColor.B + 1, 255));

                            if (textBoxLogin.BackColor.R == 255 && textBoxLogin.BackColor.G == 255 && textBoxLogin.BackColor.B == 255)
                            {
                                timer.Stop();
                            }
                        };
                        timer.Start();

                        return;
                    }
                }
            }

            SaveUserData();
            Window_programm_form.Instance.Show();

            this.Close();
        }
        private void SaveUserData()
        {
            var user = new
            {
                Role = textBoxRole.Text,
                FirstName = textBoxFirstName.Text,
                Surname = textBoxSurname.Text,
                Male = textBoxMale.Text,
                DateOfBirth = dateTimePickerDateOfBirth.Value,
                PhoneNumber = textBoxPhoneNumber.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(textBoxPassword.Text), // Хеширование пароля
                Login = textBoxLogin.Text
            };

            string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\"));

            string filePath = System.IO.Path.Combine(projectDirectory, "users.json");

            List<dynamic> users = new List<dynamic>();
            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);
                users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(json);
            }

            users.Add(user);

            string jsonToWrite = Newtonsoft.Json.JsonConvert.SerializeObject(users);

            System.IO.File.WriteAllText(filePath, jsonToWrite);
        }

    }
}
