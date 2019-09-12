using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manual_ASP_NET_WEB.ViewModels
{
    public class InformacionGeneralViewModel
    {
        //Cantidad de pacientes
        public int CantidadPacientes { get; set; }
        //Cantidad de médicos
        public int CantidadMedicos { get; set; }
        //Cantidad de consultas
        public int CantidadConsultas { get; set; }
        //Cantidad de pacientes con peso mayor a 60
        public int CantidadPacientesSobrePeso { get; set; }

    }
}