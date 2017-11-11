using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornBook : MonoBehaviour {

    bool continueFlag = true;
    float time = 0.0f;
    float changedAngle = 0f;
    private Animator animator;

    float minAngleX = 0.0F;
    float maxAngleX = 90.0F;

    float minAngleZ = 90.0F;
    float maxAngleZ = 0.0F;

    void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("isInitialize", true);
    }

    void Update()
    {
        if (continueFlag)
        {
            float angleX = Mathf.LerpAngle(minAngleX, maxAngleX, Time.time);
            float angleZ = Mathf.LerpAngle(minAngleZ, maxAngleZ, Time.time);
            transform.eulerAngles = new Vector3(angleX, 180, angleZ);
            if (transform.localEulerAngles.x == 90f && transform.localEulerAngles.z == 0)
            {
                continueFlag = false;
            }
        }
    }
}
