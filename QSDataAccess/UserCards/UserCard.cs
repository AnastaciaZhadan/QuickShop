using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace QSDataAccess.UserCards
{
    public class UserCard : IRepository<UserSizeCard>
    {
        private UserDBEntities dataBase;
        public UserCard()
        {
            dataBase = new UserDBEntities();
        }
        public bool Insert(UserSizeCard item)
        {
            try
            {
                dataBase.UserSizeCards.Add(item);
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
        public UserSizeCard GetById(int id)
        {
            return dataBase.UserSizeCards.Find(id);
        }
        public bool Delete(UserSizeCard item)
        {
            try
            {
                dataBase.UserSizeCards.Remove(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
