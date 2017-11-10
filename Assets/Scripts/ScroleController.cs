using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class ScoreController : MonoBehaviour {

	private const float SELECT_AREA_RANGE = 200;
    private bool canSelectBook = false;

	void Awake () {

	}

	void Start () {
        this.gameObject.transform.Find("Book").gameObject.GetComponent<Outline>().enabled = false;
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
            this.gameObject.transform.Find("Book").gameObject.GetComponent<Outline>().enabled = true;
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
            this.gameObject.transform.Find("Book").gameObject.GetComponent<Outline>().enabled = false;
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
