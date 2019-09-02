using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds {
    //WHEN I CREATE THE KEY BIND CHANGER, I HAVE TO MAKE THE BUTTONS IN THE OTHER SCRIPTS, THEN I HAVE TO CHANGE THEN AND SET THEM EQUAL TO THE OTHER SCRIPTS TAHT
    // HAVE THE OTHER SKILLS.
    public KeyCode inventory = KeyCode.I, skills = KeyCode.K, character = KeyCode.C, map = KeyCode.M, quest = KeyCode.L, guild = KeyCode.G, pets = KeyCode.P, equip = KeyCode.E, escape = KeyCode.Escape;
    public KeyCode Abilitiy1 = KeyCode.Alpha1, Ability2 = KeyCode.Alpha2, Ability3 = KeyCode.Alpha3, Ability4 = KeyCode.Alpha4, Ability5 = KeyCode.Alpha5, Ability6 = KeyCode.Alpha6, Ability7 = KeyCode.Alpha7;
    private static KeyBinds instance = null;
    public static KeyBinds Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new KeyBinds();
            }
                return instance;
        }
    }  
    //Functions that change the keys
    public void ChangeInvKey(KeyCode keycode)
    {
        instance.inventory = keycode;
    }
    public void ChangeSkillKey(KeyCode keycode)
    {
        instance.skills = keycode;
    }
    public void ChangeMapKey(KeyCode keycode)
    {
        instance.map = keycode;
    }
    public void ChangeQuestKey(KeyCode keycode)
    {
        instance.quest = keycode;
    }
    public void ChangeGuildKey(KeyCode keycode)
    {
        instance.guild = keycode;
    }
    public void ChangePetKey(KeyCode keycode)
    {
        instance.pets = keycode;
    }
    public void ChangeCharacterKey(KeyCode keycode)
    {
        instance.character = keycode;
    }
    public void ChangeAbilityOneKey(KeyCode keycode)
    {
        instance.Abilitiy1 = keycode;
    }
    public void ChangeAbilityTwoKey(KeyCode keycode)
    {
        instance.Ability2 = keycode;
    }
    public void ChangeAbilityThreeKey(KeyCode keycode)
    {
        instance.Ability3 = keycode;
    }
    public void ChangAbilityFourKey(KeyCode keycode)
    {
        instance.Ability4 = keycode;
    }
    public void ChangeAbilityFiveKey(KeyCode keycode)
    {
        instance.Ability5 = keycode;
    }
    public void ChangeAbilitySixKey(KeyCode keycode)
    {
        instance.Ability6 = keycode;
    }
    public void ChangeAbilitySevenKey(KeyCode keyCode)
    {
        instance.Ability7 = keyCode;
    }
    public void ChangeEquipKey(KeyCode keyCode)
    {
        instance.equip = keyCode;
    }
    // Will probably delete
    public void ChangeEscapeKey(KeyCode keyCode)
    {
        instance.escape = keyCode;
    }


}
