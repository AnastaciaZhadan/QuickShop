using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace QSDataAccess.Clothes
{
    public class Clothes : IRepository<ClothesItem>
    {
        private ShoppingDBEntities dataBase;
        public Clothes()
        {
            dataBase = new ShoppingDBEntities();
        }
        public bool Insert(ClothesItem item)
        {
            try
            {
                dataBase.ClothesItems.Add(item);
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
        public ClothesItem GetById(int id)
        {
            return dataBase.ClothesItems.Find(id);
        }
        public bool Delete(ClothesItem item)
        {
            try
            {
                dataBase.ClothesItems.Remove(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
