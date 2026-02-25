using System;
using System.Collections.Generic;
using System.Text;

namespace RutasAppBackend.Enums
{
    /// <summary>
    /// Define los tipos de acciones que un usuario ciudadano o una entidad oficial puede realizar sobre un registro.
    /// </summary>
    public enum CitizenUserActionType
    {
        /// <summary>
        /// El registro del usuario ha sido creado.
        /// </summary>
        Created,

        /// <summary>
        /// El perfil del usuario ha sido visualizado por una entidad oficial.
        /// </summary>
        ProfileViewed,

        /// <summary>
        /// Se ha utilizado el Code para activar una instacia de la app.
        /// </summary>
        CodeActivated,

        /// <summary>
        /// Se ha producido un intento de   activar una instacia de la app con un codigo ya utilizado.
        /// </summary>
        CodeAlreadyInUse,


    }
}
