using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            // Bir 'Claim' listesi oluşturuluyor. Bu liste, token içinde kullanıcıya ait bilgileri tutacak.
            var claims = new List<Claim>();

            // Eğer modelde 'Role' (rol) bilgisi boş değilse, bu bilgi 'claims' listesine ekleniyor.
            if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));

            // Kullanıcının benzersiz kimliğini belirten 'Id' bilgisi 'claims' listesine ekleniyor.
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

            // Eğer modelde 'Username' (kullanıcı adı) bilgisi boş değilse, bu bilgi de 'claims' listesine ekleniyor.
            if (!string.IsNullOrWhiteSpace(model.Username))
                claims.Add(new Claim("Username", model.Username));

            // Token imzalamada kullanılacak güvenlik anahtarı oluşturuluyor.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            // İmzalama kimlik bilgileri, HmacSha256 algoritması kullanılarak oluşturuluyor.
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tokenın geçerlilik süresi, mevcut zamana belirtilen gün sayısı eklenerek ayarlanıyor.
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            // Token nesnesi oluşturuluyor. Bu aşamada issuer (tokenı oluşturan), audience (hedef kitle), claim'ler,
            // geçerlilik süresi ve imzalama bilgileri belirleniyor.
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signingCredentials);

            // Token'ı işleyip string formatında oluşturmak için bir 'JwtSecurityTokenHandler' kullanılıyor.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            // Token ve geçerlilik süresi, 'TokenResponseViewModel' adlı bir ViewModel'e yerleştirilerek geri dönülüyor.
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
