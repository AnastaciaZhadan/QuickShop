using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSDataAccess.Clothes
{
    public interface IClothes
    {
        bool Insert(ClothesItem obj);
        ClothesItem GetClothesItemById(int id);
        bool Save();
        bool Delete(ClothesItem obj);       
    }
}
