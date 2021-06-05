using System;
using GAME.Fighters;

namespace GAME
{
    //в этом классе определена логика игры
    public class Game
    {
        private Random random;
        private FightState fightState;

        private Fighter player1;
        private Fighter player2;

        //конструктор
        public Game()
        {
            random = new Random();
            fightState = FightState.NextRound;
        }

        //метод в котором начинается игра
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Игрок 1 создает бойца...");
            player1 = CreateFighter();
            Console.Clear();
            Console.WriteLine("Игрок 2 создает бойца...");
            player2 = CreateFighter();
            Console.Clear();
            StartFight();
        }
        
        //в этом методе создается новый боец
        private Fighter CreateFighter()
        {
            Fighter fighter;
            int points = Constants.pointNumber;//очки распределяемых характеристик

            Console.WriteLine("Введите имя своего бойца...");
            string name = Console.ReadLine();
            Console.WriteLine("\nВыберите рассу бойца:\n1: Орк-Шаман\n2: Мяут\n3: Некромант\n4: Эльфийский ассасин");
            string fighterRace= Console.ReadLine();
            switch (fighterRace)
            {
                case "1":
                    fighter = new BearWarrior(name);
                    break;
                case "2":
                    fighter = new CatWarrior(name);
                    break;

                case "3":
                    fighter = new UndeadWarrior(name);
                    break;

                default:
                    fighter = new ElvenWarrior(name);
                    break;
            }

            while (points>0)
            {
                Console.Clear();
                fighter.ShowStats();
                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine("+1 Силы:      +{0} к урону", Constants.damageMultiplier);
                Console.WriteLine("+1 Ловкости:  +{0}% увернуться от атаки", Constants.dodgeChanceMultiplier);
                Console.WriteLine("+1 Живучести: +{0} HP", Constants.hpMultiplier);
                Console.WriteLine("+1 Удачи: +{0} шанс критического удара", Constants.criticalChanceMultiplier);
                Console.WriteLine("+1 Точности: +{0} шанс попадания", Constants.hitChanceMultiplier);
                Console.WriteLine();
                Console.WriteLine("Осталось очков умений: {0}", points);
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");
                Console.WriteLine("4: +1 Удачи");
                Console.WriteLine("5: +1 Точности");
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strength += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    case "3":
                        fighter.Vitality += 1;
                        break;
                    case "4":
                        fighter.Luck += 1;
                        break;
                    default:
                        fighter.Hit += 1;
                        break;
                }
                points -= 1;
            }
            fighter.IsDead += () => fightState = FightState.Stop;//потписка на событие IsDead
            return fighter;
        }

        //метод отвечающий за битву между бойцами
        private void StartFight()
        {
            //отсчет начала битвы
            for (int i = 3; i >0; i--)
            {
                Console.Clear();
                Console.WriteLine("{0}...", i);
                Console.ReadLine();
            }

            int round = 1;
            while (fightState==FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine("Раунд {0} ...",round);

                CalculateKick(player1, player2);
                CalculateKick(player2, player1);

                Console.WriteLine();
                Console.WriteLine("Игрок 1: ");
                player1.ShowStats();
                Console.WriteLine();
                Console.WriteLine("Игрок 2: ");
                player2.ShowStats();

                Console.ReadLine();

                round += 1;
            }
            Console.WriteLine("Бой окончен!!!");
            Console.ReadLine();
        }

        //в этом методе расчитывается логика ударов
        private void CalculateKick(Fighter agressor,Fighter victim)
        {
            if (victim.DodgeChance > random.Next(1, 101))
            {
                Console.WriteLine("{0} хотел ударить но противник вернулся от удара", agressor.Name);
            }
            else
            {
                victim.HP -= agressor.Kick();
                victim.HP -= agressor.UseUltimateStrike();
            }
        }
    }
}
