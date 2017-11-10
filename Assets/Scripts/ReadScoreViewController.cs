using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadScoreViewController : MonoBehaviour {

	public GameObject toggleScrollTitlePrerfab;
	public GameObject content;

	void Start () {
		SetScoreTitle ();
	}

	void Update () {

	}

    public void ClickBackButton () {
        this.gameObject.SetActive (false);
	}

	public void SetScoreTitle () {
		GameObject toggleScrollTitleInstance;
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Score");
		for(int i = 0; i < directoryInfo.GetDirectories ().Length; i++) {
			DirectoryInfo tmpDirInfo = directoryInfo.GetDirectories () [i];
			toggleScrollTitleInstance = Instantiate(toggleScrollTitlePrerfab);
			toggleScrollTitleInstance.GetComponentInChildren<Text>().text = tmpDirInfo.Name;
			toggleScrollTitleInstance.transform.SetParent(content.transform);
		}

	}

	public void GetScoreImage () {
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Score");

		for(int i = 0; i < directoryInfo.GetDirectories ().Length; i++) { // Score下のディレクトリ
			DirectoryInfo tmpDirInfo = directoryInfo.GetDirectories () [i];
			for(int j = 0; j < tmpDirInfo.GetFiles().Length; j++) { // Scoreの中のファイル
				FileInfo tmpFileInfo = tmpDirInfo.GetFiles () [j];
				Debug.Log (tmpFileInfo.Name);
			}
		}
	}
}
