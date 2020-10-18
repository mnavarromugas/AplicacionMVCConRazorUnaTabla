namespace AplicacionMVCconRazor.Models
{
    public class Persona
    {
        private int id;
        private string nombre;
        private string apellido;

        public Persona(int id, string nombre, string apellido)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public Persona()
        {
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public override string ToString()
        {
            return $"{apellido}, {nombre}";
        }
    }
}