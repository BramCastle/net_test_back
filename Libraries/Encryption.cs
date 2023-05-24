using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace net_test.Libraries
{
    public class Encription
    {
        public static string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string MD5()
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Encription.GenerateID());
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string UniqueFileName( dynamic strFile) {
            string strReturn = null;
            if ( strFile != null ) {
                strReturn = Encription.MD5() + Path.GetExtension(strFile.FileName);
            }
            return strReturn;
        }
    }
}
