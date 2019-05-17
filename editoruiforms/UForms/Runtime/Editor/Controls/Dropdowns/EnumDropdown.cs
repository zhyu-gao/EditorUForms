using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Controls.Fields;

namespace UForms.Controls.Dropdowns
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumDropdown : AbstractField<System.Enum>
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
        /// <param name="value"></param>
        /// <param name="label"></param>
        public EnumDropdown(System.Enum value, string label = "", params GUILayoutOption[] options) : base(value, label,
            options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override System.Enum DrawAndUpdateValue()
        {
            return EditorGUILayout.EnumPopup(Label, m_cachedValue,options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(System.Enum oldval, System.Enum newval)
        {
            return oldval.Equals(newval);
        }
    }
}