using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {

    public List<Transform> positions = new List<Transform>();
    int currentPosition = 0;
    public float moveDelay = 0.5f;
    float lastMoveTime;

	// Use this for initialization
	void Start () {
        transform.position = positions[currentPosition].position;
        lastMoveTime = Time.time;

        StartCoroutine(Move());
	}
	
    IEnumerator Move() {
        while(true) {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
    }


	// Update is called once per frame
	//void Update () {
        
 //       if ( Time.time > lastMoveTime + moveDelay) {
 //           MoveToNextPosition();

 //       }
	//}

    void MoveToNextPosition() {
        currentPosition++;

        if (currentPosition >= positions.Count)
            currentPosition = 0;

        transform.position = positions[currentPosition].position;

        lastMoveTime = Time.time;
    }


}
