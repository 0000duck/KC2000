using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using Render.Contracts;

namespace Menu
{
    //public class MenuPopUp : MenuElement
    //{
    //    public delegate void ButtonPressed();

    //    private MenuElement OKButton { set; get; }
    //    private MenuElement CancelButton { set; get; }
    //    private List<MenuElement> TextRows { set; get; }
    //    private bool MouseOverOkButton { set; get; }
    //    private bool MouseOverCancelButton { set; get; }
    //    private bool MouseDownOnOKButton { set; get; }
    //    private bool MouseDownOnCancelButton { set; get; }
    //    private ButtonPressed OKButtonPressed { set; get; }
    //    private ButtonPressed CancelButtonPressed { set; get; }

    //    public MenuPopUp(IRectangleFactory rectangleFactory, string text, double width, double height, ButtonPressed oKButtonPressed, ButtonPressed cancelButtonPressed)
    //        :base(rectangleFactory)
    //    {
    //        Rectangles = new List<IRectangle>();
    //        TextRows = new List<MenuElement>();
    //        OKButtonPressed = oKButtonPressed;
    //        CancelButtonPressed = cancelButtonPressed;

    //        LeftCornerX = 0.5 - (width / 2.0);
    //        LeftCornerY = 0.5 - (height / 2.0);
    //        LengthX = width;
    //        LengthY = height;

    //        //background rectangle
    //        Rectangles.Add(rectangleFactory.CreateRectangle(LeftCornerX, LeftCornerY, LengthX, LengthY,image: "BG",center: false));

    //        if (text.Length < LengthX / CharacterRectangleLengthX)
    //        {
    //            TextRows.Add(new MenuElement(rectangleFactory, text, LeftCornerX, LeftCornerY + height - (CharacterRectangleLengthY * 1.5), true));
    //        }
    //        else
    //        {
    //            int length = GetLengthOfFirstRow(text);

    //            TextRows.Add(new MenuElement(rectangleFactory, text.Substring(0, length), LeftCornerX, 
    //                LeftCornerY + height - (CharacterRectangleLengthY * 1.5), true));
    //            TextRows.Add(new MenuElement(rectangleFactory, text.Substring(length, text.Length - length), 
    //                LeftCornerX, LeftCornerY + height - (CharacterRectangleLengthY * 2.5),
    //                true));
    //        }

    //        OKButton = new MenuElement(rectangleFactory, "OK", LeftCornerX + (CharacterRectangleLengthX * 2), LeftCornerY, true);
    //        CancelButton = new MenuElement(rectangleFactory, "CANCEL", LeftCornerX + width - (CharacterRectangleLengthX * 5), LeftCornerY, true);
    //    }

    //    private int GetLengthOfFirstRow(string text)
    //    {
    //        int length = 0;
    //        string [] wordArray = text.Split(' ');
    //        int index = 0;
    //        while(index < wordArray.Length - 1)
    //        {
    //            if(length + wordArray[index].Length < LengthX / CharacterRectangleLengthX)
    //            {
    //                length += wordArray[index].Length;
    //                index++;
    //            }
    //        }
    //        return length;
    //    }

    //    public override void Draw()
    //    {
    //        if (!Visible)
    //            return;

    //        foreach (IRectangle rectangle in Rectangles)
    //        {
    //            rectangle.Draw();
    //        }

    //        foreach (MenuElement element in TextRows)
    //        {
    //            element.Draw();
    //        }
    //        if (MouseOverOkButton)
    //        { 
    //            OKButton.DrawAnimation();
    //        }
    //        else
    //            OKButton.Draw();

    //        if(MouseOverCancelButton)
    //            CancelButton.DrawAnimation();
    //        else
    //            CancelButton.Draw();
    //    }

    //    public override void DrawAnimation()
    //    {
    //        Draw();
    //    }

    //    internal void SetMouseEvents(MouseEvents events)
    //    {
    //        MouseOverOkButton = OKButton.MouseOver(events.PositionX, events.PositionY);
    //        MouseOverCancelButton = CancelButton.MouseOver(events.PositionX, events.PositionY);

    //        if (events.LeftButtonPressed)
    //        {
    //            MouseDownOnOKButton = MouseOverOkButton;

    //            MouseDownOnCancelButton = MouseOverCancelButton;
    //        }

    //        if (events.LeftButtonReleased)
    //        {
    //            if (MouseDownOnOKButton)
    //            {
    //                MouseDownOnOKButton = false;
    //                OKButtonPressed();
    //            }
    //            if (MouseDownOnCancelButton)
    //            {
    //                MouseDownOnCancelButton = false;
    //                CancelButtonPressed();
    //            }
    //        }
    //    }

    //    internal void DialogWasClosed()
    //    {
    //        CancelButtonPressed();
    //    }
    //}
}
