namespace _02._07
{
    internal class Program
    {

        struct Product
        {
            double price;
            string name;
            int count;

            public Product(double price, string name,int count)
            {
                this.price = price;
                this.name = name;
                this.count = count;
            }
            public double GetPrice() {  return price; }
            public string GetName() { return name; }
            public int GetCount() { return count; }
            public void SetPrice(double price) { this.price = price; }
            public void SetName(string name) { this.name = name; }
            public void SetCount(int count) { this.count = count; }

            public void Print()
            {
                Console.WriteLine(name.ToString() + " " + price.ToString() + " " + count.ToString());
            }


        }

        struct Check
        {
            double summa;
            double totalPrice;
            List<Product> products;
            const double armyTax=0.05;
            const double pensionTax = 0.08; 
            const double luxuryTax = 0.05; 
            const double taxForPrettyEyes = 0.1;
            const string nameShop = "Metro";
            const string addressShop = "Odesa, str. Sadova, 3";

            public Check()
            {
                products=new List<Product>();
                summa = 0;
            }
            public double GetSumma() { return summa; }
            public void SetSumma(double summ) {  this.summa = summ; }
            public List<Product> GetProducts() { return products; }
            public void AddProduct(Product product) { 
                products.Add(product);
                summa += product.GetPrice() * product.GetCount();
            }
            public void PrintCheck()
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Blue;
                Random random = new Random();
                Console.WriteLine("\t\t\t"+nameShop);
                Console.WriteLine("\t\t"+addressShop);
                Console.WriteLine("\t\t"+(DateTime.Now).ToString()+"\t"+(random.Next()%1000).ToString());
                Console.WriteLine("Терминал: " + (random.Next()%10000000).ToString());
                string cardNumber=" ";
                for(int i = 0; i < 16; i++)
                {
                    cardNumber.Replace(" ", ((random.Next() % 10).ToString()+" "));
                }
                Console.WriteLine("Номер карты: " + cardNumber);
                Console.WriteLine("Сумма: " + summa.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t\tТоварный Чек");
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Print();
                }
                totalPrice = summa;
                Console.WriteLine("Налог на армию: " + (summa*armyTax).ToString());
                totalPrice += summa * armyTax;
                Console.WriteLine("Пенсионный налог: " + (summa*pensionTax).ToString());
                totalPrice += summa * pensionTax;
                if (summa > 5000)
                {
                    Console.WriteLine("Налог на роскошь: " + (summa * luxuryTax).ToString());
                    totalPrice += summa * luxuryTax;
                }
                Console.WriteLine("Налог за красивые глазки: " + (summa * taxForPrettyEyes).ToString());
                totalPrice += summa * taxForPrettyEyes;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Итого: " + totalPrice);
                Console.WriteLine("Комиссия: 0%");
                Console.WriteLine("Налоговая инспекция: 23434545");
                Console.WriteLine("Ukraine");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }

        static void Main()
        {
            Check check=new Check();
            int count;
            Console.WriteLine("Введите количество продуктов:");
            count=Convert.ToInt32(Console.ReadLine());
            for(int i=0;i< count; i++)
            {
                Console.WriteLine("Введите название "+(i+1).ToString()+" продукта");
                string name= Console.ReadLine();
                Console.WriteLine("Введите цену " + (i + 1).ToString() + " продукта");
                double price=Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество " + (i + 1).ToString() + " продукта");
                int c=Convert.ToInt32(Console.ReadLine());
                check.AddProduct(new Product(price,name, c));
            }
            check.PrintCheck();
        }
    }
}
