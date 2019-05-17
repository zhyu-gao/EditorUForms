using System.Collections;
using System.Collections.Generic;
using UForms.Decorators;
using UnityEngine;

namespace UForms.Controls.Extended
{
    public class LayoutList : Control
    {
        public Control m_content;
        private float m_indentationAmount;

        public LayoutList(bool horizontal = true)
        {
            m_content = new Control();
            m_content.AddDecorator(new ClipContent(horizontal));
            AddChild(m_content);
        }

        public void AddItem(Control item)
        {
            m_content.AddChild(item);
        }
    }
}