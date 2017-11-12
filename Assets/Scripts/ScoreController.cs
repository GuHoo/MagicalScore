using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroleController : MonoBehaviour {

	private const float SELECT_AREA_RANGE = 200;
	private GameObject score;
    private bool canSelectBook = false;

	void Awake () {
        score = this.gameObject;
	}

	void Start () {
		
	}

	void Update () {
        ScoreControl();
	}

	void ScoreControl() {
        if (canSelectBook) {
            if (IsInSelectArea()) {
                //scores[0].GetComponent<Renderer>().material.color = Color.red;
                if(score.GetComponent<FixedJoint>() == null && Input.GetButtonDown("Fire1")) {
                    score.AddComponent<FixedJoint>();
                    score.GetComponent<FixedJoint>().connectedBody = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Rigidbody>();
                }　else {
                    Destroy(score.GetComponent<FixedJoint>());
                }
            } else {
                //scores [0].GetComponent<Renderer> ().material.color = Color.blue;
            }
        }
    }

    /// <summary>
    /// カメラの向いている方向に楽譜があるか
    /// </summary>
    private bool IsInSelectArea () {
		float screenCentorPointX = Screen.width / 2;
		float screenCentorPointY = Screen.height / 2;
		float maxSelectAreaX = screenCentorPointX + SELECT_AREA_RANGE / 2;
		float minSelectAreaX = screenCentorPointX - SELECT_AREA_RANGE / 2;
		float maxSelectAreaY = screenCentorPointY + SELECT_AREA_RANGE / 2;
		float minSelectAreaY = screenCentorPointY - SELECT_AREA_RANGE / 2;
		float scroleScreenPointX = RectTransformUtility.WorldToScreenPoint (Camera.main, score.transform.position).x;
		float scroleScreenPointY = RectTransformUtility.WorldToScreenPoint (Camera.main, score.transform.position).y;

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
