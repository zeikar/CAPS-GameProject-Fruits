using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Transform fruit; //과일의 위치 저장
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0,1.5f,-3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position =new Vector3(offset.x, offset.y, fruit.position.z + offset.z);
	}
}
