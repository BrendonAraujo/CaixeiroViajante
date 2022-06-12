using WinFormsApp1.Controller;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if(filePath.Text != "")
            {
                string[] lines = System.IO.File.ReadAllLines(filePath.Text);
                ControladorGeral controlador = new ControladorGeral(lines);
            }
            else
            {
                MessageBox.Show("É necessário selecionar pelo menos um arquivo", "Input Incorreto");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            filePath.Text = openFileDialog1.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}