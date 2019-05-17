using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Tag Field", "Fields")]
    public class TagField : AbstractField<string>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }


        public TagField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public TagField(string value, string label, params GUILayoutOption[] options) : base(value, label, options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string DrawAndUpdateValue()
        {
            return EditorGUILayout.TagField(Label, m_cachedValue, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(string oldval, string newval)
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