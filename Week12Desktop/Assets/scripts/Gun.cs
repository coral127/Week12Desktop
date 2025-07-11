using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName; //총이름
    public float range; //사정거리
    public float accuracy; //정확도
    public float fireRate; //연사속도
    public float reloadTime; //재장전 속도

    public int damage; //총의 데미지

    public int reloadBulletCount; //총알 재장전 개수
    public int currentBulletCount; //총알 개수
    public int maxBulletCount; //최대 보유 가능 총알 개수
    public int carryBulletCount; //현재 보유중인 총알 수

    public float retroActionForce; //반동 세기
    public float retroActionFineSightForce; //정조준시 반동

    public Vector3 fineSightOriginPos;
    public Animator anim;
    public ParticleSystem muzzleFlash;

    public AudioClip fire_Sound;

    
}
