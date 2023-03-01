namespace SkillFactory.Module_9
{
	class Task_9_1
	{
        static void Main(string[] args)
        {
            Exception MyException = new Exception("����� ����������");
            Exception[] exceptionsArr = { MyException, new ArgumentException(), new DivideByZeroException(), new IndexOutOfRangeException(), new NullReferenceException() };

            foreach (Exception ex in exceptionsArr)
            {
                try
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    class Task_9_2
    {
        static void Main(string[] args)
        {
            SortSurnames sortSurnames = new();
            string[] arrSurnames = { "����������", "�������", "��������", "��������", "�������" };

            sortSurnames.SortSurnamesEvent += ShowSortNum;
            sortSurnames.SortSurname(arrSurnames);
        }
        static void ShowSortNum(int sort)
        {
            switch (sort)
            {
                case 1:
                    Console.WriteLine("������ ������������ �� �����������");
                    break;
                case 2:
                    Console.WriteLine("������ ������������ �� ��������");
                    break;
            }
        }
        public class SortSurnames
        {
            public delegate void SortSurnamesDelegate(int sort);
            public event SortSurnamesDelegate? SortSurnamesEvent;
            public void SortSurname(string[] Surnames)
            {
                Console.WriteLine("������� 1 ��� 2 ��� ���������� �� ����������� ��� ��������");
                int sort = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (sort == 1)
                    {
                        IEnumerable<string> surnames = from Surname in Surnames orderby Surname.Substring(0, 1) select Surname;
                        foreach (string surname in surnames)
                        {
                            Console.WriteLine(surname);
                        }
                    }
                    else if (sort == 2)
                    {
                        IEnumerable<string> surnames = from Surname in Surnames orderby Surname.Substring(0, 1) descending select Surname;
                        foreach (string surname in surnames)
                        {
                            Console.WriteLine(surname);
                        }
                    }
                    else throw new Exception("������� �������� ��������");
                    ShowSort(sort);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            protected virtual void ShowSort(int sort)
            {
                SortSurnamesEvent?.Invoke(sort);
            }
        }
    }
}
