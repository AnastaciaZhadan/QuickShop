using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSDataAccess.Shoes
{
    public interface IShoes
    {
        bool Insert(ShoesItem obj);
        ShoesItem GetShoesItemById(int id);
        bool Save();
        bool Delete(ShoesItem shoesItem);
    }
}
