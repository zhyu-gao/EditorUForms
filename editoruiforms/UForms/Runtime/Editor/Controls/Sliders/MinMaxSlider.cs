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
    public class MinMaxSlider : AbstractField<float[]>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return false; }
        }


        /// <summary>
        /// 
        /// </summary>
        public float MinLimit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float MaxLimit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float MinValue
        {
            get { return Value[0]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float MaxValue
        {
            get { return Value[1]; }
        }


        public MinMaxSlider() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="minLimit"></param>
        /// <param name="maxLimit"></param>
        /// <param name="minvalue"></param>
        /// <param name="maxValue"></param>
        /// <param name="label"></param>
        public MinMaxSlider(float minLimit, float maxLimit, float minvalue, float maxValue, string label = "",
            params GUILayoutOption[] options) : base(null, label, options)
        {
            m_cachedValue = new float[2]
            {
                minvalue,
                maxValue
            };

            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override float[] DrawAndUpdateValue()
        {
            EditorGUILayout.MinMaxSlider(new GUIContent(Label), ref m_cachedValue[0], ref m_cachedValue[1],
                MinLimit, MaxLimit, options);
            return m_cachedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(float[] oldval, float[] newval)
        {
            return true;
        }
    }
}