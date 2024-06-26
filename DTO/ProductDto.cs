﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

    }
}
