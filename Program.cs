using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CatalogoPlantasWeb
{
    public partial class Plantas : System.Web.UI
    {
        private object plantas = null;

        private object GetPlantas1()
        {
            return plantas;
        }

        private void SetPlantas1(object value)
        {
            plantas = value;
        }

        public static object ConfigurationManager { get; private set; }
        public string Conexion { get; set; } = (string)ConfigurationManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool IsPostBack = false;
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarPlantas(GetPlantas());
            }
        }

        private void CargarCategorias()
        {
            throw new NotImplementedException();
        }

        void CargarCategorias(object ddlCategorias)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, NombreCategoria FROM Categorias", con);
                con.Open();
                ddlCategorias = cmd.ExecuteReader();
                ddlCategorias = "NombreCategoria";
                ddlCategorias = "Id";
                ddlCategorias = ddlCategorias;
            }
        }

        private object GetPlantas()
        {
            return GetPlantas1();
        }

        void CargarPlantas(object DataBindPlantas)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPlantas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SetPlantas1(dt);
                object dataBindResult = DataBindPlantas;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e, object txtPrecio, object txtNombre, object txtDescripcion, object ddlCategorias)
        {
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertPlanta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombrePlanta", txtNombre);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion);
                cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio));
                cmd.Parameters.AddWithValue("@CategoriaId", ddlCategorias);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            CargarPlantas(GetPlantas());
        }

        protected void btnActualizar_Click(object sender, EventArgs e, object txtPrecio, object txtDescripcion, object txtNombre, object ddlCategorias)
        {
            if (GetPlantas1() == null) return;

            using (SqlConnection con = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdatePlanta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = cmd.Parameters.AddWithValue("@Id", GetPlantas1());
                cmd.Parameters.AddWithValue("@NombrePlanta", txtNombre);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion);
                cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtPrecio));
                SqlParameter paramCategoriaId = cmd .Parameters.AddWithValue("@CategoriaId", ddlCategorias);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            CargarPlantas(GetPlantas());
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GetPlantas1() == null) return;

            using (SqlConnection con = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_DeletePlanta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", GetPlantas1());

                con.Open();
                cmd.ExecuteNonQuery();
            }
            CargarPlantas(GetPlantas());
        }

        protected void gvPlantas_SelectedIndexChanged(object sender, EventArgs e, object gvPlantas, object ddlCategorias, object txtDescripcion, object txtPrecio, object txtNombre)
        {
            GridViewRow row = (GridViewRow)gvPlantas;
            txtNombre = row;
            txtDescripcion = row;
            txtPrecio = row; object precioTexto = Replace("$", "");
            ddlCategorias = ddlCategorias; IndexOf(ddlCategoriasFindByText(row));
        }

        private object Replace(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private object ddlCategoriasFindByText(object text)
        {
            throw new NotImplementedException();
        }

        private void IndexOf(object value)
        {
            throw new NotImplementedException();
        }
    }
}
