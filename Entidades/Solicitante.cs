using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Solicitante
    {
        public string profesion { get; set; }
        [Required] public Persona personaSolicitante { get; set; }
        [Required] public Domicilio domicilio { get; set; }
        [MinLength(5), MaxLength(5)] public string codigoEstadoCivil { get; set; }
        [MinLength(5), MaxLength(5)] public string codigoRegimenEconomicoMatrimonial { get; set; }
        [MinLength(5), MaxLength(5)] public string codigoIntegracionFamilia { get; set; }
        public RepresentanteSolicitante representanteSolicitante { get; set; }
    }
}