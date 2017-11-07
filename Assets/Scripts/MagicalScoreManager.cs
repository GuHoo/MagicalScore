using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MagicalScoreManager : MonoBehaviour {

	public MoverioUnityPlugin moverioUnityPlugin;

	public GameObject scrole;

	public Text x;
	public Text y;
	public Text z;

	void Start () {
		Input.gyro.enabled = true;
	}

	void OnDisable(){


	}

	void Update () {
		
	}

	/// <summary>
	/// 押されたキーに応じた処理を実行する
	/// </summary>
	void DownKeyCheck()
	{
		if (Input.GetButtonDown("Fire1")) {
			PushEnterKey ();
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			PushUpKey ();
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			PushDownKey ();
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			PushLeftKey ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			PushRightKey ();
		} else if (Input.GetKey (KeyCode.Escape)) {
			PushEscapeKey ();
		}
	}

	private void PushEnterKey ()
	{

	}

	private void PushUpKey ()
	{

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
