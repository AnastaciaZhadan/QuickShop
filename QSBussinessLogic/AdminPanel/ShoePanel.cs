using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSDataAccess;
using QSDataAccess.Shoes;
using Models;

namespace QSBussinessLogic.AdminPanel
{
    public class ShoePanel
    {
        IRepository<ShoesItem> shoeDataAccess;
        public bool AddShoe(string shoeData)
        {
            ShoesItem shoe = FormShoeItem(shoeData);
            try
            {
                shoeDataAccess.Insert(shoe);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                shoeDataAccess.Save();
            }
            return true;
        }
        private ShoesItem FormShoeItem(string shoeData)
        {
            IEnumerable<string> shoeDataCollection = Helpers.SplitData(shoeData, ';');
            string[] shoeDataArray = shoeDataCollection.ToArray<string>();

            ShoeIMG shoeImage = new ShoeIMG();
            shoeImage.ShoePhoto = Helpers.GetBytes(shoeDataArray[3]);

            ShoesItem shoe = new ShoesItem();
            shoe.ShoeName = shoeDataArray[0];
            shoe.ShoeKind = shoeDataArray[1];
            shoe.EuroShoeSize = Convert.ToInt32(shoeDataArray[2]);
            shoe.ShoeIMGs = new ShoeIMG[] { shoeImage };

            return shoe;
        }
        public bool DeleteShoe(int id)
        {
            ShoesItem shoeItem = shoeDataAccess.GetById(id);
            try
            {
                shoeDataAccess.Delete(shoeItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting item.");
            }
            finally
            {
                shoeDataAccess.Save();
            }
            return true;
        }
        public string EditShoe(string shoeData, int id)
        {
            ShoesItem shoe = FormShoeItem(shoeData);
            ShoesItem shoeItemEdit = shoeDataAccess.GetById(id);
            shoeItemEdit.ShoeName = shoe.ShoeName;
            shoeItemEdit.ShoeKind = shoe.ShoeKind;
            shoeItemEdit.EuroShoeSize = shoe.EuroShoeSize;
            shoeItemEdit.ShoeIMGs = shoe.ShoeIMGs;

            string result = "";
            try
            {
                shoeDataAccess.Save();
                result = shoeItemEdit.ShoeName + ";" + shoeItemEdit.ShoeKind + ";" + shoeItemEdit.EuroShoeSize + ";";

            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
