using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UGUIController : MonoBehaviour {

	public GameObject uGUI;

	void Start () {
		
	}

	void Update () {
		
	}
		
	public void ClickBackButton () {
		uGUI.SetActive (false);
	}

	public void CheckStoragePath () {
		#if !UNITY_EDITOR && UNITY_ANDROID
			using (AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment"))
			{
				using (AndroidJavaObject storageDir = environment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
				{
					string _StorageDir = storageDir.Call<string>("getCanonicalPath");
					using (AndroidJavaClass log = new AndroidJavaClass("android.util.Log"))
					{
						log.CallStatic<int>("i", "UnityApp", _StorageDir);
					}
				}
			}
		#endif
	}

	public void GetScoreImage () {
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Score");

		Debug.Log (directoryInfo.GetDirectories ().Length);
		for(int i = 0; i < directoryInfo.GetDirectories ().Length; i++) { // Score下のディレクトリ
			DirectoryInfo tmpDirInfo = directoryInfo.GetDirectories () [i];
			for(int j = 0; j < tmpDirInfo.GetFiles().Length; j++) { // Scoreの中のファイル
				FileInfo tmpFileInfo = tmpDirInfo.GetFiles () [j];
				Debug.Log (tmpFileInfo.Name);
			}
		}
	}
}
