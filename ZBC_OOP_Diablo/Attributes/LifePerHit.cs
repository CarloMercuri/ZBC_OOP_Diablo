using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    class LifePerHit : WeaponAttribute
    {
        public LifePerHit()
        {
            Type = AttributeType.Primary;

            Min1HValues = new int[] { 1, 300, 14059 };
            Max1HValues = new int[] { 3, 420, 16875 };

            Min2HValues = new int[] { 1, 300, 14059 };
            Max2HValues = new int[] { 3, 420, 16875 };
        }

        public override string GetTooltip()
        {
            return $"+{Value} Life per Hit";
        }
    }
}
