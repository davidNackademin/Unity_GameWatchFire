using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour {

    public GameObject redSquare;

    Collider2D greenCollider;
    Collider2D redCollider;

    SpriteRenderer spriteRenderer;
    Color startColor;


    private void Start()
    {
        //SpriteRenderer spriteRenderer =  GetComponent<SpriteRenderer>();

        //spriteRenderer.color = Color.gray;


        //transform.localScale = new Vector3(2f, 3f, 1f);


        //SpriteRenderer redSpriteRenderer = redSquare.GetComponent<SpriteRenderer>();

        //redSpriteRenderer.color =Color.magenta;

        //redSquare.transform.localScale = new Vector3(0.5f, 2.5f, 1f);


        greenCollider = GetComponent<Collider2D>();
        redCollider = redSquare.GetComponent<Collider2D>();

        greenCollider.isTrigger = true;
        redCollider.isTrigger = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color; 


    }

    private void Update()
    {
        if(redCollider.IsTouching(greenCollider)) {
            spriteRenderer.color = Color.yellow; 
        } else {
            spriteRenderer.color = startColor;
        }



    }





}
