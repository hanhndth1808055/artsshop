﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public int Parent { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        public int Active { get; set; } = 1;
    }
}