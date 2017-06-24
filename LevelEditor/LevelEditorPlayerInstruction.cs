using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using IOImplementation;
using LevelEditor.Contracts;

namespace LevelEditor
{
    public class LevelEditorPlayerInstruction : IPlayerInstruction, IActivationInstruction, ILevelEditorInstruction
    {
        public double ViewXChange { set; get; }

        public double ViewYChange { set; get; }

        public bool WalkForward { set; get; }

        public bool WalkRight { set; get; }

        public bool WalkLeft { set; get; }

        public bool WalkBackward { set; get; }

        public bool FiredPressed { set; get; }

        public bool NextWeapon { set; get; }

        public bool PreviousWeapon { set; get; }

        public bool Duck { set; get; }

        public bool ActivateItem { set; get; }

        public bool OpenDoor { set; get; }

        public bool Save { set; get; }

        public bool EnterLevel { set; get; }

        public bool RotateLeft { set; get; }

        public bool RotateRight { set; get; }

        public bool MoveUp { set; get; }

        public bool MoveDown { set; get; }

        public bool MoveLeft { set; get; }

        public bool MoveRight { set; get; }

        public bool MoveForward { get; set; }

        public bool MoveBackward { get; set; }

        public bool BindToFloor { set; get; }

        public bool BindToCeiling { set; get; }

        public bool Group { set; get; }

        public bool Ungroup { set; get; }

        public bool MultiSelect { set; get; }

        public bool ItemSelected { set; get; }

        public bool SingleUngroup { set; get; }

        public bool CreateElement { set; get; }

        public bool NextOption { set; get; }

        public bool PreviousOption { set; get; }

        public bool NextOptionSelection { set; get; }

        public bool Copy { set; get; }

        public bool Paste { set; get; }

        public bool Delete { set; get; }

        public bool FlyUp { set; get; }

        public bool FlyDown { set; get; }

        public bool TextureIncreaseX { set; get; }

        public bool TextureIncreaseY { set; get; }

        public bool TextureDecreaseX { set; get; }

        public bool TextureDecreaseY { set; get; }

        public bool MirrorX { get; set; }

        public bool MirrorY { get; set; }

        public int? Number { set; get; }

        public bool SlowMotion { set; get; }

        public LevelEditorPlayerInstruction(PlayerInstruction PlayerInstruction)
        {
            ViewXChange = PlayerInstruction.ViewXChange;
            ViewYChange  = PlayerInstruction.ViewYChange;
            WalkForward  = PlayerInstruction.WalkForward;
            WalkRight  = PlayerInstruction.WalkRight;
            WalkLeft  = PlayerInstruction.WalkLeft;
            WalkBackward  = PlayerInstruction.WalkBackward;
            FiredPressed  = PlayerInstruction.FiredPressed;
            NextWeapon = PlayerInstruction.NextWeapon;
            PreviousWeapon  = PlayerInstruction.PreviousWeapon;
            Duck = PlayerInstruction.Duck;
            OpenDoor  = PlayerInstruction.OpenDoor;
            Save  = PlayerInstruction.Save;
            Number = PlayerInstruction.Number;
        }
    }
}
