# Abstract Factory
### Purpose
- Abstract the creation of a family of objects
- Multiple factories can be used to swap which family of objects will be created
- A single factory is still useful to abstract creation so that it can be mocked

### Diagram
```plantuml
@startuml
interface Factory {
    + CreateProduct1() : Product1
    + CreateProduct2() : Product2
}
@enduml
```
```mermaid
---
title: Structure
---
classDiagram
    Factory --> Product1
    Factory --> Product2
    
    class Factory {
        <<interface>>
        +createProduct1()* Product1
        +createProduct2()* Product2
    }
    
    class Product1 {
        <<interface>>
    }
    
    class Product2 {
        <<interface>>
    }
```

```mermaid
---
title: Implementation
---
classDiagram
IWeaponFactory --> IDefensiveWeapon
IWeaponFactory --> IOffensiveWeapon

    IWeaponFactory <|-- MedievalWeaponFactory
    IDefensiveWeapon <|-- WoodenShield
    IOffensiveWeapon <|-- TwinDaggers
    MedievalWeaponFactory --> WoodenShield
    MedievalWeaponFactory --> TwinDaggers

    IWeaponFactory <|-- SciFiWeaponFactory
    IDefensiveWeapon <|-- EnergyShield
    IOffensiveWeapon <|-- PlasmaBlaster
    SciFiWeaponFactory --> EnergyShield
    SciFiWeaponFactory --> PlasmaBlaster
    
    class IWeaponFactory {
        <<interface>>
        +createDefensiveWeapon()* IDefensiveWeapon
        +createOffensiveWeapon()* IOffensiveWeapon
    }
    
    class IDefensiveWeapon {
        <<interface>>
    }

    class IOffensiveWeapon {
        <<interface>>
    }

    class MedievalWeaponFactory {
        +createDefensiveWeapon() IDefensiveWeapon
        +createOffensiveWeapon() IOffensiveWeapon
    }

    class WoodenShield { }
    class TwinDaggers { }

    class SciFiWeaponFactory {
        +createDefensiveWeapon() IDefensiveWeapon
        +createOffensiveWeapon() IOffensiveWeapon
    }

    class EnergyShield { }
    class PlasmaBlaster { }
```

### Sources
* [Source Making](https://sourcemaking.com/design_patterns/abstract_factory)
