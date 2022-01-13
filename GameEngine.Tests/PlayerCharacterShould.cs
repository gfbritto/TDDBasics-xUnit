using Xunit;
using System;

namespace GameEngine.Tests
{
    [Trait("Category", "Player")]
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateCharacterFullName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Connor";

            Assert.Equal("Sarah Connor", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Connor";

            Assert.StartsWith("Sarah", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithFirstName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Connor";

            Assert.EndsWith("COnnor", sut.FullName, StringComparison.CurrentCultureIgnoreCase);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Connor";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqual()
        {
            var sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleep()
        {
            var sut = new PlayerCharacter();

            sut.Sleep();

            Assert.InRange(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            var sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            var sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveSomeKindOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var sut = new PlayerCharacter();

            var weapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(weapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoemptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            var sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            var sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }
    }
}
