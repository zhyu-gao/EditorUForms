using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyField : AbstractField<SerializedProperty>
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
        public bool IncludeChildren { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        /// <param name="includeChildren"></param>
        public PropertyField(SerializedProperty value, string label = "", bool includeChildren = false,
            params GUILayoutOption[] options) : base(value,
            label, options)
        {
            IncludeChildren = includeChildren;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override SerializedProperty DrawAndUpdateValue()
        {
            IncludeChildren =
                EditorGUILayout.PropertyField(m_cachedValue, new GUIContent(Label), IncludeChildren, options);
            return m_cachedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(SerializedProperty oldval, SerializedProperty newval)
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