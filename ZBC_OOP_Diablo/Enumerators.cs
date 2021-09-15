using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public enum WeaponType
    {
        Axe,
        Dagger,
        Mace,
        Spear,
        Sword,
        CeremonialKnife,
        FistWeapon,
        Flail,
        MightyWeapon,
        Scythe
    }

    public enum WeaponQuality
    {
        Blue = 0,
        Yellow = 1,
        Legendary = 2
    }
    
    public enum WeaponCategory
    {
        OneHanded,
        TwoHanded
    }

    public enum BonusDamageType
    {
        Poison = 0,
        Cold = 1,
        Fire = 2,
        Lightning = 3,
        Arcane = 4,
        Holy = 5
    }

    public enum AttributeType
    {
        Primary,
        Secondary
    }
}
