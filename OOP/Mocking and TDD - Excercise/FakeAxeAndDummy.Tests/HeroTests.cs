using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceWhenTargetDies()
    {
        //Arrange
        Mock<ITarget> targetMock = new Mock<ITarget>();
        targetMock.Setup(t => t.GiveExperience()).Returns(20);
        targetMock.Setup(t => t.IsDead()).Returns(true);
        Mock<IWeapon> weaponMock = new Mock<IWeapon>();
        Hero hero = new Hero("Viktor", weaponMock.Object);
        //Act
        hero.Attack(targetMock.Object);
        //Assert
        Assert.That(20, Is.EqualTo(hero.Experience));
    }
}