using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XpBarGain : MonoBehaviour
{
    public Image xpBar;
    public Image hpBar, manaBar, shieldBar;
    public Text xpPercentage, manaPercentage, hpPercentage;
    private float xp = 0;
    private float maxXp;
    [HideInInspector]
    public float maxHp;
    float minHp = 0;
    float minMana = 0;
    float maxMana;
    float minShield = 0;
    bool isInitalized = false;
    bool ischeckXp = false;
    bool ischeckHp = false;
    bool isCheckMana = false;
    bool isCheckShield = false;

    // Use this for initialization
    void Start()
    {
        // Declear all the hp for the character
        // UpdateXpBar();
        // UpdateHPBar();
        // UpdateManaBar();
        xp = GameInformation.CurrentXp;
        maxHp = GameInformation.PlayerMaxHp;
        maxMana = GameInformation.PlayerMaxEnergy;
        minShield = GameInformation.PlayerShield;
    }
    public float GetMaxHp()
    {
        return maxHp;
    }
    public float GetMaxMana()
    {
        return maxMana;
    }
    // Update is called once per frame
    void Update()
    {


        if (!isInitalized)
        {
            maxXp = GameInformation.RequiredXP;
            isInitalized = true;
            UpdateHPBar();
            UpdateManaBar();
            UpdateXpBar();
            UpdateShieldBar();
        }
        if (isInitalized)
        {
            if (GameInformation.PlayerHealth != minHp)
            {
                UpdateHPBar();

            }
            if (GameInformation.CurrentXp != xp)
            {
                UpdateXpBar();
            }
            if (GameInformation.PlayerEnergy != minMana)
            {

                UpdateManaBar();
            }
            if (GameInformation.PlayerShield != minShield)
            {
                UpdateShieldBar();
            }
        }
    }

    private void UpdateXpBar()
    {
        bool isFirst = false;
        //Debug.Log(GameInformation.RequiredXP);
        if (!ischeckXp)
        {
            maxXp = GameInformation.RequiredXP;
            GameInformation.RequiredXP = maxXp;
            ischeckXp = true;
            xp = 0;
            isFirst = true;
        }
        if (GameInformation.CurrentXp != xp || isFirst)
        {
            xp = GameInformation.CurrentXp;
            float ratio = xp / GameInformation.RequiredXP;
            if (ratio > 1)
            {
                ratio = 1;
            }
            Debug.Log(ratio);
            xpBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

            xpPercentage.text = (ratio * 100).ToString() + " %";
        }


    }
    private void UpdateShieldBar()
    {
        bool isFirst = false;
        //Debug.Log(GameInformation.RequiredXP);
        if (!isCheckShield)
        {
            minShield = 0;
            isFirst = true;
            isCheckShield = true;
        }
        if (GameInformation.PlayerShield != minShield || isFirst)
        {
            minShield = GameInformation.PlayerShield;
            float ratio = minShield / maxHp; // Shield Bar cannot be bigger then hp.. therefore
            if (GameInformation.PlayerShield == 0 && minShield == 0)
            {
                ratio = 0;
                shieldBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
                return;
            }
            if (ratio > 1)
            {
                ratio = 1;
            }
            shieldBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            Debug.Log(ratio);


        }


    }
    private void UpdateHPBar()
    {
        bool isFirst = false;
        if (isInitalized)
        {

            if (!ischeckHp)
            {
                // maxHp = 100;
                GameInformation.PlayerHealth = maxHp;
                minHp = maxHp;
                ischeckHp = true;
                isFirst = true;

            }

            if (GameInformation.PlayerHealth != minHp || isFirst)
            {
                // Debug.Log(GameInformation.PlayerHealth);
                minHp = GameInformation.PlayerHealth;
                float ratio1 = minHp / maxHp;
                if (ratio1 > 1)
                {
                    ratio1 = 1;
                }
                hpBar.rectTransform.localScale = new Vector3(ratio1, 1, 1);
                int tempHp = (int)minHp;
                hpPercentage.text = tempHp.ToString(); // Make it a number instead
            }
        }

    }
    //HAVE TO ADD MANA AND HP REGEN
    // ALSO SHOULD SHOW THE MANA AND HP AS NUMBERS
    // NOT PERCENTS
    private void UpdateManaBar()
    {
        bool isFirst = false;
        if (!isCheckMana)
        {
            // maxMana = 270;
            GameInformation.PlayerEnergy = maxMana;
            isCheckMana = true;
            minMana = maxMana;
            isFirst = true;
            int tempMana = (int)minMana;
            manaPercentage.text = tempMana.ToString();
        }
        if (GameInformation.PlayerEnergy != minMana || isFirst)
        {
            //Debug.Log(GameInformation.PlayerEnergy);
            minMana = GameInformation.PlayerEnergy;
            float ratio2 = minMana / maxMana;
            if (ratio2 > 1)
            {
                ratio2 = 1;
            }
            manaBar.rectTransform.localScale = new Vector3(ratio2, 1, 1);
            Mathf.Round(ratio2);
            int tempMana = (int)minMana;
            manaPercentage.text = tempMana.ToString();
        }
    }
}
