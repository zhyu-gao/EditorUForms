using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;
using UForms.Controls.Fields;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [ExposeControl("Foldout", "General")]
    public class Foldout : AbstractField<bool>
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
        public bool ToggleOnLabelClick { get; set; }


        public Foldout() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="unfolded"></param>
        /// <param name="toggleOnLabelClick"></param>
        public Foldout(string label = "", bool unfolded = false, bool toggleOnLabelClick = true,
            params GUILayoutOption[] options) : base(unfolded, label, options)
        {
            ToggleOnLabelClick = toggleOnLabelClick;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool DrawAndUpdateValue()
        {
            return EditorGUILayout.Foldout(m_cachedValue, Label);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(bool oldval, bool newval)
        {
            return oldval.Equals(newval);
        }
    }
}