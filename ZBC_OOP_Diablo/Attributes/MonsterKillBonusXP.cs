using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class MonsterKillBonusXP : WeaponAttribute
    {
        public MonsterKillBonusXP()
        {
            Type = AttributeType.Secondary;

            Min1HValues = new int[] { 5, 50, 140 };
            Max1HValues = new int[] { 6, 99, 2000 };

            Min2HValues = new int[] { 1, 50, 140};
            Max2HValues = new int[] { 2, 79, 200};
        }

        public override string GetTooltip()
        {
            return $"Monster kills grant +{Value} experience";
        }


    }
}
