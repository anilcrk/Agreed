using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Agreed.Core.Helpers.Cryption
{
    public static class AES256
    {
            private static string PASSWORD = "HAC19981985861907a1n2i3l4";
            private static string SALT = "h1a2c3r4i5a6n7i8l9c10i11r12i13k14";

            public static string EncryptAndEncode(string raw)
            {
                using (var csp = new AesCryptoServiceProvider())
                {
                    ICryptoTransform e = GetCryptoTransform(csp, true);
                    byte[] inputBuffer = Encoding.UTF8.GetBytes(raw);
                    byte[] output = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                    string encrypted = Convert.ToBase64String(output);
                    return encrypted;
                }
            }

            public static string DecodeAndDecrypt(string encrypted)
            {
                using (var csp = new AesCryptoServiceProvider())
                {
                    var d = GetCryptoTransform(csp, false);
                    byte[] output = Convert.FromBase64String(encrypted);
                    byte[] decryptedOutput = d.TransformFinalBlock(output, 0, output.Length);
                    string decypted = Encoding.UTF8.GetString(decryptedOutput);
                    return decypted;
                }
            }

            private static ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, bool encrypting)
            {
                csp.Mode = CipherMode.CBC;
                csp.Padding = PaddingMode.PKCS7;
                var spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(PASSWORD), Encoding.UTF8.GetBytes(SALT), 65536, HashAlgorithmName.SHA256);
                byte[] key = spec.GetBytes(32);

                csp.KeySize = 256;
                csp.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                csp.Key = key;

                if (encrypting)
                {
                    return csp.CreateEncryptor();
                }
                return csp.CreateDecryptor();
            }
        
    }
}
