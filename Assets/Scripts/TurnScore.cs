using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScore : MonoBehaviour {

    public bool closeFlag = false;
    public bool openFlag = true;
    //private Animator animator;

    float minAngleX = 0.0F;
    float maxAngleX = 90.0F;

    float minAngleZ = 90.0F;
    float maxAngleZ = 0.0F;

    float totalTime = 0.0f;

    void Start () {
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(openFlag) { // 回転しながら本を開く
            turnWhileOpening();
        } else if(closeFlag) { // 回転しながら本を閉じる
            turnWhileClosing();
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && GetComponent<TurnScore>().closeFlag == false) {
            GetComponent<TurnScore>().openFlag = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && GetComponent<TurnScore>().openFlag == false) {
            GetComponent<TurnScore>().closeFlag = true;
        }
    }

    private void turnWhileOpening () {
        totalTime += Time.deltaTime;
        float angleX = Mathf.LerpAngle(minAngleX, maxAngleX, totalTime);
        float angleZ = Mathf.LerpAngle(minAngleZ, maxAngleZ, totalTime);
        transform.eulerAngles = new Vector3(angleX, 180, angleZ);
        if (transform.localEulerAngles.x == 90f && transform.localEulerAngles.z == 0) {
            openFlag = false;
            totalTime = 0.0f;
        }
    }

    private void turnWhileClosing() {
        totalTime += Time.deltaTime;
        float angleX = Mathf.LerpAngle(maxAngleX, minAngleX, totalTime);
        float angleZ = Mathf.LerpAngle(maxAngleZ, minAngleZ, totalTime);
        transform.eulerAngles = new Vector3(angleX, 180, angleZ);
        if (transform.localEulerAngles.x == 0.0f && transform.localEulerAngles.z == 90.0f) {
            closeFlag = false;
            totalTime = 0.0f;
        }
    }
}
