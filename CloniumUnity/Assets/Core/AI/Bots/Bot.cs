using Clonium.Core.AI.Decisions;
using Clonium.Core.MapModel;

namespace Clonium.Core.AI.Bots
{
    public abstract class Bot
    {
        public DotColor BotColor { get; }

        public Bot(DotColor dotColor)
        {
            BotColor = dotColor;
        }

        public abstract Decision RequestDecision(Map map);
    }
}