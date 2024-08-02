namespace Web_API.Transfer
{

    public class RecargaResponseDTO
    {
        public int? IdRecarga { get; set; }
        public int? IdContacto { get; set; }
        public int? IdUsuario { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? FechaHora { get; set; }
    }
}
