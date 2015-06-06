using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSDataAccess.UserCards
{
    public interface IUserCards
    {
        bool Insert(UserSizeCard userCardItem);
        UserSizeCard GetUserSizeCardById(int id);
        bool Save();
        bool Delete(UserSizeCard userCardItem);
    }
}
