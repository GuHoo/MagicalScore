using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimation : MonoBehaviour {

    private Animator animator;

    SkinnedMeshRenderer smr;

    float blendOne = 0f;
    float blendSpeed = 1f;


    private void Awake() {


    }

    // Use this for initialization
    void Start() {
        smr = GetComponentInChildren<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            animator.SetBool("isOpening", true);
        }
        else {
            animator.SetBool("isOpening", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            animator.SetBool("isClosing", true);
        }
        else {
            animator.SetBool("isClosing", false);
        }

        if (blendOne < 100f) {
            smr.SetBlendShapeWeight(0, blendOne);
            Debug.Log(blendOne);
            blendOne += blendSpeed;
        }

    }
}
