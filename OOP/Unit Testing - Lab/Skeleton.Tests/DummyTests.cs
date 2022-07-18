using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    [SetUp]
    public void Initialize()
    {
        this.dummy = new Dummy(100, 100);
    }
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        //Arrange        
        this.dummy.TakeAttack(50);
        //Act
        int expectedOutput = 50;
        int actualOutput = dummy.Health;

        //Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput),
                    String.Format($"Dummy loses {actualOutput} health, instead of {expectedOutput}"));
    }
    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        //Arrange
        this.dummy.TakeAttack(120);

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(50));
    }
    [Test]
    public void DeadDummyGiveExp()
    {
        //Arrange
        this.dummy.TakeAttack(150);

        //Act
        int expectedOutput = 100;
        int actualOutput = this.dummy.GiveExperience();

        //Assert
        
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }
    [Test]
    public void AliveDummyGiveExp()
    {
        //Arrange
        

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        
    }

}
