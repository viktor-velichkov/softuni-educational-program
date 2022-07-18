using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void Initialize()
    {
        this.axe = new Axe(2, 2);
        this.dummy = new Dummy(100, 100);
    }
    [Test]
    public void DoesAxeLoseDurabilityAfterAttack()
    {
        //Arrange
        this.axe.Attack(this.dummy);

        //Act

        int expectedResult = 1;
        int actualResult = axe.DurabilityPoints;


        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        //Arrange
        this.axe.Attack(this.dummy);
        this.axe.Attack(this.dummy);

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy), "Axe is broken.");
    }

}