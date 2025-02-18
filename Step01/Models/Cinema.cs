﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        public string? Logo { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        //5.1 Relations
        public List<Movie>? Movies { get; set; } // Bir cinemada birçok film olabilir
    }
}
