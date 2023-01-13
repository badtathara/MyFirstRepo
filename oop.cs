using System;
namespace Main
{
    class Program
    {
        static void Main()
        {
            // R - объект родительского класса
            MFC R = new MFC("Ольга", "Роман", "Валерия");
            R.Output();
            R.Tir();    
            // разделитель информации

            // D - объект дочернего класса
            DMFC D = new DMFC("Сусанна", "Андрей", "Артур", "Диана");
            D.Output();
            D.Tir();

            // V объект класса - внук, наследуется от DMFC
            VMFC V = new VMFC("Марина", "Петр", "Феодосий", "Екатерина", "Кукушкины");
            V.Output();
            V.Tir();

            // Дети и фамилия
            Console.WriteLine("Дети: " + R.GetChild());
            Console.WriteLine("Дети: " + D.GetChild());
            Console.WriteLine("Дети: " + V.GetChild());
            Console.WriteLine("Фамилия: " + V.GetName());
            V.Tir();
        }
    }
    // Инкапсуляция в классе MFC
    public class MFC
    {
        protected string mother;
        protected string father;
        protected string child;
        public MFC(string m, string f, string c)
        {
            mother = m;
            father = f;
            child = c;
        }
        // возврат имени ребенка
        public virtual string GetChild()
        {
            return child;
        }
        // вывод имен членов семьи
        public virtual void Output()
        {
            Console.WriteLine("Mать: " + mother);
            Console.WriteLine("Отец: " + father);
            Console.WriteLine("Ребенок: " + child);
        }
        // Рисование разграничительной линии (пригодится)
        public virtual void Tir()
        {
            Console.WriteLine("_____________________________");
        }
    }
    public class DMFC : MFC
    {
        protected string child2; // + 2-й ребенок
                                 // конструктор класса наследуется вот так:
        public DMFC(string m, string f, string c, string d) : base(m, f, c)
        {
            child2 = d;
        }
        // перегрузка метода (модификатор override)
        public override string GetChild()
        {
            return child + ", " + child2;
        }
        // Перегрузка метода - полиморфизм (добавим 2 ребенка)
        public override void Output()
        {
            base.Output();  // используем метод родительского класса
            Console.WriteLine("Второй ребенок: " + child2); // только добавление
        }
    }
    public class VMFC : DMFC
    {
        protected string name; // + фамилия семьи
        public VMFC(string m, string f, string c, string d, string n) : base(m, f, c, d)
        {
            name = n;
        }
        // Перегрузка метода - полиморфизм (добавим фамилию)
        public override void Output()
        {
            Console.WriteLine("Фамилия семьи: {0}", name);
            base.Output(); // будет использоваться метод класса DMFC
        }
        public string GetName()
        {
            return name;
        }
    }
}
