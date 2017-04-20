using Common.Interface;
using System;

namespace BotFactory.Common.Tools
{
    public class FactoryProgressEventArgs :EventArgs  ,IFactoryProgressEventArgs
    {
        private object _Bot;

        public object Bot
        {
            get { return _Bot; }
            set { _Bot = value; }
        }

    }
}
