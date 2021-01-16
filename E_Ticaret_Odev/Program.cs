using System;

//Barışcan KURTKAYA
//15.01.2020 C# 
//If you type wrong id and password then system will give you a trial account with 15000 money.

namespace E_Ticaret_Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            Products[] product = Identify_Product();
            Customer[] customer = Identify_Customer();
            Customer customer_id =Customer_Control(customer);
            Console.WriteLine(customer_id.Custommer_Name + " Your Money : " + customer_id.Wallet);

            string choice="";
            while (choice != "0")
            {
                Console.WriteLine("Hello " +customer_id.Custommer_Name + " do you want to see all products or do you want to make a search?\nType 1 for All Products, Type 2 for Search, Type 3 for Buy, Type 0 for EXIT");
                choice = Console.ReadLine();
                if (choice == "1") //Printing Product
                {
                    Printing(product);
                }
                else if (choice == "2") //Search Product type
                {
                    Product_Type_Find(product);
                }
                else if (choice == "3")
                {
                    Product_Buy(customer_id, product);
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Good Bye");
                }
                else
                {
                    Console.WriteLine("Wrong Button! Please try again.");
                }
            }
            
        }

        static Customer[] Identify_Customer()
        {
            Customer customer1 = new Customer();
            customer1.Custommer_Name = "Baris99";
            customer1.Password = "123456789";
            customer1.Wallet = 5; //Öğrenci olunca böyle oluyor ne yazık ki :D

            Customer customer2 = new Customer();
            customer2.Custommer_Name = "Engin_demirog";
            customer2.Password = "Engin1";
            customer2.Wallet = 5000;

            Customer[] customer = new Customer[] { customer1, customer2 };
            return customer;
        }
            
        static Products[] Identify_Product() // TR: Ürünlerin kaydedildiği fonksiyon. ENG: The function which is saving products.
            {
                Products product1 = new Products();  //TR: Desktop ürününü tanıtan kısım. ENG: identifying the desktop product.
                product1.Product_Type = "Computer";
                product1.Product_Name = "Desktop";
                product1.Product_Prices = 1000;
                product1.Product_Pieces = 15;

                Products product2 = new Products(); //TR: Laptop ürününü tanıtan kısım. ENG: identifying the Laptop product.
                product2.Product_Type = product1.Product_Type;
                product2.Product_Name = "Laptop";
                product2.Product_Prices = 1560.50;
                product2.Product_Pieces = 3;

                Products product3 = new Products(); //TR: iPhone ürününü tanıtan kısım. ENG: identifying the iPhone product.
                product3.Product_Type = "CellPhone";
                product3.Product_Name = "iPhone";
                product3.Product_Prices = 799.99;
                product3.Product_Pieces = 6;

                Products product4 = new Products(); //TR: Samsung ürününü tanıtan kısım. ENG: identifying the Samsung product.
                product4.Product_Type = product3.Product_Type;
                product4.Product_Name = "Samsung";
                product4.Product_Prices = 690.75;
                product4.Product_Pieces = 11;

                Products[] product = new Products[] { product1, product2, product3, product4 };
                return product;
            }

        static void Printing(Products[] product) //TR:Ürünleri yazdıran fonksiyon ENG: The funciton which is printing products.
            {
            Console.WriteLine("There is the all products (3 Times for homework)");
            Console.WriteLine("*******FOR DÖNGÜSÜ******** ");
                for (int i = 0; i < product.Length; i++) //i integer'ı product arayindeki variable sayısını geçtiği an bitecek bir for döngüsü
                {
                    Console.WriteLine("Product Type: " + product[i].Product_Type +
                        "\nProduct Name: " + product[i].Product_Name +
                        "\nProduct Price: " + product[i].Product_Prices +
                        "\nProduct Pieces: " + product[i].Product_Pieces + "\n");
                }

                Console.WriteLine("*******FOREACH DÖNGÜSÜ******** ");
                foreach (Products pro in product)   //product arrayinin sırayla içinde gezen foreach
                {
                    Console.WriteLine("Product Type: " + pro.Product_Type +
                        "\nProduct Name: " + pro.Product_Name +
                        "\nProduct Price: " + pro.Product_Prices +
                        "\nProduct Pieces: " + pro.Product_Pieces + "\n");
                }

                Console.WriteLine("*******WHILE DÖNGÜSÜ******** ");

                int c = 0; //counter to while
                while (c < product.Length)    //c integerı product arrayinin içindeki variable sayısından küçük olduğu sürece dönen while yapısı
                {
                    Console.WriteLine("Product Type: " + product[c].Product_Type +
                        "\nProduct Name: " + product[c].Product_Name +
                        "\nProduct Price: " + product[c].Product_Prices +
                        "\nProduct Pieces: " + product[c].Product_Pieces + "\n");
                    c++;
                }
            }

        static void Product_Type_Find(Products[] product) //TR: Ürünlerin tipinden ürünleri getiren fonksiyon. ENG: The funciton which is brings to you what type you want to see.
            {
            string find;
            Console.WriteLine("Which Product type do you want to search?");
            find = Console.ReadLine();
            switch (find)
            {
                case "Computer":
                    foreach (Products pro in product)   //product arrayinin sırayla içinde gezen foreach
                    {
                        if(pro.Product_Type=="Computer")
                        Console.WriteLine("Here are the products you are looking for!" +
                            "\nProduct Name: " + pro.Product_Name +
                            "\nProduct Price: " + pro.Product_Prices +
                            "\nProduct Pieces: " + pro.Product_Pieces + "\n");
                    }
                    break;
                case "CellPhone":
                    foreach (Products pro in product)   //product arrayinin sırayla içinde gezen foreach
                    {
                        if (pro.Product_Type == "CellPhone")
                            Console.WriteLine("Here are the products you are looking for!" +
                                "\nProduct Name: " + pro.Product_Name +
                                "\nProduct Price: " + pro.Product_Prices +
                                "\nProduct Pieces: " + pro.Product_Pieces + "\n");
                    }
                    break;
                default:
                    Console.WriteLine("We can't find a product type you want to search");
                    break;

            }
                
            } 

        static Customer Customer_Control(Customer [] customer)
        {
            string id;
            string pw;
            Console.WriteLine("Please enter your id ");
            id = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            pw = Console.ReadLine();
            while (true) 
            {
                foreach (Customer correct_customer in customer)
                {
                    if (id == correct_customer.Custommer_Name && pw == correct_customer.Password)
                    {
                        return correct_customer;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Id or Password! There is your Trial account");
                        Customer customer3 = new Customer();
                        customer3.Custommer_Name = "Trial account";
                        customer3.Wallet = 15000;
                        return customer3;
                    }
                }
            }
        } //TR: Girilen ID ve Şifreyi database'de kontrol eden fonksiyon. ENG: This function controls your id and password in database.

        static double Product_Buy(Customer customer_id, Products[] product)
        {
            string product_buy;
            Console.WriteLine("Which product do you want to buy?");
            product_buy = Console.ReadLine();
            switch (product_buy)
            {
                case "Desktop":
                    if (customer_id.Wallet >= product[0].Product_Prices && product[0].Product_Pieces != 0)
                    {
                        customer_id.Wallet = (customer_id.Wallet) - (product[0].Product_Prices);
                        product[0].Product_Pieces--;
                        Console.WriteLine("Your new Wallet: " + customer_id.Wallet);
                    }
                    else if (product[0].Product_Pieces == 0)
                    {
                        Console.WriteLine("We don't have any of" + product[0].Product_Name);
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately You don't have any money.");
                    }
                    break;
                case "Laptop":
                    if (customer_id.Wallet >= product[1].Product_Prices && product[1].Product_Pieces != 0)
                    {
                        customer_id.Wallet = (customer_id.Wallet) - (product[1].Product_Prices);
                        product[1].Product_Pieces--;
                        Console.WriteLine("Your new Wallet: " + customer_id.Wallet);
                    }
                    else if (product[1].Product_Pieces == 0)
                    {
                        Console.WriteLine("We don't have any of" + product[1].Product_Name);
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately You don't have any money.");
                    }
                    break;
                case "iPhone":
                    if (customer_id.Wallet >= product[2].Product_Prices && product[2].Product_Pieces != 0)
                    {
                        customer_id.Wallet = (customer_id.Wallet) - (product[2].Product_Prices);
                        product[2].Product_Pieces--;
                        Console.WriteLine("Your new Wallet: " + customer_id.Wallet);
                    }
                    else if (product[2].Product_Pieces == 0)
                    {
                        Console.WriteLine("We don't have any of" + product[2].Product_Name);
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately You don't have any money.");
                    }
                    break;
                case "Samsung":
                    if (customer_id.Wallet >= product[3].Product_Prices && product[3].Product_Pieces!=0)
                    {
                        customer_id.Wallet = (customer_id.Wallet) - (product[3].Product_Prices); 
                        product[3].Product_Pieces--;
                        Console.WriteLine("Your new Wallet: " + customer_id.Wallet);
                    }
                    else if (product[3].Product_Pieces == 0)
                    {
                        Console.WriteLine("We don't have any of" + product[3].Product_Name);
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately You don't have any money.");
                        Console.WriteLine("Wallet: " + customer_id.Wallet);
                    }
                    break;
            }
            return customer_id.Wallet;
        } //TR:Ürünün alınmasını sağlayan fonksiyon. ENG: You can buy a product with this function.
        
    }

    class Products //TR: Ürünülerin verisinin tutulduğu class. ENG: This class keeping products' datas.
    {
        public string Product_Type { get; set; } //TR: Ürünün tipini tutar. ENG: Keeps products type.
        public string Product_Name { get; set; } //TR:Ürünün ismini tutar. ENG: Keeps product name.
        public double Product_Prices { get; set; }  // TR:Ürünün fiyatını tutar. ENG: Keep product price.
        public int Product_Pieces { get; set; }  // TR:Üründen kaç adet olduğunu tutar. ENG: Keeps how many items are available.
    }
    class Customer //TR: Müşterilerin verisinin tutulduğu class. ENG: This class keeping customers' datas.
    {
        public string Custommer_Name { get; set; }
        public string Password { get; set; }
        public double Wallet { get; set; } //TR: Cüzdanınız ENG: Your wallet.
    }
}
