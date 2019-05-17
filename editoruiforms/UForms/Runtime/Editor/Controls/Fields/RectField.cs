using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Rect Field", "Fields")]
    public class RectField : AbstractField<Rect>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public RectField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public RectField(Rect value, string label, params GUILayoutOption[] options) : base(value, label, options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Rect DrawAndUpdateValue()
        {
            return EditorGUILayout.RectField(Label, m_cachedValue, options);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(Rect oldval, Rect newval)
        {
            return oldval.Equals(newval);
        }
    }
}