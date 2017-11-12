using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornBook : MonoBehaviour {

    bool continueFlag = true;
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
        bornMovement();
    }

    private void bornMovement ()
    {
        if (continueFlag)
        {
            totalTime += Time.deltaTime;
            float angleX = Mathf.LerpAngle(minAngleX, maxAngleX, totalTime);
            float angleZ = Mathf.LerpAngle(minAngleZ, maxAngleZ, totalTime);
            Debug.Log(totalTime);
            transform.eulerAngles = new Vector3(angleX, 180, angleZ);
            /*
            if (transform.localEulerAngles.x == 90f && transform.localEulerAngles.z == 0)
            {
                continueFlag = false;
            }*/
        }
    }
}
