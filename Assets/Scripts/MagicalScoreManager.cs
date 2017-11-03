using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MagicalScoreManager : MonoBehaviour {

	public MoverioUnityPlugin moverioUnityPlugin;

	public GameObject camera;
	public GameObject scrole;

	public Text x;
	public Text y;
	public Text z;
	//public Text w;

	bool hasFixedJoint = true;

	void Start () {
		Input.gyro.enabled = true;
		Debug.Log (scrole.GetComponent<FixedJoint> ().connectedBody);
	}

	void OnDisable(){


	}

	void Update () {
		DownKeyCheck ();
		/*
		x.text = Input.gyro.attitude.x.ToString();
		y.text = Input.gyro.attitude.y.ToString();
		z.text = Input.gyro.attitude.z.ToString();
		w.text = Input.gyro.attitude.w.ToString();
		*/


		x.text = camera.transform.eulerAngles.x.ToString ();
		y.text = camera.transform.eulerAngles.y.ToString ();
		z.text = camera.transform.eulerAngles.z.ToString ();
	}

	/// <summary>
	/// 押されたキーに応じた処理を実行する
	/// </summary>
	void DownKeyCheck()
	{
		// 真ん中のボタン
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
		if (hasFixedJoint) {
			Destroy (scrole.GetComponent<FixedJoint> ());
			hasFixedJoint = false;
		} else {
			scrole.AddComponent<FixedJoint> ();
			scrole.GetComponent<FixedJoint> ().connectedBody = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Rigidbody>();
			hasFixedJoint = true;
		}
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
