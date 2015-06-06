using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSBussinessLogic.AdminPanel;
using QSDataAccess;
using QSDataAccess.Shoes;
using QSDataAccess.Clothes;

namespace QSBussinessLogic.AdminPanel
{
    class AdminPanel
    {
        ClothesPanel clothesPanel;
        ShoePanel shoePanel;
        public AdminPanel()
        {
            clothesPanel = new ClothesPanel();
            shoePanel = new ShoePanel();
        }
        
    }
}
