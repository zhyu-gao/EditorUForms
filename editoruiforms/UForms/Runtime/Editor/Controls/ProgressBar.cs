using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Progress Bar", "General")]
    public class ProgressBar : Control
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Progress { get; set; }

        public Rect ScreenRect { get; set; }

        public ProgressBar() : base()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="progress"></param>
        public ProgressBar(Rect screenRect, string text, float progress = 0.0f, params GUILayoutOption[] options) :
            base(options)
        {
            ScreenRect = screenRect;
            Text = text;
            Progress = progress;
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnDraw()
        {
            Progress = Mathf.Clamp01(Progress);
            EditorGUI.ProgressBar(ScreenRect, Progress, Text);
        }
    }
}