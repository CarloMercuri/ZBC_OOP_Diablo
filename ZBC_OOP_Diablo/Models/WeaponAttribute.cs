using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public abstract class WeaponAttribute
    {

        private AttributeType type;

        /// <summary>
        /// The type of the attribute (Primary or Secondary)
        /// </summary>
        public AttributeType Type 
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// The minimum values for 1 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        public int[] Min1HValues { get; set; }

        /// <summary>
        /// The maximum values for 1 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        public int[] Max1HValues { get; set; }

        /// <summary>
        /// The minimum values for 2 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        public int[] Min2HValues { get; set; }

        /// <summary>
        /// The maximum values for 2 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        public int[] Max2HValues { get; set; }

        /// <summary>
        /// The value that has been locked in place
        /// </summary>
        public int Value { get; set; }

        public WeaponAttribute()
        {
            
        }

        public virtual string GetTooltip()
        {
            return "";
        }


        public virtual void CalculateAttributeValue(Weapon weapon)
        {
            Random rand = new Random();
            int val = 0;

            if (weapon.Category == WeaponCategory.OneHanded)
            {
                val = rand.Next(Min1HValues[(int)weapon.Quality], Max1HValues[(int)weapon.Quality] + 1);
            }
            else
            {
                val = rand.Next(Min2HValues[(int)weapon.Quality], Max2HValues[(int)weapon.Quality] + 1);
            }

            Value = val;
        }
    }
}
