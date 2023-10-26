using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahmad_Raza_fa20_bcs_001_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void GeneratePassword()
        {
            // Get user input from TextBoxes
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string regNumber = textBox3.Text;

            // Validate input and generate password
            if (firstName.Length >= 1 && lastName.Length >= 1 && regNumber.Length >= 11)
            {
                // Extract initials
                char initial1 = char.ToUpper(firstName[0]);
                char initial2 = char.ToUpper(lastName[0]);

                // Extract last two digits from registration number
                string lastTwoDigits = regNumber.Substring(regNumber.Length - 2);

                // Generate random password
                Random random = new Random();
                string specialCharacters = "!@#$%^&*()_-+=<>?/"; // Define your set of special characters
                string numbers = "0123456789";

                string password = string.Format("{0}{1}{2}{3}{4}",
                    initial1, initial2, numbers[random.Next(4, 10)], numbers[random.Next(4, 10)],
                    specialCharacters[random.Next(specialCharacters.Length)]);

                // Display the generated password
                textBox4.Text = password;
            }
            else
            {
                textBox4.Text = "Invalid input!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneratePassword();
        }
    }
}
