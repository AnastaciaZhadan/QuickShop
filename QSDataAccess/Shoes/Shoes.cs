using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace QSDataAccess.Shoes
{
    public class Shoes:IRepository<ShoesItem>
    {
        private ShoppingDBEntities dataBase;
        public Shoes()
        {
            dataBase = new ShoppingDBEntities();
        }
        public bool Insert(ShoesItem item)
        {
            try
            {
                dataBase.ShoesItems.Add(item);
                return true;
            }
            catch(Exception ex)
            { 
                return false; 
            }
        }
        public bool Save()
        {
            try
            {
                dataBase.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public ShoesItem GetById(int id)
        {
            return dataBase.ShoesItems.Find(id);
        }
        public bool Delete(ShoesItem item)
        {
            try
            {
                dataBase.ShoesItems.Remove(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
