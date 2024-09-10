namespace MultiShop.RapidAPI.Models
{
    public class ECommerceViewModel
    {
 
            public Datum[] data { get; set; }
       

       

        public class Datum
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string product_description { get; set; }
            public string[] product_photos { get; set; }
            public Product_Attributes product_attributes { get; set; }
            public float? product_rating { get; set; }
            public string product_page_url { get; set; }
            public string product_offers_page_url { get; set; }
            public string product_specs_page_url { get; set; }
            public string product_reviews_page_url { get; set; }
            public int product_num_reviews { get; set; }
            public string product_num_offers { get; set; }
            public string[] typical_price_range { get; set; }
            public Offer offer { get; set; }
        }

        public class Product_Attributes
        {
            public string Sensor { get; set; }
            public string Features { get; set; }
            public string Colour { get; set; }
            public string Connectivity { get; set; }
            public string Type { get; set; }
        }

        public class Offer
        {
            public string store_name { get; set; }
            public object store_rating { get; set; }
            public string offer_page_url { get; set; }
            public int store_review_count { get; set; }
            public object store_reviews_page_url { get; set; }
            public string price { get; set; }
            public string shipping { get; set; }
            public object tax { get; set; }
            public bool on_sale { get; set; }
            public string original_price { get; set; }
            public string product_condition { get; set; }
            public bool top_quality_store { get; set; }
        }

        public class Sponsored_Products
        {
            public int rank { get; set; }
            public string placement { get; set; }
            public string product_title { get; set; }
            public string price { get; set; }
            public bool on_sale { get; set; }
            public string product_photo { get; set; }
            public string offer_page_url { get; set; }
            public string store_name { get; set; }
            public string shipping { get; set; }
        }

    }
}
