using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LevelEditor.Contracts;
using FrameworkContracts;

namespace LevelEditor.Elements
{
    public class BoxSideManipulator
    {
        private ITextureNormalizer _textureNormalizer;

        public BoxSideManipulator(ITextureNormalizer textureNormalizer)
        {
            _textureNormalizer = textureNormalizer;
        }

        internal void InterPretTextureCommands(string selectedSide, ILevelEditorInstruction levelEditorInstruction, IVisualParameters parameters)
        {
            if (levelEditorInstruction.Delete)
            {
                DeleteSide(selectedSide, parameters);
                return;
            }

            InterpretTextureChanges(selectedSide, levelEditorInstruction, parameters);
        }

        private void InterpretTextureChanges(string selectedSide,ILevelEditorInstruction levelEditorInstruction, IVisualParameters parameters)
        {
            List<ISide> sides = new List<ISide>();
            switch (selectedSide)
            {
                case "Left":
                    sides.Add(parameters.NegativeX);
                    break;
                case "Front":
                    sides.Add(parameters.NegativeZ);
                    break;
                case "Back":
                    sides.Add(parameters.PositiveZ);
                    break;
                case "Right":
                    sides.Add(parameters.PositiveX);
                    break;
                case "Top":
                    sides.Add(parameters.Top);
                    break;
                case "Bottom":
                    sides.Add(parameters.Bottom);
                    break;
                case "All":
                    sides.Add(parameters.NegativeX);
                    sides.Add(parameters.NegativeZ);
                    sides.Add(parameters.PositiveZ);
                    sides.Add(parameters.PositiveX);
                    sides.Add(parameters.Top);
                    sides.Add(parameters.Bottom);
                    break;
            }

            sides.RemoveAll(x=>x == null);
            ManipulateTextureCoordinates(sides, levelEditorInstruction);

            if (levelEditorInstruction.Number.HasValue)
            {
                NormalizeSide(parameters, levelEditorInstruction.Number.Value);
            }
        }

        private void ManipulateTextureCoordinates(List<ISide> sides, ILevelEditorInstruction levelEditorInstruction)
        {
            double texcoordFactor = 1.0 / 64.0; 
            foreach (ISide side in sides)
            {
                if (levelEditorInstruction.MoveBackward)
                {
                    MoveSide(side, 0, -texcoordFactor);
                }
                if (levelEditorInstruction.MoveForward)
                {
                    MoveSide(side, 0, texcoordFactor);
                }
                if (levelEditorInstruction.MoveLeft)
                {
                    MoveSide(side, -texcoordFactor, 0);
                }
                if (levelEditorInstruction.MoveRight)
                {
                    MoveSide(side, texcoordFactor, 0);
                }
                if (levelEditorInstruction.RotateLeft)
                {
                    RotateCorners(side, true);
                }
                if (levelEditorInstruction.RotateRight)
                {
                    RotateCorners(side, false);
                }
                //if (levelEditorInstruction.MoveUp)
                //{
                //    Scale(side, 0.1, 0.1);
                //}
                //if (levelEditorInstruction.MoveDown)
                //{
                //    Scale(side, -0.1, -0.1);
                //}
                //if (levelEditorInstruction.TextureIncreaseX)
                //{
                //    Scale(side, 0.1, 0);
                //}
                //if (levelEditorInstruction.TextureIncreaseY)
                //{
                //    Scale(side, 0, 0.1);
                //}
                //if (levelEditorInstruction.TextureDecreaseX)
                //{
                //    Scale(side, -0.1, 0);
                //}
                //if (levelEditorInstruction.TextureDecreaseY)
                //{
                //    Scale(side, 0, -0.1);
                //}
                if (levelEditorInstruction.MirrorX)
                {
                    MirrorX(side);
                }
                if (levelEditorInstruction.MirrorY)
                {
                    MirrorY(side);
                }
            }
        }

        private void NormalizeSide(IVisualParameters parameters, int size)
        {
            _textureNormalizer.NormalizeTextures(parameters, (double)size);
        }

        private void MirrorY(ISide side)
        {
            ITextureCoordinate temp1 = side.TexCoord1;
            ITextureCoordinate temp2 = side.TexCoord2;

            side.TexCoord1 = side.TexCoord4;
            side.TexCoord2 = side.TexCoord3;
            side.TexCoord4 = temp1;
            side.TexCoord3 = temp2;
        }

        private void MirrorX(ISide side)
        {
            ITextureCoordinate temp1 = side.TexCoord1;
            ITextureCoordinate temp4 = side.TexCoord4;

            side.TexCoord1 = side.TexCoord2;
            side.TexCoord4 = side.TexCoord3;
            side.TexCoord2 = temp1;
            side.TexCoord3 = temp4;
        }

        private void Scale(ISide side, double scaleX, double scaleY)
        {
            List<ITextureCoordinate> list = new List<ITextureCoordinate> { side.TexCoord1, side.TexCoord2, side.TexCoord3, side.TexCoord4 };
            ITextureCoordinate fixSide = SearchFixCorner(list);

            foreach (ITextureCoordinate textureCoordinate in list)
            {
                if (textureCoordinate == fixSide)
                    continue;

                textureCoordinate.X *= (1 + scaleX);
                textureCoordinate.Y *= (1 + scaleY);
            }
        }

        private ITextureCoordinate SearchFixCorner(List<ITextureCoordinate> list)
        {
            double lowestX = 10000;
            double lowestY = 10000;

            foreach (ITextureCoordinate textureCoordinate in list)
            {
                if (textureCoordinate.X < lowestX)
                    lowestX = textureCoordinate.X;

                if (textureCoordinate.Y < lowestY)
                    lowestY = textureCoordinate.Y;
            }

            ITextureCoordinate corner = list.Find(x=>x.X == lowestX && x.Y == lowestY);

            if (corner != null)
                return corner;

            return list.Find(x => x.X < lowestX + 0.0001 && x.Y < lowestY + 0.0001);
        }


        private void RotateCorners(ISide side, bool clockwise)
        {
            double tempX, tempY;

            tempX = side.TexCoord1.X;
            tempY = side.TexCoord1.Y;

            if (clockwise)
            {
                side.TexCoord1.X = side.TexCoord4.X;
                side.TexCoord1.Y = side.TexCoord4.Y;
                side.TexCoord4.X = side.TexCoord3.X;
                side.TexCoord4.Y = side.TexCoord3.Y;
                side.TexCoord3.X = side.TexCoord2.X;
                side.TexCoord3.Y = side.TexCoord2.Y;
                side.TexCoord2.X = tempX;
                side.TexCoord2.Y = tempY;
            }
            else
            {
                side.TexCoord1.X = side.TexCoord2.X;
                side.TexCoord1.Y = side.TexCoord2.Y;
                side.TexCoord2.X = side.TexCoord3.X;
                side.TexCoord2.Y = side.TexCoord3.Y;
                side.TexCoord3.X = side.TexCoord4.X;
                side.TexCoord3.Y = side.TexCoord4.Y;
                side.TexCoord4.X = tempX;
                side.TexCoord4.Y = tempY;
            }
        }

        private void MoveSide(ISide side, double valueX, double valueY)
        {
            side.TexCoord1.X += valueX;
            side.TexCoord1.Y += valueY;

            side.TexCoord2.X += valueX;
            side.TexCoord2.Y += valueY;

            side.TexCoord3.X += valueX;
            side.TexCoord3.Y += valueY;

            side.TexCoord4.X += valueX;
            side.TexCoord4.Y += valueY;
        }

        private void DeleteSide(string selectedSide, IVisualParameters parameters)
        {
            switch (selectedSide)
            {
                case "Left":
                    parameters.NegativeX = null;
                    break;
                case "Front":
                    parameters.NegativeZ = null;
                    break;
                case "Back":
                    parameters.PositiveZ = null;
                    break;
                case "Right":
                    parameters.PositiveX = null;
                    break;
                case "Top":
                    parameters.Top = null;
                    break;
                case "Bottom":
                    parameters.Bottom = null;
                    break;
            }
        }
    }
}
