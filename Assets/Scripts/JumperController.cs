﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {

    public GameManager gameManager;
    public List<GameObject> positions = new List<GameObject>();
    int currentPosition = 0;
    public float moveDelay = 0.5f;
    float lastMoveTime;

	// Use this for initialization
	void Start () {
        transform.position = positions[currentPosition].transform.position;
        lastMoveTime = Time.time;

        StartCoroutine(Move());
	}
	
    IEnumerator Move() {
        while(true) {
            yield return new WaitForSeconds(moveDelay);
            StartCoroutine( MoveToNextPosition());
        }
    }


	// Update is called once per frame
	//void Update () {
        
 //       if ( Time.time > lastMoveTime + moveDelay) {
 //           MoveToNextPosition();

 //       }
	//}

    IEnumerator MoveToNextPosition() {
        currentPosition++;

        if (currentPosition >= positions.Count)
            currentPosition = 0;

        transform.position = positions[currentPosition].transform.position;

        lastMoveTime = Time.time;

        // wait one frame until crash check is done so physics is calculated
        yield return null;

        if(positions[currentPosition].GetComponent<JumperPosition>().dangerPosition) {
            if (gameManager.Crash(gameObject)) {
                Die();
            } else {

             //   Debug.Log("Continue!");
            }


        }
    }

    void Die() {
        Destroy(transform.parent.gameObject);

    }

}
