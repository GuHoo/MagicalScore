using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalBookScript : MonoBehaviour {


    private Animator animator;

    private void Awake() {


    }

    // Use this for initialization
    void Start() {
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
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            animator.SetBool("isTurning", true);
        }
        else {
            animator.SetBool("isTurning", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            animator.SetBool("isReturning", true);
        }
        else {
            animator.SetBool("isReturning", false);
        }

    }
}
