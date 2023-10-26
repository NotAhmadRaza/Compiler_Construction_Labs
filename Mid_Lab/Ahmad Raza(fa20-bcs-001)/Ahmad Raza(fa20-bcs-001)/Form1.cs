namespace Ahmad_Raza_fa20_bcs_001_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ParseList()
        {
            string input = textBox1.Text;
            int position = 0;

            try
            {
                bool result = ParseList(input, ref position);
                if (result && position == input.Length)
                {
                    textBox2.Text = "Valid List!";
                }
                else
                {
                    textBox2.Text = "Invalid List!";
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = "Error: " + ex.Message;
            }
        }

        private bool ParseList(string input, ref int position)
        {
            if (ParseItem(input, ref position))
            {
                return ParseRest(input, ref position);
            }
            return false;
        }

        private bool ParseRest(string input, ref int position)
        {
            if (position < input.Length && input[position] == ',')
            {
                position++; // Consume comma
                return ParseItem(input, ref position) && ParseRest(input, ref position);
            }
            return true; // ε case
        }

        private bool ParseItem(string input, ref int position)
        {
            // Skip any leading spaces
            while (position < input.Length && char.IsWhiteSpace(input[position]))
            {
                position++;
            }

            // Check for 'id'
            if (position < input.Length && input.Substring(position, 2) == "id")
            {
                position += 2; // Consume 'id'
                return true;
            }

            // Check for 'num'
            if (position < input.Length && input.Substring(position, 3) == "num")
            {
                position += 3; // Consume 'num'
                return true;
            }

            // Check for 'string'
            if (position < input.Length && input.Substring(position, 6) == "string")
            {
                position += 6; // Consume 'string'
                return true;
            }

            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ParseList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}