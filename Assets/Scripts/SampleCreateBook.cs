﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCreateBook : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime.ToString());
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject scoreBookPrerfab = (GameObject)Resources.Load("Prefabs/ScoreBook");
            Instantiate(scoreBookPrerfab, new Vector3(0, 1, 1), Quaternion.Euler(0, 180, 90));
        }
    }
}
