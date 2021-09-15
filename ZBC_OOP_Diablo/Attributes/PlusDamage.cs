using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class PlusDamage : WeaponAttribute
    {
        public PlusDamage()
        {            
            Type = AttributeType.Primary;
            Min1HValues = new int[] { 2, 3, 6 };
            Max1HValues = new int[] { 4, 7, 10 };
            Min2HValues = new int[] { 2, 4, 6 };
            Max2HValues = new int[] { 4, 7, 10 };
        }

        public override string GetTooltip()
        {
            return $"+{Value}% Damage";
        }
    }
}
