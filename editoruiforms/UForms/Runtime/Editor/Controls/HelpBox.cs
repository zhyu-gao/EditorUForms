using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Help Box", "General")]
    public class HelpBox : Control
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageType Type { get; set; }

        public HelpBox() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        public HelpBox(string text, MessageType type = MessageType.None, params GUILayoutOption[] options) :
            base(options)
        {
            Text = text;
            Type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDraw()
        {
            EditorGUILayout.HelpBox(Text, Type);
        }
    }
}