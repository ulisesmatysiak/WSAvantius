using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class DocumentoAnexo
    {
        [Required][MinLength(1)] public string LocalizadorArchivo { get; set; }
        [Required][MinLength(1)] public string Titulo { get; set; }
        [Required] public bool Principal { get; set; }
        [Required][MinLength(1)] public string CodigoCategoriaDocumento { get; set; }
        public string Descripcion { get; set; }
    }
}