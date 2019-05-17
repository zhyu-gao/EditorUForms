// Uncomment this to visually debug control screen rects
//#define UFORMS_DEBUG_RECTS

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UForms.Decorators;
using UForms.Core;
using UForms.Application;

namespace UForms.Controls
{
    /// <summary>
    /// Defines a base class for all controls.
    /// </summary>
    public class Control : IDrawable
    {
        /// <summary>
        /// Control visibility mode.
        /// </summary>
        public enum VisibilityMode
        {
            /// <summary>
            /// Control is visible.
            /// </summary>
            Visible,

            /// <summary>
            /// Control is not visible, but it's space is reserved.
            /// </summary>
            Hidden,

            /// <summary>
            /// Control is not visible, and takes no space when doing layout.
            /// </summary>
            Collapsed
        }

        /// <summary>        
        /// Dirty flag should be used to trigger a repaint on internal component changes, as otherwise repaint will only be invoked by specific editor events
        /// flag will propagate upwards and will be collected by the application from the root component if it reaches it.
        /// </summary>
        [HideInInspector]
        public bool Dirty
        {
            get { return m_dirty; }
            set
            {
                if (m_container == null)
                {
                    m_dirty = value;
                    if (value && m_application != null)
                    {
                        m_dirtyFrame = m_application.Frame;
                    }
                }
                else
                {
                    if (value)
                    {
                        m_container.Dirty = true;
                    }
                }
            }
        }

        private uint m_dirtyFrame;
        public GUILayoutOption[] options;
        /// <summary>
        /// This field was added for use with the designer to avoid the need to create additional metadata. It is not used anywhere else currently
        /// </summary>

        public string Id { get; set; }

        public bool Enabled { get; set; }

        /// <summary>
        /// What is the visibility mode of the control?
        /// Visible = default
        /// Hidden = layout control and reserve space but don't draw
        /// Collapsed = don't layout, generate empty rect and don't draw
        /// </summary>
        public VisibilityMode Visibility
        {
            get { return m_visibility; }
            set { m_visibility = value; }
        }

        public float leftSpace = 0;
        public bool ResetPivotRoot;
        public float parentLeftSpace;
        /// <summary>
        /// Contained children elements.               
        /// </summary>
        [HideInInspector]
        public List<Control> Children { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [HideInInspector]
        public List<Decorator> Decorators { get; private set; }

        /// <summary>
        /// Containing element if control is in a hierarchy.
        /// </summary>
        protected Control m_container;

        private VisibilityMode m_visibility;

        private bool m_dirty;

        private UFormsApplication m_application;

        private List<int> m_pendingRemoval;
        private Queue<Control> m_pendingAddition;

        #region Other events

        /// <summary>
        /// Override this method to add functionality on update.
        /// </summary>
        protected virtual void OnUpdate()
        {
        }

        #endregion


        #region Internal Drawing Events

        /// <summary>
        /// Override this method to add functionality to an early draw pass.
        /// </summary>
        protected virtual void OnBeforeDraw()
        {
        }

        /// <summary>
        /// Override this method to add functionality to the main draw pass. 
        /// </summary>
        protected virtual void OnDraw()
        {
        }

        /// <summary>
        /// Override this method to add functionality to the layout pass.
        /// </summary>
        protected virtual void OnLayout()
        {
        }

        /// <summary>
        /// Override this method to add functionality to a late layout pass.
        /// </summary>
        protected virtual void OnAfterLayout()
        {
        }

        #endregion

        #region Internal System Events

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnContextClick(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDragExited(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDragPerform(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDragUpdated(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExecuteCommand(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnIgnore(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnKeyDown(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnKeyUp(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnLayout(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMouseDown(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMouseDrag(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMouseMove(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMouseUp(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRepaint(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnScrollWheel(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnUsed(Event e)
        {
        }

        /// <summary>
        /// Override this to handle this event type.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValidateCommand(Event e)
        {
        }

        #endregion

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Control(params GUILayoutOption[] options)
        {
            this.options = options;
            Init();
        }

        private void Init()
        {
            Children = new List<Control>();
            Decorators = new List<Decorator>();

            Enabled = true;
            Visibility = VisibilityMode.Visible;

            m_pendingRemoval = new List<int>();
            m_pendingAddition = new Queue<Control>();
        }


        /// <summary>
        /// Used internally to reference the application context to this control.
        /// </summary>
        /// <param name="app"></param>
        public void SetApplicationContext(UFormsApplication app)
        {
            if (m_application != app)
            {
                m_application = app;

                foreach (Control child in Children)
                {
                    if (child != null)
                    {
                        child.SetApplicationContext(app);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a child control.
        /// </summary>
        /// <param name="child">Control objec to add.</param>
        /// <returns>Added control object.</returns>
        public Control AddChild(Control child)
        {
            if (child.Dirty)
            {
                Dirty = true;
            }

            child.m_container = this;
            child.SetApplicationContext(m_application);

            m_pendingAddition.Enqueue(child);

            return child;
        }


        /// <summary>
        /// Removes a child control.
        /// </summary>
        /// <param name="child">Control object to remove.</param>
        /// <returns>Removed control object.</returns>
        public Control RemoveChild(Control child)
        {
            if (child.m_container == this)
            {
                child.m_container = null;

                int index = Children.IndexOf(child);
                if (index >= 0)
                {
                    child = null;
                    m_pendingRemoval.Add(index);
                }
            }

            return child;
        }


        /// <summary>
        /// Adds a decorator to this control.
        /// </summary>
        /// <param name="decorator">Decorator object to add.</param>
        /// <returns>Added decorator object.</returns>
        public Decorator AddDecorator(Decorator decorator)
        {
            decorator.SetControl(this);

            Decorators.Add(decorator);

            return decorator;
        }


        /// <summary>
        /// Removes a decorator from this control.
        /// </summary>
        /// <param name="decorator">Decorator object to remove.</param>
        /// <returns>Removed decorator object.</returns>
        public Decorator RemoveDecorator(Decorator decorator)
        {
            if (Decorators.Contains(decorator))
            {
                decorator.SetControl(null);

                Decorators.Remove(decorator);
            }

            return decorator;
        }

        /// <summary>
        /// Update method, used internally.
        /// </summary>
        public void Update()
        {
            if (m_pendingRemoval.Count > 0)
            {
                // Sort in descending order so removal does not affect indices on multile removes
                m_pendingRemoval.Sort((a, b) => { return b.CompareTo(a); });

                foreach (int index in m_pendingRemoval)
                {
                    Children.RemoveAt(index);
                }

                m_pendingRemoval.Clear();
            }

            while (m_pendingAddition.Count > 0)
            {
                Control child = m_pendingAddition.Dequeue();

                if (child.Dirty)
                {
                    Dirty = true;
                }

                Children.Add(child);
            }

            OnUpdate();

            foreach (Control child in Children)
            {
                child.Update();
            }
        }


        /// <summary>
        /// Layout method, used internally.
        /// </summary>
        public void Layout()
        {
            if (m_container == null)
            {
                parentLeftSpace = 0;
            }
            else
            {
                parentLeftSpace = m_container.parentLeftSpace + m_container.leftSpace;
            }
            if (m_container != null)
            {
                leftSpace = parentLeftSpace + leftSpace;
            }
            
            
            foreach (Decorator decorator in Decorators)
            {
                decorator.Layout();
            }

            OnLayout();

            if (m_visibility != VisibilityMode.Collapsed)
            {
                foreach (Control child in Children)
                {
                    if (child != null)
                    {
                        child.Layout();
                    }
                }
            }

            OnAfterLayout();

            foreach (Decorator decorator in Decorators)
            {
                decorator.AfterLayout();
            }
        }

        /// <summary>
        /// Draw method, used internally.
        /// </summary>
        public void Draw()
        {
            // m_application.position
            // We will cache the enabled property at the beginning of the draw phase so we can safely determine if we should close it as soon as drawing completes.
            // This is a fail safe in case the state changes while drawing is being processed (one example would be buttons invoking actions if clicked immediately, inside the draw call).
            bool localScopeEnabled = Enabled;
            if (!localScopeEnabled)
            {
                EditorGUI.BeginDisabledGroup(true);
            }

            if (m_visibility == VisibilityMode.Visible)
            {
                foreach (Decorator decorator in Decorators)
                {
                    decorator.BeforeDraw();
                }

                OnBeforeDraw();

                foreach (Decorator decorator in Decorators)
                {
                    decorator.Draw();
                }

                foreach (Control child in Children)
                {
                    if (child != null)
                    {
                        child.Draw();
                    }
                }

                OnDraw();

                foreach (Decorator decorator in Decorators)
                {
                    decorator.AfterDraw();
                }
            }

            if (!localScopeEnabled)
            {
                EditorGUI.EndDisabledGroup();
            }

            if (m_container == null)
            {
                // 10 seems to be the magic number of frames we need to keep a repaint request active for the layout to settle nicely and responsively.
                // Should probably figure out why the hell this does not get resolved in 2 passes ( assuming in a single pass not all layouting elements are in sync due to execution order )
                if (Dirty && m_application && m_application.Frame > m_dirtyFrame + 10)
                {
                    Dirty = false;
                }
            }
        }


        /// <summary>
        /// Event processing method, used internally.
        /// </summary>
        /// <param name="e"></param>
        public void ProcessEvents(Event e)
        {
            // Don't process events for collapsed elements
            if (Visibility == VisibilityMode.Collapsed)
            {
                return;
            }

            if (e == null)
            {
                return;
            }

            switch (e.type)
            {
                case EventType.ContextClick:
                    OnContextClick(e);
                    break;

                case EventType.DragExited:
                    OnDragExited(e);
                    break;

                case EventType.DragPerform:
                    OnDragPerform(e);
                    break;

                case EventType.DragUpdated:
                    OnDragUpdated(e);
                    break;

                case EventType.ExecuteCommand:
                    OnExecuteCommand(e);
                    break;

                case EventType.Ignore:
                    OnIgnore(e);
                    break;

                case EventType.KeyDown:
                    OnKeyDown(e);
                    break;

                case EventType.KeyUp:
                    OnKeyUp(e);
                    break;

                case EventType.Layout:
                    OnLayout(e);
                    break;

                case EventType.MouseDown:
                    OnMouseDown(e);
                    break;

                case EventType.MouseDrag:
                    OnMouseDrag(e);
                    break;

                case EventType.MouseMove:
                    OnMouseMove(e);
                    break;

                case EventType.MouseUp:
                    OnMouseUp(e);
                    break;

                case EventType.Repaint:
                    OnRepaint(e);
                    break;

                case EventType.ScrollWheel:
                    OnScrollWheel(e);
                    break;

                case EventType.Used:
                    OnUsed(e);
                    break;

                case EventType.ValidateCommand:
                    OnValidateCommand(e);
                    break;
            }

            foreach (Control child in Children)
            {
                // If event was consumed during propagation, stop processing
                if (e == null)
                {
                    return;
                }

                if (child != null)
                {
                    child.ProcessEvents(e);
                }
            }
        }
    }
}