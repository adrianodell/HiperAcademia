using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperAcademia
{
    public partial class Form1 : Form
    {
        string Nome;
        int Idade;
        decimal Altura;
        decimal Peso;
        int[] Dias;
        List<int> Anos;
        Dictionary<int, string> Meses;

        public Form1()
        {
            InitializeComponent();

            Dias = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };

            Anos = new List<int>()
            {
                1970,
                1980,
                1981,
                1982,
                1983,
                1984,
                1995,
                1996,
                1997,
                1998,
                1999,
                2000
            };
            
            Meses = new Dictionary<int, string>()
            {
                { 1 , "Janeiro" },
                { 2 , "Fevereiro" },
                { 3 , "Março" },
                { 4 , "Abril" },
                { 5 , "Maio" },
                { 6 , "Junho" },
                { 7 , "Julho" },
                { 8 , "Agosto" },
                { 9 , "Setembro" },
                { 10 , "Outubro" },
                { 11 , "Novembro" },
                { 12 , "Dezembro" }
            };

            foreach (int dia in Dias)
            {
                cbxDia.Items.Add(dia);
            }

            foreach (int ano in Anos)
            {
                cbxAno.Items.Add(ano);
            }

            cbxMes.DataSource = new BindingSource(Meses, null);
            cbxMes.DisplayMember = "Value";
            cbxMes.ValueMember = "Key";

            
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            string Nome = txtNome.Text;            

            if (!decimal.TryParse(txtAltura.Text, out Altura))
            {
                MessageBox.Show("Altura inválida!");
                return;
            }

            if (!decimal.TryParse(txtPeso.Text, out Peso))
            {
                MessageBox.Show("Peso inválida!");
                return;
            }

            string descricao = VerificarImc(Peso, Altura, out decimal imc);
            
            MessageBox.Show($"Nome: {Nome}\nNascimento: {cbxDia.Text} de {cbxMes.Text} de {cbxAno.Text}\nIMC: {imc.ToString("N2")}\n\n{descricao}");
        }

        private string VerificarImc(decimal peso, decimal altura, out decimal imc)
        {
            imc = Peso / (Altura * Altura);

            if (imc < (decimal)18.5)
            {
                return "Abaixo do peso";
            }
            else if (imc >= (decimal)18.5 && imc < 25)
            {
                return "Peso normal";
            }
            else if (imc >= 25 && imc < 30)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30 && imc < 35)
            {
                return "Obesidade grau 1";
            }
            else if (imc >= 35 && imc < 39)
            {
                return "Obesidade grau 2";
            }
            else
            {
                return "Obesidade grau 3";
            }
        }


        private string TraduzirMes(int mes)
        {
            string descricao = string.Empty;

            switch (mes)
            {
                case 1:
                    descricao = "Janeiro";
                    break;
                case 2:
                    descricao = "Feveriero";
                    break;
                case 3:
                    descricao = "Março";
                    break;
                case 4:
                    descricao = "Abril";
                    break;
                case 5:
                    descricao = "Maio";
                    break;
                case 6:
                    descricao = "Junho";
                    break;
                case 7:
                    descricao = "Julho";
                    break;
                case 8:
                    descricao = "Agosto";
                    break;
                case 9:
                    descricao = "Setembro";
                    break;
                case 10:
                    descricao = "Outubro";
                    break;
                case 11:
                    descricao = "Novembro";
                    break;
                case 12:
                    descricao = "Dezembro";
                    break;
                default:
                    descricao = "Mês não encontrado";
                    break;
            }

            return descricao;
        }

        public string TraduzirMesLinq(int mes)
        {
            return Meses.FirstOrDefault(x => x.Key == mes).Value;
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMes.Text, out int mes))
            {
                MessageBox.Show("Número inválido!");
                return;
            }

            string descricao = TraduzirMesLinq(mes);

            MessageBox.Show(descricao);
        }
    }
}
