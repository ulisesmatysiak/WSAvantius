using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class DocumentoAnexo
    {
        [Required][MinLength(1)] public string localizadorArchivo { get; set; }
        [Required][MinLength(1)] public string titulo { get; set; }
        [Required] public bool principal { get; set; }
        [Required][MinLength(1)] public string codigoCategoriaDocumento { get; set; }
        public string descripcion { get; set; }
    }
}