using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void HeroRepository_Should_Create_Valid_HeroRepository()
    {
        Assert.IsNotNull(heroRepository);
        Assert.IsNotNull(heroRepository.Heroes);
        Assert.AreEqual(0, heroRepository.Heroes.Count);    
    }

    [Test]
    public void Create_ShouldThrowsExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void Create_ShouldThrowsExceptionWhenThereIsAlreadyHeroWithSameName()
    {
        heroRepository.Create(new Hero("Hero", 100));
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(new Hero("Hero", 1000)));
    }

    [Test]
    public void Create_ShouldAddHeroToTheRepository()
    {
        string expected = $"Successfully added hero Hero with level 100";
        Hero hero = new Hero("Hero", 100);

        string output = heroRepository.Create(hero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);
        Assert.AreEqual(expected, output);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Remove_ShouldThrowsExceptionWhenNameIsInvalid(string name)
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name));
    }

    [Test]
    [TestCase("Krum", false, 1)]
    [TestCase("Hero", true, 0)]
    public void Remove_ShouldReturnCorrectDependingOnHeroExistsOrNot(string name, bool expected, int count)
    {
        Hero hero = new Hero("Hero", 100);
        this.heroRepository.Create(hero);

        bool output = heroRepository.Remove(name);

        Assert.AreEqual(expected, output);
        Assert.AreEqual(count, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevel_ReturnValidHero()
    {
        Hero hero1 = new Hero("Hero1", 100);
        Hero hero2 = new Hero("Hero2", 200);
        Hero hero3 = new Hero("Hero3", 50);
        Hero hero4 = new Hero("Hero4", 180);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);
        this.heroRepository.Create(hero4);

        Hero hero = heroRepository.GetHeroWithHighestLevel();
        Assert.AreSame(hero2, hero);
    }

    [Test]
    public void GetHero_ReturnsValidHeroy()
    {
        Hero hero1 = new Hero("Hero1", 100);
        Hero hero2 = new Hero("Hero2", 200);
        Hero hero3 = new Hero("Hero3", 50);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        Hero hero = heroRepository.GetHero("Hero3");
        Assert.AreSame(hero3, hero);
    }

    [Test]
    public void GetHero_ReturnsNullWhenThereIsNotAheroWithThatName()
    {
        Hero hero1 = new Hero("Hero1", 100);
        Hero hero2 = new Hero("Hero2", 200);
        Hero hero3 = new Hero("Hero3", 50);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        Hero hero = heroRepository.GetHero("NonExisting");
        Assert.AreSame(null, hero);
    }
}