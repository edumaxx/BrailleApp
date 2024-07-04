using System;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace Braille_APP
{
    public partial class Braille : Form
    {

        string[] brailleABNT = {
            "100000", // a
            "101000", // b
            "110000", // c
            "110100", // d
            "100100", // e
            "111000", // f
            "111100", // g
            "101100", // h
            "011000", // i
            "011100", // j
            "100010", // k
            "101010", // l
            "110010", // m
            "110110", // n
            "100110", // o
            "111010", // p
            "111110", // q
            "101110", // r
            "011010", // s
            "011110", // t
            "100011", // u
            "101011", // v
            "011111", // w
            "110011", // x
            "110111", // y
            "100111", // z
            "001000", // ,
            "001010", // ;
            "001100", // :
            "000010", // .
            "001001", // ?
            "001110", // !
            "010001"  // maiúscula
        };

        string[] brailleNum = {
            "011100", // 0
            "100000", // 1
            "101000", // 2
            "110000", // 3
            "110100", // 4
            "100100", // 5
            "111000", // 6
            "111100", // 7
            "101100", // 8
            "011000"  // 9
        };


        public Braille()
        {
            InitializeComponent();
        }

        private void Braille_Load(object sender, EventArgs e)
        {

            txtValue.ScrollBars = ScrollBars.Vertical;
            txtValue.TextChanged += new EventHandler(txtValue_TextChanged);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Arquivo de Texto | *.txt";
            sf.ShowDialog();


            if (string.IsNullOrEmpty(sf.FileName) == false)
            {

                try
                {
                    using (StreamWriter writer = new StreamWriter(sf.FileName, false, Encoding.UTF8))
                    {
                        writer.Write(txtValue.Text);
                        writer.Flush();
                    }
                }
                catch
                {
                    MessageBox.Show("Não foi possivel salvar o seu arquivo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Arquivo de texto | *.txt";
            of.ShowDialog();
            if (string.IsNullOrEmpty(of.FileName) == false)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(of.FileName, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage)))
                    {
                        txtValue.Text = reader.ReadToEnd();
                    }
                }

                catch
                {
                    MessageBox.Show("Não foi possivel abrir o seu arquivo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btn_Traduzir_Click(object sender, EventArgs e)
        {
            string frase = txtValue.Text;
            string[] braille = { "", "", "" };

            for (int i = 0; i < frase.Length; i++)
            {
                char letra = char.ToLower(frase[i]);
                if (letra == ' ')
                {
                    braille[0] += "  ";
                    braille[1] += "  ";
                    braille[2] += "  ";
                }
                else if ((letra >= 'a' && letra <= 'z') || letra == ',' || letra == '?' || letra == '!' || letra == '.' || letra == ';' || letra == ':')
                {
                    int index;
                    if (letra >= 'a' && letra <= 'z')
                    {
                        index = letra - 'a';
                    }
                    else if (letra == ',')
                    {
                        index = 26;
                    }
                    else if (letra == ';')
                    {
                        index = 27;
                    }
                    else if (letra == ':')
                    {
                        index = 28;
                    }
                    else if (letra == '.')
                    {
                        index = 29;
                    }
                    else if (letra == '?')
                    {
                        index = 30;
                    }
                    else if (letra == '!')
                    {
                        index = 31;
                    }
                    else
                    {
                        index = -1;
                    }

                    if (index != -1)
                    {
                        string codigo = brailleABNT[index];

                        if (char.IsUpper(frase[i]))
                        {
                            braille[0] += "01 ";
                            braille[1] += "00 ";
                            braille[2] += "01 ";
                        }

                        braille[0] += codigo.Substring(0, 2) + " ";
                        braille[1] += codigo.Substring(2, 2) + " ";
                        braille[2] += codigo.Substring(4, 2) + " ";
                    }
                }
                else if (letra >= '0' && letra <= '9')
                {
                    braille[0] += "01 ";
                    braille[1] += "01 ";
                    braille[2] += "11 ";
                    int indice = letra - '0';
                    string codigo = brailleNum[indice];
                    braille[0] += codigo.Substring(0, 2) + " ";
                    braille[1] += codigo.Substring(2, 2) + " ";
                    braille[2] += codigo.Substring(4, 2) + " ";
                }
            }

            Tradução_Braille newForm = new Tradução_Braille();
            newForm.SetText(braille);
            newForm.ShowDialog();
        }


        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            if (tb != null)
            {
                if (tb.Text.Length > 625)
                {
                    tb.Text = tb.Text.Substring(0, 625);
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                }

                string[] lines = tb.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                if (lines.Length > 27)
                {
                    tb.Text = string.Join(Environment.NewLine, lines, 0, 27);
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                }

                else
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Length > 25)
                        {
                            string currentLine = lines[i];
                            lines[i] = currentLine.Substring(0, 25);
                            string remainingText = currentLine.Substring(25);

                            if (i + 1 < lines.Length)
                            {
                                lines[i + 1] = remainingText + lines[i + 1];
                            }
                            else
                            {
                                Array.Resize(ref lines, lines.Length + 1);
                                lines[i + 1] = remainingText;
                            }
                        }
                    }

                    tb.TextChanged -= txtValue_TextChanged;
                    tb.Text = string.Join(Environment.NewLine, lines);
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                    tb.TextChanged += txtValue_TextChanged;
                }
            }
        }


    }
}