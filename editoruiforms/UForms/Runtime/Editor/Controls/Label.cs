using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Label", "General")]
    public class Label : Control
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Selectable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }


        public Label() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="selectable"></param>
        public Label(string text, bool selectable = false, params GUILayoutOption[] options) : base(options)
        {
            Text = text;
            Selectable = selectable;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDraw()
        {
            if (Selectable)
            {
                EditorGUILayout.SelectableLabel(Text, options);
            }
            else
            {
                EditorGUILayout.LabelField(Text, options);
            }
        }
    }
}