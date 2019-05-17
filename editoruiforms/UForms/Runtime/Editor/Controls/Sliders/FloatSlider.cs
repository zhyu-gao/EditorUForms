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
    [ExposeControl("Float Slider", "Sliders")]
    public class FloatSlider : AbstractField<float>
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
        public float LeftValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float RightValue { get; set; }


        public FloatSlider() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="label"></param>
        /// <param name="value"></param>
        public FloatSlider(float leftValue, float rightValue, string label = "", float value = 0,
            params GUILayoutOption[] options) : base(value, label, options)
        {
            LeftValue = leftValue;
            RightValue = rightValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override float DrawAndUpdateValue()
        {
            return EditorGUILayout.Slider(Label, m_cachedValue, LeftValue, RightValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(float oldval, float newval)
        {
            return oldval.Equals(newval);
        }
    }
}