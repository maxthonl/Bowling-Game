using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Frame 
    {
        private List<int> _rolls = new List<int>();
        public int NextFrameRollIndex { get; private set; }
        public int Score 
        {
            get
            {
                return _rolls.Sum();
            }
        }

        public Frame(List<int> rolls, int nextIndex)
        {
            _rolls = rolls;
            NextFrameRollIndex = nextIndex;
        }
    }

    public class FrameFactory
    {
        private FrameFactory(){ }

        public static Frame BuildFrame(List<int> rolls, int startIndex)
        {
            if(rolls[startIndex] == 10)
            {
                return new StrikeFrame(rolls.GetRange(startIndex, 3), startIndex + 1);
            }

            if(rolls[startIndex] + rolls[startIndex + 1] == 10)
            {
                return new SpaceFrame(rolls.GetRange(startIndex, 3), startIndex + 2);
            }

            return new Frame(rolls.GetRange(startIndex, 2), startIndex + 2);
        }
    }

    public class StrikeFrame : Frame
    {
        public StrikeFrame(List<int> rolls, int nextIndex) : base(rolls, nextIndex)
        {
        }
    }

    public class SpaceFrame : Frame
    {
        public SpaceFrame(List<int> rolls, int nextIndex) : base(rolls, nextIndex)
        {
        }
    }
}
