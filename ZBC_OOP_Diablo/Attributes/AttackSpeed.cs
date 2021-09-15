using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class AttackSpeed : WeaponAttribute
    {
        public AttackSpeed()
        {
            Type = AttributeType.Primary;

            Min1HValues = new int[] { 2, 4, 5 };
            Max1HValues = new int[] { 2, 5, 7 };
            Min2HValues = new int[] { 2, 3, 5 };
            Max2HValues = new int[] { 2, 5, 7 };

        }

        public override string GetTooltip()
        {
            return $"Increases Attack Speed by {Value}%";
        }
    }
}
