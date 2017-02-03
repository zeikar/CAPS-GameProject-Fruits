using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour {

    public GameObject[] stages;     //만든 스테이지들

    public Transform StageParent;

    const int stageSize = 25;        //한 스테이지 길이
    int endOfStage = 25;     //현 전체 스테이지 길이

    void Init()
    {
        for(int i = 0; i < 3; i++)      //초기엔 일단 3개 생성
        {
            SpawnStage(endOfStage);
        }
    }

    void SpawnStage(int posZ){      //스테이지 이어붙이기
        int stageIndex = Random.Range(0, stages.Length);
        GameObject StageObject = Instantiate(stages[stageIndex]);
        StageObject.transform.position = new Vector3(0, 0, posZ);

        StageObject.transform.SetParent(StageParent);
        if(StageParent.GetChild(0).position.z < Fruits.instance.GetFruitPosZ()-stageSize * 2)
        {
            Destroy(StageParent.GetChild(0).gameObject);
        }

        endOfStage += stageSize;
    }

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        int fruitPosZ = Fruits.instance.GetFruitPosZ();

        if(endOfStage - 3 * stageSize < fruitPosZ)
        {
            SpawnStage(endOfStage);
        }
	}
}
