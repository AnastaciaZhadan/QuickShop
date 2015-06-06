using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSDataAccess.Shoes
{
    public class Shoes:IShoes
    {
        private QuickShoppingDBEntities dataBase;
        public Shoes()
        {
            dataBase = new QuickShoppingDBEntities();
        }
        public bool Insert(ShoesItem shoesItem)
        {
            try
            {
                dataBase.ShoesItems.Add(shoesItem);
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
        public ShoesItem GetShoesItemById(int id)
        {
            return dataBase.ShoesItems.Find(id);
        }
        public bool Delete(ShoesItem shoesItem)
        {
            try
            {
                dataBase.ShoesItems.Remove(shoesItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
