using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class SkillCooldown : WeaponAttribute
    {
        public SkillCooldown()
        {
            Type = AttributeType.Primary;
            Min1HValues = new int[] { 4, 5, 6 };
            Max1HValues = new int[] { 5, 9, 10 };
            Min2HValues = new int[] { 4, 5, 6 };
            Max2HValues = new int[] { 5, 9, 10 };
        }

        public override string GetTooltip()
        {
            return $"Reduces cooldown of all skills by {Value}%";
        }
    }
}
