using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject jumperPrefab;
    public GameObject fireman;

	// Use this for initialization
	void Start () {
        GameObject newJumper = Instantiate(jumperPrefab);
        newJumper.GetComponentInChildren<JumperController>().gameManager = this;

	}

    public bool Crash(GameObject jumper) {

        Collider2D jumperCollider = jumper.GetComponent<Collider2D>();
        Collider2D firemanCollider = fireman.GetComponentInChildren<Collider2D>();

        if (jumperCollider == null || firemanCollider == null)
        {
            Debug.Log("collider not found");
        }

        if( jumperCollider.IsTouching(firemanCollider)){
         //   Debug.Log("no danger!!");
            return false;
        }
        else {
           // Debug.Log("Danger!!!");
            return true;
        }
            
        
    }

}
