using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MagicalScoreManager : MonoBehaviour {

	public MoverioUnityPlugin moverioUnityPlugin;

	void Start () {

	}

	void OnDisable(){


	}

	void Update () {
		DownKeyCheck ();
	}

	/// <summary>
	/// 押されたキーに応じた処理を実行する
	/// </summary>
	void DownKeyCheck()
	{
		// 真ん中のボタン
		if (Input.GetButtonDown("Fire1")) {
			PushEnterKey ();
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			PushUpKey ();
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			PushDownKey ();
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			PushLeftKey ();
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			PushRightKey ();
		} else if (Input.GetKey(KeyCode.Escape)) {
			PushEscapeKey ();
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

	private void PushEnterKey ()
	{
		
	}

	private void PushEscapeKey (){

	}
}
