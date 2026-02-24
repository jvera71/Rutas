namespace RutasAppBackend.Enums
{
    /// <summary>
    /// Define los métodos de activación de una alerta de pánico.
    /// </summary>
    public enum TriggerMethod
    {
        /// <summary>
        /// Pulsación directa del botón de pánico en pantalla.
        /// </summary>
        ManualButton,

        /// <summary>
        /// Activación por soltar el "interruptor de hombre muerto".
        /// </summary>
        DeadMansSwitch,

        /// <summary>
        /// Activación mediante combinación de botones físicos del dispositivo.
        /// </summary>
        HardwareButtons,

        /// <summary>
        /// Activación por sacudida violenta del dispositivo.
        /// </summary>
        Shake,

        /// <summary>
        /// Activación automática por desviación de ruta o parada inusual.
        /// </summary>
        AutomaticDeviation
    }
}
