using System.Linq;
using Clonium.Core.AI.Decisions;
using Clonium.Core.MapModel;

namespace Clonium.Core.AI.Bots
{
    public class MediumBot : Bot
    {
        public MediumBot(DotColor dotColor) : base(dotColor)
        {
        }

        public override Decision RequestDecision(Map map)
        {
            var dot = map.GetDots(BotColor).OrderByDescending(d => d?.Count).FirstOrDefault();
            var newDot = new Dot(dot, dot.Count + 1);

            return new Decision(newDot);
        }
    }
}