using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	private const float SELECT_AREA_RANGE = 200;
    private bool canSelectBook = false;

	void Awake () {

	}

	void Start () {
		
	}

	void Update () {
        ScoreControl();
	}

	void ScoreControl() {
        if (canSelectBook)
        {
            ScoreSelect();
        }
	}

    private void ScoreSelect()
    {
        if (IsInSelectArea ())
        {
            //this.gameObject.transform.Find("Book").gameObject.GetComponent<Outline>();
            if (Input.GetButtonDown("Fire1"))
            {
                if (!this.gameObject.GetComponent<FixedJoint>())
                {
                    this.gameObject.AddComponent<FixedJoint>();
                    this.gameObject.GetComponent<FixedJoint>().connectedBody = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Rigidbody>();
                } else {
                    Destroy(this.gameObject.GetComponent<FixedJoint>());
                }
            }

        } else {
            //scores [0].GetComponent<Renderer> ().material.color = Color.blue;
        }
    }

	private bool IsInSelectArea () {
		float screenCentorPointX = Screen.width / 2;
		float screenCentorPointY = Screen.height / 2;
		float maxSelectAreaX = screenCentorPointX + SELECT_AREA_RANGE / 2;
		float minSelectAreaX = screenCentorPointX - SELECT_AREA_RANGE / 2;
		float maxSelectAreaY = screenCentorPointY + SELECT_AREA_RANGE / 2;
		float minSelectAreaY = screenCentorPointY - SELECT_AREA_RANGE / 2;
		float scroleScreenPointX = RectTransformUtility.WorldToScreenPoint (Camera.main, this.gameObject.transform.position).x;
		float scroleScreenPointY = RectTransformUtility.WorldToScreenPoint (Camera.main, this.gameObject.transform.position).y;

		if (minSelectAreaX <= scroleScreenPointX && scroleScreenPointX <= maxSelectAreaX) {
			if (minSelectAreaY <= scroleScreenPointY && scroleScreenPointY <= maxSelectAreaY) {
				return true;
			}
		}
		return false;
	}

    public void setCanSelectBook (bool flag)
    {
        canSelectBook = flag;
    }
}
