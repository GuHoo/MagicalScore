using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIController : MonoBehaviour {

	public GameObject uGUI;

	void Start () {
		
	}

	void Update () {
		
	}
		
	public void ClickBackButton () {
		uGUI.SetActive (false);
	}
}
