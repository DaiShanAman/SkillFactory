namespace SkillFactory.Module_7
{
	class Taks_7_7
	{
		abstract class Delivery
		{
			protected string address;
			public string Address { get; set; }
			string[] addresses = { "Космонавтов, 8", "Пушкина, дом Колотушкина", "Проспект Мира, 21" }
			public Delivery()
			{
				address = "адрес неустановлен";
			}
			public abstract void DeliverTo();
		}

		class HomeDelivery : Delivery
		{
			public HomeDelivery()
			{
				string address;
				Console.WriteLine("Введите адрес вашего дома");
				address = Console.ReadLine();
				Address = address;
			}
			public override void DeliverTo()
			{
				Console.WriteLine($"Товар будет доставлен по адресу {Address}"); ;
			}
		}

		class PickPointDelivery : Delivery
		{
			public PickPointDelivery()
			{
				int key;
				string address;
				Console.WriteLine($"Введите номер ближайшего к вам пункта выдачи\n1. {addresses[0]}\n2. {addresses[1]}\n3. {addresses[2]}");
				key = int.Parse(Console.ReadLine());
				switch (key)
				{
					case 1:
						address = addresses[0];
						break;
					case 2:
						address = addresses[1];
						break;
					case 3:
						address = addresses[2];
						break;
					default:
						Console.WriteLine("Указан некорректный номер, товар будет доставлен в основной пункт выдачи по адрессу: " + addresses[0]);
						address = addresses[0];
						break;
				}
				Address = address;
			}
			public override void DeliverTo()
			{
				Console.WriteLine($"Товар доставлен по адресу {Address}"); ;
			}
		}

		class ShopDelivery : Delivery
		{
			public ShopDelivery()
			{
				Address = addresses[0];
			}
			public override void Deliver()
			{
				Console.WriteLine($"Товар доставлен по адресу нахождения магазина {Address}"); ;
			}
		}


		class Product
		{
			private string description;
			private double price;
			public double Price
			{
				get
				{
					return price;
				}
				set
				{
					if (value > 0)
					{
						price = value;
					}
				}
			}
			public Product()
			{
				Console.WriteLine("Введите название товара");
				description = Console.ReadLine();
				Console.WriteLine("Введите цену товара больше нуля"); // тут можно впилить проверку из модуля 5, но задание этого не требует, поэтому пусть так
				price = double.Parse(Console.ReadLine());
			}
			public Product(string description, double price)
			{
				this.description = description;
				this.price = price;
			}
			public override string ToString()
			{
				return "Товар - " + description + "\nЦена - " + price;
			}
		}

		static class ProductExtensions
		{
			public static double GetPriceOfProduct(this Product temp)
			{
				Console.WriteLine($"Цена товара {temp.Price} рублей");
				double result = temp.Price;
				return result;
			}
		}


		class Order<TDelivery> where TDelivery : Delivery
		{
			public TDelivery Delivery;
			private Product[] Goods;
			private int number;
			public int Number { get; set; }
			public string Description;

			public Order(TDelivery Delivery, Product[] products)
			{
				Goods = products;
				this.Delivery = Delivery;
			}
			public void DisplayAddress()
			{
				Console.WriteLine(Delivery.Address);
			}
			public T DisplayNumber()
			{
				Console.WriteLine($"Номер заказа: {number}");
				return number;
			}
		}
	}
}
