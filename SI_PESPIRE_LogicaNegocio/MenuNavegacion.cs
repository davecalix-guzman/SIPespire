namespace SI_PESPIRE_LogicaNegocio
{
    public class MenuNavegacion
    {
        public int ModuloAccionId { get; set; }

        public int ModuloId { get; set; }

        public string ModuloAccionNombre { get; set; }

        public int ModuloPadre { get; set; }

        public bool EsMenu { get; set; }

        public string Enlace { get; set; }
    }
}