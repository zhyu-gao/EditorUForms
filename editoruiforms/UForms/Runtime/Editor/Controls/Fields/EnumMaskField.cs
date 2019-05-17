using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumMaskField : AbstractField<System.Enum>
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
        /// <param name="value"></param>
        /// <param name="label"></param>
        public EnumMaskField(System.Enum value, string label = "", params GUILayoutOption[] options) : base(value,
            label, options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override System.Enum DrawAndUpdateValue()
        {
            if (m_cachedValue == null)
            {
                // Throw some kind of exception here? this value should always be initialized...
                return null;
            }

            return EditorGUILayout.EnumMaskField(Label, m_cachedValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(System.Enum oldval, System.Enum newval)
        {
            if (oldval == null || newval == null)
            {
                if (oldval == null && newval == null)
                {
                    return true;
                }

                return false;
            }

            return oldval.Equals(newval);
        }
    }
}