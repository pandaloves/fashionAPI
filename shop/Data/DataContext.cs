using shop.Entities;
using Microsoft.EntityFrameworkCore;

namespace shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "Joely short dress",
                ProductPrice = 299,
                ProductDescription = "100% polyester. Polyester och andra syntetmaterial tappar mikroplast vid tvätt, så vi rekommenderar en tvättpåse för att skydda alla tyger och plagg från att slitas eller sträckas ut i tvättmaskinen. Det kommer också att begränsa mikrofiberläckage i tvättprocessen, vilket innebär att mikroplaster förhindras från att tränga in i floder och hav.",
                ProductImage = "https://image-resizing.booztcdn.com/ida-sjostedt/istjoelydress_cros_10.webp?has_grey=0&has_webp=0&dpr=2.5&size=w400"
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Sienna hot pink dress",
                ProductPrice = 499,
                ProductDescription = "Skivad tyll formar den här uttalande klänningen som har en lätt rynkad livdel med en söt halsringning (med halkfria remsor), inramad av axelband. Den passande midjan toppar en snurrvärd skaterkjol som slutar i en flirtig minifåll. Dold dragkedja/lås baktill.",
                ProductImage = "https://www.beginningboutique.com/cdn/shop/files/Ella-Light-Pink-Off-Shoulder-Formal-Maxi-Dress-1_750x.jpg?v=1695082651"
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Wide-Leg Dense Silk Trousers",
                ProductPrice = 399,
                ProductDescription = "Ett lätt tyg tillverkat av premium mullbärssilkefibrer, där en del av dem är vridna medurs och andra i moturs riktning. Dessa fibrer vävs sedan till ett slättvävt tyg.",
                ProductImage = "https://slimages.macysassets.com/is/image/MCY/products/3/optimized/24486773_fpx.tif?op_sharpen=1&wid=700&hei=855&fit=fit,1"
            },
            new Product
            {
                ProductId = 4,
                ProductName = "Green Textured Long Coat",
                ProductPrice = 599,
                ProductDescription = "Oversized dubbelknäppt skräddarsydd kappa med breda, vassa vadderade axlar. Tillverkad av en borstad ullblandning som är gjord av återvunnet tyg.",
                ProductImage = "https://thehouseofrare.com/cdn/shop/files/DUNE-GREEN-CC-01672HERO.jpg?v=1692181253"
            },
            new Product
            {
                ProductId = 5,
                ProductName = "Cottinfab dress",
                ProductPrice = 399,
                ProductDescription = "Gröna och blåa etniska motiv tryckt a-line klänning Fyrkantig hals Trekvarts, puffärm Samlad eller veckad detalj Maxi längd i volangfåll.",
                ProductImage = "https://cottinfab.com/cdn/shop/products/DSS9849B_1.jpg?v=1658397269"
            },
            new Product
            {
                ProductId = 6,
                ProductName = "Cottinfab blue long dress",
                ProductPrice = 599,
                ProductDescription = "Var ditt modiga jag med denna eleganta blå a-linje klänning från huset av Cottinfab. Tillverkad i förstklassig viskos för superb glans och drapering, den är vacker.",
                ProductImage = "https://img.tatacliq.com/images/i7/437Wx649H/MP000000011546729_437Wx649H_202112231153021.jpeg"
            },
            new Product
            {
                ProductId = 7,
                ProductName = "Trench Coats for Women",
                ProductPrice = 499,
                ProductDescription = "En trenchcoat är en viktig resesällskap och erbjuder en blandning av stil, funktionalitet och anpassningsförmåga. Det är en pålitlig sköld mot växlande väder som håller dig torr och bekväm samtidigt som den ger extra värme i kallare klimat.",
                ProductImage = "https://m.media-amazon.com/images/I/51J7wbYdUFL._AC_UY1000_.jpg"
            },
            new Product
            {
                ProductId = 8,
                ProductName = "Pink Solid Dress",
                ProductPrice = 299,
                ProductDescription = "Letar du efter en fantastisk samling klänningar? ja, lägg händerna på den här klänningen från trend arrest och få även möjligheten att välja mellan lavendelfärg.",
                ProductImage = "https://www.berrylush.com/cdn/shop/products/BeFunky-design_20_01f99db8-d17c-4f5d-b92b-51a5d1b0fc0b.jpg?v=1628422958"
            },
            new Product
            {
                ProductId = 9,
                ProductName = "Oversize wool coat",
                ProductPrice = 899,
                ProductDescription = "Ullmix tyg. Midi design. Oversize design. Lapel-krage V-ringad krage. Långärmad. Två sidfickor. Knäppning framtill. Slits baktill. Innerfoder. Office utseende.",
                ProductImage = "https://st.mngbcn.com/rcs/pics/static/T6/fotos/S20/67060448_99.jpg?ts=1699012974202&imwidth=360&imdensity=2"
            },
            new Product
            {
                ProductId = 10,
                ProductName = "Women's Organic V-neck Tshirt",
                ProductPrice = 259,
                ProductDescription = "Att bygga en grönare, renare garderob börjar med t-shirts som den här. Vår Essential Women's V-neck T-shirt är uppfriskande annorlunda än engångs-T-shirts, och är gjord av rejäl och otroligt mjuk organisk peruansk Pima-bomull som kommer att hålla i år, ja år, av entusiastisk användning. Toppen med v-ringning är lätt rundad för en mjukare look och precis lagom djup.95 % ekologisk Pima bomull 5 % elastan stretchjersey.",
                ProductImage = "https://www.fairindigo.com/cdn/shop/files/BG_OF_03974_Sage_SS24_1535_720x.jpg?v=1710026423"
            },
            new Product
            {
                ProductId = 11,
                ProductName = "Straight Leg 4-Season Trousers",
                ProductPrice = 730,
                ProductDescription =
         "Ett par 4-säsongsbyxor i klassisk rakbensform med en färg som aldrig går ur stilen. De rena linjerna är gjorda för att smickra dina kurvor. Vår 4-säsongskollektion är den ultimata lösningen för mångsidig garderob året runt.",
                ProductImage =
         "https://lanebryant.scene7.com/is/image/lanebryantProdATG/401208_0000009187?$pdpMainImage$"
            },
             new Product
             {
                 ProductId = 12,
                 ProductName = "Men's Aran Wool Sweater",
                 ProductPrice = 589,
                 ProductDescription =
         "Aran Sweater är en tidlös garderob som är nödvändig och en tröja för livet. Bärd i århundraden av fiskaren från Irland och populär av Vogue på 1950-talet, den här robusta tröjan är en sann mångsysslare.",
                 ProductImage =
         "https://cdn11.bigcommerce.com/s-scgdirr/products/17595/images/92077/C1347_-_Moss_Green__69889.1676391063.560.850.jpg?c=2"
             },
               new Product
               {
                   ProductId = 13,
                   ProductName = "Women Gold SolidCasual Sweater",
                   ProductPrice = 359,
                   ProductDescription =
         "Vi presenterar den lyxiga guldtröjan från Allen Solly, designad för kvinnor som värderar mode och komfort lika mycket. Den här huvtröjan är gjord av mysigt akrylmaterial och lovar en åtsittande passform för ultimat komfort.",
                   ProductImage =
         "https://imagescdn.planetfashion.in/img/app/product/6/643576-6434989.jpg?auto=format&w=494.40000000000003"
               },
                    new Product
                    {
                        ProductId = 14,
                        ProductName = "Winter Thick Warm Parka Men Jacket",
                        ProductPrice = 2019,
                        ProductDescription =
         "Håller dig torr och bekväm - Den här vinterjackan för män har en tuff vattentät finish, vilket säkerställer att du förblir skyddad och torr. Låt inte vädret dämpa ditt humör - den här vinterjackan för män är designad för att hålla dig bekväm och snygg oavsett vad Moder Natur kastar på dig.",
                        ProductImage =
         "https://m.media-amazon.com/images/I/71MlHIksisL._AC_SX569_.jpg"
                    },
                    new Product
                    {
                        ProductId = 15,
                        ProductName = "Cotton Casual Shirt",
                        ProductPrice = 299,
                        ProductDescription =
         "Tillverkad av premium bomullstyg som är mjukt, bekvämt, andas, håller länge och slitstarkt även efter många tvättar.",
                        ProductImage =
         "https://www.oxford.com.pk/cdn/shop/files/Blue_4.jpg?v=1688717022&width=1200",
                    },
       new Product
       {
           ProductId = 16,
           ProductName = "LADIES LONG SLEEVE SHIRT WHITE",
           ProductPrice = 299,
           ProductDescription =
                   "Långärmad volangskjorta för damer i vitt har en vit volang på kragen, muddarna och framsidan av skjortan. Denna fantastiska damskjorta i 100 % bomull med volangkrage är en vackert skräddarsydd elegant skjorta som kan bäras ensam eller också ser fantastisk ut under våra jackor och tröjor.",
           ProductImage =
                   "https://www.hhequestrian.com.au/wp-content/uploads/2017/05/white-frill-shirt-1024x1536.jpg",
       },
       new Product
       {
           ProductId = 17,
           ProductName = "Women Fit Sports White TShirt",
           ProductPrice = 259,
           ProductDescription =
                   "Utstråla elegansen med varje outfit när du rockar den här T-shirten. Tillverkad av tyger av högsta kvalitet, den andas utomordentligt och lämnar en härlig chic känsla till alla dina outfits!",
           ProductImage =
                   "https://www.globalrepublic.in/cdn/shop/products/1_83e28aa9-a80c-41e6-aed6-f306ab41f5c4_1000x.jpg?v=1591353307",
       },
       new Product
       {
           ProductId = 18,
           ProductName = "WOMEN'S JERSEY SHORT SLEEVE TShirt",
           ProductPrice = 199,
           ProductDescription =
                   "En del av vår avslappnade kollektion, denna t-shirt i tröja för kvinnor har rund hals, korta ärmar och en modern, lösare passform för enkel stil. Den här t-shirten är gjord av vår supermjuka 100 % Airlume-bomull och känns fantastisk hela dagen.",
           ProductImage =
                   "https://www.bellacanvas.com/bella/product/hires/64000024511_1.jpg",
       },
       new Product
       {
           ProductId = 19,
           ProductName = "WHITE CROP TOP AND POLKA DOTS SKIRT SET",
           ProductPrice = 1199,
           ProductDescription =
                   "Lyft din stil med vår White Crop Top och Polka Dots Skirt Set, en perfekt blandning av chic och lekfull. Denna trendiga ensemble kombinerar en skarp vit crop-top med en flirtig prickig kjol, vilket skapar en fräsch och levande look.",
           ProductImage =
                   "https://img.ltwebstatic.com/images3_pi/2024/12/27/1a/1735291272fe616ca26f688e5b7ae3c4fd0619a9a8_thumbnail_560x.webp",
       },
       new Product
       {
           ProductId = 20,
           ProductName = "Midi satin skirt",
           ProductPrice = 599,
           ProductDescription =
                   "Flödande tyg. Satin. Midi design. Rak design. Resårband. Kontorsutseende. Sammansättning: 96 % polyester, 4 % elastan. Innehåller minst 50 % återvunnet material. Designad i Barcelona.",
           ProductImage =
                   "https://shop.mango.com/assets/rcs/pics/static/T6/fotos/S20/67047149_05_D7.jpg?ts=1712578361673&imwidth=312&imdensity=2",
       },
       new Product
       {
           ProductId = 21,
           ProductName = "BLEKT TSHIRT MED TEXT",
           ProductPrice = 299,
           ProductDescription =
                   "Vid Tshirt. Rund krage. Kortärmad. Kombinerade tryck i kontrast på fram- och baksidan. Blekt effekt.",
           ProductImage =
                   "https://static.zara.net/assets/public/2b30/fed2/a2024c86b4da/db613f14747a/06224428433-a1/06224428433-a1.jpg?ts=1709114725351&w=824",
       }
        );

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductQuantity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                 .Property(e => e.TotalAmount)
                 .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                 .Property(e => e.ProductPrice)
                 .HasColumnType("decimal(18, 2)");

            // one-to-one relationship between ShopUser and Cart
            modelBuilder.Entity<ShopUser>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            // one-to-many relationship between ShopUser and Orders
            modelBuilder.Entity<ShopUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // one-to-many relationship between Cart and CartItems
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // one-to-many relationship between Order and OrderItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // many-to-one relationship between CartItem and Product
            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Product)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.ProductId);

            // many-to-one relationship between OrderItem and Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            // one-to-one relationship between Order and Payment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
