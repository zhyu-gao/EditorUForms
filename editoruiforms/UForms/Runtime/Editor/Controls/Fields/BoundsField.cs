using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Bounds Field", "Fields")]
    public class BoundsField : AbstractField<Bounds>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public BoundsField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public BoundsField(Bounds value, string label, params GUILayoutOption[] options) : base(value, label, options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Bounds DrawAndUpdateValue()
        {
            return EditorGUILayout.BoundsField(new GUIContent(Label), m_cachedValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(Bounds oldval, Bounds newval)
        {
            return oldval.Equals(newval);
        }
    }
}