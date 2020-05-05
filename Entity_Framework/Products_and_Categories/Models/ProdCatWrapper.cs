using System;
using System.Collections.Generic;

namespace Products_and_Categories.Models
{
    public class ProdCatWrapper
    {
        public Product Product {get;set;}
        public List<Product> Products {get;set;}
        public Association Association {get;set;}
        public Category Category {get;set;}
        public List<Category> Categories {get;set;}

    }
}