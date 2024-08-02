using BibleBLL;
using BibleDal;
using BibleEnteties;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BiblePL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char FirstHebChar = (char)1488;
            char LastHebChar = (char)1514;
            ClassBLL classbll = new ClassBLL();
            string word = textBox1.Text;
            if (word[0] >= FirstHebChar && word[0] <= LastHebChar)
            {
                List<string> list = classbll.findExactLocation(word);
                listBox1.Items.Clear();
                {
                    foreach (string item in list)
                    {
                        listBox1.Items.Add(item);
                    }

                }
            }
            else
            {
                throw new ArithmeticException("Access denied - You must insert only in hebrew.");
            }



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

            char FirstHebChar = (char)1488;
            char LastHebChar = (char)1514;
            ClassBLL classbll = new ClassBLL();
            string word = textBox1.Text;
            if (word[0] >= FirstHebChar && word[0] <= LastHebChar)
            {
                List<int> p = classbll.SearchWordIndexes(word);
                listBox1.Items.Clear();
                {
                    foreach (int item in p)
                    {
                        listBox1.Items.Add($"place: {item}");
                    }
                }
            }
            else
            {
                throw new ArithmeticException("Access denied - You must insert only in hebrew.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char FirstHebChar = (char)1488;
            char LastHebChar = (char)1514;
            ClassBLL classbll = new ClassBLL();
            string word = textBox1.Text;
            if (word[0] >= FirstHebChar && word[0] <= LastHebChar)
            {
                List<string> p = classbll.findIntractuon(word);
                listBox1.Items.Clear();
                {
                    foreach (string person in p)
                    {
                        listBox1.Items.Add($"דיבר עם: {person}");
                    }
                }
            }
            else
            {
                throw new ArithmeticException("Access denied - You must insert only in hebrew.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}