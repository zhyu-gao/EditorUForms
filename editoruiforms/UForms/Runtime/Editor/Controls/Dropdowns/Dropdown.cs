using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Controls.Fields;

namespace UForms.Controls.Dropdowns
{
    /// <summary>
    /// 
    /// </summary>
    public class Dropdown : AbstractField<int>
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
        public string[] OptionNames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionNames"></param>
        /// <param name="label"></param>
        /// <param name="selection"></param>
        public Dropdown(string[] optionNames, string label = "", int selection = 0, params GUILayoutOption[] options) :
            base(selection, label, options)
        {
            OptionNames = optionNames;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override int DrawAndUpdateValue()
        {
            return EditorGUILayout.Popup(m_cachedValue, OptionNames,options);
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