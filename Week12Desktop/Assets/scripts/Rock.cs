using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; //바위 체력

    [SerializeField]
    private float destroyTime; //파편 제거 시간

    [SerializeField]
    private SphereCollider col; //구체 콜라이더

    //필요한 게임 오브젝트
    [SerializeField]
    private GameObject go_rock; //일반 바위
    [SerializeField]
    private GameObject go_debris; //깨진 바위
    [SerializeField]
    private GameObject go_effect_prefebs; //채굴 이펙트
    [SerializeField]
    private GameObject go_rock_item_prefab; //돌멩이 아이템

    //돌멩이 아이템 등장 개수
    [SerializeField]
    private int count;

    //필요한 사운드 이름
    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destroy_Sound;

    public void Mining()
    {
        SoundManager.instance.PlaySE(strike_Sound);
        var clone = Instantiate(go_effect_prefebs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destroyTime);

        hp--;
        if(hp <= 0)
        {
            Destruction();
        }
    }
    
    private void Destruction()
    {
        SoundManager.instance.PlaySE(destroy_Sound);

        col.enabled = false;
        
        for(int i = 0; i < count; i++)
        {
            Instantiate(go_rock_item_prefab, go_rock.transform.position, Quaternion.identity);
        }

        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, destroyTime); 
    }
}
