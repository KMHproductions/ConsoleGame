using System;

namespace GAME.Fighters
{
    public class ElvenWarrior:Fighter
    {
        //в конструкторе использован опциональный параметр (string name = "имя выбирает игрок")
        public ElvenWarrior(string name = "имя выбирает игрок") : base(
            name,
            "Эльфийский ассасин",
            "Когда скорость и мастерсво эльфийских воинов достигает своего пика они становятся ассасинами,безшумными убийцами,способными прикончить цель с пары ударов.Специальный удар - мастерство ассасина (при атаке к текущему показателю урона добавляется показатель силы).",
            1, 1, 1, 1, 1)
        {

        }

        public override int UseUltimateStrike()
        {
            int totalDamage = Strength;
            Console.WriteLine("Годами отточеные навыки боя позволяют {0} наносить дополнительно {1} урона.", Name, totalDamage);
            return totalDamage;
        }
    }
}
