using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Braille_APP
{
    public partial class Tradução_Braille : Form
    {
        SerialPort _serial = new SerialPort();

        public Tradução_Braille()
        {
            InitializeComponent();
        }

        private void Tradução_Braille_Load(object sender, EventArgs e)
        {
            SetComboComPorts();
            SetComboParity();
            SetComboBaudRate();
            SetComboDataSize();
            SetComboHandshake();

            txtTradu.ScrollBars = ScrollBars.Vertical;
            txtTradu.TextChanged += new EventHandler(txtTradu_TextChanged);
        }


        private void SetComboHandshake()
        {
            cbbHandshake.DataSource = Enum.GetNames(typeof(Handshake));
        }


        private void SetComboComPorts()
        {
            string[] avaliablePorts = SerialPort.GetPortNames();
            cbbComPorts.DataSource = avaliablePorts;
        }

        private void SetComboParity()
        {
            cbbParity.DataSource = Enum.GetNames(typeof(Parity));
        }

        private void SetComboBaudRate()
        {
            cbbBaudRate.DataSource = new int[]
            {
                4800,
                9600,
                14400,
                19200,
                38400,
                56000,
                57600,
                115200
            };
        }

        private void SetComboDataSize()
        {
            cbbDataSize.DataSource = new int[]
            {
                7,
                8
            };
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _serial = new SerialPort(
                   portName: (string)cbbComPorts.SelectedValue,
                   baudRate: (int)cbbBaudRate.SelectedValue,
                   parity: (Parity)Enum.Parse(typeof(Parity), (string)cbbParity.SelectedValue),
                   dataBits: (int)cbbDataSize.SelectedValue,
                   stopBits: StopBits.One);

                _serial.Open();
                MessageBox.Show($"Conexão com a porta \"{(string)cbbComPorts.SelectedValue}\" realizada com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Não foi possivel conectar a porta serial \"{(string)cbbComPorts.SelectedValue}\".", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _serial.Close();
                MessageBox.Show($"Conexão fechada com a porta \"{(string)cbbComPorts.SelectedValue}\" realizada com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Não foi possivel desconectar a porta serial \"{(string)cbbComPorts.SelectedValue}\".", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTradu_TextChanged(object sender, EventArgs e)
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
                if (lines.Length > 54)
                {
                    tb.Text = string.Join(Environment.NewLine, lines, 0, 54);
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                }

                else
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Length > 50)
                        {
                            string currentLine = lines[i];
                            lines[i] = currentLine.Substring(0, 50);
                            string remainingText = currentLine.Substring(50);

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

                    tb.TextChanged -= txtTradu_TextChanged;
                    tb.Text = string.Join(Environment.NewLine, lines);
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                    tb.TextChanged += txtTradu_TextChanged;
                }
            }
        }

        public void SetText(StringBuilder formattedBrailleText)
        {
            if (txtTradu != null)
            {
                txtTradu.Text = formattedBrailleText.ToString();
            }
            else
            {
                MessageBox.Show("Os controles de texto não foram inicializados corretamente.");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!_serial.IsOpen)
            {
                MessageBox.Show("A porta serial não está aberta. Por favor, conecte-se primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = txtTradu.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    if (c == '1' || c == '0')
                    {
                        _serial.Write(c.ToString());
                        await Task.Delay(1000); // Delay de 1 segundo entre cada caractere
                    }
                }

                // Enviar uma quebra de linha para indicar a mudança de linha
                _serial.Write(Environment.NewLine);
                await Task.Delay(9000); // Delay de 1 segundo para a quebra de linha
            }

            MessageBox.Show("Transmissão concluída.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }

}
