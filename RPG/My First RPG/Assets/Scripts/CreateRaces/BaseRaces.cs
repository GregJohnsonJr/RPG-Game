using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHumanRace : BaseCharacterRace
{
    // Devils, Angles, Fairies, Demi-gods, 
    public BaseHumanRace()
    {
        new BaseCharacterRace();
        RaceName = "Human";
        RaceDescription = "An explorer of the unknown";
        HasStaminaBonus = true;
        HasAgilityBonus = true;
        HasMasteryBonus = true;
    }
}
public class BaseDwarfRace : BaseCharacterRace
{

    public BaseDwarfRace()
    {
        new BaseCharacterRace();
        RaceName = "Dwarf";
        RaceDescription = "A short mighty dwarf";
        HasStrengthBonus = true;
        HasStaminaBonus = true;
        HasEnduranceBonus = true;
    }
}

public class BaseElfRace : BaseCharacterRace
{
    public BaseElfRace()
    {
        new BaseCharacterRace();
        RaceName = "Elf";
        RaceDescription = "A true knowledge seeker in the arcane arts, but will use close combat if needed";
        HasMasteryBonus = true;
        HasIntellectBonus = true;
        HasAgilityBonus = true;
    }
}
public class BaseGnomeRace : BaseCharacterRace
{

    public BaseGnomeRace()
    {
        new BaseCharacterRace();
        RaceName = "Gnome";
        RaceDescription = "A short fellow who loves to invent and make things out of nothing";
        HasIntellectBonus = true;
        HasStrengthBonus = true;
        HasMasteryBonus = true;
    }
}
public class BaseFairyRace : BaseCharacterRace
{

    public BaseFairyRace()
    {
        new BaseCharacterRace();
        RaceName = "Fairy";
        RaceDescription = "A rare Race that specializes in aiding their companions";
        HasIntellectBonus = true;
        HasMasteryBonus = true;
        HasHealingBonus = true;
    }
}
public class BaseDemiGodRace : BaseCharacterRace
{

    public BaseDemiGodRace()
    {
        new BaseCharacterRace();
        RaceName = "Demi-God";
        RaceDescription = "A small race of people that are born from human god relationships. They all have god-like magic.";
        HasIntellectBonus = true;
        HasStrengthBonus = true;
        HasStaminaBonus = true;
    }
}
public class BaseDevilRace : BaseCharacterRace
{

    public BaseDevilRace()
    {
        new BaseCharacterRace();
        RaceName = "Devil";
        RaceDescription = "Demons that have come from the underworld that love to tormet people.";
        HasStrengthBonus = true;
        HasEnduranceBonus = true;
        HasAgilityBonus = true;
    }
}
public class BaseAngelRace : BaseCharacterRace
{

    public BaseAngelRace()
    {
        new BaseCharacterRace();
        RaceName = "Fairy";
        RaceDescription = "People from the skies above that fight devils and aid people.";
        HasIntellectBonus = true;
        HasMasteryBonus = true;
        HasStaminaBonus = true;
    }
}






