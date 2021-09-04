using Domain;
using Domain.Enums;
using Infraestructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmProductos : Form
    {
        private ProductModel productModel;
        public frmProductos()
        {
            productModel = new ProductModel();
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {

            string name, description;
            int id, quantity;
            decimal price;
            DateTime caducityDate;

            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show($"Error, el ID: {txtID.Text} no tiene el formato correcto",
                    "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            name = txtNombre.Text;
            description = txtDescripcion.Text;
            if (!int.TryParse(txtCantidad.Text, out quantity))
            {
                MessageBox.Show($"Error, la cantidad: {txtCantidad.Text} no tiene el formato correcto",
                    "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out price))
            {
                MessageBox.Show($"Error, el precio: {txtPrecio.Text} no tiene el formato correcto",
                    "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(txtFechCad.Text, out caducityDate))
            {
                MessageBox.Show($"Error, la fecha: {txtFechCad.Text} no tiene el formato correcto",
                    "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Product product = new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                Quantity = quantity,
                Price = price,
                CaducityDate = caducityDate,
                UnidadDeMedida = (UnidadDeMedida)cmbUnidadDeMedida.SelectedIndex
            };

            productModel.Add(product);
            MessageBox.Show($@"
                             Id:{product.Id}
                         Nombre:{product.Name}
                    Descripcion:{product.Description}
                       Cantidad:{product.Quantity}
                         Precio:{product.Price}
             Fecha de caducidad:{product.CaducityDate}
                Unidad de medidad:{product.UnidadDeMedida}");

            ClearTexboxes();

        }

        private void ClearTexboxes()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtFechCad.Clear();
        }
      

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbUnidadDeMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string name, description;
            decimal price;
            int cantidad;

            name = txtNombre.Text;
            description = txtDescripcion.Text;
            price = decimal.Parse(txtPrecio.Text);
            cantidad = int.Parse(txtCantidad.Text);

            string jsonObject = $@"
                                  ""Id"": 1,
                                  ""Nombre"": ""{name}"",
                                  ""Descripcion"": ""{description}"",
                                  ""Precio"": ""{price}"",
                                  ""Cantidad"": ""{cantidad}"",

                                  ";

            Product product = JsonConvert.DeserializeObject<Product>(jsonObject);
            Product pro = product;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Count() - 1);
            //elimina elementos uno a uno

            rchJson.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintInformationMessage($"Producto por caducidad: {ProductModel.ProductoByCaducidad}");
        }

        private void PrintInformationMessage(string v)
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintInformationMessage($"Producto por rango de precio: {ProductModel.GetProductsByPriceRange()}");
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
