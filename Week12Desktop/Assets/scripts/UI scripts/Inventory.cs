using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool invertoryActivated = false;

    //필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotParent;

    private Slot[] slots;
    void Start()
    {
        slots = go_SlotParent.GetComponentsInChildren<Slot>();
    }

   
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invertoryActivated = !invertoryActivated;

            if (invertoryActivated)
                OpenInventory();
            else
                Closeinventory();
        }
    }

    private  void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void Closeinventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item,int _count = 1)
    {
        
        if(Item.ItemType.Equipment != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].AddItem(_item, _count);
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
                    
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].AddItem(_item, _count);
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
        }
    }
}
