using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MagicalScoreManager : MonoBehaviour {

	public MoverioUnityPlugin moverioUnityPlugin;

    public GameObject readlScoreView;

	void Start () {
		Input.gyro.enabled = true;
	}

	void OnDisable(){


	}

	void Update () {
        DownKeyCheck();
    }

    /// <summary>
    /// 押されたキーに応じた処理を実行する
    /// </summary>
    void DownKeyCheck()
	{
		if (Input.GetButtonDown("Fire1")) {
			PushEnterKey ();
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			PushUpKey ();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			PushDownKey ();
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			PushLeftKey ();
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			PushRightKey ();
		} else if (Input.GetKeyDown(KeyCode.Escape)) {
			PushEscapeKey ();
		}
	}

	private void PushEnterKey ()
	{

	}

	private void PushUpKey ()
	{
        if (readlScoreView.activeSelf)
        {
            readlScoreView.SetActive(false);
        } else
        {
            readlScoreView.SetActive(true);
        }
    }

	private void PushDownKey ()
	{

	}

	private void PushLeftKey ()
	{

	}

	private void PushRightKey ()
	{

	}
		

	private void PushEscapeKey (){

	}
}
