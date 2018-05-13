﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise2.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Ingredients { get; set; }
    }
}