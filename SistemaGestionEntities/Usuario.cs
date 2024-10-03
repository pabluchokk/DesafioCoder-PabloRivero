namespace SistemaGestionEntities
{
    public class Usuario
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        private string _contraseña;
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public string Mail { get; set; }
    }
}
