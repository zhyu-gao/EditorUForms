using UnityEngine;
using System.Collections;

namespace UForms.Events
{
    /// <summary>
    /// A nicer enumeration for commonly used mouse buttons.
    /// </summary>
    public enum MouseButton
    {
        /// <summary>
        /// Left mouse button.
        /// </summary>
        Left,

        /// <summary>
        /// Middle mouse button.
        /// </summary>
        Middle,

        /// <summary>
        /// Right mouse button.
        /// </summary>
        Right,

        /// <summary>
        /// Other unspecified mouse button. Use the raw button value to determine which in this case.
        /// </summary>
        Other
    }

    /// <summary>
    /// Click event arguments.
    /// </summary>
    public class ClickEventArgs
    {        
        /// <summary>
        /// The raw button value provided by Unity.
        /// </summary>
        public int          rawButton;

        /// <summary>
        /// A nicer enumeration for commonly used mouse buttons.
        /// </summary>
        public MouseButton  button;

        /// <summary>
        /// Constructor for <c>ClickEventArgs</c>.
        /// </summary>
        /// <param name="btn">Raw button value</param>
        public ClickEventArgs( int btn )
        {
            rawButton = btn;

            switch( btn )
            {
                case 0:     button = MouseButton.Left;      break;
                case 1:     button = MouseButton.Right;     break;
                case 2:     button = MouseButton.Middle;    break;
                default:    button = MouseButton.Other;     break;
            }
        }
    }
}