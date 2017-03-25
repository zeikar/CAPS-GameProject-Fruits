using UnityEngine;
using System.Collections;

public class Fruits : MonoBehaviour
{

    const int MAX_WIDTH = 5;

    public int freshness;   //체력
    public int score = 0;
    public static Fruits instance;

    float speed = 5f;     //이동속도
    Rigidbody rigid;    //전반적인 물리엔진
    float jump_power;       //점프 정도
    int targetLane;     //과일이 달릴 차선

    const float originalSpeed = 30f;
    const float originalJumpPower = 10f;
    const float rotateSpeed = 60f;

    bool isJumping = false;
    bool isInvisible = false;

    void Init()
    {
        freshness = 3;
        score = 0;
    }

    void Awake()
    {
        instance = this;
        Init();
    }

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();  // 리지드바디 컴포넌트 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
        //Move(); // 앞으로 가는 함수 호출
    }

    void Move()
    {
        //rigid.AddForce(speed * Vector3.forward); // 앞으로 가도록 

        transform.position += new Vector3((targetLane - transform.position.x) * 0.2f, 0, 0);  //차이의 0.2만큼 조금씩 이동

        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * speed * Time.deltaTime * rotateSpeed);

        if (speed < originalSpeed)
        {
            speed += 0.01f;
        }

        score = (int)transform.position.z;
        UIManager.instance.ScoreUpdate();
    }
    public void Move(Vector3 v)
    {
        int newLane = targetLane + (int)Mathf.Round(v.x);

        if (IsAbletoMove(newLane))
        {
            targetLane = newLane;
        }
    }

    public void JumpStart()
    {
        isJumping = true;
        jump_power = originalJumpPower;
    }
    void Jump()
    {
        //점프
        if (!isJumping)
        {
            return;
        }

        transform.Translate(Vector3.up * jump_power * Time.deltaTime, Space.World);

        jump_power -= 0.2f;

        if (transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            isJumping = false;
        }
    }


    public void Bigger()
    {
        StartCoroutine(GetBigger());
    }
    IEnumerator GetBigger()
    {
        isInvisible = true;
        transform.localScale = new Vector3(3, 3, 3);
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);

        yield return new WaitForSeconds(2);

        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        isInvisible = false;
    }


    public void SpeedUp()
    {
        StartCoroutine(GetSpeedUp());
    }
    IEnumerator GetSpeedUp()
    {
        isInvisible = true;
        speed += 20.0f;

        yield return new WaitForSeconds(2);

        speed = originalSpeed;
        isInvisible = false;
    }

    public void Bruised()
    {
        freshness--;
        UIManager.instance.HeartUpdate();

        speed = -1; //맞나요? 약간 뒤로 물러나거나...

        if (freshness == 0)
        {
            Death();
        }
    }

    public void Heal()
    {
        if (freshness < 3)
        {
            freshness++;
            UIManager.instance.HeartUpdate();
        }
        //하트 하나 늘리기
    }

    public void Godown()
    {
        //y가 점차 감소...

        Death();
    }

    void Death()
    {
        //Fade Out
    }

    public int GetFruitPosZ()
    {
        return (int)transform.position.z;
    }

    bool IsGround()      // 과일이 땅에 있으면 true, 공중에(뛰고)있으면 false
    {
        return transform.position.y < 0.51f;
    }

    public bool GetIsInvisible()
    {
        return isInvisible;
    }

    bool IsAbletoMove(int position)
    {
        return (position <= MAX_WIDTH / 2 && position >= -MAX_WIDTH / 2);
    }
}
