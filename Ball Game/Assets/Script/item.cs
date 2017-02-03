using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider obj)
    {
        Action(obj);
    }

    public virtual void Action(Collider obj)
    {

    }
}
