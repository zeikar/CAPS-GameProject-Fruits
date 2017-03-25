using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Transform fruit; //과일의 위치 저장
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0,4,-5);
        transform.Rotate(Vector3.right, 20);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = fruit.position + offset;
	}
}
