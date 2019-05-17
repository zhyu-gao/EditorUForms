using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Controls.Fields;

namespace UForms.Controls.Dropdowns
{
    /// <summary>
    /// 
    /// </summary>
    public class IntDropdown : AbstractField<int>
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
        public int[] OptionValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] OptionNames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionValues"></param>
        /// <param name="optionNames"></param>
        /// <param name="label"></param>
        /// <param name="selection"></param>
        public IntDropdown(int selection, string[] optionNames, int[] optionValues, string label = "", params GUILayoutOption[] options) : base(selection,
            label,options)
        {
            OptionValues = optionValues;
            OptionNames = optionNames;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override int DrawAndUpdateValue()
        {
            return EditorGUILayout.IntPopup(m_cachedValue, OptionNames, OptionValues,options);
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