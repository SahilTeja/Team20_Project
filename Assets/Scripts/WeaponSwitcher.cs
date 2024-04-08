using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int currentItem;
    public Transform[] itemList;

    // Start is called before the first frame update
    void Start()
    {
        changeWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeWeapon(int num)
    {
        currentItem = num;
        for(int i = 0; i < itemList.Length; i++)
        {
            if(i == num)
            {
                itemList[i].gameObject.SetActive(true);
            }
            else
            {
                itemList[i].gameObject.SetActive(false);
            }
        }
    }
}
