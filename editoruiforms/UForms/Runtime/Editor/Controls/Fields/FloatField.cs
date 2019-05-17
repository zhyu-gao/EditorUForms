using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Float Field", "Fields")]
    public class FloatField : AbstractField<float>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public FloatField() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public FloatField(float value, string label, params GUILayoutOption[] options) : base(value, label,options)
        {
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override float DrawAndUpdateValue()
        {
            return EditorGUILayout.FloatField(Label, m_cachedValue,options);
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