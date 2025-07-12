using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.PackageManager;
using UnityEngine;

public class PickaxeController : CloseWeaponController
{
    //활성화 여부
    public static bool isActivate = true;

    private void Start()
    {
        weaponManager.currentWeapon = currentCloseWeapon.GetComponent<Transform>();
        weaponManager.currentWeaponAnim = currentCloseWeapon.anim;
    }


    protected override IEnumerator HitCoroutine()
    {

        void Update()
        {
            if (isActivate == true)
                TryAttack();

        }

        while (isSwing)
        {
            if (CheckObject())
            {
                if(hitInfo.transform.tag == "Rock")
                {
                    hitInfo.transform.GetComponent<Rock>().Mining();
                }
                isSwing = false;
                Debug.Log(hitInfo.transform.name);
            }
            yield return null;
        }
    }
    public override void CloseWeaponChange(CloseWeapon _closeWeapon)
    {
        base.CloseWeaponChange(_closeWeapon);
        isActivate = true;
    }
}
