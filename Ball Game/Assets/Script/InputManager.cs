using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fruits.instance.JumpStart();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Fruits.instance.Move(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Fruits.instance.Move(Vector3.right);
        }
    }
}
