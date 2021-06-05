using System;

namespace GAME.Fighters
{
    //родительский класс бойцов
    public abstract class Fighter
    {
        protected Random random;//системный класс Random это генератор случайных чисел(создание переменной random)

        public delegate void IsDeadDelegate();//делегат 
        public event IsDeadDelegate IsDead;//событие определяющие смерть бойца

        public string Name { get; private set; }//имя бойца
        public string Race { get; private set; }//расса бойца
        public string UltimateStrike { get; private set; }//описание специального удара

        //описание идет парами каждая пара зависит друг от друга
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                Damage = value * Constants.damageMultiplier;
            }
        }//сила бойца
        public int Damage { get; private set; }//урон бойца

        private int agility;
        public int Agility
        {
            get { return agility; }
            set
            {
                agility = value;
                DodgeChance = value * Constants.dodgeChanceMultiplier;
            }
        }//ловкость бойца
        public int DodgeChance { get; private set; }//шанс увернуться от удара

        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HP = value * Constants.hpMultiplier;
            }
        }//живучесть бойца
        private int hp;//кол-во здоровья
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp <= 0)
                {
                    hp = 0;
                    IsDead();
                }
            }
        }

        private int luck;
        public int Luck
        {
            get { return luck; }
            set
            {
                luck = value;
                CriticalChance = value * Constants.criticalChanceMultiplier;
            }
        }//удача бойца
        public int CriticalChance { get; private set; }//шанс критического удара

        private int hit;
        public int Hit
        {
            get { return hit; }
            set
            {
                hit = value;
                HitChance = value * Constants.hitChanceMultiplier;
            }
        }//точность бойца
        public int HitChance { get; private set; }//шанс попадания

        //конструктор
        protected Fighter(string name,string race,string ultimateStrike,int strenght,int agility,int vitality,int luck,int hit)//параметры конструктора
        {
            random = new Random();//создание переменной random в конструкоре
            Name = name;
            Race = race;
            UltimateStrike = ultimateStrike;
            Strength = strenght;
            Agility = agility;
            Vitality = vitality;
            Luck = luck;
            Hit = hit;
        }

        //метод расчитывает кол-во нанесенного урона
        public int Kick()
        {
            int totalDamage = random.Next(Damage - 10, Damage + 11);//cистемный метод Next(есть нижний и верхний придел от -10 до +10,верхний придел +1)расчитывает случайные значения,TotalDamage - колво нанесенного урона
            Console.WriteLine("{0} ударил и нанес {1} урона!", Name, totalDamage);
            return totalDamage;
        }

        //абстрактный метод использования особого удара должен быть переопределен в дочерних классах
        public abstract int UseUltimateStrike();

        //метод выводит на консоль текущие состояние бойца
        public virtual void ShowStats()
        {
            Console.WriteLine("Имя: {0}\nРасса: {1}\nСила: {2}\t\tУрон: {3}\nЛовкость: {4}\t\tУворот: {5}\nЖивучесть: {6}\t\tКол-во жизней: {7}\nУдача: {8}\t\tКрит: {9}\nТочность: {10}\t\tШанс попадания: {11}\nОсобый удар: {12}",Name,Race,Strength,Damage,Agility,DodgeChance,Vitality,HP,Luck,CriticalChance,Hit,HitChance,UltimateStrike);
            Console.WriteLine();
        }
    }
}
