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
    public class BoxLine : Control
    {
        /// <summary>
        /// Implementation of the OnBeforeDraw step.
        /// </summary>
        protected override void OnBeforeDraw()
        {
        }

        /// <summary>
        /// Implementation of the OnAfterDraw step.
        /// </summary>
        protected override void OnDraw()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(leftSpace);
            GUILayout.Box("", GUILayout.Width(UFormsApplication.WindowRect.width - 5 - leftSpace),
                GUILayout.Height(3));
            GUILayout.EndHorizontal();
        }
    }
}