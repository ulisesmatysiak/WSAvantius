using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Solicitante
    {
        public string Profesion { get; set; }
        [Required] public Persona PersonaSolicitante { get; set; }
        [Required] public Domicilio Domicilio { get; set; }
        [MinLength(5), MaxLength(5)] public string CodigoEstadoCivil { get; set; }
        [MinLength(5), MaxLength(5)] public string CodigoRegimenEconomicoMatrimonial { get; set; }
        [MinLength(5), MaxLength(5)] public string CodigoIntegracionFamilia { get; set; }
        public RepresentanteSolicitante RepresentanteSolicitante { get; set; }
    }
}