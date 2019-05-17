using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Layer Field", "Fields")]
    public class LayerField : AbstractField<int>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public LayerField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public LayerField(int value, string label, params GUILayoutOption[] options) : base(value, label, options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override int DrawAndUpdateValue()
        {
            return EditorGUILayout.LayerField(Label, m_cachedValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(int oldval, int newval)
        {
            return oldval.Equals(newval);
        }
    }
}