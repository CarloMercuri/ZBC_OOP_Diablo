using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public interface IItemAttribute
    {
        /// <summary>
        /// The minimum values for 1 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        float[] Min1HValues { get; set; }
        
        float[] Min2HValues { get; set; }
       
        /// <summary>
        /// The value that has been locked in place
        /// </summary>
        float Value { get; set; }
    }
}
