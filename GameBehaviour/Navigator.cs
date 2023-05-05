using GameCommon;
using GameInterfaces;
using GameModels;

namespace GameBehaviour
{
    public class Navigator : INavigator
    {
        private IPlayerFeedbackProvider playerFeedbackProvider;
        private IGameStateTracker gameStateTracker;
        private List<ConsoleKey> navKeys;

        public Navigator(IPlayerFeedbackProvider playerFeedbackProvider, IGameStateTracker gameStateTracker)
        {
            this.navKeys = new List<ConsoleKey>
                { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
            this.playerFeedbackProvider = playerFeedbackProvider;
            this.gameStateTracker = gameStateTracker;
            this.gameStateTracker.MineHit += GameStateTracker_MineHit;
        }

        private void GameStateTracker_MineHit()
        {
            playerFeedbackProvider.MineHit(gameStateTracker.LivesLeft);
        }

        public void Navigate(ConsoleKey key)
        {
            var latestMove = new Move(key).GetNewGridLocation(gameStateTracker.CurrentLocation);

            if (this.CanNavigate(latestMove))
            {
                gameStateTracker.AddNewLocation(latestMove);
                playerFeedbackProvider.LatestMove(latestMove.X, latestMove.YtoChar(), gameStateTracker.Score);
            }
            else
            {
                if (navKeys.Any(a => a == key))
                {
                    playerFeedbackProvider.InvalidMove();
                }
                else
                {
                    playerFeedbackProvider.InvalidKeyInput();
                }

            }
        }

        public bool CanNavigate(IGridLocation location) => location.X is >= BoardLimits.MinLimit and <= BoardLimits.MaxLimit &&
                                                            location.Y is >= BoardLimits.MinLimit and <= BoardLimits.MaxLimit;


    }
}