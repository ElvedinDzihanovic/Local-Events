using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLCrypto;

namespace PCL.Util
{
    public class UIHelper
    {
        public static string GenerateSalt()
        {
            var buf = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
            return Convert.ToBase64String(buf);
            /*
            byte[] arr = new byte[16];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(arr);
            return Convert.ToBase64String(arr);
    */
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] byteLozinka = Encoding.Unicode.GetBytes(lozinka);
            byte[] byteSalt = Convert.FromBase64String(salt);
            byte[] forHashing = new byte[byteLozinka.Length + byteSalt.Length];

            System.Buffer.BlockCopy(byteLozinka, 0, forHashing, 0, byteLozinka.Length);
            System.Buffer.BlockCopy(byteSalt, 0, forHashing, byteLozinka.Length, byteSalt.Length);

            var algorithm = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] inArray = algorithm.HashData(forHashing);
            return Convert.ToBase64String(inArray);

            //HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            //return Convert.ToBase64String(alg.ComputeHash(forHashing));
        }
    }
}
