using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Pig : MonoBehaviour
{
    [SerializeField] private string animalName; //동물의 이름
    [SerializeField] private int hp; //동물의 체력

    [SerializeField] private float walkSpeed; //걷기 속도

    private Vector3 direction; //방향

    //상태변수
    private bool isAction; //행동 여부 확인
    private bool isWalking; //걷기 여부 확인

    [SerializeField] private float walkTime; //걷기 시간
    [SerializeField] private float waitTime; //대기시간
    private float currentTime;

    //필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private BoxCollider boxCol;

    void Start()
    {
        currentTime = waitTime;
        isAction = true;
        
    }

    
    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }

    private void Move()
    {
        if (isWalking)
        {
            rigid.MovePosition(transform.position + (transform.forward * walkSpeed * Time.deltaTime));
        }

    }

    private void Rotation()
    {
        if (isWalking)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                ReSetas();
        }
    }

    private void ReSetas()
    {
        isWalking = false; isAction = true;
        anim.SetBool("Walking", isWalking);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
        RandomAction();
    }
    private void RandomAction()
    {
        int _random = Random.Range(3, 4); //대기, 풀뜯기, 두리번, 걷기

        if (_random == 0)
            Wait();
        else if (_random == 1)
            Eat();
        else if (_random == 2)
            Peek();
        else
            TryWalk();  
    }

    private void Wait()
    {
        currentTime = waitTime;
        Debug.Log("대기");
    }
    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
        Debug.Log("풀뜯기");
    }
    private void Peek()
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
        Debug.Log("두리번");
    }
    private void TryWalk()
    {
        currentTime = walkTime;
        anim.SetBool("Walking", isWalking);
        Debug.Log("걷기");
    }
}
