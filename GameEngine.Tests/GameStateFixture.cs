using System;

namespace GameEngine.Tests
{
    public class GameStateFixture : IDisposable
    {
        public GameState State { get; }

        public GameStateFixture()
        {
            State = new GameState();
        }

        public void Dispose()
        {
            State.Reset();
        }
    }
}
