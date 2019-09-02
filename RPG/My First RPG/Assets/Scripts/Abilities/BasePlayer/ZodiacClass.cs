using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacClass
{
    public bool MagicalBonus;
    public bool TankBonus;
    public bool HealBonus;
    public bool SpeedBonus;
    public bool isCapricorn, isAquarius, isPisces, isAries, isTaurus, isGemini, isCancer, isLeo, isVirgo, isLibra, isScorpio, isSagittarius;
    public bool isRat, isOx, isTiger, isRabbit, isDragon, isSnake, isHorse, isSheep, isMonkey, isRooster, isDog, isPig;
    // Needs bonuses for each class, gotta read into the history and what they are 
    //Ophiuchus will be in a xpac
    // Revenge of the Ophichus
    // There are two different zoidacs
}
public class WesternZodiac : ZodiacClass
{
    public WesternZodiac()
    {
        new ZodiacClass();
    }
}
public class ChineseZodiac : ZodiacClass
{
    public ChineseZodiac()
    {
        new ZodiacClass();
    }
}
public class BaseCapricornClass : WesternZodiac
{

    public BaseCapricornClass()
    {

        isCapricorn = true;
    }

}
public class BaseAquariusClass : WesternZodiac
{
    public BaseAquariusClass()
    {

        isAquarius = true;
    }

}
public class BasePiscesClass : WesternZodiac
{
    public BasePiscesClass()
    {

        isPisces = true;
    }

}
public class BaseAriesClass : WesternZodiac
{
    public BaseAriesClass()
    {

        isAries = true;
    }
}
public class BaseTaurusClass : WesternZodiac
{
    public BaseTaurusClass()
    {
  
        isTaurus = true;
    }
}
public class BaseGeminiClass : WesternZodiac
{
    public BaseGeminiClass()
    {
    
        isGemini = true;
    }

}
public class BaseCancerClass : WesternZodiac
{
    public BaseCancerClass()
    {
        isCancer = true;
    }

}
public class BaseLeoClass : WesternZodiac
{
    public BaseLeoClass()
    {
       
        isLeo = true;
    }

}
public class BaseVirgoClass : WesternZodiac
{
    public BaseVirgoClass()
    {
     
        isVirgo = true;
    }

}
public class BaseLibraClass : WesternZodiac
{
    public BaseLibraClass()
    {
        isLibra = true;
    }

}
public class BaseScorpioClass : WesternZodiac
{
    public BaseScorpioClass()
    {
        isScorpio = true;
    }

}
public class BaseSagittariusClass : WesternZodiac
{
    public BaseSagittariusClass()
    {
        isSagittarius = true;
    }

}
public class BaseRatClass : ChineseZodiac
{
    public BaseRatClass()
    {
        isRat = true;
    }

}
public class BaseOxClass : ChineseZodiac
{
    public BaseOxClass()
    {
        isOx = true;
    }

}
public class BaseTigerClass : ChineseZodiac
{
    public BaseTigerClass()
    {
        isTiger = true;
    }

}
public class BaseRabbitClass : ChineseZodiac
{
    public BaseRabbitClass()
    {
        isRabbit = true;
    }

}
public class BaseDragonClass : ChineseZodiac
{
    public BaseDragonClass()
    {
        isDragon = true;
    }

}
public class BaseSnakeClass : ChineseZodiac
{
    public BaseSnakeClass()
    {
        isSnake = true;
    }

}
public class BaseHorseClass : ChineseZodiac
{
    public BaseHorseClass()
    {
        isHorse = true;
    }

}
public class BaseSheepClass : ChineseZodiac
{
    public BaseSheepClass()
    {
        isSheep = true;
    }

}
public class BaseMonkeyClass : ChineseZodiac
{

    public BaseMonkeyClass()
    {
        isMonkey = true;
    }
}
public class BaseRoosterClass : ChineseZodiac
{
    public BaseRoosterClass()
    {
        isRooster = true;
    }

}
public class BaseDogClass : ChineseZodiac
{
    public BaseDogClass()
    {
        isDog = true;
    }

}
public class BasePigClass : ChineseZodiac
{
    public BasePigClass()
    {
        isPig = true;
    }

}

