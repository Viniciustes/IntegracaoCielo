using FileHelpers;

namespace IntegracaoCielo.Dominio.Entidades
{
    /// <summary>
    /// Tipo 9 - Trailer
    /// </summary>
    [FixedLengthRecord()]
    public class ArquivoCieloTrailer
    {
        /// <summary>
        /// Tipo de registro
        /// Constante 9: Identifica o tipo de registro de detalhe trailer (final do arquivo).
        /// </summary>
        [FieldFixedLength(1)]
        public string TipoDeRegistro;

        /// <summary>
        /// Total de registro
        /// Número total de registros, os quais não incluem header e trailer.
        /// </summary>
        [FieldFixedLength(11)]
        public string TotalDeRegistro;

        /// <summary>
        /// Uso Cielo
        /// Reservado para Cielo.
        /// </summary>
        [FieldFixedLength(238)]
        public string UsoCielo;
    }
}
