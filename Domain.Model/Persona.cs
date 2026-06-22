namespace Domain.Model
{
    public abstract class Persona
    {
        public string Dni { get; set; }
        public string TipoDni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public Persona(string dni, string tipoDni, string nombre, string apellido, string telefono)
        {
            SetDni(dni);
            SetTipoDni(tipoDni);
            SetNombre(nombre);
            SetApellido(apellido);
            SetTelefono(telefono);
        }

        public void SetDni(string dni)
        {
            
        }
        public void SetTipoDni(string tipoDni)
        {

        }
        public void SetNombre(string nombre)
        {

        }
        public void SetApellido(string apellido)
        {

        }

        public void SetTelefono(string telefono)
        {
            
        }
    }
}
