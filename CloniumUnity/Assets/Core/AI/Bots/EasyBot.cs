using Clonium.Core.AI.Decisions;
using Clonium.Core.General;
using Clonium.Core.MapModel;

namespace Clonium.Core.AI.Bots
{
    public class EasyBot : Bot
    {
        public EasyBot(DotColor dotColor) : base(dotColor)
        {
        }

        public override Decision RequestDecision(Map map)
        {
            var randomDot = map.GetDots(BotColor).Random();
            var newDot = new Dot(randomDot, randomDot.Count + 1);
           
            return new Decision(newDot);
        }
    }
}