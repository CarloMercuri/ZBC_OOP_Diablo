using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class ResourceCost : WeaponAttribute
    {
        public ResourceCost()
        {
            Type = AttributeType.Primary;
            Min1HValues = new int[] { 5, 7, 8 };
            Max1HValues = new int[] { 6, 9, 10 };

            Min2HValues = new int[] { 5, 7, 8 };
            Max2HValues = new int[] { 6, 9, 10 };          
        }

        public override string GetTooltip()
        {
            return $"Reduces all resource costs by {Value}%";
        }


    }
}
