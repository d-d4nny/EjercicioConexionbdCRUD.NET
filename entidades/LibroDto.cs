using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioConexionbdCRUD.entidades
{
    public class LibroDto
    {
        // Atributos
        private long idLibro;
        private string titulo;
        private string autor;
        private string isbn;
        private int edicion;

        // Constructores
        public LibroDto(long idLibro, string titulo, string autor, string isbn, int edicion)
        {
            this.idLibro = idLibro;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.edicion = edicion;
        }

        public LibroDto()
        {
        }

        // Propiedades (Getters y Setters)
        public long IdLibro
        {
            get { return idLibro; }
            set { idLibro = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public int Edicion
        {
            get { return edicion; }
            set { edicion = value; }
        }

        // ToString
        public override string ToString()
        {
            return "LibroDto [IdLibro=" + idLibro + ", Titulo=" + titulo + ", Autor=" + autor + ", ISBN=" + isbn + ", Edicion=" + edicion + "]";
        }

        public string QueryBase()
        {
            return "LibroDto [IdLibro=" + idLibro + ", Titulo=" + titulo + "]";
        }
    }
}
