// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

//çeşitli yetkilere sahip kullanıcılarımızın yapabileceği ilemlerle ilgili kısıtlamaların olduğu kısım.
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        //her mikroservis için o mikroservise erişim sağlanacak olan key belirliyeceğiz.
        //resoucecatalog ismindeki key e sahip olan mikroservis kullanıcısı catalof fullpermission işlemini gerçekleştiricek
        public static IEnumerable<ApiResource> ApiResources =>
                   new ApiResource[]
                   {
                new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
                new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
                new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
                 new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },
                 new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },
                 new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"} },
                 new ApiResource("ResourcePayment"){Scopes={ "PaymentFullPermission" } },
                 new ApiResource("ResourceImage"){Scopes={ "ImageFullPermission" } },
                 new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"} },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
};
                
                   
    public static IEnumerable<IdentityResource> IdentityResources =>
         new IdentityResource[]
         {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()

         };
    public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
                new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
                new ApiScope("DiscountFullPermission","Full authority for discount operations"),
                new ApiScope("OrderFullPermission","Full authority for order operations"),
                 new ApiScope("CargoFullPermission","Full authority for cargo operations"),
                 new ApiScope("BasketFullPermission","Full authority for basket operations"),
                 new ApiScope("CommentFullPermission","Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
             new ApiScope("ImageFullPermission","Full authority for image operations"),
                 new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients => new Client[]
            {
                // visitor
                new Client
                {
                    ClientId = "MultiShopVisitorId",
                    ClientName = "Multi Shop Visitor User",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },

                    AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "OcelotFullPermission","CommentFullPermission", "ImageFullPermission", }
                },

                //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission","OcelotFullPermission","CommentFullPermission", "PaymentFullPermission","ImageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile }
            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission"
                ,"CargoFullPermission", "BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=6000
            }
        };
    }
}