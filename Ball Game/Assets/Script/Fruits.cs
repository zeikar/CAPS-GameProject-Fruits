using UnityEngine;
using System.Collections;

public class Fruits : MonoBehaviour {

    const int MAX_WIDTH = 5;

    public int freshness;   //체력
    public float speed;
    Rigidbody rigid;    //전반적인 물리엔진
    public float jump_power;
    public static Fruits instance;
    int TargetLane=0;
    

    void Init()
    {

    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();  // 유니티에서 물리엔진 받아옴
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

        transform.position += new Vector3((TargetLane - transform.position.x) * 0.2f, 0, 0);
    }

    public void Move(Vector3 v)
    {
        int newLane = TargetLane + (int)Mathf.Round(v.x);

        if (IsAbleToMove(newLane))
        {
            TargetLane = newLane;
        }
    }

    public void Jump()
    {
        if (IsGround())     // 과일이 땅에 있을 때만
        {
            rigid.AddForce(jump_power * Vector3.up);    //위로 가도록
        }
    }

    public void Growth()
    {

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

    bool IsGround()      // 과일이 땅에 있으면 true, 공중에(뛰고)있으면 false
    {
        return transform.position.y < 0.51f;
    }

    bool IsAbleToMove(int pos)
    {
        return pos <= MAX_WIDTH / 2 && pos >= -MAX_WIDTH / 2;
    }
}
