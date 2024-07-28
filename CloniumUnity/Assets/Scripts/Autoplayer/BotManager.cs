using System.Collections.Generic;
using System.Threading.Tasks;
using Clonium.Core.AI.Bots;
using Clonium.Core.AI.Decisions;
using Clonium.Core.MapModel;

namespace Clonium.Autoplayer
{
    public class BotManager
    {
        private TurnManager _turnManager;
        private Map _map;
        
        private List<Bot> _activeBots;
        
        public BotManager(TurnManager turnManager, Map map, IEnumerable<DotColor> aiControlledColors)
        {
            _turnManager = turnManager;
            _map = map;
            _activeBots = new List<Bot>();

            int i = 0;
            
            foreach (var color in aiControlledColors)
            {
                if (i == 0)
                {
                    _activeBots.Add(new EasyBot(color));
                }
                else if(i == 2)
                {
                    _activeBots.Add(new MediumBot(color));
                }
                else
                {
                    _activeBots.Add(new HardBot(color));
                }

                i++;
            }
            
            _turnManager.TurnUpdated += OnTurnUpdated;
        }

        public void Dispose()
        {
            _turnManager.TurnUpdated -= OnTurnUpdated;
        }

        private async void OnTurnUpdated(DotColor color)
        {
            foreach (var bot in _activeBots)
            {
                if (bot.BotColor == color)
                {
                    var decision = bot.RequestDecision(_map);
                    await WaitBeforePublish(decision);
                    break;
                }
            }
        }

        private async Task WaitBeforePublish(Decision decision)
        {
            await Task.Delay(500);
            _map.SetDots(new[] { decision.SelectedDot });
            _turnManager.UpdateTurn();
        }
    }
}