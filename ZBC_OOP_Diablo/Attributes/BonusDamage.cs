using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class BonusDamage : WeaponAttribute
    {
        private int valueMin;

        public int ValueMin
        {
            get { return valueMin; }
            set { valueMin = value; }
        }

        private int valueMax;

        public int ValueMax
        {
            get { return valueMax; }
            set { valueMax = value; }
        }

        private BonusDamageType damageType;

        public BonusDamageType DamageType
        {
            get { return damageType; }
            set { damageType = value; }
        }


        public BonusDamage()
        {
            Type = AttributeType.Primary;
        }

        public override void CalculateAttributeValue(Weapon weapon)
        {
            Random rand = new Random();

            switch (weapon.Quality)
            {
                case WeaponQuality.Blue:
                    ValueMin = rand.Next(3, 6);
                    ValueMax = rand.Next(5, 8);
                    break;

                case WeaponQuality.Yellow:
                    if(weapon.Category == WeaponCategory.OneHanded)
                    {
                        valueMin = rand.Next(330, 376);
                        valueMax = rand.Next(500, 610);
                    }
                    else
                    {
                        valueMin = rand.Next(400, 450);
                        ValueMax = rand.Next(610, 650);
                    }

                    break;

                case WeaponQuality.Legendary:
                    if(weapon.Category == WeaponCategory.OneHanded)
                    {
                        ValueMin = rand.Next(981, 1200);
                        ValueMax = rand.Next(1175, 1491);
                    }
                    else
                    {
                        ValueMin = rand.Next(1177, 1440);
                        ValueMax = rand.Next(1410, 1788);
                    }

                    break;
            }

            Array values = Enum.GetValues(typeof(BonusDamageType));

            damageType = (BonusDamageType)values.GetValue(rand.Next(values.Length));
        }

        public override string GetTooltip()
        {
            return $"+{valueMin}-{valueMax} {damageType.ToString()} Damage";
        }
    }
}
