﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Movie.Models.Movie;

namespace Movie.Models.Keyword
{
    [Table("MovieKeyword")]
    public class MovieKeyword
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MovieId")]
        public Movies? Movies { get; set; }

        [ForeignKey("KeywordId")]
        public Keyword? Keyword { get; set; }
    }
}
