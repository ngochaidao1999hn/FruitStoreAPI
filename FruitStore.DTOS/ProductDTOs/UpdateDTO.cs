﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.DTOS.ProductDTOs
{
    public class UpdateDTO
    {

        public int Id { get; set; }
        public string FruitName { get; set; }
        public double? Price { get; set; }
        public string Descrip { get; set; }
        public DateTime ImpDate { get; set; }
        public int? Quantity { get; set; }
        public bool? IsImported { get; set; }
        public IFormFile? Img { get; set; }
        public int? IdCate { get; set; }
        public int? IdUnit { get; set; }
        public int? IdOrigin { get; set; }
    }
}
