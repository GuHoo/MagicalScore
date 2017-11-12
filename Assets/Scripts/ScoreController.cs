using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroleController : MonoBehaviour {

	private const float SELECT_AREA_RANGE = 200;
	private GameObject[] scores;
	private bool inSelectArea = false;
	private bool hasFixedJoint = false;
    private bool canSelectBook = false;

	void Awake () {
        scores = GameObject.FindGameObjectsWithTag ("Score");
	}

	void Start () {
		
	}

	void Update () {
        ScloleControl ();
	}

	void ScloleControl() {
        if (canSelectBook)
        {
            inSelectArea = IsInSelectArea();
            if (!hasFixedJoint)
            {
                if (inSelectArea)
                {
                    //scores[0].GetComponent<Renderer>().material.color = Color.red;	
                    if (Input.GetButtonDown("Fire1"))
                    {
                        scores[0].AddComponent<FixedJoint>();
                        scores[0].GetComponent<FixedJoint>().connectedBody = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Rigidbody>();
                        hasFixedJoint = true;
                    }
                }
                else
                {
                    //scores [0].GetComponent<Renderer> ().material.color = Color.blue;
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Destroy(scores[0].GetComponent<FixedJoint>());
                    hasFixedJoint = false;
                }
            }
        }
	}

	private bool IsInSelectArea () {
		float screenCentorPointX = Screen.width / 2;
		float screenCentorPointY = Screen.height / 2;
		float maxSelectAreaX = screenCentorPointX + SELECT_AREA_RANGE / 2;
		float minSelectAreaX = screenCentorPointX - SELECT_AREA_RANGE / 2;
		float maxSelectAreaY = screenCentorPointY + SELECT_AREA_RANGE / 2;
		float minSelectAreaY = screenCentorPointY - SELECT_AREA_RANGE / 2;
		float scroleScreenPointX = RectTransformUtility.WorldToScreenPoint (Camera.main, scores[0].transform.position).x;
		float scroleScreenPointY = RectTransformUtility.WorldToScreenPoint (Camera.main, scores[0].transform.position).y;

		if (minSelectAreaX <= scroleScreenPointX && scroleScreenPointX <= maxSelectAreaX) {
			if (minSelectAreaY <= scroleScreenPointY && scroleScreenPointY <= maxSelectAreaY) {
				return true;
			}
		}
		return false;
	}

    public void changeCanSelectBook ()
    {
        canSelectBook = !canSelectBook;
    }
}
