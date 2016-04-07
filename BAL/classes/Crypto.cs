using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace BAL
{
    public static class Crypto
    {
        private static string Password { get; }
        private static string SaltValue { get; }
        private static string HashName { get; }
        private static int PasswordIterations { get; }
        private static string InitVector { get; }
        private static int KeySize { get; }

        static Crypto()
        {
            Password = "]40Ef$;l9?,p3Ld";
            SaltValue = "123987";
            HashName = "SHA1";
            InitVector = "WellHelloThere";
            KeySize = 256;
            PasswordIterations = 5;
        }               
        
        /// <summary>
        /// Encypts CipherText
        /// </summary>
        /// <param name="sPlainText"></param>
        /// <returns>Encrypted CipherText</returns>
        public static string Encrypt(string sPlainText)
        {
            string strCipherText = "";

            try
            {
                strCipherText = RijndaelEncrypt(sPlainText, Password, SaltValue, HashName, PasswordIterations, InitVector, KeySize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return strCipherText;
        }

        /// <summary>
        /// Decrypts CipherText
        /// </summary>
        /// <param name="sCipherText"></param>
        /// <returns>sCipherText</returns>
        public static string Decrypt(string sCipherText)
        {
            string strPlainText = "";

            try
            {
                strPlainText = RijndaelDecrypt(sCipherText, Password, SaltValue, HashName, PasswordIterations, InitVector, KeySize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return strPlainText;
        }

        /// <summary>
        /// Symetric Key Encryption using the Rijndael Algorithm
        /// </summary>
        /// <param name="sText">Plain Text to Encrypt</param>
        /// <param name="sPassword">ASCII String used to Generate the  Key</param>
        /// <param name="sSaltValue">Salt Value used with Password to Generate Key</param>
        /// <param name="sHashName">Hash Algorithm used to Generate the Key(SHA1 or MD5)</param>
        /// <param name="iPasswordIterations">Number of Iterations used to Generate the Key(minimum 2)</param>
        /// <param name="sInitVector">16 ASCII Characters used to encrypt the first block of the Plain Text</param>
        /// <param name="iKeySize">Encryption Key Bits (128, 192 or 256)</param>
        /// <returns>Encrypted String</returns>
        private static string RijndaelEncrypt(string sPlainText, string sPassword, string sSaltValue, string sHashName, int nPasswordIterations, string sInitVector, int nKeySize)
        {
            PasswordDeriveBytes oPassword = null;
            ICryptoTransform oEncryptor = null;
            MemoryStream oMemStream = null;
            CryptoStream oCryptoStream = null;
            byte[] arrInitVector = null;
            byte[] arrSaltValue = null;
            byte[] arrText = null;
            byte[] arrCipherText = null;
            byte[] arrKey = null;

            try
            {
                arrInitVector = Encoding.ASCII.GetBytes(sInitVector);
                arrSaltValue = Encoding.ASCII.GetBytes(sSaltValue);
                arrText = Encoding.UTF8.GetBytes(sPlainText);
                arrCipherText = null;

                // generate password from passphrase and salt values to derive the key
                oPassword = new PasswordDeriveBytes(
                    sPassword,
                    arrSaltValue,
                    sHashName,
                    nPasswordIterations
                    );

                // generate random key
                arrKey = oPassword.GetBytes(nKeySize / 8);

                // init encryption object, mode is Cipher Block Chaining
                RijndaelManaged oRijEncrypt = new RijndaelManaged();
                oRijEncrypt.Mode = CipherMode.CBC;

                // init encryptor
                oEncryptor = oRijEncrypt.CreateEncryptor(arrKey, arrInitVector);

                // init streams
                oMemStream = new MemoryStream();
                oCryptoStream = new CryptoStream(oMemStream, oEncryptor, CryptoStreamMode.Write);

                // encrypt text
                oCryptoStream.Write(arrText, 0, sPlainText.Length);
                oCryptoStream.FlushFinalBlock();
                arrCipherText = oMemStream.ToArray();

                return Convert.ToBase64String(arrCipherText, 0,arrCipherText.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // clean up
                if (oEncryptor != null) oEncryptor.Dispose();
                if (oMemStream != null) oMemStream.Close();
                if (oCryptoStream != null) oCryptoStream.Close();
            }
        }

        /// <summary>
        /// Symetric Key Decryption using the Rijndael Algorithm
        /// </summary>
        /// <param name="sText">Cipher Text to Decrypt</param>
        /// <param name="sPassword">ASCII String used to Generate the Key</param>
        /// <param name="sSaltValue">Salt Value used with Password to Generate Key</param>
        /// <param name="sHashName">Hash Algorithm used to Generate the Key(SHA1 or MD5)</param>
        /// <param name="iPasswordIterations">Number of Iterations used to Generate the Key(minimum 2)</param>
        /// <param name="sInitVector">16 ASCII Characters used to encrypt the first block of the Plain Text</param>
        /// <param name="iKeySize">Encryption Key Bits (128, 192 or 256)</param>
        /// <returns>Decrypted String</returns>
        private static string RijndaelDecrypt(string sCipherText, string sPassword, string sSaltValue, string sHashName, int nPasswordIterations, string sInitVector, int nKeySize)
        {
            PasswordDeriveBytes oPassword = null;
            ICryptoTransform oDecryptor = null;
            MemoryStream oMemStream = null;
            CryptoStream oCryptoStream = null;
            int iDecryptedBytes = 0;
            byte[] arrInitVector = null;
            byte[] arrSaltValue = null;
            byte[] arrText = null;
            byte[] arrCipherText = null;
            byte[] arrKey = null;

            try
            {
                arrInitVector = Encoding.ASCII.GetBytes(sInitVector);
                arrSaltValue = Encoding.ASCII.GetBytes(sSaltValue);
                arrCipherText = Convert.FromBase64String(sCipherText);
                arrText = null;

                // generate password from passphrase and salt values to derive the key
                oPassword = new PasswordDeriveBytes(
                    sPassword,
                    arrSaltValue,
                    sHashName,
                    nPasswordIterations
                    );

                // generate random key
                arrKey = oPassword.GetBytes(nKeySize / 8);

                // init encryption object, mode is Cipher Block Chaining
                RijndaelManaged oRijEncrypt = new RijndaelManaged();
                oRijEncrypt.Mode = CipherMode.CBC;

                // init encryptor
                oDecryptor = oRijEncrypt.CreateDecryptor(arrKey, arrInitVector);

                // init streams
                oMemStream = new MemoryStream(arrCipherText);
                oCryptoStream = new CryptoStream(oMemStream,oDecryptor, CryptoStreamMode.Read);

                // decrypt text
                arrText = new byte[arrCipherText.Length];
                iDecryptedBytes = oCryptoStream.Read(arrText, 0,arrText.Length);
                string sTe = Encoding.UTF8.GetString(arrText, 0,iDecryptedBytes);
                return sTe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // clean up
                if (oDecryptor != null) oDecryptor.Dispose();
                if (oMemStream != null) oMemStream.Close();
                if (oCryptoStream != null) oCryptoStream.Close();
            }
        }      
    }
}
