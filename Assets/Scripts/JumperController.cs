using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {

    public List<Transform> positions = new List<Transform>();

	// Use this for initialization
	void Start () {
        transform.position = positions[0].position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
