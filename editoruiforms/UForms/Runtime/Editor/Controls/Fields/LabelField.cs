using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Label Field", "Fields")]
    public class LabelField : AbstractField<string>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public LabelField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public LabelField(string value, string label = "", params GUILayoutOption[] options) : base(value, label,
            options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string DrawAndUpdateValue()
        {
            // Not sure why this is a field by Unity's definition...
            GUILayout.Label(m_cachedValue, options);
            return Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(string oldval, string newval)
        {
            return true; // Never going to change!
        }
    }
}