using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class HUD : MonoBehaviour
{
    //필요한 컴포넌트
    [SerializeField]
    private GunController theGunController;
    private Gun currentGun;

    // HUD 호출 및 비활성화
    [SerializeField]
    private GameObject go_BulletHUD;

    //총알 개수 텍스트 반영
    [SerializeField]
    private Text[] text_Bullet;


    
    void Update()
    {
        CheckBullet(); 
    }

    private void CheckBullet()
    {
        currentGun = theGunController.GetGun();
        text_Bullet[0].text = currentGun.carryBulletCount.ToString();
        text_Bullet[1].text = currentGun.reloadBulletCount.ToString();
        text_Bullet[2].text = currentGun.currentBulletCount.ToString();
    }
}
