using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{   
    public abstract class Weapon
    {
        public WeaponType Type;
        public WeaponCategory Category;
        public WeaponQuality Quality;
        public List<IWeaponAttribute> attributes;
        public string Name;

        public Weapon(WeaponType type, WeaponCategory category, WeaponQuality quality)
        {
            this.Type = type;
            this.Category = category;
            this.Quality = quality;
            attributes = new List<IWeaponAttribute>();
        }
    }
}
