using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class AreaDamage : WeaponAttribute
    {
        public AreaDamage()
        {
            Type = AttributeType.Primary;
            Min1HValues = new int[] { 10, 14, 16 };
            Max1HValues = new int[] { 12, 20, 24 };
            Min2HValues = new int[] { 10, 14, 16 };
            Max2HValues = new int[] { 10, 20, 24 };
        }

        public override string GetTooltip()
        {
            return $"Chance to Deal {Value}% Area Damage on Hit";
        }
    }
}
