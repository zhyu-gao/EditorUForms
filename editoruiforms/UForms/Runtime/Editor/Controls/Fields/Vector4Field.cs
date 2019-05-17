using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Vector4 Field", "Fields")]
    public class Vector4Field : AbstractField<Vector4>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public Vector4Field() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public Vector4Field(Vector4 value, string label, params GUILayoutOption[] options) : base(value, label, options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Vector4 DrawAndUpdateValue()
        {
            return EditorGUILayout.Vector4Field(Label, m_cachedValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(Vector4 oldval, Vector4 newval)
        {
            return oldval.Equals(newval);
        }
    }
}