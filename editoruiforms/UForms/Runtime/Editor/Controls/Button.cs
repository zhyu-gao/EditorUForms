using System;
using UnityEngine;
using System.Collections;
using UForms.Events;
using UForms.Attributes;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Button", "General")]
    public class Button : Control
    {
        /// <summary>
        /// 
        /// </summary>
        //public event Click Clicked;
        public Action<ClickEventArgs, Event> Clicked;

        /// <summary>
        /// 
        /// </summary>
        public Action<ClickEventArgs, Event> MouseDown;

        /// <summary>
        /// 
        /// </summary>
        public Action<ClickEventArgs, Event> MouseUp;

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public Button(string text) : base()
        {
            Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="text"></param>
        public Button(string text = "", params GUILayoutOption[] options) : base(options)
        {
            Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDraw()
        {
            if (GUILayout.Button(Text, options))
            {
                int button = 0;

                if (Event.current != null)
                {
                    button = Event.current.button;
                }

                if (Clicked != null)
                {
                    Dirty = true;
                    Clicked(new ClickEventArgs(button), Event.current);
                }
            }
        }
    }
}