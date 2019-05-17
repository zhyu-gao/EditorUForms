using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Text Field", "Fields")]
    public class TextField : AbstractField<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public bool PasswordMask { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected override bool UseBackingFieldChangeDetection
        {
            get { return true; }
        }

        public TextField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        /// <param name="passwordMask"></param>
        public TextField(string value, string label = "", bool passwordMask = false, params GUILayoutOption[] options) :
            base(value, label, options)
        {
            PasswordMask = passwordMask;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string DrawAndUpdateValue()
        {
            if (PasswordMask)
            {
                return GUILayout.PasswordField(m_cachedValue, '*', options);
            }
            else
            {
                return GUILayout.TextField(m_cachedValue, options);
            }
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