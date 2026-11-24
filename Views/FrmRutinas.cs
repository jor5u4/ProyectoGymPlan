///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmRutinas : Form
    {
        private UsuarioBasico usuario;
        private bool esEntrenador;

        public FrmRutinas(UsuarioBasico usuario, bool esEntrenador = false)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.esEntrenador = esEntrenador;

            Load -= FrmRutinas_Load;
            Load += FrmRutinas_Load;

            btnAgregarRutina.Click -= btnAgregarRutina_Click;
            btnAgregarRutina.Click += btnAgregarRutina_Click;

            btnEditarRutina.Click -= btnEditarRutina_Click;
            btnEditarRutina.Click += btnEditarRutina_Click;

            btnEliminarRutina.Click -= btnEliminarRutina_Click;
            btnEliminarRutina.Click += btnEliminarRutina_Click;

            btnVolver.Click -= btnVolver_Click;
            btnVolver.Click += btnVolver_Click;

            dgvRutinas.CellDoubleClick -= dgvRutinas_CellDoubleClick;
            dgvRutinas.CellDoubleClick += dgvRutinas_CellDoubleClick;
        }

        private void FrmRutinas_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = esEntrenador ? "ADMINISTRAR RUTINAS" : "MIS RUTINAS";

            btnAgregarRutina.Visible = esEntrenador;
            btnEditarRutina.Visible = esEntrenador;
            btnEliminarRutina.Visible = esEntrenador;

            dgvRutinas.ReadOnly = true;
            dgvRutinas.AllowUserToAddRows = false;
            dgvRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutinas.MultiSelect = false;

            CargarRutinas();
        }

        private void CargarRutinas()
        {
            dgvRutinas.Rows.Clear();

            if (usuario.Rutinas == null)
            {
                return;
            }

            foreach (Rutina rutina in usuario.Rutinas)
            {
                int fila = dgvRutinas.Rows.Add(
                    rutina.Nombre,
                    rutina.Descripcion,
                    rutina.FechaInicio.ToShortDateString(),
                    rutina.Ejercicios.Count
                );

                dgvRutinas.Rows[fila].Tag = rutina;
            }
        }

        private Rutina? ObtenerRutinaSeleccionada()
        {
            if (dgvRutinas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una rutina.");
                return null;
            }

            return dgvRutinas.SelectedRows[0].Tag as Rutina;
        }

        private int ObtenerIndiceRutina(Rutina rutina)
        {
            if (usuario.Rutinas == null)
            {
                return -1;
            }

            return usuario.Rutinas.IndexOf(rutina);
        }

        private static List<UsuarioBasico> LeerUsuarios()
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "usuarios.json");

            if (!File.Exists(ruta))
            {
                throw new FileNotFoundException("No se encontró el archivo de usuarios.");
            }

            string json = File.ReadAllText(ruta);

            return JsonSerializer.Deserialize<List<UsuarioBasico>>(json)
                ?? new List<UsuarioBasico>();
        }

        private void GuardarUsuarios(List<UsuarioBasico> usuarios)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "usuarios.json");

            string nuevoJson = JsonSerializer.Serialize(
                usuarios,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(ruta, nuevoJson);
        }

        private UsuarioBasico? BuscarUsuarioGuardado(List<UsuarioBasico> usuarios)
        {
            return usuarios.FirstOrDefault(
                u => u.NombreUsuario == usuario.NombreUsuario
            );
        }

        private void btnAgregarRutina_Click(object sender, EventArgs e)
        {
            if (!esEntrenador)
            {
                MessageBox.Show("Solo el entrenador puede agregar rutinas.");
                return;
            }

            FrmAgregarRutina formulario = new FrmAgregarRutina();

            if (formulario.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                List<UsuarioBasico> usuarios = LeerUsuarios();
                UsuarioBasico? usuarioGuardado = BuscarUsuarioGuardado(usuarios);

                if (usuarioGuardado == null)
                {
                    MessageBox.Show("No se encontró el usuario.");
                    return;
                }

                if (usuarioGuardado.Rutinas == null)
                {
                    usuarioGuardado.Rutinas = new List<Rutina>();
                }

                Rutina nuevaRutina = new Rutina(
                    formulario.NombreRutina,
                    formulario.DescripcionRutina,
                    formulario.FechaInicioRutina,
                    formulario.FechaVencimientoRutina

                );
                nuevaRutina.Ejercicios = new List<Ejercicio>(formulario.EjerciciosRutina);
                usuarioGuardado.Rutinas.Add(nuevaRutina);

                GuardarUsuarios(usuarios);

                usuario = usuarioGuardado;
                CargarRutinas();

                MessageBox.Show("Rutina agregada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la rutina: " + ex.Message);
            }
        }

        private void btnEditarRutina_Click(object sender, EventArgs e)
        {
            if (!esEntrenador)
            {
                MessageBox.Show("Solo el entrenador puede editar rutinas.");
                return;
            }

            Rutina? rutinaSeleccionada = ObtenerRutinaSeleccionada();

            if (rutinaSeleccionada == null)
            {
                return;
            }

            int indice = ObtenerIndiceRutina(rutinaSeleccionada);

            if (indice < 0)
            {
                MessageBox.Show("No se pudo identificar la rutina seleccionada.");
                return;
            }

            FrmAgregarRutina formulario = new FrmAgregarRutina(rutinaSeleccionada);

            if (formulario.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                List<UsuarioBasico> usuarios = LeerUsuarios();
                UsuarioBasico? usuarioGuardado = BuscarUsuarioGuardado(usuarios);

                if (usuarioGuardado == null || usuarioGuardado.Rutinas == null)
                {
                    MessageBox.Show("No se encontró el usuario o sus rutinas.");
                    return;
                }

                if (indice >= usuarioGuardado.Rutinas.Count)
                {
                    MessageBox.Show("No se encontró la rutina que desea editar.");
                    return;
                }

                Rutina rutinaGuardada = usuarioGuardado.Rutinas[indice];

                rutinaGuardada.Nombre = formulario.NombreRutina;
                rutinaGuardada.Descripcion = formulario.DescripcionRutina;
                rutinaGuardada.FechaInicio = formulario.FechaInicioRutina;
                rutinaGuardada.FechaVencimiento = formulario.FechaVencimientoRutina;
                rutinaGuardada.Ejercicios = new List<Ejercicio>(formulario.EjerciciosRutina);
                GuardarUsuarios(usuarios);

                usuario = usuarioGuardado;
                CargarRutinas();

                MessageBox.Show("Rutina actualizada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo editar la rutina: " + ex.Message);
            }
        }

        private void btnEliminarRutina_Click(object sender, EventArgs e)
        {
            if (!esEntrenador)
            {
                MessageBox.Show("Solo el entrenador puede eliminar rutinas.");
                return;
            }

            Rutina? rutinaSeleccionada = ObtenerRutinaSeleccionada();

            if (rutinaSeleccionada == null)
            {
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar la rutina {rutinaSeleccionada.Nombre}?",
                "Eliminar rutina",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            int indice = ObtenerIndiceRutina(rutinaSeleccionada);

            if (indice < 0)
            {
                MessageBox.Show("No se pudo identificar la rutina seleccionada.");
                return;
            }

            try
            {
                List<UsuarioBasico> usuarios = LeerUsuarios();
                UsuarioBasico? usuarioGuardado = BuscarUsuarioGuardado(usuarios);

                if (usuarioGuardado == null || usuarioGuardado.Rutinas == null)
                {
                    MessageBox.Show("No se encontró el usuario o sus rutinas.");
                    return;
                }

                if (indice >= usuarioGuardado.Rutinas.Count)
                {
                    MessageBox.Show("No se encontró la rutina que desea eliminar.");
                    return;
                }

                usuarioGuardado.Rutinas.RemoveAt(indice);

                GuardarUsuarios(usuarios);

                usuario = usuarioGuardado;
                CargarRutinas();

                MessageBox.Show("Rutina eliminada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la rutina: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvRutinas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvRutinas.Rows[e.RowIndex].Tag is Rutina rutina)
            {
                if (rutina.Ejercicios.Count == 0)
                {
                    MessageBox.Show("Esta rutina aún no tiene ejercicios.", rutina.Nombre);
                    return;
                }

                string ejerciciosTexto = string.Join(
                    Environment.NewLine,
                    rutina.Ejercicios.Select(ej =>
                    {
                        string linea = $"• {ej.Nombre}: {ej.Series}x{ej.Repeticiones}";
                        if (ej.Peso > 0) linea += $" | {ej.Peso} kg";
                        if (ej.DuracionMinutos > 0) linea += $" | {ej.DuracionMinutos} min";
                        return linea;
                    })
                );

                string mensaje =
                    $"Descripción: {rutina.Descripcion}\n" +
                    $"Vigencia: {rutina.FechaInicio.ToShortDateString()} - {rutina.FechaVencimiento.ToShortDateString()}\n\n" +
                    $"Ejercicios:\n{ejerciciosTexto}";

                MessageBox.Show(mensaje, $"Rutina: {rutina.Nombre}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}