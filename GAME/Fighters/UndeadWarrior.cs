using System;

namespace GAME.Fighters
{
    public class UndeadWarrior:Fighter
    {
        //в конструкторе использован опциональный параметр(string name = "имя выбирает игрок")
        public UndeadWarrior(string name = "имя выбирает игрок") : base(
            name,
            "Некромант",
            "Некроманты - могучие волшебники которых поглатила тьма,уже не люди и не умершие,обреченные на вечные страдания...Специальный удар - касание смерти (при атаке есть вероятность 5% нанести чудовищный урон(урон равен показателю Damage*100)).",
            1, 1, 1, 1, 1)
        {

        }

        public override int UseUltimateStrike()
        {
            int chance = random.Next(1, 101);
            if (chance <= 5)
            {
                int totalDamage = Damage * 100;
                Console.WriteLine("{0} делает чудовищный удар нанося {1} урона.", Name, totalDamage);
                return totalDamage;
            }
            return 0;
        }
    }
}
