using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  HandController : CloseWeaponController
{

    //활성화 여부
    public static bool isActivate = false;

    void Update()
    {
        if (isActivate == true)
            TryAttack();

    }
    protected override IEnumerator HitCoroutine()
    {
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
