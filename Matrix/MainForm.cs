using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                dataGridView2.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                dataGridView3.Columns.Add(column);

                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView3.Rows.Add();
                //dataGridView1.Rows[i].Cells[0].Value = i.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix2 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix2.Zapoln(dataGridView2);
            matrix3 = (matrix1 + matrix2);
            matrix3.FullVisual(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix2 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix2.Zapoln(dataGridView2);
            matrix3 = (matrix1 - matrix2);
            matrix3.FullVisual(dataGridView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix3 = matrix1.Trans();
            matrix3.FullVisual(dataGridView3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyMatrix matrix1 = new MyMatrix();
            MyMatrix matrix2 = new MyMatrix();
            MyMatrix matrix3;
            matrix1.Zapoln(dataGridView1);
            matrix2.Zapoln(dataGridView2);
            matrix3 = (matrix1 * matrix2);
            matrix3.FullVisual(dataGridView3);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            saveFileDialog1.Filter = "(*.matrix)|*.matrix|All files (*.*)|*.*";
            saveFileDialog1.Title = "Зберегти матрицю";
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView3.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView3.ColumnCount; j++)
                            {
                                myWritet.Write(dataGridView3.Rows[i].Cells[j].Value.ToString() + " ");
                            }
                            myWritet.WriteLine();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Сталась помилка: \n{0}", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        myWritet.Close();
                    }

                    myStream.Close();
                }
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            About about = new About();
            if (about.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}