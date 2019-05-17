using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UForms.Application;
using UForms.Controls;
using UForms.Decorators;
using UForms.Events;

namespace UForms.Controls.Extended
{
    public class FoldoutList : Control
    {
        public Foldout m_foldout;
        public Control m_content;
        private string title;
        private float m_indentationAmount;

        public FoldoutList(string title, float indentation, bool unfolded = true)
            : base()
        {
            m_indentationAmount = indentation;
            this.title = title;
            unfolded = EditorPrefs.GetBool("foldout-" + title);
            m_foldout = new Foldout(title, unfolded);
            m_content = new Control();
            AddChild(m_foldout);
            AddChild(m_content);
            m_foldout.ValueChange += FoldoutValueChange;
            SetFoldState(unfolded);
        }

        public void AddItem(Control item)
        {
            item.leftSpace = m_indentationAmount;
            m_content.AddChild(item);
        }

        void FoldoutValueChange(EditEventArgs args, Event nativeEvent)
        {
            SetFoldState((bool) args.newValue);
            EditorPrefs.SetBool("foldout-" + title, (bool) args.newValue);
        }
        
        private void SetFoldState(bool state)
        {
            m_content.Visibility = (state ? VisibilityMode.Visible : VisibilityMode.Collapsed);
            Dirty = true;
        }
    }
}