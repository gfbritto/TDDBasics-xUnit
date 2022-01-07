using Xunit;

namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Peter");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Peter King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnType()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Peter King", true);

            var boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Peter King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_IsAssignable()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Peter King", true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparedInstances()
        {
            var sut = new EnemyFactory();

            var enemy1 = sut.Create("Peter");
            var enemy2 = sut.Create("Peter");

            Assert.NotSame(enemy1,enemy2);
        }
    }
}
