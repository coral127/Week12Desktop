using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    //ü��
    [SerializeField]
    private int hp;
    private int currentHp;

    //���׹̳�
    [SerializeField]
    private int sp;
    private int currentSp;

    //���׹̳� ������
    [SerializeField]
    private int spIncreaseSpeed;

    //���׹̳� ��ȸ�� ������
    [SerializeField]
    private int spRechargetime;
    private int currentSpRechargeTime;

    //���׹̳� ���� ����
    private bool spUsed;

    //����
    [SerializeField]
    private int dp;
    private int currentDp;

    //�����
    [SerializeField]
    private int hungry;
    private int currentHungry;

    //����� ���� �ӵ�
    [SerializeField]
    private int hungryDecreaseTime;
    private int currnetHungryDecreaseTime;

    //�񸶸�
    [SerializeField]
    private int thirsty;
    private int currentThirsty;

    //�񸶸� ���� �ӵ�
    [SerializeField]
    private int thirstyDecreaseTime;
    private int currnetThirstyDecreaseTime;

    //������
    [SerializeField]
    private int satisfy;
    private int currentSatisfy;

    //�ʿ��� �̹���
    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0, DP = 1, SP = 2, HUNGRY = 3, THIRSTY = 4, SATISFY = 5 ;


    void Start()
    {
        currentHp = hp;
        currentDp = dp;
        currentSp = sp;
        currentHungry = hungry;
        currentThirsty = thirsty;
        currentSatisfy = satisfy;
    }

    // Update is called once per frame
    void Update()
    {
        Hungry();
        Thirsty();
        SPRechargeTime();
        SPRecover();
        GaugeUpdate();
    }

    private void SPRechargeTime()
    {
        if (spUsed)
        {
            if(currentSpRechargeTime < spRechargetime)
               currentSpRechargeTime++;
            else
                spUsed = false;
        }
    }

    private void SPRecover()
    {
        if(!spUsed && currentSp < sp)
        {
            currentSp += spIncreaseSpeed;
        }
    }
    private void Hungry()
    {
        if (currentHungry > 0)
        {
            if (currnetHungryDecreaseTime <= hungryDecreaseTime)
            {
                currnetHungryDecreaseTime++;
            }
            else
            {
                currentHungry--;
                currnetHungryDecreaseTime = 0;
            }

        }
        else
            Debug.Log("����� ��ġ�� 0�� �Ǿ����ϴ�");
    }

    private void Thirsty()
    {
        if (currentThirsty > 0)
        {
            if (currnetThirstyDecreaseTime <= thirstyDecreaseTime)
            {
                currnetThirstyDecreaseTime++;
            }
            else
            {
                currentThirsty--;
                currnetThirstyDecreaseTime = 0;
            }

        }
        else
            Debug.Log("�񸶸� ��ġ�� 0�� �Ǿ����ϴ�"); 
    }

    private void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currentHp / hp;
        images_Gauge[SP].fillAmount = (float)currentSp / sp;
        images_Gauge[DP].fillAmount = (float)currentDp / dp;
        images_Gauge[HUNGRY].fillAmount = (float)currentHungry / hungry;
        images_Gauge[THIRSTY].fillAmount = (float)currentThirsty / thirsty;
        images_Gauge[SATISFY].fillAmount = (float)currentSatisfy / satisfy;
    }

    public void DecreaseStamina(int _count)
    {
        spUsed = true;
        currentSpRechargeTime = 0;

        if(currentSp - _count > 0)
            currentSp -= _count;
        else
            currentSp = 0;
    }


}
