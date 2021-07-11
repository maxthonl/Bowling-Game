using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class GameTests
    {
        private Game game = new Game();

        [Fact]
        public void Game_NoAnySpareOrStrike()
        {
            MultiRolls(20, 1);
            game.Score().Should().Be(20);
        }

        [Fact]
        public void Game_WhenExisting1Space()
        {
            game.Roll(6); game.Roll(4);
            MultiRolls(18, 1);
            game.Score().Should().Be(29);
        }

        [Fact]
        public void Game_WhenExisting1Strike()
        {
            game.Roll(10);
            MultiRolls(18, 1);
            game.Score().Should().Be(30);
        }

        [Fact]
        public void Game_WhenFullStrikes()
        {
            MultiRolls(12, 10);
            game.Score().Should().Be(300);
        }

        [Fact]
        public void Game_WhenFullSpaces()
        {
            for (var i = 0; i < 10; i++)
            {
                game.Roll(3);
                game.Roll(7);
            }
            game.Roll(6);

            game.Score().Should().Be(133);
        }

        private void MultiRolls(int times, int score)
        {
            for(var i=0; i<times; i++)
            {
                game.Roll(score);
            }
        }
    }
}
