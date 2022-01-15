using FruitStore.DAL.Models;
using FruitStore.DTOS.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Interfaces
{
    public interface IProductBusiness:IRepository<Fruit>
    {
        
    }
}
