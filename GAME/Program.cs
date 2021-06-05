using System;
using GAME.Fighters;//потключаем пространтсво имен папки Fighters

namespace GAME
{
    class Program
    {
        static void Main()
        {
            Menu();
        }

        //метод отвечающий за главное меню
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("БОЙЦОВСКИЙ КЛУБ\n");
            Console.WriteLine("1 - Начать игру");
            Console.WriteLine("2 - Правила");
            Console.WriteLine("3 - Выход");
            string option = Console.ReadLine();//символ (1,2,3) который выбирает игрок в стартовом меню
            if (option=="1")
            {
                Game game = new Game();
                game.StartGame();
            }
            if (option=="2")
            {
                Rules();
            }
            if (option=="3")
            {
                return;//если return используется в методе void он просто выходит из него(метода)
            }

            Menu();//рекурсия(метод вызывает сам себя),пока игрок не введет значение 3 метод продолжит вызывать сам себя
        }

        //метод описывающий правила игры
        static void Rules()
        {
            Console.Clear();//очищает консоль
            Console.WriteLine("+1 Силы:      +{0} к урону", Constants.damageMultiplier);
            Console.WriteLine("+1 Ловкости:  +{0}% увернуться от атаки", Constants.dodgeChanceMultiplier);
            Console.WriteLine("+1 Живучести: +{0} HP", Constants.hpMultiplier);
            Console.WriteLine("+1 Удачи:     +{0} шанс критического удара", Constants.criticalChanceMultiplier);
            Console.WriteLine("+1 Точности:  +{0} шанс попадания", Constants.hitChanceMultiplier);
            new BearWarrior().ShowStats();
            new CatWarrior().ShowStats();
            new UndeadWarrior().ShowStats();
            new ElvenWarrior().ShowStats();
            Console.ReadLine();
        }
    }
}
