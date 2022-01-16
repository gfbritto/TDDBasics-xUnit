using Xunit;

namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;

        public GameStateShould(GameStateFixture gameStateFixture)
        {
            _gameStateFixture = gameStateFixture;
        }

        [Fact]
        public void DamageAllEnemiesWhenEarfquake()
        {
            var player = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarfquake = player.Health - GameState.EarthquakeDamage;

            _gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarfquake, player.Health);
            Assert.Equal(expectedHealthAfterEarfquake, player.Health);
        }

        [Fact]
        public void Reset()
        {
            var sut = new GameState();

            var playerCharacter = new PlayerCharacter();
            var playerCharacter2 = new PlayerCharacter();

            sut.Players.Add(playerCharacter);
            sut.Players.Add(playerCharacter2);

            sut.Reset();

            Assert.Empty(sut.Players);
        }
    }
}
