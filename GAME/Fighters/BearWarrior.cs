using System;

namespace GAME.Fighters
{
    public class BearWarrior : Fighter
    {
        //в конструкторе использован опциональный параметр(string name = "имя выбирает игрок")
        public BearWarrior(string name="имя выбирает игрок"):base(
            name,
            "Орк-Шаман",
            "Могущественные орки шаманы проживают одинокими отшельниками глубоко в лесах, и проктикуют ликонтропию.Специальный удар - атака медведя(при атаке есть вероятность 50% нанести рваную рану(урон равен показателю Strength*2)).",
            1,1,1,1,1)
        {

        }

        public override int UseUltimateStrike()
        {
            int chance = random.Next(1, 101);
            if (chance <= 50)
            {
                int totalDamage = Strength * 2;
                Console.WriteLine("Из рук {0} на секунду вырастают медвежьи когти и он делает  противнику рваную рану дополнительно нанося {1} урона.", Name, totalDamage);
                return totalDamage;
            }
            return 0;
        }
    }
}
