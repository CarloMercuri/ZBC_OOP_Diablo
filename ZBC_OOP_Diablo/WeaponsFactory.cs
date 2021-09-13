using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class WeaponsFactory
    {
        private List<IWeaponAttribute> PrimaryAttributes;
        private List<IWeaponAttribute> SecondaryAttributes;

        public WeaponsFactory()
        {

        }

        public void CreateWeapon()
        {
            Weapon wpn = new Mace(WeaponType.Mace, WeaponCategory.OneHanded, WeaponQuality.Yellow);
                
            
               
        }
    }
}
