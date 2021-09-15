using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class Vitality : WeaponAttribute
    {
        public Vitality()
        {
            Type = AttributeType.Primary;
            Min1HValues = new int[] { 18, 300, 626 };
            Max1HValues = new int[] { 26, 524, 750 };
            Min2HValues = new int[] { 1, 450, 946 };
            Max2HValues = new int[] { 26, 494, 1125 };
        }

        public override string GetTooltip()
        {
            return $"+{Value} Vitality";
        }
    }
}
