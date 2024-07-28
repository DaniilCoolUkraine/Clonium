using Clonium.Core.MapModel;

namespace Clonium.Core.AI.Decisions
{
    public class Decision
    {
        public Dot SelectedDot { get; }

        public Decision(Dot dot)
        {
            SelectedDot = dot;
        }
    }
}