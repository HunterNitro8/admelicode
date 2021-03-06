﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admeli.AlmacenBox.fecha;
using Admeli.AlmacenBox.Nuevo;
using Admeli.Componentes;
using Entidad;
using Entidad.Configuracion;
using Modelo;


namespace Admeli.AlmacenBox.buscar
{
    public partial class FormBuscarCompra : Form
    {


        // servicios necesarios

        AlmacenModel AlmacenModel = new AlmacenModel();
        ProductoModel productoModel = new ProductoModel();
        FechaModel fechaModel = new FechaModel();
        NotaSalidaModel NotaSalidaModel = new NotaSalidaModel();
        CompraModel compraModel = new CompraModel();        // objetos que cargan a un inicio

        private List<CompraNEntrada> listCompraNEntrada { get; set; }

        // entidadades auxiliares

     
        private string formato { get; set; }
        private int nroDecimales = 2;
        private FechaSistema fechaSistema { get; set; }



        //objetos en tiempo real
        public  CompraNEntrada currentCompraNEntrada { get; set; }
     

        public FormBuscarCompra()
        {
            InitializeComponent();
            
            formato = "{0:n" + nroDecimales + "}";
           


        }


        public FormBuscarCompra(Compra currentCompra)
        {
            InitializeComponent();
          
            formato = "{0:n" + nroDecimales + "}";
           
        }

        #region=======================metodos de apoyo
        private string darformato(object dato)
        {
            return string.Format(CultureInfo.GetCultureInfo("en-US"), this.formato, dato);
        }
        #endregion
        #region ================================ Root Load ================================

        private void FormNotaSalidaNew_Load(object sender, EventArgs e)
        {
            cargarCompras();

        }
        private void reLoad()
        {
            
        }

        #endregion

        #region ============================== Load ==============================


        private async void cargarCompras()
        {
            try
            {
                listCompraNEntrada = await compraModel.comprasSinNota(ConfigModel.sucursal.idSucursal);

                compraNEntradaBindingSource.DataSource = listCompraNEntrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Cargar Compras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        #endregion

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtDocumentoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

      
        private void dgvNotaSalida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            entrarGuiaremision();

        }

        private void entrarGuiaremision()
        {
            if (dgvCompras.Rows.Count == 0)
            {
                MessageBox.Show("No hay un registro seleccionado", "nota salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int index = dgvCompras.CurrentRow.Index; // Identificando la fila actual del datagridview
            int idCompra = Convert.ToInt32(dgvCompras.Rows[index].Cells[0].Value); // obteniedo el idRegistro del datagridview

            currentCompraNEntrada = listCompraNEntrada.Find(x => x.idCompra == idCompra);         
            this.Close();
        }

        private void txtNroCompra_TextChanged(object sender, EventArgs e)
        {
            BindingList<CompraNEntrada> filtered = new BindingList<CompraNEntrada>(listCompraNEntrada.Where(obj => obj.numeroDocumento.Contains(txtNroCompra.Text)).ToList());
            compraNEntradaBindingSource.DataSource = filtered;
            dgvCompras.Update();
        }

        private void txtOrdenCompra_TextChanged(object sender, EventArgs e)
        {
            BindingList<CompraNEntrada> filtered = new BindingList<CompraNEntrada>(listCompraNEntrada.Where(obj => obj.OrdenCompraNro.Contains(txtOrdenCompra.Text)).ToList());
            compraNEntradaBindingSource.DataSource = filtered;
            dgvCompras.Update();
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {
            BindingList<CompraNEntrada> filtered = new BindingList<CompraNEntrada>(listCompraNEntrada.Where(obj => obj.nombreProveedor.ToUpper().Contains(txtNombreProveedor.Text.Trim().ToUpper())).ToList());
            compraNEntradaBindingSource.DataSource = filtered;
            dgvCompras.Update();
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            BindingList<CompraNEntrada> filtered = new BindingList<CompraNEntrada>(listCompraNEntrada.Where(obj => obj.rucDni.ToUpper().Contains(txtNroDocumento.Text.Trim().ToUpper())).ToList());
            compraNEntradaBindingSource.DataSource = filtered;
            dgvCompras.Update();
        }

        private void btnfechaFacturacion_Click(object sender, EventArgs e)
        {
            FormFecha fecha = new FormFecha();
            fecha.ShowDialog();
            BindingList<CompraNEntrada> filtered = new BindingList<CompraNEntrada>(listCompraNEntrada.Where(obj => obj.NFechaFacturacion >= fecha.desde && obj.NFechaFacturacion <= fecha.hasta).ToList());
            compraNEntradaBindingSource.DataSource = filtered;
            dgvCompras.Update();
        }

        private void btnFechaPago_Click(object sender, EventArgs e)
        {
            FormFecha fecha = new FormFecha();
            fecha.ShowDialog();
            BindingList<CompraNEntrada> filtered = new BindingList<CompraNEntrada>(listCompraNEntrada.Where(obj => obj.NFechaPago >= fecha.desde && obj.NFechaPago <= fecha.hasta).ToList());
            compraNEntradaBindingSource.DataSource = filtered;
            dgvCompras.Update();
        }
    }
}
