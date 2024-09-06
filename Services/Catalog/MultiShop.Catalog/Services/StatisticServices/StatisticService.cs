using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;

            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {

            // MongoDB Aggregate işlemi için bir pipeline tanımlanıyor. Bu pipeline aşamaları içerir.
            var pipeline = new BsonDocument[]
            {
              // $group aşaması: Verileri gruplamak için kullanılır. Burada "_id" alanı null, yani tüm ürünler tek bir gruba toplanıyor.
               new BsonDocument("$group", new BsonDocument
               {
             {"_id", null }, // Bu, gruplama için bir anahtar kullanmıyoruz anlamına gelir. Tüm veriler bir grup olur.
        
                 // averagePrice: Bu, "$avg" operatörü kullanılarak "ProductPrice" alanının ortalamasını hesaplar.
                    {"averagePrice", new BsonDocument("$avg", "$ProductPrice") }
                 } )
                  };

            // MongoDB'deki _productCollection koleksiyonuna Aggregate sorgusu uygulanıyor. Pipeline'daki işlemler burada çalıştırılır.
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);

            // Sonuçlar arasından ilk belgeyi alıyoruz. Eğer hiç sonuç yoksa, null döner.
            var price = result.FirstOrDefault()
                // averagePrice alanındaki değeri alıyoruz. Eğer bulunmazsa, decimal.Zero (0.0) döner.
                .GetValue("averagePrice", decimal.Zero)
                // Değeri decimal türüne dönüştürüyoruz.
                .AsDecimal;

            // Hesaplanan ortalama fiyatı döndürüyoruz.
            return price;
        }

        public Task<long> GetProductCount()
        {
            return _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
