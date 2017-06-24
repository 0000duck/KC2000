using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace LevelEditor.Contracts
{
    public interface ILevelEditorInstruction : IPlayerInstruction
    {
        bool RotateLeft { set; get; }

        bool RotateRight { set; get; }

        bool MoveUp { set; get; }

        bool MoveDown { set; get; }

        bool MoveLeft { set; get; }

        bool MoveRight { set; get; }

        bool MoveForward { get; set; }

        bool MoveBackward { get; set; }

        bool Group { set; get; }

        bool Ungroup { set; get; }

        bool SingleUngroup { set; get; }

        bool MultiSelect { set; get; }

        bool ItemSelected { set; get; }

        bool CreateElement { set; get; }

        bool NextOption { set; get; }

        bool PreviousOption { set; get; }

        bool NextOptionSelection { set; get; }

        bool Copy { set; get; }

        bool Paste { set; get; }

        bool Delete { set; get; }

        bool FlyUp { set; get; }

        bool FlyDown { set; get; }

        bool TextureIncreaseX { set; get; }

        bool TextureIncreaseY { set; get; }

        bool TextureDecreaseX { set; get; }

        bool TextureDecreaseY { set; get; }

        bool MirrorX { get; set; }

        bool MirrorY { get; set; }

        bool SlowMotion { get; set; }
    }
}
