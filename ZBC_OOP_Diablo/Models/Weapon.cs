using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class Weapon
    {
        private WeaponType type;

        public WeaponType Type
        { 
            get { return type; }
            set { type = value; }
        }

        private WeaponCategory category;

        public WeaponCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        private WeaponQuality quality;

        public WeaponQuality Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        private List<WeaponAttribute> attributes;

        public List<WeaponAttribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int baseDamageMin;

        public int BaseDamageMin
        {
            get { return baseDamageMin; }
            set { baseDamageMin = value; }
        }

        private int baseDamageMax;

        public int BaseDamageMax
        {
            get { return baseDamageMax; }
            set { baseDamageMax = value; }
        }

        private float baseAttackSpeed;

        public float BaseAttackSpeed
        {
            get { return baseAttackSpeed; }
            set { baseAttackSpeed = value; }
        }

        private float weaponDPS;

        public float WeaponDPS
        {
            get { return weaponDPS; }
            set { weaponDPS = value; }
        }


        public Weapon(WeaponType type, WeaponCategory category, WeaponQuality quality)
        {
            this.type = type;
            this.category = category;
            this.quality = quality;
            attributes = new List<WeaponAttribute>();

            if(category == WeaponCategory.OneHanded)
            {
                BaseAttackSpeed = 1f;
            }
            else
            {
                baseAttackSpeed = 1.7f;
            }

            switch (quality)
            {
                case WeaponQuality.Blue:
                    if(category == WeaponCategory.OneHanded)
                    {
                        baseDamageMin = 8;
                        baseDamageMax = 10;
                    }
                    else
                    {
                        baseDamageMin = 14;
                        baseDamageMax = 16;
                    }
                    
                    break;

                case WeaponQuality.Yellow:
                    if (category == WeaponCategory.OneHanded)
                    {
                        baseDamageMin = 251;
                        baseDamageMax = 465;
                    }
                    else
                    {
                        baseDamageMin = 856;
                        baseDamageMax = 1280;
                    }
                    break;

                case WeaponQuality.Legendary:
                    if (category == WeaponCategory.OneHanded)
                    {
                        baseDamageMin = 316;
                        baseDamageMax = 585; 
                    }
                    else
                    {
                        baseDamageMin = 1462;
                        baseDamageMax = 1609;
                    }
                    break;
            }
        }

        public void CalculateWeaponDPS()
        {
            foreach(WeaponAttribute attribute in attributes)
            {
                if(attribute.GetType() == typeof(BonusDamage))
                {
                    BonusDamage dmg = attribute as BonusDamage;

                    baseDamageMin += dmg.ValueMin;
                    baseDamageMax += dmg.ValueMax;
                }

                if (attribute.GetType() == typeof(AttackSpeed))
                {
                    baseAttackSpeed += (baseAttackSpeed / 100) * attribute.Value;
                }


            }

            weaponDPS = Convert.ToInt32((((float)baseDamageMin + (float)baseDamageMax) / 2) * baseAttackSpeed);

            foreach (WeaponAttribute attribute in attributes)
            {
                if(attribute.GetType() == typeof(PlusDamage))
                {
                    weaponDPS += (weaponDPS / 100) * attribute.Value;
                }
            }

        }


    }
}
