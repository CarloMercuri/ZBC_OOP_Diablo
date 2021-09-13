using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public interface IWeaponAttribute
    {
        /// <summary>
        /// The minimum values for 1 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        float[] Min1HValues { get; set; }

        /// <summary>
        /// The maximum values for 1 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        float[] Max1HValues { get; set; }

        /// <summary>
        /// The minimum values for 2 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        float[] Min2HValues { get; set; }

        /// <summary>
        /// The maximum values for 2 handed weapons as array. 0 = blue, 1 = yellow, 2 = legendary
        /// </summary>
        float[] Max2HValues { get; set; }

        /// <summary>
        /// The value that has been locked in place
        /// </summary>
        float Value { get; set; }

        /// <summary>
        /// The tooltip that will show on the UI
        /// </summary>
        string ToolTip { get; set; }

        // Methods

        void AssignValue(float value);
    }
}
