﻿using System;
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
        private const int Columns = 50;
        private const int Rows = 54;

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
            string[,] brailleMatrix = new string[Rows * 3, Columns]; // Multiplicar as linhas por 3 para acomodar cada linha de Braille

            // Inicializar matriz de Braille
            for (int r = 0; r < Rows * 3; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    brailleMatrix[r, c] = " ";
                }
            }

            // Traduzir frase para Braille e preencher a matriz
            FillBrailleMatrix(frase, brailleMatrix);

            Tradução_Braille newForm = new Tradução_Braille();
            newForm.SetText(ConvertMatrixToArray(brailleMatrix)); // Converter a matriz antes de passar
            newForm.ShowDialog();
        }

        private void FillBrailleMatrix(string frase, string[,] brailleMatrix)
        {
            int currentRow = 0;
            int currentCol = 0;

            for (int i = 0; i < frase.Length; i++)
            {
                char letra = frase[i];
                bool isUpper = char.IsUpper(letra);
                letra = char.ToLower(letra);

                if (letra == ' ')
                {
                    AddBrailleChar(brailleMatrix, currentRow, currentCol, "  ", "  ", "  ");
                }
                else if ((letra >= 'a' && letra <= 'z') || letra == ',' || letra == '?' || letra == '!' || letra == '.' || letra == ';' || letra == ':')
                {
                    int index = GetBrailleIndex(letra);
                    if (index != -1)
                    {
                        if (isUpper)
                        {
                            // Prefixo para letras maiúsculas
                            AddBrailleChar(brailleMatrix, currentRow, currentCol, " 01", " 00", " 01");
                            currentCol++;
                            if (currentCol >= Columns)
                            {
                                currentCol = 0;
                                currentRow += 3;
                                if (currentRow >= Rows * 3) break;
                            }
                        }
                        string codigo = brailleABNT[index];
                        AddBrailleChar(brailleMatrix, currentRow, currentCol,
                            codigo.Substring(0, 2),
                            codigo.Substring(2, 2),
                            codigo.Substring(4, 2));
                    }
                }
                else if (letra >= '0' && letra <= '9')
                {
                    // Prefixo para números
                    AddBrailleChar(brailleMatrix, currentRow, currentCol, "01", "01", "11");
                    currentCol++;
                    if (currentCol >= Columns)
                    {
                        currentCol = 0;
                        currentRow += 3;
                        if (currentRow >= Rows * 3) break;
                    }

                    string codigo = brailleNum[letra - '0'];
                    AddBrailleChar(brailleMatrix, currentRow, currentCol,
                        codigo.Substring(0, 2),
                        codigo.Substring(2, 2),
                        codigo.Substring(4, 2));
                }

                // Atualizar posição na matriz
                currentCol++;
                if (currentCol >= Columns)
                {
                    currentCol = 0;
                    currentRow += 3;
                    if (currentRow >= Rows * 3)
                    {
                        break; // Parar se atingir o fim da matriz
                    }
                }
            }
        }

        private void AddBrailleChar(string[,] brailleMatrix, int row, int col, string line1, string line2, string line3)
        {
            brailleMatrix[row, col] = line1;
            brailleMatrix[row + 1, col] = line2;
            brailleMatrix[row + 2, col] = line3;
        }

        private int GetBrailleIndex(char letra)
        {
            if (letra >= 'a' && letra <= 'z') return letra - 'a';
            if (letra == ',') return 26;
            if (letra == ';') return 27;
            if (letra == ':') return 28;
            if (letra == '.') return 29;
            if (letra == '?') return 30;
            if (letra == '!') return 31;
            return -1;
        }

        private string[] ConvertMatrixToArray(string[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            string[] result = new string[rows];

            for (int r = 0; r < rows; r++)
            {
                StringBuilder rowBuilder = new StringBuilder();
                for (int c = 0; c < cols; c++)
                {
                    rowBuilder.Append(matrix[r, c]);
                }
                result[r] = rowBuilder.ToString();
            }

            return result;
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