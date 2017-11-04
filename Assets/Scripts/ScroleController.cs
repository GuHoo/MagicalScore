using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroleController : MonoBehaviour {

	private const float SELECT_AREA_RANGE = 80;
	private GameObject[] scroles;


	void Awake () {
		scroles = GameObject.FindGameObjectsWithTag ("Scrole");
	}

	void Start () {
		
	}

	void Update () {
		CheckSclole ();
	}

	void CheckSclole () {
		if (IsInSelectArea ()) {
			scroles[0].GetComponent<Renderer>().material.color = Color.red;
		} else {
			scroles[0].GetComponent<Renderer>().material.color = Color.blue;
		}
	}

	private bool IsInSelectArea () {
		float screenCentorPointX = Screen.width / 2;
		float screenCentorPointY = Screen.height / 2;
		float maxSelectAreaX = screenCentorPointX + SELECT_AREA_RANGE / 2;
		float minSelectAreaX = screenCentorPointX - SELECT_AREA_RANGE / 2;
		float maxSelectAreaY = screenCentorPointY + SELECT_AREA_RANGE / 2;
		float minSelectAreaY = screenCentorPointY - SELECT_AREA_RANGE / 2;
		float scroleScreenPointX = RectTransformUtility.WorldToScreenPoint (Camera.main, scroles [0].transform.position).x;
		float scroleScreenPointY = RectTransformUtility.WorldToScreenPoint (Camera.main, scroles [0].transform.position).y;

		if (minSelectAreaX <= scroleScreenPointX && scroleScreenPointX <= maxSelectAreaX) {
			if (minSelectAreaY <= scroleScreenPointY && scroleScreenPointY <= maxSelectAreaY) {
				return true;
			}
		}
		return false;
	}
}
