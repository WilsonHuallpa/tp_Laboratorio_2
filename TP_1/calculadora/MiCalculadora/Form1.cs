using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FromCalculadora : Form
    {
      
        public FromCalculadora()
        {
        
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirBinario_Click(object sender, EventArgs e)
        {
            string binario = this.lbResultado.Text;
            if(binario == "Resultado")
            {
                this.lbResultado.Text = binario;
            }
            else
            {
                binario = Numero.DecimalBinario(binario);
                this.lbResultado.Text = binario;
            }
           
        }

        private void btnConvertirDecimal_Click(object sender, EventArgs e)
        {
            string numeroDecimal = this.lbResultado.Text;

            if(numeroDecimal == "Resultado")
            {
                this.lbResultado.Text = numeroDecimal;
            }
            else
            {
                numeroDecimal = Numero.BinarioDecimal(numeroDecimal);
                this.lbResultado.Text = numeroDecimal;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            if(this.cmdOperadores.SelectedItem == null)
            {
                this.cmdOperadores.Text = "+";
            }

            resultado = Operar(this.textNumero1.Text, this.textNumero2.Text, this.cmdOperadores.SelectedItem.ToString());

            this.lbResultado.Text = resultado.ToString();
        }

       /// <summary>
       /// limpir pantalla
       /// </summary>
         public void Limpiar()
         {
             this.textNumero1.Clear();
             this.textNumero2.Clear();
             this.cmdOperadores.ResetText();
             this.cmdOperadores.Text = null;
             this.lbResultado.Text = "Resultado";

         }
        /// <summary>
        ///  Opera dos numero con su repectivo operador.
        /// </summary>
        /// <param name="numero1">numero 1 tipo string</param>
        /// <param name="numero2">numero 2 tipo string</param>
        /// <param name="operador"> operador tipo string</param>
        /// <returns>Devuelve el resultado de la operaciones.</returns>
         public static double Operar (string numero1, string numero2, string operador)
         {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            double resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
         }

        
    }
}
