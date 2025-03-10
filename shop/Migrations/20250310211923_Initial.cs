using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ShopUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_ShopUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ShopUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_ShopUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ShopUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { 1, "100% polyester. Polyester och andra syntetmaterial tappar mikroplast vid tvätt, så vi rekommenderar en tvättpåse för att skydda alla tyger och plagg från att slitas eller sträckas ut i tvättmaskinen. Det kommer också att begränsa mikrofiberläckage i tvättprocessen, vilket innebär att mikroplaster förhindras från att tränga in i floder och hav.", "https://image-resizing.booztcdn.com/ida-sjostedt/istjoelydress_cros_10.webp?has_grey=0&has_webp=0&dpr=2.5&size=w400", "Joely short dress", 299m, 0m },
                    { 2, "Skivad tyll formar den här uttalande klänningen som har en lätt rynkad livdel med en söt halsringning (med halkfria remsor), inramad av axelband. Den passande midjan toppar en snurrvärd skaterkjol som slutar i en flirtig minifåll. Dold dragkedja/lås baktill.", "https://www.beginningboutique.com/cdn/shop/files/Ella-Light-Pink-Off-Shoulder-Formal-Maxi-Dress-1_750x.jpg?v=1695082651", "Sienna hot pink dress", 499m, 0m },
                    { 3, "Ett lätt tyg tillverkat av premium mullbärssilkefibrer, där en del av dem är vridna medurs och andra i moturs riktning. Dessa fibrer vävs sedan till ett slättvävt tyg.", "https://slimages.macysassets.com/is/image/MCY/products/3/optimized/24486773_fpx.tif?op_sharpen=1&wid=700&hei=855&fit=fit,1", "Wide-Leg Dense Silk Trousers", 399m, 0m },
                    { 4, "Oversized dubbelknäppt skräddarsydd kappa med breda, vassa vadderade axlar. Tillverkad av en borstad ullblandning som är gjord av återvunnet tyg.", "https://thehouseofrare.com/cdn/shop/files/DUNE-GREEN-CC-01672HERO.jpg?v=1692181253", "Green Textured Long Coat", 599m, 0m },
                    { 5, "Gröna och blåa etniska motiv tryckt a-line klänning Fyrkantig hals Trekvarts, puffärm Samlad eller veckad detalj Maxi längd i volangfåll.", "https://cottinfab.com/cdn/shop/products/DSS9849B_1.jpg?v=1658397269", "Cottinfab dress", 399m, 0m },
                    { 6, "Var ditt modiga jag med denna eleganta blå a-linje klänning från huset av Cottinfab. Tillverkad i förstklassig viskos för superb glans och drapering, den är vacker.", "https://img.tatacliq.com/images/i7/437Wx649H/MP000000011546729_437Wx649H_202112231153021.jpeg", "Cottinfab blue long dress", 599m, 0m },
                    { 7, "En trenchcoat är en viktig resesällskap och erbjuder en blandning av stil, funktionalitet och anpassningsförmåga. Det är en pålitlig sköld mot växlande väder som håller dig torr och bekväm samtidigt som den ger extra värme i kallare klimat.", "https://m.media-amazon.com/images/I/51J7wbYdUFL._AC_UY1000_.jpg", "Trench Coats for Women", 499m, 0m },
                    { 8, "Letar du efter en fantastisk samling klänningar? ja, lägg händerna på den här klänningen från trend arrest och få även möjligheten att välja mellan lavendelfärg.", "https://www.berrylush.com/cdn/shop/products/BeFunky-design_20_01f99db8-d17c-4f5d-b92b-51a5d1b0fc0b.jpg?v=1628422958", "Pink Solid Dress", 299m, 0m },
                    { 9, "Ullmix tyg. Midi design. Oversize design. Lapel-krage V-ringad krage. Långärmad. Två sidfickor. Knäppning framtill. Slits baktill. Innerfoder. Office utseende.", "https://st.mngbcn.com/rcs/pics/static/T6/fotos/S20/67060448_99.jpg?ts=1699012974202&imwidth=360&imdensity=2", "Oversize wool coat", 899m, 0m },
                    { 10, "Att bygga en grönare, renare garderob börjar med t-shirts som den här. Vår Essential Women's V-neck T-shirt är uppfriskande annorlunda än engångs-T-shirts, och är gjord av rejäl och otroligt mjuk organisk peruansk Pima-bomull som kommer att hålla i år, ja år, av entusiastisk användning. Toppen med v-ringning är lätt rundad för en mjukare look och precis lagom djup.95 % ekologisk Pima bomull 5 % elastan stretchjersey.", "https://www.fairindigo.com/cdn/shop/files/BG_OF_03974_Sage_SS24_1535_720x.jpg?v=1710026423", "Women's Organic V-neck Tshirt", 259m, 0m },
                    { 11, "Ett par 4-säsongsbyxor i klassisk rakbensform med en färg som aldrig går ur stilen. De rena linjerna är gjorda för att smickra dina kurvor. Vår 4-säsongskollektion är den ultimata lösningen för mångsidig garderob året runt.", "https://lanebryant.scene7.com/is/image/lanebryantProdATG/401208_0000009187?$pdpMainImage$", "Straight Leg 4-Season Trousers", 730m, 0m },
                    { 12, "Aran Sweater är en tidlös garderob som är nödvändig och en tröja för livet. Bärd i århundraden av fiskaren från Irland och populär av Vogue på 1950-talet, den här robusta tröjan är en sann mångsysslare.", "https://cdn11.bigcommerce.com/s-scgdirr/products/17595/images/92077/C1347_-_Moss_Green__69889.1676391063.560.850.jpg?c=2", "Men's Aran Wool Sweater", 589m, 0m },
                    { 13, "Vi presenterar den lyxiga guldtröjan från Allen Solly, designad för kvinnor som värderar mode och komfort lika mycket. Den här huvtröjan är gjord av mysigt akrylmaterial och lovar en åtsittande passform för ultimat komfort.", "https://imagescdn.planetfashion.in/img/app/product/6/643576-6434989.jpg?auto=format&w=494.40000000000003", "Women Gold SolidCasual Sweater", 359m, 0m },
                    { 14, "Håller dig torr och bekväm - Den här vinterjackan för män har en tuff vattentät finish, vilket säkerställer att du förblir skyddad och torr. Låt inte vädret dämpa ditt humör - den här vinterjackan för män är designad för att hålla dig bekväm och snygg oavsett vad Moder Natur kastar på dig.", "https://m.media-amazon.com/images/I/71MlHIksisL._AC_SX569_.jpg", "Winter Thick Warm Parka Men Jacket", 2019m, 0m },
                    { 15, "Tillverkad av premium bomullstyg som är mjukt, bekvämt, andas, håller länge och slitstarkt även efter många tvättar.", "https://www.oxford.com.pk/cdn/shop/files/Blue_4.jpg?v=1688717022&width=1200", "Cotton Casual Shirt", 299m, 0m },
                    { 16, "Långärmad volangskjorta för damer i vitt har en vit volang på kragen, muddarna och framsidan av skjortan. Denna fantastiska damskjorta i 100 % bomull med volangkrage är en vackert skräddarsydd elegant skjorta som kan bäras ensam eller också ser fantastisk ut under våra jackor och tröjor.", "https://www.hhequestrian.com.au/wp-content/uploads/2017/05/white-frill-shirt-1024x1536.jpg", "LADIES LONG SLEEVE SHIRT WHITE", 299m, 0m },
                    { 17, "Utstråla elegansen med varje outfit när du rockar den här T-shirten. Tillverkad av tyger av högsta kvalitet, den andas utomordentligt och lämnar en härlig chic känsla till alla dina outfits!", "https://www.globalrepublic.in/cdn/shop/products/1_83e28aa9-a80c-41e6-aed6-f306ab41f5c4_1000x.jpg?v=1591353307", "Women Fit Sports White TShirt", 259m, 0m },
                    { 18, "En del av vår avslappnade kollektion, denna t-shirt i tröja för kvinnor har rund hals, korta ärmar och en modern, lösare passform för enkel stil. Den här t-shirten är gjord av vår supermjuka 100 % Airlume-bomull och känns fantastisk hela dagen.", "https://www.bellacanvas.com/bella/product/hires/64000024511_1.jpg", "WOMEN'S JERSEY SHORT SLEEVE TShirt", 199m, 0m },
                    { 19, "Lyft din stil med vår White Crop Top och Polka Dots Skirt Set, en perfekt blandning av chic och lekfull. Denna trendiga ensemble kombinerar en skarp vit crop-top med en flirtig prickig kjol, vilket skapar en fräsch och levande look.", "https://img.ltwebstatic.com/images3_pi/2024/12/27/1a/1735291272fe616ca26f688e5b7ae3c4fd0619a9a8_thumbnail_560x.webp", "WHITE CROP TOP AND POLKA DOTS SKIRT SET", 1199m, 0m },
                    { 20, "Flödande tyg. Satin. Midi design. Rak design. Resårband. Kontorsutseende. Sammansättning: 96 % polyester, 4 % elastan. Innehåller minst 50 % återvunnet material. Designad i Barcelona.", "https://shop.mango.com/assets/rcs/pics/static/T6/fotos/S20/67047149_05_D7.jpg?ts=1712578361673&imwidth=312&imdensity=2", "Midi satin skirt", 599m, 0m },
                    { 21, "Vid Tshirt. Rund krage. Kortärmad. Kombinerade tryck i kontrast på fram- och baksidan. Blekt effekt.", "https://static.zara.net/assets/public/2b30/fed2/a2024c86b4da/db613f14747a/06224428433-a1/06224428433-a1.jpg?ts=1709114725351&w=824", "BLEKT TSHIRT MED TEXT", 299m, 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShopUsers");
        }
    }
}
