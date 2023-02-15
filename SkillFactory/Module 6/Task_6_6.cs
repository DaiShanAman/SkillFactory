namespace SkillFactory.Module_6
{
    class Task_6_5
    {
        //6.6.2
        class User
        {
            private int age;
            public int Age
            {
                get
                {
                    return age;
                }

                set
                {
                    if (value < 18)
                    {
                        Console.WriteLine("Возраст должен быть не меньше 18");
                    }
                    else
                    {
                        age = value;
                    }
                }
            }
            
            private string login = string.Empty;
            public string Login
            {
                get { return login; }
                set {
                    if (value.Length < 3)
                    {
                        Console.WriteLine("Имя должно состоять хотя бы из 3х символов");
                    }
                    else
                    {
                        login = value;
                    }
                }
            }

            private string email = string.Empty;
            public string Email
            {
                get { return email; }
                set
                {
                    if (!value.Contains('@'))
                    {
                        Console.WriteLine("В почтовом адресе должен быть символ \"@\"");
                    }
                    else
                    {
                        email = value;
                    }
                }
            }
        }
    }
}
