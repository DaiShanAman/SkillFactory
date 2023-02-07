namespace SkillFactory.Module_7
{
	class Taks_7_7
	{
		abstract class Delivery
		{
			protected string address;
			public string Address { get; set; }
			string[] addresses = { "�����������, 8", "�������, ��� �����������", "�������� ����, 21" }
			public Delivery()
			{
				address = "����� ������������";
			}
			public abstract void DeliverTo();
		}

		class HomeDelivery : Delivery
		{
			public HomeDelivery()
			{
				string address;
				Console.WriteLine("������� ����� ������ ����");
				address = Console.ReadLine();
				Address = address;
			}
			public override void DeliverTo()
			{
				Console.WriteLine($"����� ����� ��������� �� ������ {Address}"); ;
			}
		}

		class PickPointDelivery : Delivery
		{
			public PickPointDelivery()
			{
				int key;
				string address;
				Console.WriteLine($"������� ����� ���������� � ��� ������ ������\n1. {addresses[0]}\n2. {addresses[1]}\n3. {addresses[2]}");
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
						Console.WriteLine("������ ������������ �����, ����� ����� ��������� � �������� ����� ������ �� �������: " + addresses[0]);
						address = addresses[0];
						break;
				}
				Address = address;
			}
			public override void DeliverTo()
			{
				Console.WriteLine($"����� ��������� �� ������ {Address}"); ;
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
				Console.WriteLine($"����� ��������� �� ������ ���������� �������� {Address}"); ;
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
				Console.WriteLine("������� �������� ������");
				description = Console.ReadLine();
				Console.WriteLine("������� ���� ������ ������ ����"); // ��� ����� ������� �������� �� ������ 5, �� ������� ����� �� �������, ������� ����� ���
				price = double.Parse(Console.ReadLine());
			}
			public Product(string description, double price)
			{
				this.description = description;
				this.price = price;
			}
			public override string ToString()
			{
				return "����� - " + description + "\n���� - " + price;
			}
		}

		static class ProductExtensions
		{
			public static double GetPriceOfProduct(this Product temp)
			{
				Console.WriteLine($"���� ������ {temp.Price} ������");
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
				Console.WriteLine($"����� ������: {number}");
				return number;
			}
		}
	}
}
