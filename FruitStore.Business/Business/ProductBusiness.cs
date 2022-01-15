using FruitStore.Business.Interfaces;
using FruitStore.DAL.EF;
using FruitStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.Business.Business
{
    public class ProductBusiness:Repository<Fruit>,IProductBusiness
    {
        public ProductBusiness(fruitstoreContext context) : base(context) 
        {

        }
    }
}
