using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;
using UForms.Controls.Fields;

namespace UForms.Controls.Sliders
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Int Slider", "Sliders")]
    public class IntSlider : AbstractField<int>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LeftValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RightValue { get; set; }


        public IntSlider() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="label"></param>
        /// <param name="value"></param>
        public IntSlider(int leftValue, int rightValue, string label = "", int value = 0,
            params GUILayoutOption[] options) : base(value, label, options)
        {
            LeftValue = leftValue;
            RightValue = rightValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override int DrawAndUpdateValue()
        {
            return EditorGUILayout.IntSlider(Label, m_cachedValue, LeftValue, RightValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(int oldval, int newval)
        {
            return oldval.Equals(newval);
        }
    }
}