using UnityEngine;
using System.Collections;

public class Fruits : MonoBehaviour {

    const int MAX_WIDTH = 5;

    public int freshness;   //체력
    public float speed;     //이동속도
    Rigidbody rigid;    //전반적인 물리엔진
    public float jump_power;       //점프 정도
    public static Fruits instance;
    int targetLane;     //과일이 달릴 차선

    void Init()
    {

    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();  // 리지드바디 컴포넌트 가져옴
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Move(); // 앞으로 가는 함수 호출
    }

    void Move()
    {
        rigid.AddForce(speed * Vector3.forward); // 앞으로 가도록 

        transform.position += new Vector3((targetLane - transform.position.x) * 0.2f,0,0);  //차이의 0.2만큼 조금씩 이동
    }

    public void Jump()
    {
        if (IsGround())     // 과일이 땅에 있을 때만
        {
            rigid.AddForce(jump_power * Vector3.up);    //위로 가도록
        }
    }

    public void Move(Vector3 v)
    {
        int newLane = targetLane + (int)Mathf.Round(v.x);   //

        if (IsAbletoMove(newLane))
        {
            targetLane =newLane;
        }
    }

    public void Bigger()
    {
        StartCoroutine( GetBigger());
    }

    IEnumerator GetBigger()
    {
        transform.localScale = new Vector3(3, 3, 3);
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);

        yield return new WaitForSeconds(2);

        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }


    public void SpeedUp()
    {

    }

    void Bruised()
    {

    }

    void Heal()
    {

    }

    void Death()
    {

    }

    public int GetFruitPosZ()
    {
        return (int)transform.position.z;
    }

    bool IsGround()      // 과일이 땅에 있으면 true, 공중에(뛰고)있으면 false
    {
        return transform.position.y < 0.51f;
    }

    bool IsAbletoMove(int position)
    {
        return (position <= MAX_WIDTH/2 && position >= -MAX_WIDTH / 2);
    }
}
