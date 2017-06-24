using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class ImpulseConverter : IImpulseConverter
    {
        IList<Impulse> IImpulseConverter.ConvertDegreeToImplse(Degree movement, double weight, double speed)
        {
            List<Impulse> list = new List<Impulse>();
            switch (movement)
            {
                case Degree.Degree_0:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromLeftToRight, Strength = weight + speed });
                    break;
                case Degree.Degree_45:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromLeftToRight, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    list.Add(new Impulse { ImpulseDirection = Direction.FromBottomToTop, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    break;
                case Degree.Degree_90:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromBottomToTop, Strength = weight + speed });
                    break;
                case Degree.Degree_135:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromBottomToTop, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    list.Add(new Impulse { ImpulseDirection = Direction.FromRightToLeft, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    break;
                case Degree.Degree_180:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromRightToLeft, Strength = weight + speed });
                    break;
                case Degree.Degree_225:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromRightToLeft, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    list.Add(new Impulse { ImpulseDirection = Direction.FromTopToBottom, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    break;
                case Degree.Degree_270:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromTopToBottom, Strength = weight + speed });
                    break;
                case Degree.Degree_315:
                    list.Add(new Impulse { ImpulseDirection = Direction.FromTopToBottom, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    list.Add(new Impulse { ImpulseDirection = Direction.FromLeftToRight, Strength = weight + (speed * MathHelper.SinusOf45Degree) });
                    break;
            }
            return list;
        }

        IList<Impulse> IImpulseConverter.ConvertVectorToImplse(Vector2D vector, double weight, double speed)
        {
            List<Impulse> list = new List<Impulse>();

            if (vector.X >= 0)
            {
                list.Add(new Impulse
                {
                    ImpulseDirection = Direction.FromLeftToRight,
                    Strength = weight + (speed * vector.X)
                });
            }
            else
            {
                list.Add(new Impulse
                {
                    ImpulseDirection = Direction.FromRightToLeft,
                    Strength = weight + (speed * -1 * vector.X)
                });
            }

            if (vector.Y >= 0)
            {
                list.Add(new Impulse
                {
                    ImpulseDirection = Direction.FromBottomToTop,
                    Strength = weight + (speed * vector.Y)
                });
            }
            else
            {
                list.Add(new Impulse
                {
                    ImpulseDirection = Direction.FromTopToBottom,
                    Strength = weight + (speed * -1 * vector.Y)
                });
            }

            return list;
        }
    }
}
