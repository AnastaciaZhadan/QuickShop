using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSDataAccess.UserCards
{
    public class UserCard:IUserCards
    {
        private QuickShoppingDBEntities dataBase;
        public UserCard()
        {
            dataBase = new QuickShoppingDBEntities();
        }
        public bool Insert(UserSizeCard userCardItem)
        {
            try
            {
                dataBase.UserSizeCards.Add(userCardItem);
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
        public UserSizeCard GetUserSizeCardById(int id)
        {
            return dataBase.UserSizeCards.Find(id);
        }
        public bool Delete(UserSizeCard userCardItem)
        {
            try
            {
                dataBase.UserSizeCards.Remove(userCardItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
