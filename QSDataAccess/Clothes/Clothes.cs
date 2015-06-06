using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSDataAccess.Clothes;

namespace QSDataAccess.Clothes
{
    public class Clothes : IClothes
    {
        private QuickShoppingDBEntities dataBase;
        public Clothes()
        {
            dataBase = new QuickShoppingDBEntities();
        }
        public bool Insert(ClothesItem clothesItem)
        {
            try
            {
                dataBase.ClothesItems.Add(clothesItem);
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
        public ClothesItem GetClothesItemById(int id)
        {
            return dataBase.ClothesItems.Find(id);
        }
        public bool Delete(ClothesItem clothesItem)
        {
            try
            {
                dataBase.ClothesItems.Remove(clothesItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
