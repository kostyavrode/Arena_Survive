using System;

namespace UI.Model
{
    public class GameOverModel
    {
        public float SurvivalTime { get; private set; }
        public int Kills { get; private set; }

        public event Action<float, int> OnGameOverDataUpdated;

        public void SetGameOverData(float survivalTime, int kills)
        {
            SurvivalTime = survivalTime;
            Kills = kills;
            OnGameOverDataUpdated?.Invoke(SurvivalTime, Kills);
        }
    }
}