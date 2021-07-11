
using System.Collections.Generic;

namespace Kata
{
    public class Game
    {
        private const int frameCount = 10;
        private List<int> rollScores = new List<int>();

        public void Roll(int score){
            rollScores.Add(score);
        }

        public int Score() {
            var totalScore = 0;
            var rollIndex = 0;
            for (int i = 0; i < frameCount; i++)
            {
                var frame = FrameFactory.BuildFrame(rollScores, rollIndex);
                totalScore += frame.Score;
                rollIndex = frame.NextFrameRollIndex;
            }
            return totalScore;
        }
    }
}
