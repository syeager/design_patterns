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

public sealed record EnergyShield : IDefensiveWeapon;

public sealed record PlasmaBlaster : IOffensiveWeapon;

#endregion

#region Implementation 2

public sealed class MedievalFactory : IWeaponFactory
{
    public IDefensiveWeapon CreateDefensiveWeapon() => new WoodenShield();
    public IOffensiveWeapon CreateOffensiveWeapon() => new TwinDaggers();
}

public sealed record WoodenShield : IDefensiveWeapon;

public sealed record TwinDaggers : IOffensiveWeapon;

#endregion