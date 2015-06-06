using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoQrUtilities;
using System.Drawing;
using System.IO;

namespace QSBussinessLogic
{
    class QRHelper
    {
        static QrUtilitiesWrapper qrUtils;
        public QRHelper()
        {
            qrUtils = new QrUtilitiesWrapper();
        }
        public static byte[] MakeQRImage(string data)
        {
            Bitmap qrImage = qrUtils.GetQrEncoding(data, 200, 200);
            byte[] imageBytes = Helpers.ImageToByte(qrImage);
            return imageBytes;
        }
        
    }
}
