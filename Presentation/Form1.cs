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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmEmpleado : Form
    {
        private EmployeeModel employeeModel;


        public int Count { get; set; }
        public frmEmpleado()
        {
            employeeModel = new EmployeeModel();
            
            InitializeComponent();
        }
       

        private void Button1_Click(object sender, EventArgs e)
        {

            //string dni, names, lastnames;
            //decimal wage;

            //dni = txtDni.Text;
            //names = txtNombres.Text;
            //lastnames = txtApellidos.Text;
            //ValidateEmpleado(dni, names, lastnames, txtSalario.Text);

            //if (!decimal.TryParse(txtSalario.Text,out wage))
            //{
            //    MessageBox.Show($"Error, el salario: {txtSalario.Text} no tiene el formato correcto",
            //        "Mensaje de error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    return;
            //}


            //Employee employee = new Employee()
            //{
            //    Id = ++Count,
            //    Dni = dni,
            //    Names = names,
            //    Lastnames = lastnames,
            //    Wage = wage,
            //    AcademicLevel = (AcademicLevel)cmbAcademicLevel.SelectedIndex,
            //    Gender = (Gender)cmbGenero.SelectedIndex
            //};

            //string jsonObject = JsonConvert.SerializeObject(employee);

            string jsonEmp = @"{ ""Id"": 1, ""Dni"":""001-000000-0000U"",
                                 ""Names"": ""Jeser"",""Lastnames"": ""Funes"",
                                 ""Wage"": 12000, ""AcademicLevel"": 4,
                                 ""Gender"":1
                               }";
            Employee employee = JsonConvert.DeserializeObject<Employee>(jsonEmp);
            employeeModel.Add(employee);

            //PrintInformationMessage(jsonObject);
            MessageBox.Show($@" 
                                Id:{employee.Id}
                               DNI:{employee.Dni}
                           Nombres:{employee.Names}
                         Apellidos:{employee.Lastnames}
                           Salario:{employee.Wage}
                   Nivel Academico:{employee.AcademicLevel}
                            Genero:{employee.Gender}
                             Count:{employeeModel.GetEmployees().Length}");
            ClearTextboxes();
        }
        #region Empty Methods
        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {



        }
        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void TxtApellidos_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        private void ClearTextboxes()
        {
            txtDni.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtSalario.Text = string.Empty;
            txtDni.Focus();
        }


        private void ValidateEmpleado(string dni, string names, string lastnames, string wage)
        {
            

            if (string.IsNullOrWhiteSpace(dni) ||
                string.IsNullOrWhiteSpace(names) ||
                string.IsNullOrWhiteSpace(lastnames) ||
                string.IsNullOrWhiteSpace(wage))
            {
                throw new ArgumentException("Error, todos los campos son requeridos.");
            }
            //if (!Regex.Match(dni, patternDni).Success)
            //{
            //    throw new ArgumentException($"Error, el DNI:'{dni}' no tiene el formato correcto.");
            //}

            if (names.Length > 20 || lastnames.Length > 20)
            {
                throw new ArgumentException($"Error, el Nombre o Apellido deben tener un maximo de 20 caracteres.");
            }
            if (!decimal.TryParse(wage, out decimal sal))
            {
                throw new ArgumentException($"Error, el Salario:{wage} no tiene el formato correcto.");
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            PrintInformationMessage($"Salario Maximo: {employeeModel.GetSalarioMaximo()}");
        }

        private void PrintInformationMessage(string message)
        {
            MessageBox.Show(message, "Mensaje de informacion", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void TxtSalario_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnMinimo_Click(object sender, EventArgs e)
        {
            PrintInformationMessage($"Salario Minimo:{employeeModel.GetSalarioMinimo()}");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            PrintInformationMessage($"Salario Promedio:{employeeModel.GetSalarioPromedio()}");
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            PrintInformationMessage($"Salarios encima del promedio:{employeeModel.GetSalarioEncimaPromedio()}");
        }

        private void BtnDebProm_Click(object sender, EventArgs e)
        {
            PrintInformationMessage($"Salarios debajo del promedio:{employeeModel.GetSalarioDebajoPromedio()}");
        }

        private void BtnAbrirProducto_Click(object sender, EventArgs e)
        {
            frmProductos frm2 = new frmProductos();
            frm2.Show();
        }

        
    }
}
