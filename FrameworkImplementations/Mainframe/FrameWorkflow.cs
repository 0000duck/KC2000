using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class FrameWorkflow : IExecuteble
    {
        private IExecuteble _gameLogic; 
        private IDrawable _renderer;

        public FrameWorkflow(IExecuteble gameLogic, IDrawable renderer)
        {
            _gameLogic = gameLogic;
            _renderer = renderer;
        }

        void IExecuteble.ExecuteLogic()
        {
            _gameLogic.ExecuteLogic();
            _renderer.Draw();
        }
    }
}
