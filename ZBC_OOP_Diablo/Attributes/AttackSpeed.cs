using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo.Attributes
{
    public class AttackSpeed : IWeaponAttribute
    {
        private float[] min1HValues;

        public float[] Min1HValues
        {
            get { return min1HValues; }
            set { min1HValues = value; }
        }

        private float[] max1HValues;

        public float[] Max1HValues
        {
            get { return max1HValues; }
            set { max1HValues = value; }
        }

        private float[] min2HValues;

        public float[] Min2HValues
        {
            get { return min2HValues; }
            set { min2HValues = value; }
        }

        private float[] max2HValues;

        public float[] Max2HValues
        {
            get { return max2HValues; }
            set { max2HValues = value; }
        }

        private float value;

        public float Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private string toolTip;

        public string ToolTip
        {
            get { return toolTip; }
            set { this.toolTip = value; }
        }

        public AttackSpeed()
        {
            min1HValues = new float[] { 2, 4, 5 };
            max2HValues = new float[] { 2, 5, 7 };

        }

        public void AssignValue(float value)
        {
            this.value = value;

            toolTip = $"Increases Attack Speed by {value}%";
        }

    }
}
