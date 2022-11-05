using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class HCE_EpisodioAtencion
    {
        public string Accion { get; set; }
        public Nullable<int> IdPaciente { get; set; }
        public Nullable<int> IdOrdenAtencion { get; set; }
        public Nullable<int> LineaOrdenAtencion { get; set; }
        public Nullable<int> TipoOrdenAtencion { get; set; }
        public string CodigoOA { get; set; }


    //exec [dbo].[SP_VW_ATENCIONPACIENTE_LISTAR] @UnidadReplicacion=NULL,@IdEpisodioAtencion=NULL,@UnidadReplicacionEC=NULL,@IdPaciente=140793,
    //@EpisodioClinico=NULL,@IdEstablecimientoSalud=NULL,@IdUnidadServicio=NULL,@IdPersonalSalud=NULL,@aaaaAtencion=NULL,@EpisodioAtencion=NULL,
    //@FechaRegistro=NULL,@FechaAtencion=NULL,@TipoAtencion=NULL,@IdOrdenAtencion=6294493,@LineaOrdenAtencion=1,@TipoOrdenAtencion=1,@Estado=NULL,
    //@UsuarioModificacion=NULL,@FechaModificacion=NULL,@IdEspecialidad=NULL,@CodigoOA='0003036832',@FechaOrden=NULL,@IdProcedimiento=NULL,
    //@IdTipoOrden=NULL,@FechaRegistroEpiClinico=NULL,@FechaCierreEpiClinico=NULL,@TipoPaciente=NULL,@Edad=NULL,@CodigoHC=NULL,@CodigoHCAnterior=NULL,
    //@CodigoHCSecundario=NULL,@TipoHistoria=NULL,@EstadoPaciente=NULL,@NumeroFile=0,@IDPACIENTE_OK=NULL,@Persona=0,@NombreCompleto=NULL,
    //@TipoDocumento=NULL,@Documento=NULL,@EsCliente=NULL,@EsProveedor=NULL,@EsEmpleado=NULL,@EsOtro=NULL,@TipoPersona=NULL,@FechaNacimiento=NULL,
    //@Sexo=NULL,@Nacionalidad=NULL,@EstadoCivil=NULL,@NivelInstruccion=NULL,@CodigoPostal=NULL,@Provincia=NULL,@Departamento=NULL,
    //@FecIniDiscamec=NULL,@FecFinDiscamec=NULL,@Pais=NULL,@EsPaciente=NULL,@EsEmpresa=NULL,@personanew=NULL,@EstadoPersona=NULL,@Servicio=NULL,
    //@INICIO=0,@NUMEROFILAS=0,@Version=NULL,@ACCION='LISTAR'

    }
}