using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannikov_crypto
{
    public partial class Form1 : Form
    {
        private string language;

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            textBox2.Visible = false;
            dataGridView3.Visible = false;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            textBox2.Visible = true;
            dataGridView3.Visible = true;
        }

        private void checkLanguage()
        {
            if (radioButton3.Checked == true)
                language = "en";
            else if (radioButton4.Checked == true)
                language = "ru";
            else
            {
                MessageBox.Show("ТЫ НЕ УКАЗАЛ ЯЗЫК");
                return;
            }
        }
        private void codingPlayFear()
        {
            play_fear playFear = new play_fear(richTextBox1.Text, textBox1.Text, language);
            if (language == "ru")
            {
                playFear.takeCryptoResult();

                string result = "";
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        result += playFear.ruResultSquare[i, j];
                    }
                    result += "\n";
                }
                dataGridView1.RowCount = 8;
                dataGridView1.ColumnCount = 4;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        dataGridView1[j, i].Value = playFear.ruResultSquare[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == playFear.ruStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = playFear.ruStrSplited[k++];
                    }
                    result += "\n";
                }

                playFear.getCrypto();

                string str = "";
                for (int i = 0; i < playFear.ruStrSplited.Length; ++i)
                {
                    str += playFear.ruStrSplited[i];

                }
                richTextBox2.Text = str;
            }
            else
            {
                playFear.takeCryptoResult();

                string result = "";
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        result += playFear.enResultSquare[i, j];
                    }
                    result += "\n";
                }
                dataGridView1.RowCount = 5;
                dataGridView1.ColumnCount = 5;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        dataGridView1[j, i].Value = playFear.enResultSquare[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == playFear.enStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = playFear.enStrSplited[k++];
                    }
                    result += "\n";
                }

                playFear.getCrypto();

                string str = "";
                for (int i = 0; i < playFear.enStrSplited.Length; ++i)
                {
                    str += playFear.enStrSplited[i];

                }
                richTextBox2.Text = str;
            }
        }
        private void encodingPlayFear()
        {
            play_fear playFear = new play_fear(richTextBox1.Text, textBox1.Text, language);
            string result = "";
            if (language == "ru")
            {
                playFear.takeCryptoResult();
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        result += playFear.ruResultSquare[i, j];
                    }
                    result += "\n";
                }

                if (language == "ru")
                {
                    dataGridView1.RowCount = 8;
                    dataGridView1.ColumnCount = 4;
                    for (int i = 0; i < 8; ++i)
                    {
                        for (int j = 0; j < 4; ++j)
                        {

                            dataGridView1[j, i].Value = playFear.ruResultSquare[i, j];
                        }
                        result += "\n";
                    }


                    dataGridView2.RowCount = 8;
                    dataGridView2.ColumnCount = 6;
                    int k = 0;
                    for (int i = 0; i < 8; ++i)
                    {
                        for (int j = 0; j < 6; ++j)
                        {
                            if (k == playFear.ruStrSplited.Length)
                                break;
                            else
                                dataGridView2[j, i].Value = playFear.ruStrSplited[k++];
                        }
                        result += "\n";
                    }

                    playFear.takeDeCrypto();

                    string str = "";
                    for (int i = 0; i < playFear.ruStrSplited.Length; ++i)
                    {
                        str += playFear.ruStrSplited[i];

                    }
                    richTextBox3.Text = str;
                }
            }
            else
            {
               
                playFear.takeCryptoResult();
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        result += playFear.enResultSquare[i, j];
                    }
                    result += "\n";
                }

                dataGridView1.RowCount = 5;
                dataGridView1.ColumnCount = 5;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        dataGridView1[j, i].Value = playFear.enResultSquare[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == playFear.enStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = playFear.enStrSplited[k++];
                    }
                    result += "\n";
                }

                playFear.takeDeCrypto();

                string str = "";
                for (int i = 0; i < playFear.enStrSplited.Length; ++i)
                {
                    str += playFear.enStrSplited[i];

                }
                richTextBox3.Text = str;

            }
        }
        private void codindWhiteStone()
        {
            white_stone whiteStone = new white_stone(richTextBox1.Text, textBox1.Text, textBox2.Text, language);
            if (language == "ru")
            {
                whiteStone.takeCryptoResult();
                //1
                string result = "";
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        result += whiteStone.ruResultSquare[i, j];
                    }
                    result += "\n";
                }
                dataGridView1.RowCount = 8;
                dataGridView1.ColumnCount = 4;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        dataGridView1[j, i].Value = whiteStone.ruResultSquare[i, j];
                    }
                    result += "\n";
                }
                //2
                result = "";
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        result += whiteStone.ruResultSquare1[i, j];
                    }
                    result += "\n";
                }
                dataGridView3.RowCount = 8;
                dataGridView3.ColumnCount = 4;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        dataGridView3[j, i].Value = whiteStone.ruResultSquare1[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == whiteStone.ruStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = whiteStone.ruStrSplited[k++];
                    }
                    result += "\n";
                }

                whiteStone.getCrypto();

                string str = "";
                for (int i = 0; i < whiteStone.ruStrSplited.Length; ++i)
                {
                    str += whiteStone.ruStrSplited[i];

                }
                richTextBox2.Text = str;
            }
            else
            {
                whiteStone.takeCryptoResult();

                string result = "";
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        result += whiteStone.enResultSquare[i, j];
                    }
                    result += "\n";
                }
                dataGridView1.RowCount = 5;
                dataGridView1.ColumnCount = 5;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        dataGridView1[j, i].Value = whiteStone.enResultSquare[i, j];
                    }
                    result += "\n";
                }
                //2
                result = "";
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        result += whiteStone.enResultSquare1[i, j];
                    }
                    result += "\n";
                }
                dataGridView3.RowCount = 5;
                dataGridView3.ColumnCount = 5;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        dataGridView3[j, i].Value = whiteStone.enResultSquare1[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == whiteStone.enStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = whiteStone.enStrSplited[k++];
                    }
                    result += "\n";
                }

                whiteStone.getCrypto();

                string str = "";
                for (int i = 0; i < whiteStone.enStrSplited.Length; ++i)
                {
                    str += whiteStone.enStrSplited[i];

                }
                richTextBox2.Text = str;
            }
        }
        private void encodindWhiteStone()
        {
            white_stone whiteStone = new white_stone(richTextBox1.Text, textBox1.Text, textBox2.Text, language);
            if (language == "ru")
            {
                whiteStone.takeCryptoResult();
                //1
                string result = "";
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        result += whiteStone.ruResultSquare[i, j];
                    }
                    result += "\n";
                }
                dataGridView1.RowCount = 8;
                dataGridView1.ColumnCount = 4;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        dataGridView1[j, i].Value = whiteStone.ruResultSquare[i, j];
                    }
                    result += "\n";
                }
                //2
                result = "";
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        result += whiteStone.ruResultSquare1[i, j];
                    }
                    result += "\n";
                }
                dataGridView3.RowCount = 8;
                dataGridView3.ColumnCount = 4;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        dataGridView3[j, i].Value = whiteStone.ruResultSquare1[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == whiteStone.ruStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = whiteStone.ruStrSplited[k++];
                    }
                    result += "\n";
                }

                whiteStone.takeDeCrypto();

                string str = "";
                for (int i = 0; i < whiteStone.ruStrSplited.Length; ++i)
                {
                    str += whiteStone.ruStrSplited[i];

                }
                richTextBox3.Text = str;
            }
            else
            {
                whiteStone.takeCryptoResult();

                string result = "";
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        result += whiteStone.enResultSquare[i, j];
                    }
                    result += "\n";
                }
                dataGridView1.RowCount = 5;
                dataGridView1.ColumnCount = 5;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        dataGridView1[j, i].Value = whiteStone.enResultSquare[i, j];
                    }
                    result += "\n";
                }
                //2
                result = "";
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        result += whiteStone.enResultSquare1[i, j];
                    }
                    result += "\n";
                }
                dataGridView3.RowCount = 5;
                dataGridView3.ColumnCount = 5;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        dataGridView3[j, i].Value = whiteStone.enResultSquare1[i, j];
                    }
                    result += "\n";
                }


                dataGridView2.RowCount = 8;
                dataGridView2.ColumnCount = 6;
                int k = 0;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 6; ++j)
                    {
                        if (k == whiteStone.enStrSplited.Length)
                            break;
                        else
                            dataGridView2[j, i].Value = whiteStone.enStrSplited[k++];
                    }
                    result += "\n";
                }

                whiteStone.takeDeCrypto();

                string str = "";
                for (int i = 0; i < whiteStone.enStrSplited.Length; ++i)
                {
                    str += whiteStone.enStrSplited[i];

                }
                richTextBox3.Text = str;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkLanguage();
            if (radioButton1.Checked == true)
                codindWhiteStone();
            else if (radioButton2.Checked == true)
                codingPlayFear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkLanguage();
            if (radioButton1.Checked == true)
                encodindWhiteStone();
            else if (radioButton2.Checked == true)
                encodingPlayFear();            
        }
    }
}
