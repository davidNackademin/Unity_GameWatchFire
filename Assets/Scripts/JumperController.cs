using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {
    
    public Transform positions;

    int currentPosition = 0;

    [HideInInspector]
    public float moveDelay;
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
        {
            currentPosition = 0;
            GameManager.Instance.JumperSaved();
            Die();
        }

        transform.position = positions.GetChild(currentPosition).transform.position;

        lastMoveTime = Time.time;

        if(positions.GetChild(currentPosition).GetComponent<JumperPosition>().dangerPosition) {
            if (GameManager.Instance.Crash(gameObject)) {
                Die();
            } 
        }
    }

    void Die() {
        Destroy(transform.parent.gameObject);

    }

}
