namespace EjercicioConexionbdCRUD.entidades
{
    /// <summary>
    /// Clase que representa un libro (Data Transfer Object).
    /// </summary>
    public class LibroDto
    {
        // Atributos
        private long idLibro; // Identificador del libro
        private string titulo; // Título del libro
        private string autor; // Autor del libro
        private string isbn; // Número de ISBN del libro
        private int edicion; // Número de edición del libro

        // Constructores

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="idLibro">Identificador del libro.</param>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="isbn">Número de ISBN del libro.</param>
        /// <param name="edicion">Número de edición del libro.</param>
        public LibroDto(long idLibro, string titulo, string autor, string isbn, int edicion)
        {
            this.idLibro = idLibro;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.edicion = edicion;
        }

        /// <summary>
        /// Constructor sin parámetros.
        /// </summary>
        public LibroDto()
        {
        }

        // Propiedades (Getters y Setters)

        /// <summary>
        /// Obtiene o establece el identificador del libro.
        /// </summary>
        public long IdLibro
        {
            get { return idLibro; }
            set { idLibro = value; }
        }

        /// <summary>
        /// Obtiene o establece el título del libro.
        /// </summary>
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        /// <summary>
        /// Obtiene o establece el autor del libro.
        /// </summary>
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        /// <summary>
        /// Obtiene o establece el número de ISBN del libro.
        /// </summary>
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        /// <summary>
        /// Obtiene o establece el número de edición del libro.
        /// </summary>
        public int Edicion
        {
            get { return edicion; }
            set { edicion = value; }
        }

        // ToString

        /// <summary>
        /// Convierte el objeto LibroDto a una representación en cadena de caracteres.
        /// </summary>
        /// <returns>Cadena que representa el objeto LibroDto.</returns>
        public override string ToString()
        {
            return "LibroDto [IdLibro=" + idLibro + ", Titulo=" + titulo + ", Autor=" + autor + ", ISBN=" + isbn + ", Edicion=" + edicion + "]";
        }

        /// <summary>
        /// Obtiene una representación básica del objeto LibroDto para consultas simples.
        /// </summary>
        /// <returns>Cadena que representa el objeto LibroDto para consultas básicas.</returns>
        public string QueryBase()
        {
            return "LibroDto [IdLibro=" + idLibro + ", Titulo=" + titulo + "]";
        }
    }
}