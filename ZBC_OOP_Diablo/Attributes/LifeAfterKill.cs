using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class LifeAfterKill : WeaponAttribute
    {
        public LifeAfterKill()
        {
            Type = AttributeType.Secondary;

            Min1HValues = new int[] { 2, 947, 6428 };
            Max1HValues = new int[] { 8, 1380, 8914 };

            Min2HValues = new int[] { 2, 1421, 7324 };
            Max2HValues = new int[] { 8, 2071, 10154};
        }

        public override string GetTooltip()
        {
            return $"+{Value} Life After Each Kill";
        }
    }
}
