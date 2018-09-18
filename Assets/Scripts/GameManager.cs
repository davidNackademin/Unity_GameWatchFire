using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance;  }}

    public GameObject jumperPrefab;
    public GameObject fireman;
    public LifeViewController lifeController;
    public PointsController pointsController;
    public float spawnDelay = 5.0f;
    public float moveDelay = 0.5f;

    private List<GameObject> jumperPool;
    private int poolSize = 15;


    bool continueGame = true;
    int points = 0;

    Collider2D firemanCollider;


    private void Awake()
    {
        if (Instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    // Use this for initialization
    void Start () {
        firemanCollider = fireman.GetComponentInChildren<Collider2D>();

        lifeController.RestoreAllLives();

        jumperPool = new List<GameObject>();

        InitJumperPool();

        StartCoroutine(JumperSpawner());
	}

    void InitJumperPool() {
        for (int i = 0; i < poolSize; i++ ) {
            GameObject jumper = Instantiate(jumperPrefab);
            jumper.SetActive(false);
            jumperPool.Add(jumper);
        }

    }

    GameObject GetJumper() {
        
        for (int i = 0; i < jumperPool.Count; i++) {

            if(!jumperPool[i].activeInHierarchy) {
                return jumperPool[i];
            }
        }
        return null;
    }


    IEnumerator JumperSpawner() {
        while(continueGame) {
            NewJumper(moveDelay - (0.02f * points));

            yield return new WaitForSeconds(spawnDelay - (0.1f * points) );
        }
    }


    GameObject NewJumper(float delay) {
        // GameObject newJumper = Instantiate(jumperPrefab);
        GameObject newJumper = GetJumper();
        newJumper.SetActive(true);
        JumperController jumperController = newJumper.GetComponentInChildren<JumperController>();
      //  jumperController.gameManager = this;
        jumperController.moveDelay = delay;

        return newJumper;
    }

    public void JumperSaved() {
        points++;
        pointsController.SetPoint(points);
    }

    public bool Crash(GameObject jumper) {

        LayerMask mask = LayerMask.GetMask("Fireman");
        RaycastHit2D hit = Physics2D.Raycast(jumper.transform.position, Vector2.down, Mathf.Infinity, mask);
        if ( hit.collider != null) {
            return false;
        }
        else {
            LoseOneLife();
            return true;
       } 
    }

    void LoseOneLife()
    {
        if (!lifeController.RemoveLife())
        {
            Debug.Log("Game Over!");
            continueGame = false;
        }
    }
}
