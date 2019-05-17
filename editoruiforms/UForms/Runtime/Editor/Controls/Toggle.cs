using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;
using UForms.Controls.Fields;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Toggle", "General")]
    public class Toggle : AbstractField<bool>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }

        public Toggle() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <param name="labelOnRight"></param>
        public Toggle(string label, bool value = false, params GUILayoutOption[] options) : base(value, label, options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool DrawAndUpdateValue()
        {
            return GUILayout.Toggle(m_cachedValue, Label, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(bool oldval, bool newval)
        {
            return oldval.Equals(newval);
        }
    }
}