namespace SkillFactory.Module_6
{
    class Taks_6_2
    {
       class Rectangle
        {
            public int a;
            public int b;
            public Rectangle()
            {
                a = 6;
                b = 4;
            }

            public Rectangle(int side)
            {
                a = side;
                b = side;
            }

            public Rectangle(int first, int second)
            {
                a = first;
                b = second;
            }

            public int Square()
            {
                return a * b;
            }
        }
    }
}
