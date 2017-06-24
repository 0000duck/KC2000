using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class LoadTextRenderer : IDrawable
    {
        private ILevelIdProvider _levelIdProvider;
        private IDrawable _america;
        private IDrawable _africa;
        private IDrawable _europe;
        private IDrawable _asia;

        private IDrawable _level;

        private IDrawable _one;
        private IDrawable _two;
        private IDrawable _three;
        private IDrawable _four;
        private IDrawable _five;
        private IDrawable _six;
        private IDrawable _seven;
        private IDrawable _eight;

        public LoadTextRenderer(ITextFactory textFactory, ILevelIdProvider levelIdProvider)
        {
            _levelIdProvider = levelIdProvider;

            _america = new TextRenderer(textFactory.CreateText(0.324, 0.2, "AMERICA"));
            _africa = new TextRenderer(textFactory.CreateText(0.349, 0.2, "AFRICA"));
            _europe = new TextRenderer(textFactory.CreateText(0.349, 0.2, "EUROPE"));
            _asia = new TextRenderer(textFactory.CreateText(0.4, 0.2, "ASIA"));
            _level = new TextRenderer(textFactory.CreateText(0.292, 0.1, "LEVEL:"));

            _one = new TextRenderer(textFactory.CreateText(0.652, 0.1, "1"));
            _two = new TextRenderer(textFactory.CreateText(0.652, 0.1, "2"));
            _three = new TextRenderer(textFactory.CreateText(0.652, 0.1, "3"));
            _four = new TextRenderer(textFactory.CreateText(0.652, 0.1, "4"));
            _five = new TextRenderer(textFactory.CreateText(0.652, 0.1, "5"));
            _six = new TextRenderer(textFactory.CreateText(0.652, 0.1, "6"));
            _seven = new TextRenderer(textFactory.CreateText(0.652, 0.1, "7"));
            _eight = new TextRenderer(textFactory.CreateText(0.652, 0.1, "8"));
        }

        void IDrawable.Draw()
        {
            _level.Draw();
            switch (_levelIdProvider.GetLevelId())
            {
                case 12:
                    _america.Draw();
                    _one.Draw();
                    break;
                case 11:
                    _america.Draw();
                    _two.Draw();
                    break;
                case 13:
                    _america.Draw();
                    _three.Draw();
                    break;
                case 6:
                    _america.Draw();
                    _four.Draw();
                    break;
                case 7:
                    _america.Draw();
                    _five.Draw();
                    break;
                case 9:
                    _america.Draw();
                    _six.Draw();
                    break;
                case 8:
                    _america.Draw();
                    _seven.Draw();
                    break;


                case 1:
                    _africa.Draw();
                    _one.Draw();
                    break;
                case 19:
                    _africa.Draw();
                    _two.Draw();
                    break;
                case 3:
                    _africa.Draw();
                    _three.Draw();
                    break;
                case 2:
                    _africa.Draw();
                    _four.Draw();
                    break;
                case 15:
                    _africa.Draw();
                    _five.Draw();
                    break;
                case 16:
                    _africa.Draw();
                    _six.Draw();
                    break;
                case 17:
                    _africa.Draw();
                    _seven.Draw();
                    break;
                case 18:
                    _africa.Draw();
                    _eight.Draw();
                    break;

                case 22:
                    _europe.Draw();
                    _one.Draw();
                    break;
                case 20:
                    _europe.Draw();
                    _two.Draw();
                    break;
                case 5:
                    _europe.Draw();
                    _three.Draw();
                    break;
                case 14:
                    _europe.Draw();
                    _four.Draw();
                    break;

                case 4:
                    _asia.Draw();
                    _one.Draw();
                    break;
                case 23:
                    _asia.Draw();
                    _two.Draw();
                    break;
                case 25:
                    _asia.Draw();
                    _three.Draw();
                    break;
                case 24:
                    _asia.Draw();
                    _four.Draw();
                    break;
                case 26:
                    _asia.Draw();
                    _five.Draw();
                    break;
                case 27:
                    _asia.Draw();
                    _six.Draw();
                    break;
                case 28:
                    _asia.Draw();
                    _seven.Draw();
                    break;
            }
        }
    }
}
