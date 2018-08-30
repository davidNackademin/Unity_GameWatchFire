﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour {

    TextMeshPro textMesh;
    int points = 0;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();

        textMesh.SetText(points.ToString());

        if(textMesh == null) {
            Debug.LogError("Textmesh component not found!");
        }
    }


    public void AddPoint() {
        points++;
        textMesh.SetText(points.ToString());



    }

	
}
