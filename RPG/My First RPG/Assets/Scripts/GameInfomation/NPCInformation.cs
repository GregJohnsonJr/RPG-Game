using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInformation : MonoBehaviour
{

    void Awake()
    {
        PlayerName = gameObject.name;
        QuestCounter = 0;
        DontDestroyOnLoad(gameObject);
        Init();
    }
    // public static List<BaseAbility> playerAbilities; //another way
    void Init()
    {
        QuestIDs = new List<int>();
        interactions = gameObject.GetComponent<Interactions>();
        
    }
    public string PlayerBio { get; set; }
    public bool IsMale { get; set; }
    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public BaseCharacterClass PlayerClass { get; set; }
    public BaseCharacterRace Race { get; set; }
    public int Stamina { get; set; }
    public int Intellect { get; set; }
    public int Endurance { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Resistance { get; set; }
    public int Mastery { get; set; }
    public int Gold { get; set; }
    public int MainStat { get; set; }
    public int SecondStat { get; set; }
    public int BounsStat { get; set; }
    public float CritChance { get; set; }
    public float CritDamage { get; set; }
    public ZodiacClass Zodiac { get; set; }
    public float PlayerHealth { get; set; }
    public float PlayerEnergy { get; set; }
    public List<int> QuestIDs { get; set; }
    public int QuestCounter { get; set; }
    public Interactions interactions { get; set; }
    public static GameObject ReturnNPCGameObject(string name)
    {
        GameObject temp;
        NPCInformation[] nPC = GameObject.FindObjectsOfType(typeof(NPCInformation)) as NPCInformation[];
        for (int i = 0; i < nPC.Length; i++)
        {
            if(nPC[i].PlayerName == name)
            {
                temp = nPC[i].gameObject;
                return temp;
            }
        }
        temp = null;
        return temp;
        
    }
}
