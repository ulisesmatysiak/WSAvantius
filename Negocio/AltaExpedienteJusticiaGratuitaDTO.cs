﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WS_Avantius.Datos;
using WS_Avantius.Entidades;
using WS_Avantius.Negocio.Service.Implementaciones;
using WS_Avantius.Negocio.Utils.Mappers;

namespace WS_Avantius.Negocio
{
    public class AltaExpedienteJusticiaGratuitaDTO
    {
        public static Response srvAltaExpedienteJusticiaGratuita(DateTime fecha, int idExpediente)
        {
            AltaExpedienteJusticiaGratuita data = obtenerAltaExpedienteJusticiaGratuita(fecha, idExpediente);
            var body = mapearAltaExpedienteJusticaGratuita(data);

            Response response = new Response();

            using (var httpClient = new HttpClient())
            {
                AltaExpedienteJusticiaGratuitaService srv = new AltaExpedienteJusticiaGratuitaService(httpClient);
                response = srv.apiSolicitudJusticiaGratuitaPost(body);
            }

            return response;
        }

        #region Armo los json mapeo
        private static string mapearAltaExpedienteJusticaGratuita(AltaExpedienteJusticiaGratuita data)
        {
            return AltaExpedienteJusticiaGratuitaMapper.MapearAltaExpedienteJusticiaGrauita(data);
        }
        #endregion

        #region Obtengo los objetos
        public static AltaExpedienteJusticiaGratuita obtenerAltaExpedienteJusticiaGratuita(DateTime fecha, int idExpediente)
        {
            AltaExpedienteJusticiaGratuita altaExpedienteJusticiaGratuita = new AltaExpedienteJusticiaGratuita
            {
                //entidadPresenta = "A01059",
                solicitud = obtenerSolicitud(fecha, idExpediente)
            };
            return altaExpedienteJusticiaGratuita;
        }

        private static Solicitud obtenerSolicitud(DateTime fecha, int idExpediente)
        {
            AltaExpedienteJusticiaGratuitaDAO dao = new AltaExpedienteJusticiaGratuitaDAO();
            return dao.obtenerSolicitud(fecha, idExpediente);
        }
        #endregion
    }
}