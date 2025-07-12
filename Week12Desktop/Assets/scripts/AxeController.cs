using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : CloseWeaponController
{

    //Ȱ��ȭ ����
    public static bool isActivate = false;

    


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
