using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products_and_Categories
{
    public class Association
    {
        [Key]
        public int AssociationId {get;set;}
        // Lines 14 - 15 is creating the 

        public int ProductId {get;set;}
        public int CategoryId {get;set;}

        // Code below is the Navigation Property
        public Product Product {get;set;}
        public Category Category {get;set;}
    }
}