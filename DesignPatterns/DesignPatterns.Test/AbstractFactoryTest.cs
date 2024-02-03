using DesignPatterns.Source.Creational;

namespace DesignPatterns.Test;

public sealed class AbstractFactoryTest
{
    [Test]
    public void SwitchFactories()
    {
        IWeaponFactory weaponFactory = new SciFiWeaponFactory();

        var defense = weaponFactory.CreateDefensiveWeapon();
        var offense = weaponFactory.CreateOffensiveWeapon();

        Assert.Multiple(() =>
        {
            Assert.That(defense, Is.TypeOf<EnergyShield>());
            Assert.That(offense, Is.TypeOf<PlasmaBlaster>());
        });

        weaponFactory = new MedievalFactory();

        defense = weaponFactory.CreateDefensiveWeapon();
        offense = weaponFactory.CreateOffensiveWeapon();

        Assert.Multiple(() =>
        {
            Assert.That(defense, Is.TypeOf<WoodenShield>());
            Assert.That(offense, Is.TypeOf<TwinDaggers>());
        });
    }
}