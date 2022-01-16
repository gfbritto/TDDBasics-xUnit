using Xunit;

namespace GameEngine.Tests
{
    public class GameStateShould
    {
        [Fact]
        public void DamageAllEnemiesWhenEarfquake()
        {
            var sut = new GameState();

            var playerCharacter = new PlayerCharacter();
            var playerCharacter2 = new PlayerCharacter();

            sut.Players.Add(playerCharacter);
            sut.Players.Add(playerCharacter2);

            var expectedHealthAfterEarfquake = playerCharacter.Health - GameState.EarthquakeDamage;

            sut.Earthquake();

            Assert.Equal(expectedHealthAfterEarfquake, playerCharacter.Health);
            Assert.Equal(expectedHealthAfterEarfquake, playerCharacter2.Health);
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
