using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; //바위 체력

    [SerializeField]
    private float destoryTime; //파편 제거 시간

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
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip effect_sound;
    [SerializeField]
    private AudioClip effect_sound2;


    public void Mining()
    {
        audioSource.clip = effect_sound;
        audioSource.Play();
        var clone = Instantiate(go_effect_prefebs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destoryTime);

        hp--;
        if(hp <= 0)
        {
            Destruction();
        }
    }
    
    private void Destruction()
    {
        audioSource.clip = effect_sound;
        audioSource.Play();

        col.enabled = false;
        Destroy(go_rock);
        go_debris.SetActive(true);
        Destroy(go_debris, destoryTime); 
    }
}
