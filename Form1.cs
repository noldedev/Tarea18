using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Tarea18
{
    public partial class Form1 : Form
    {
        int num = 1;
        int fila;

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        //Boton para salir
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Boton para agregar
        private void button1_Click(object sender, EventArgs e)
        {
            string vendedor = textBox1.Text;
            string producto1 = textBox2.Text;
            double cantidad1 = double.Parse(textBox3.Text);
            double precio1 = double.Parse(textBox4.Text);
            string producto2 = textBox5.Text;
            double cantidad2 = double.Parse(textBox6.Text);
            double precio2 = double.Parse(textBox7.Text);

            double subtotal = (cantidad1 * precio1) + (cantidad2 * precio2);

            // Calcular Descuento y Porcentaje
            double descuento = CalcularDescuento(subtotal);
            double porcentaje = ObtenerPorcentajeDescuento(subtotal);

            double total = subtotal - descuento;

            dataGridView1.Rows.Add(num, vendedor, producto1, cantidad1, precio1, producto2, cantidad2, precio2, subtotal, descuento, porcentaje, total - descuento);
            num = num + 1;
            LimpiarTextBoxes();
        }

        private double CalcularDescuento(double subTotal)
        {
            if (subTotal > 10001)
                return subTotal * 0.2;
            else if (subTotal > 7001)
                return subTotal * 0.16;
            else if (subTotal > 5001)
                return subTotal * 0.12;
            else if (subTotal > 3001)
                return subTotal * 0.1;
            else
                return 0; // No hay descuento
        }


        private double ObtenerPorcentajeDescuento(double subTotal)
        {
            if (subTotal > 10001)
                return 20;
            else if (subTotal > 7001)
                return 16;
            else if (subTotal > 5001)
                return 12;
            else if (subTotal > 3001)
                return 10;
            else
                return 0;
        }

        private void LimpiarTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1[1, fila].Value.ToString();
            textBox2.Text = dataGridView1[2, fila].Value.ToString();
            textBox3.Text = dataGridView1[3, fila].Value.ToString();
            textBox4.Text = dataGridView1[4, fila].Value.ToString();
            textBox5.Text = dataGridView1[5, fila].Value.ToString();
            textBox6.Text = dataGridView1[6, fila].Value.ToString();
            textBox7.Text = dataGridView1[7, fila].Value.ToString();



        }

        //Boton para eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(fila);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
        }

        //Boton para actualizar
        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener valores de los TextBox
            string vendedor = textBox1.Text;
            string producto1 = textBox2.Text;
            double cantidad1 = double.Parse(textBox3.Text);
            double precio1 = double.Parse(textBox4.Text);
            string producto2 = textBox5.Text;
            double cantidad2 = double.Parse(textBox6.Text);
            double precio2 = double.Parse(textBox7.Text);

            // Calcular SubTotal
            double subtotal = (cantidad1 * precio1) + (cantidad2 * precio2);

            // Calcular Descuento y Porcentaje
            double descuento = CalcularDescuento(subtotal);
            double porcentaje = ObtenerPorcentajeDescuento(subtotal);

            double total = subtotal - descuento;

            // Actualizar DataGridView con los nuevos valores calculados
            dataGridView1[1, fila].Value = vendedor;
            dataGridView1[2, fila].Value = producto1;
            dataGridView1[3, fila].Value = cantidad1;
            dataGridView1[4, fila].Value = precio1;
            dataGridView1[5, fila].Value = producto2;
            dataGridView1[6, fila].Value = cantidad2;
            dataGridView1[7, fila].Value = precio2;
            dataGridView1[8, fila].Value = subtotal;
            dataGridView1[9, fila].Value = descuento;
            dataGridView1[10, fila].Value = porcentaje;
            dataGridView1[11, fila].Value = total - descuento;

        }
    }
}
