using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSDataAccess;
using QSDataAccess.UserCards;
using Models;

namespace QSBussinessLogic.UserCardPanel
{
    class UserCardPanel
    {
        IRepository<UserSizeCard> userCardDataAccess;
        public UserCardPanel()
        {
            userCardDataAccess = new UserCard();
        }
        public bool CreateCard(string userCardData)
        {
            UserSizeCard userCard = FormUserCard(userCardData);
            try
            {
                userCardDataAccess.Insert(userCard);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                userCardDataAccess.Save();
            }
            return true;
        }
        private UserSizeCard FormUserCard(string userCardData)
        {
            IEnumerable<string> userCardDataCollection = Helpers.SplitData(userCardData, ';');
            string[] clothesDataArray = userCardDataCollection.ToArray<string>();

            UserSizeCard userCard = new UserSizeCard();
            userCard.UserId = clothesDataArray[0];
            userCard.Height = Convert.ToInt32(clothesDataArray[1]);
            userCard.InterClothSize = clothesDataArray[2];
            userCard.EuroShoeSize = Convert.ToInt32(clothesDataArray[3]);
            userCard.Width = Convert.ToInt32(clothesDataArray[4]);

            return userCard;
        }
        public bool DeleteShoe(int id)
        {
            UserSizeCard userCard = userCardDataAccess.GetById(id);
            try
            {
                userCardDataAccess.Delete(userCard);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting item.");
            }
            finally
            {
                userCardDataAccess.Save();
            }
            return true;
        }
        public string EditShoe(string userCardData, int id)
        {
            UserSizeCard userCard = FormUserCard(userCardData);
            UserSizeCard userCardEdit = userCardDataAccess.GetById(id);
            userCardEdit.UserId = userCard.UserId;
            userCardEdit.Height = userCard.Height;
            userCardEdit.InterClothSize = userCard.InterClothSize;
            userCardEdit.EuroShoeSize = userCard.EuroShoeSize;
            userCardEdit.Width = userCard.Width;

            string result = "";
            try
            {
                userCardDataAccess.Save();
                result = userCardEdit.UserId + ";" + userCardEdit.Height +";" + userCardEdit.InterClothSize + ";" + userCardEdit.EuroShoeSize+
                    ";" + userCardEdit.Width;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
