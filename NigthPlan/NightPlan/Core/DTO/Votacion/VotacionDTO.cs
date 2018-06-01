using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class VotacionDTO
    {
        [Required]
        public int? IdGrupo { get; set; }
        [Required]
        public int? IdEstablecimiento { get; set; }
        public DateTime? FechaDeRespuesta { get; set; }
    }
}