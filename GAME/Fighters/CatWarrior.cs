using System;

namespace GAME.Fighters
{
    public class CatWarrior:Fighter
    {
        //в конструкторе использован опциональный параметр(string name = "имя выбирает игрок")
        public CatWarrior(string name = "имя выбирает игрок") : base(
            name,
            "Мяут",
            "Мяуты - расса кошек-людей,эксперимент магов,который вышел из под контроля...Проживают в саваннах Африки.Специальный удар - быстрые атаки (при атаке есть вероятность 25% нанесение двойного урона(урон равен показателю Damage*2)).",
            1, 1, 1, 1, 1)
        {

        }

        public override int UseUltimateStrike()
        {
            int chance = random.Next(1, 101);
            if (chance<=25)
            {
                int totalDamage = Damage * 2;
                Console.WriteLine("На секунду лапы {0} делают молниеносную атаку дополнительно нанося {1} урона.", Name, totalDamage);
                return totalDamage;
            }
            return 0;
        }
    }
}
