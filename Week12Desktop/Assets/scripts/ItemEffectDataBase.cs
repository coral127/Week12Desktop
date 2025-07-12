using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class ItemEffect
{
    public string itemName; //�������� �̸� (Ű��)
    [Tooltip("HP, SP, DP, HUNGRY, THIRSTY, SATISFIY �� �����մϴ�")]
    public string[] part; //����
    public int[] num; //��ġ
}

public class ItemEffectDataBase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;

    //�ʿ��� ������Ʈ
    [SerializeField]
    private StatusController thePlayerStatus;
    [SerializeField]
    private weaponManager theWeaponManager;

    private const string HP = "HP", SP = "SP", DP = "DP", HUNGRY = "HUNGRY", THIRSTY = "THIRSTY", SATISFIY = "SATISFIY";
   
    public void UseItem(Item _item)
    {

        if (_item.itemType == Item.ItemType.Equipment)
        {
            StartCoroutine(theWeaponManager.ChangeWeaponCoroutine(_item.weaponType, _item.itemName));

        }
        else if (_item.itemType == Item.ItemType.Used)
        {
            for (int x = 0; x < itemEffects.Length; x++)
            {

                if (itemEffects[x].itemName == _item.itemName)
                {

                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {

                        switch (itemEffects[x].part[y])
                        {
                            case HP:
                                thePlayerStatus.IncreseHP(itemEffects[x].num[y]);
                                break;
                            case SP:
                                //thePlayerStatus.In(itemEffects[x].num[y]);
                                break;
                            case DP:
                                thePlayerStatus.IncreseDP(itemEffects[x].num[y]);
                                break;
                            case THIRSTY:
                                thePlayerStatus.IncreseThirsty(itemEffects[x].num[y]);
                                break;
                            case HUNGRY:
                                thePlayerStatus.IncreseHungry(itemEffects[x].num[y]);
                                break;
                            case SATISFIY:
                                break;
                            default:
                                Debug.Log("�߸��� Status ����.HP , SP , DP, HUNGRY , THIRSTY , SATISFIY �� �����մϴ�");
                                break;
                        }
                        Debug.Log(_item.itemName + "�� ����߽��ϴ�");
                    }
                    return;
                }
                
            }
            Debug.Log("ItemEffectDataBase�� ��ġ�ϴ� itemName �����ϴ�");
        }
        
    }

}
