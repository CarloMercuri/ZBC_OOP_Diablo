﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class Mace : Weapon
    {
        public Mace(WeaponType type, WeaponCategory category, WeaponQuality quality) 
            : base(type, category, quality)
        {
            
        }
    }
}