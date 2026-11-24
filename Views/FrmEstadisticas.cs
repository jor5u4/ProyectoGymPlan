///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public class FrmEstadisticas : Form
    {
        private readonly UsuarioBasico usuario;
        private readonly FiltroEstadisticas estadisticas = new FiltroEstadisticas();
        private readonly Controllers.Usuario usuarioController = new Controllers.Usuario();

        private readonly DateTimePicker dtpDesde = new DateTimePicker();
        private readonly DateTimePicker dtpHasta = new DateTimePicker();
        private readonly Button btnConsultar = new Button();
        private readonly Button btnCerrar = new Button();
        private readonly Label lblResumen = new Label();
        private readonly DataGridView dgvTopVisitantes = new DataGridView();
        private readonly DataGridView dgvTopAusentes = new DataGridView();

        public FrmEstadisticas(UsuarioBasico usuario)
        {
            this.usuario = usuario;
            ConstruirInterfaz();
            Load += (sender, e) => Consultar();
        }

        private void ConstruirInterfaz()
        {
            Text = "Estadísticas";
            ClientSize = new Size(900, 640);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Controls.Add(CrearEtiqueta("Desde:", 20, 22));
            ConfigurarFecha(dtpDesde, 80, DateTime.Today.AddDays(-30));
            Controls.Add(CrearEtiqueta("Hasta:", 240, 22));
            ConfigurarFecha(dtpHasta, 300, DateTime.Today);

            btnConsultar.Text = "Consultar";
            btnConsultar.Location = new Point(470, 12);
            btnConsultar.Size = new Size(120, 34);
            btnConsultar.Click += (sender, e) => Consultar();
            Controls.Add(btnConsultar);

            lblResumen.Location = new Point(20, 60);
            lblResumen.Size = new Size(860, 95);
            lblResumen.Font = new Font("Segoe UI", 10F);
            Controls.Add(lblResumen);

            Controls.Add(CrearEtiqueta("Top 10 de más visitantes", 20, 165));
            ConfigurarTabla(dgvTopVisitantes, 20);

            Controls.Add(CrearEtiqueta("Top 10 de ausentes", 460, 165));
            ConfigurarTabla(dgvTopAusentes, 460);

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(760, 592);
            btnCerrar.Size = new Size(120, 36);
            btnCerrar.Click += (sender, e) => Close();
            Controls.Add(btnCerrar);
        }

        private static Label CrearEtiqueta(string texto, int x, int y)
        {
            return new Label
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
        }

        private void ConfigurarFecha(DateTimePicker selector, int x, DateTime valorInicial)
        {
            selector.Format = DateTimePickerFormat.Short;
            selector.Location = new Point(x, 18);
            selector.Size = new Size(150, 27);
            selector.Value = valorInicial;
            Controls.Add(selector);
        }

        private void ConfigurarTabla(DataGridView tabla, int x)
        {
            tabla.Location = new Point(x, 192);
            tabla.Size = new Size(420, 385);
            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.RowHeadersVisible = false;
            tabla.MultiSelect = false;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tabla.Columns.Add("colPosicion", "#");
            tabla.Columns.Add("colUsuario", "Usuario");
            tabla.Columns.Add("colNombre", "Nombre");
            tabla.Columns.Add("colVisitas", "Visitas");
            tabla.Columns["colPosicion"]!.FillWeight = 20;

            Controls.Add(tabla);
        }

        private void Consultar()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha inicial no puede ser posterior a la fecha final.");
                return;
            }

            try
            {
                List<UsuarioBasico> usuarios = Controllers.Usuario.ObtenerUsuarios();
                UsuarioBasico actual = usuarios.FirstOrDefault(u =>
                    string.Equals(u.NombreUsuario, usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase))
                    ?? usuario;

                MostrarResumen(actual, desde, hasta);
                LlenarTabla(dgvTopVisitantes, FiltroEstadisticas.ObtenerTopVisitantes(usuarios, desde, hasta));
                LlenarTabla(dgvTopAusentes, FiltroEstadisticas.ObtenerTopAusentes(usuarios, desde, hasta));
            }
            catch (Exception ex) when (ex is System.IO.IOException || ex is System.Text.Json.JsonException)
            {
                MessageBox.Show("No se pudieron leer los datos: " + ex.Message);
            }
        }

        private void MostrarResumen(UsuarioBasico actual, DateTime desde, DateTime hasta)
        {
            ResumenPersonal resumen = estadisticas.ObtenerResumenPersonal(actual, desde, hasta);

            lblResumen.Text =
                $"Mis estadísticas del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}\n" +
                $"Visitas en el período: {resumen.VisitasEnRango}\n" +
                $"Cambio de peso: {FormatearCambio(resumen.CambioPeso, "kg")}\n" +
                $"Cambio de cintura (objetivo): {FormatearCambio(resumen.CambioCintura, "cm")}\n" +
                $"Insignias de logro: {resumen.InsigniasLogro}  |  Insignias de la vergüenza: {resumen.InsigniasVerguenza}";
        }

        private static string FormatearCambio(double? cambio, string unidad)
        {
            if (!cambio.HasValue)
            {
                return "sin mediciones suficientes en el período";
            }

            return $"{cambio.Value:+0.00;-0.00;0.00} {unidad}";
        }

        private void LlenarTabla(DataGridView tabla, List<ResumenVisitas> filas)
        {
            tabla.Rows.Clear();

            for (int i = 0; i < filas.Count; i++)
            {
                ResumenVisitas fila = filas[i];
                int indice = tabla.Rows.Add(i + 1, fila.NombreUsuario, fila.Nombre, fila.CantidadVisitas);

                if (string.Equals(fila.NombreUsuario, usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    tabla.Rows[indice].DefaultCellStyle.BackColor = Color.LightYellow;
                    tabla.Rows[indice].DefaultCellStyle.Font = new Font(tabla.Font, FontStyle.Bold);
                }
            }
        }
    }
}
