using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionEvents : MonoBehaviour, IPointerClickHandler
{
    public Text desc;
    public int classSelection;
    public CreateNewPlayer player;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (classSelection == 0)
        {
            var temp = new BaseMageClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 1)
        {
            var temp = new BaseWarriorClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 2)
        {
            var temp = new BaseArcherClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 3)
        {
            var temp = new BaseRougeClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 4)
        {
            var temp = new BasePriestClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 5)
        {
            var temp = new BaseWarlockClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 6)
        {
            var temp = new BasePaladinClass();
            desc.text = temp.characterClassDescrip;
        }
        else if (classSelection == 7)
        {
            var temp = new BaseEnhancerClass();
            desc.text = temp.characterClassDescrip;
        }
        player.SetClassNum(classSelection);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
