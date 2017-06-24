using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace OpenTKPortation.Implementations
{
    public class MessageRendererFactory : IMessageRendererFactory
    {
        private ITextFactory _textFactory;

        public MessageRendererFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory;
        }
        public IMessageRenderer CreateMessageRenderer(double cornerX, double cornerY)
        {
            return new MessageRenderer(_textFactory, cornerX, cornerY);
        }
    }
}
