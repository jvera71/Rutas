namespace RutasAppBackend.Enums
{
    /// <summary>
    /// Define los tipos de incidencias urbanas que pueden ser reportadas.
    /// </summary>
    public enum IssueType
    {
        /// <summary>
        /// Iluminación insuficiente en la vía pública.
        /// </summary>
        PoorLighting,

        /// <summary>
        /// Presencia de personas o grupos que generan inseguridad.
        /// </summary>
        IntimidatingPresence,

        /// <summary>
        /// Mobiliario urbano dañado u obstáculos peligrosos.
        /// </summary>
        InfrastructureDamage,

        /// <summary>
        /// Otros problemas no categorizados.
        /// </summary>
        Other
    }
}
