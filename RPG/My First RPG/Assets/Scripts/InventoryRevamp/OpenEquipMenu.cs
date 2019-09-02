using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEquipMenu : MonoBehaviour {

    public GameObject equipMenu;
    bool isOpened = true;
    bool isEarly = true;

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isOpened = false;

        if (isEarly)
        {
            equipMenu.SetActive(false);
            isEarly = false;
        }
        if (Input.GetKeyDown(KeyBinds.Instance.equip) && equipMenu.activeInHierarchy == false)
        {
            if (!isOpened)
            {
                equipMenu.SetActive(true);
                isOpened = true;
            }
        }
        if (Input.GetKeyDown(KeyBinds.Instance.equip) && equipMenu.activeInHierarchy == true)
        {
            if (!isOpened)
            {
                equipMenu.SetActive(false);
                isOpened = true;
            }
        }
    }
}
