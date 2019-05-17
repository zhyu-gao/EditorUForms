using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Vector3 Field", "Fields")]
    public class Vector3Field : AbstractField<Vector3>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public Vector3Field() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public Vector3Field(Vector3 value, string label, params GUILayoutOption[] options) : base(value, label, options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Vector3 DrawAndUpdateValue()
        {
            return EditorGUILayout.Vector3Field(Label, m_cachedValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(Vector3 oldval, Vector3 newval)
        {
            return oldval.Equals(newval);
        }
    }
}