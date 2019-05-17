using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UForms.Application;
using UForms.Controls;
using UForms.Attributes;

namespace UForms.Decorators
{
    /// <summary>
    /// This decorator creates a clipping area for the contained children, based on the controls bounding rectangle.
    /// </summary>

    [ExposeControl("Clip Content", "Decorators")]
    public class ClipContent : Decorator
    {
        private bool horizontal;
        private bool cutoffLine;

        public ClipContent(bool horizontal, bool cutoffLine = false)
        {
            this.horizontal = horizontal;
            this.cutoffLine = cutoffLine;
        }

        /// <summary>
        /// Implementation of the OnLayout step.
        /// </summary>
        protected override void OnLayout()
        {
        }

        /// <summary>
        /// Implementation of the OnBeforeDraw step.
        /// </summary>
        protected override void OnBeforeDraw()
        {
            if (horizontal)
            {
                EditorGUILayout.BeginHorizontal();
            }
            else
            {
                EditorGUILayout.BeginVertical();
            }
            GUILayout.Space(m_boundControl.parentLeftSpace);
        }

        /// <summary>
        /// Implementation of the OnAfterDraw step.
        /// </summary>
        protected override void OnAfterDraw()
        {
            if (horizontal)
            {
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.EndVertical();
            }

            if (cutoffLine)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(m_boundControl.leftSpace);
                GUILayout.Box("", GUILayout.Width(UFormsApplication.WindowRect.width - 5), GUILayout.Height(3));
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}