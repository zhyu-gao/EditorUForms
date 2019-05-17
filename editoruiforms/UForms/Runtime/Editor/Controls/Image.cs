using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UForms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class Image : Control
    {
        /// <summary>
        /// 
        /// </summary>
        public Texture DrawTexture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Material DrawMaterial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DrawTransparent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DrawAlpha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ScaleMode Scale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Rect? TexCoords { get; set; }

        public Rect ScreenRect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="texCoords"></param>
        /// <param name="scaleMode"></param>
        /// <param name="drawAlpha"></param>
        /// <param name="drawTransparent"></param>
        /// <param name="mat"></param>
        public Image(Rect screenRect, Texture tex = null, Rect? texCoords = null,
            ScaleMode scaleMode = ScaleMode.ScaleToFit, bool drawAlpha = false, bool drawTransparent = true,
            Material mat = null) : base()
        {
            DrawTexture = tex;
            Scale = scaleMode;
            DrawAlpha = drawAlpha;
            DrawTransparent = drawTransparent;
            DrawMaterial = mat;
            TexCoords = texCoords;
            ScreenRect = screenRect;
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnDraw()
        {
            if (DrawTexture == null)
            {
                return;
            }

            if (DrawAlpha)
            {
                EditorGUI.DrawTextureAlpha(ScreenRect, DrawTexture, Scale);
            }
            else
            {
                if (TexCoords != null)
                {
                    GUI.DrawTextureWithTexCoords(ScreenRect, DrawTexture, TexCoords ?? default(Rect), DrawTransparent);
                }
                else
                {
                    if (DrawTransparent)
                    {
                        EditorGUI.DrawTextureTransparent(ScreenRect, DrawTexture, Scale);
                    }
                    else
                    {
                        EditorGUI.DrawPreviewTexture(ScreenRect, DrawTexture, DrawMaterial, Scale);
                    }
                }
            }
        }
    }
}