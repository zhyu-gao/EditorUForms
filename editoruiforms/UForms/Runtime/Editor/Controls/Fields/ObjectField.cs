using UnityEngine;
using UnityEditor;
using System.Collections;
using UForms.Attributes;

namespace UForms.Controls.Fields
{
    /// <summary>
    /// 
    /// </summary>
    [ExposeControl("Object Field", "Fields")]
    public class ObjectField : AbstractField<Object>
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
        public System.Type Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AllowSceneObjects { get; set; }


        public ObjectField() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="allowSceneObjects"></param>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public ObjectField(System.Type type, bool allowSceneObjects = false, Object value = null, string label = "",
            params GUILayoutOption[] options) :
            base(value, label, options)
        {
            Type = type;
            AllowSceneObjects = allowSceneObjects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Object DrawAndUpdateValue()
        {
            return EditorGUILayout.ObjectField(Label, m_cachedValue, Type, AllowSceneObjects, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldval"></param>
        /// <param name="newval"></param>
        /// <returns></returns>
        protected override bool TestValueEquality(Object oldval, Object newval)
        {
            if (oldval == null || newval == null)
            {
                if (oldval == null && newval == null)
                {
                    return true;
                }

                return false;
            }

            return oldval.Equals(newval);
        }
    }
}