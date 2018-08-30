﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject jumperPrefab;
    public GameObject fireman;
    public LifeViewController lifeController;

    Collider2D firemanCollider;


	// Use this for initialization
	void Start () {
        firemanCollider = fireman.GetComponentInChildren<Collider2D>();

        lifeController.RestoreAllLives();
        NewJumper();

	}

    void NewJumper() {
        GameObject newJumper = Instantiate(jumperPrefab);
        newJumper.GetComponentInChildren<JumperController>().gameManager = this;

    }

    public bool Crash(GameObject jumper) {

        LayerMask mask = LayerMask.GetMask("Fireman");
        RaycastHit2D hit = Physics2D.Raycast(jumper.transform.position, Vector2.down, Mathf.Infinity, mask);
        if ( hit.collider != null) {
            Debug.Log("Collision: " + hit.collider.gameObject.name);
            return false;
        }
        else {
            LoseOneLife();
            return true;
       } 
    }

    void LoseOneLife() {
        
        if (!lifeController.RemoveLife() )
        {
            Debug.Log("Game Over!");
        }
        else
        {
            NewJumper();
        }
    }

}
