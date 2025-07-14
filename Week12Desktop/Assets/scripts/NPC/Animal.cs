using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [SerializeField] protected string animalName; //동물의 이름
    [SerializeField] protected int hp; //동물의 체력

    [SerializeField] protected float walkSpeed; //걷기 속도
    [SerializeField] protected float runSpeed; //뛰기 속도
    
    

    [SerializeField]
    protected Vector3 destination; //목적지

    //상태변수
    protected bool isAction; //행동 여부 확인
    protected bool isWalking; //걷기 여부 확인
    protected bool isRunning; //뛰는지 확인
    protected bool isDead; //죽ㅇ 판

    [SerializeField] protected float walkTime; //걷기 시간
    [SerializeField] protected float waitTime; //대기시간
    [SerializeField] protected float runTime; //뛰기 시간
    protected float currentTime;

    //필요한 컴포넌트
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected BoxCollider boxCol;
    protected AudioSource theAudio;
    protected NavMeshAgent nav;

    [SerializeField] protected AudioClip[] sound_normal;
    [SerializeField] protected AudioClip sound_Hurt;
    [SerializeField] protected AudioClip soung_Dead;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        theAudio = GetComponent<AudioSource>();
        currentTime = waitTime;
        isAction = true;

    }

    void Update()
    {
        if (!isDead)
        {
            Move();
            ElapseTime();
        }
    }

    protected void Move()
    {
        if (isWalking || isRunning)
        {
            //rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
            nav.SetDestination(transform.position + destination * 5f);
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

    protected virtual void ReSetas()
    {
        isWalking = false; isRunning = false; isAction = true;
        nav.speed = walkSpeed;
        nav.ResetPath();
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
    }
    

    
    protected void TryWalk()
    {
        nav.speed = walkSpeed;
        currentTime = walkTime;
        anim.SetBool("Walking", isWalking);
        Debug.Log("걷기");
    }
    

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                return;
            }

            PlaySE(sound_Hurt);
            anim.SetTrigger("Hurt");
        }
    }

    protected void Dead()
    {
        PlaySE(soung_Dead);
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("Dead");
    }

    protected void RandomSound()
    {
        int _random = Random.Range(0, 3); //일상 사운드 3개
        PlaySE(sound_normal[_random]);
    }

    protected void PlaySE(AudioClip _clip)
    {
        theAudio.clip = _clip;
        theAudio.Play();
    }
}
