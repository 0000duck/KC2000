using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Screen
{
    public class CountRenderer : ICountRenderer
    {
        private Dictionary<int, IRectangle> _numbers;
        private double _digitSize;
        private IColorToPercentMapper _colorMapper;

        public CountRenderer(Dictionary<int, IRectangle> numbers, IColorToPercentMapper colorMapper, double digitSize)
        {
            _numbers = numbers;
            _digitSize = digitSize;
            _colorMapper = colorMapper;
        }

        void ICountRenderer.RenderCount(int count, double leftCornerX, double leftCornerY)
        {
            double percent = _colorMapper.MapColor(count > 0 ? C64Color.White : C64Color.Red);

            int hundred = (count - (count % 100)) / 100;

            _numbers[hundred].SetPosition(leftCornerX, leftCornerY);
            _numbers[hundred].DrawAnimation(percent);

            count -= hundred * 100;

            int ten = (count - (count % 10)) / 10;

            _numbers[ten].SetPosition(leftCornerX + _digitSize, leftCornerY);
            _numbers[ten].DrawAnimation(percent);

            count -= ten * 10;

            int one = count;

            _numbers[one].SetPosition(leftCornerX + (_digitSize * 2), leftCornerY);
            _numbers[one].DrawAnimation(percent);
        }
    }
}
