using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public class MaskField : AbstractField<int>
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
        public List<string> Options { get; private set; }


        public MaskField() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="label"></param>
        public MaskField(int value, string[] optionss = default(string[]), string label = "",
            params GUILayoutOption[] options) : base(value, label, options)
        {
            Options = new List<string>();

            if (options != null)
            {
                Options.AddRange(optionss);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override int DrawAndUpdateValue()
        {
            return EditorGUILayout.MaskField(Label, m_cachedValue, Options.ToArray(), options);
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