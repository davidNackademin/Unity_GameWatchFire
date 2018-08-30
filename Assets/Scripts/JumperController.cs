using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {

    [HideInInspector]
    public GameManager gameManager;
    public Transform positions;

    int currentPosition = 0;
    public float moveDelay = 0.5f;
    float lastMoveTime;

	// Use this for initialization
	void Start () {
        transform.position = positions.GetChild(currentPosition).transform.position;
        lastMoveTime = Time.time;

        StartCoroutine(Move());
	}
	
    IEnumerator Move() {
        while(true) {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
    }


    void MoveToNextPosition() {
        currentPosition++;

        if (currentPosition >= positions.childCount)
            currentPosition = 0;

        transform.position = positions.GetChild(currentPosition).transform.position;

        lastMoveTime = Time.time;

        if(positions.GetChild(currentPosition).GetComponent<JumperPosition>().dangerPosition) {
            if (gameManager.Crash(gameObject)) {
                Die();
            } 
        }
    }

    void Die() {
        Destroy(transform.parent.gameObject);

    }

}
