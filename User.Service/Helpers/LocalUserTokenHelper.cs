using System;
using System.Collections.Generic;
using System.Text;

namespace User.Service.Helpers
{
    public static class LocalUserTokenHelper
    {
        private const string TokenSignKey = "jasidjfaois09080m5tyuit";
        private const string TokenEncryptKey = "ythgbinhuimkdiny";

        public static string GenerateLocalToken(long userId)
        {
            var dicts = new Dictionary<string, string>();
            dicts.Add("Id", userId.ToString());

            var token = new TokenBuilder(TokenSignKey).Build(dicts);
            var encryptToken = AesHelper.Encrypt(token, TokenEncryptKey);

            return Convert.ToBase64String(encryptToken).UrlEncode();
        }

        public static bool VerifyLocalToken(string token, out long userId)
        {
            userId = 0L;

            try
            {
                var tokenBytes = Convert.FromBase64String(token.UrlDecode());

                var descriptToken = Encoding.UTF8.GetString(AesHelper.Decrypt(tokenBytes, TokenEncryptKey));

                Dictionary<string, string> dicts;

                var isVerified = new TokenBuilder(TokenSignKey).Verify(descriptToken, out dicts);

                if (isVerified)
                {
                    userId = dicts["Id"].ToInt64();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}