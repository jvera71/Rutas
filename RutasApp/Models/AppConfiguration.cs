using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasApp.Models
{
    /// <summary>
    /// Tipos de interfaz disponibles para el Camouflage Mode.
    /// </summary>
    public enum CamouflageInterfaceType
    {
        MusicPlayer,
        Maps,
        SocialMedia,
        Browser,
        Calculator,
        BlankScreen
    }

    /// <summary>
    /// Preferencias del usuario para la prevención activa y pasiva en la aplicación.
    /// </summary>
    [Table("AppConfigurations")]
    public class AppConfiguration
    {
        /// <summary>
        /// Identificador único de la configuración.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Interfaz elegida para el Camouflage Mode (Modo Incógnito).
        /// </summary>
        public CamouflageInterfaceType CamouflageInterface { get; set; } = CamouflageInterfaceType.MusicPlayer;

        /// <summary>
        /// Activación del disparador por hardware: agitar el teléfono.
        /// </summary>
        public bool EnableShakeTrigger { get; set; } = false;

        /// <summary>
        /// Activación del disparador por hardware: presionar el botón de encendido.
        /// </summary>
        public bool EnablePowerButtonTrigger { get; set; } = false;
    }
}
