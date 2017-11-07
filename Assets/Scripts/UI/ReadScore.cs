using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScore : MonoBehaviour {

	public GameObject readScoreView;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeActive () {
		Debug.Log (readScoreView.activeSelf);
		if (readScoreView.activeSelf) {
			readScoreView.SetActive (false);
		} else {
			readScoreView.SetActive (true);
		}
	}
}
