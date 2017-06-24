using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using Render.Contracts;

namespace Menu
{
    public class MenuPage : IDrawable
    {
        public delegate void ElementClicked();

        protected Dictionary<IMenuElement, Action> MenuElements { set; get; }

        protected MenuElement SelectedElement { set; get; }

        protected bool MouseDownOnSelectedElement { set; get; }

        protected List<MenuPage> SubPages { set; get; }

        protected MenuPage ActiveSubPage { set; get; }

        protected IRectangle Mouse { set; get; }

        protected double MouseX { set; get; }

        protected double MouseY { set; get; }

        protected bool Active { get { return ActiveSubPage == null;  } }

        private bool EscapePressed { set; get; }

        protected Action _jumpBack;

        public MenuPage(IRectangle mouse, Action jumpBack = null)
        {
            _jumpBack = jumpBack;
            SubPages = new List<MenuPage>();
            MenuElements = new Dictionary<IMenuElement, Action>();
            Mouse = mouse;
        }

        public virtual void Draw()
        {
            if (ActiveSubPage != null)
            {
                ActiveSubPage.Draw();
                return;
            }

            foreach (MenuElement element in MenuElements.Keys)
            {
                if(element == SelectedElement)
                    element.DrawAnimation();
                else
                    element.Draw();
            }

            Mouse.Draw();
        }

        protected void SetMouseState(MouseEvents events, IPressedKeyDetector keyboardState)
        {
            if (MouseX != events.PositionX || MouseY != events.PositionY)
            {
                MouseX = events.PositionX;
                MouseY = events.PositionY;
                Mouse.SetPosition(MouseX, MouseY);
            }
            if (ActiveSubPage != null)
            {
                DelegateToSubPage(events, keyboardState);
                return;
            }
            
            SelectedElement = FindSelectedMenuElement(events);          
            CheckMouseButtons(events);

            if (IsEscapeReleased(keyboardState) && _jumpBack != null)
                _jumpBack();
        }

        private void CheckMouseButtons(MouseEvents events)
        {
            if (events.LeftButtonPressed)
            {
                if (SelectedElement != null)
                {
                    MouseDownOnSelectedElement = true;
                }
                else
                {
                    MouseDownOnSelectedElement = false;
                }
            }

            if (events.LeftButtonReleased)
            {
                if (SelectedElement != null && MouseDownOnSelectedElement)
                {
                    PlayClickSound();
                    MenuElements[SelectedElement]();
                    MouseDownOnSelectedElement = false;
                }
            }
        }

        private MenuElement FindSelectedMenuElement(MouseEvents events)
        {
            MenuElement menuElement = null;
            foreach (MenuElement element in MenuElements.Keys)
            {
                if (element.Visible && element.MouseOver(events.PositionX, events.PositionY))
                    menuElement = element;
            }
            return menuElement;
        }

        private void DelegateToSubPage(MouseEvents events, IPressedKeyDetector keyboardState)
        {
            ActiveSubPage.SetMouseState(events, keyboardState);
        }

        protected bool IsEscapeReleased(IPressedKeyDetector keyboardState)
        {
            if (EscapePressed)
            {
                if (!keyboardState.IsKeyDown(Keys.Escape))
                {
                    EscapePressed = false;
                    return true;
                }
            }
            EscapePressed = keyboardState.IsKeyDown(Keys.Escape);
            return false;
        }

        protected void ClickedBackground()
        {
        }


        protected void ClickedBackButton()
        {
            ActiveSubPage = null;
        }

        protected void PlayClickSound()
        {
            //ClickSound.SoundEffectInstance.Play();
        }

        protected void ClickedSubPage(int index)
        {
            ActiveSubPage = SubPages[index];
        }

        protected void SubPageIsFinished()
        {
            ActiveSubPage = null;
        }
    }
}
