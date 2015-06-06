using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSDataAccess;
using QSDataAccess.Clothes;

namespace QSBussinessLogic.AdminPanel
{
    class ClothesPanel
    {
        IClothes clothesDataAcess;
        public bool AddShoe(string shoeData)
        {
            ClothesItem shoe = FormClothesItem(shoeData);
            try
            {
                clothesDataAcess.Insert(shoe);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                clothesDataAcess.Save();
            }
            return true;
        }
        private ClothesItem FormClothesItem(string clothesData)
        {
            IEnumerable<string> clothesDataCollection = Helpers.SplitData(clothesData, ';');
            string[] clothesDataArray = clothesDataCollection.ToArray<string>();

            ClothesIMG clothesImage = new ClothesIMG();
            clothesImage.ClothesPhoto = Helpers.GetBytes(clothesDataArray[4]);

            ClothesItem clothes = new ClothesItem();
            clothes.ClothesName = clothesDataArray[0];
            clothes.ClothesKind = clothesDataArray[1];
            clothes.InterClothSize = clothesDataArray[2];
            clothes.ClothesIMGs = new ClothesIMG[] { clothesImage };
            clothes.ModelHeight = Convert.ToInt32(clothesDataArray[3]);

            return clothes;
        }
        public bool DeleteShoe(int id)
        {
            ClothesItem clothesItem = clothesDataAcess.GetClothesItemById(id);
            try
            {
                clothesDataAcess.Delete(clothesItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting item.");
            }
            finally
            {
                clothesDataAcess.Save();
            }
            return true;
        }
        public string EditShoe(string clothesData, int id)
        {
            ClothesItem clothes = FormClothesItem(clothesData);
            ClothesItem clothesItemEdit = clothesDataAcess.GetClothesItemById(id);
            clothesItemEdit.ClothesName = clothes.ClothesName;
            clothesItemEdit.ClothesKind = clothes.ClothesKind;
            clothesItemEdit.InterClothSize = clothes.InterClothSize;
            clothesItemEdit.ClothesIMGs = clothes.ClothesIMGs;
            clothesItemEdit.ModelHeight = clothes.ModelHeight;

            string result = "";
            try
            {
                clothesDataAcess.Save();
                result = clothesItemEdit.ClothesName + ";" + clothesItemEdit.ClothesKind + ";" + clothesItemEdit.InterClothSize + ";";
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
