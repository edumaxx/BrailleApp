using System;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Braille_APP
{
    public partial class Braille : Form
    {



        //public const string Braillelibdll = @"c:\users\eduar\source\repos\braille app\braillelib\x64\debug\Braillelib.dll";
        //[DllImport(Braillelibdll, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int AddNumbers(int a, int b);

        //[DllImport(Braillelibdll, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int SubstractNumbers(int a, int b);




        SerialPort _serial;

        public Braille()
        {
            InitializeComponent();
        }

        private void Braille_Load(object sender, EventArgs e)
        {
            SetComboComPorts();
            SetComboParity();
            SetComboBaudRate();
            SetComboDataSize();
            SetComboHandshake();
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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!_serial.IsOpen)
            {
                return;
            }


            _serial.Write(txtValue.Text);
        }


    }
}