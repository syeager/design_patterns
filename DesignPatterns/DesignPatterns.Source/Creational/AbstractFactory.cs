namespace DesignPatterns.Source.Creational;

#region Interfaces

public interface IWeaponFactory
{
    IDefensiveWeapon CreateDefensiveWeapon();
    IOffensiveWeapon CreateOffensiveWeapon();
}

public interface IDefensiveWeapon;

public interface IOffensiveWeapon;

#endregion

#region Implementation 1

public sealed class SciFiWeaponFactory : IWeaponFactory
{
    public IDefensiveWeapon CreateDefensiveWeapon() => new EnergyShield();
    public IOffensiveWeapon CreateOffensiveWeapon() => new PlasmaBlaster();
}

public sealed class EnergyShield : IDefensiveWeapon;

public sealed class PlasmaBlaster : IOffensiveWeapon;

#endregion

#region Implementation 2

public sealed class MedievalFactory : IWeaponFactory
{
    public IDefensiveWeapon CreateDefensiveWeapon() => new WoodenShield();
    public IOffensiveWeapon CreateOffensiveWeapon() => new TwinDaggers();
}

public sealed class WoodenShield : IDefensiveWeapon;

public sealed class TwinDaggers : IOffensiveWeapon;

#endregion