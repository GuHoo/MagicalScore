using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadScoreViewController : MonoBehaviour {

	private GameObject toggleScrollTitlePrerfab;
    private GameObject scoreBookPrerfab;
    private GameObject viewport;
	private GameObject content;
    private Texture[] testPapers;


    void Start() {
        toggleScrollTitlePrerfab = (GameObject)Resources.Load("Prefabs/ToggleScrollTitle");
        scoreBookPrerfab = (GameObject)Resources.Load("Prefabs/ScoreBook");
        viewport = this.gameObject.transform.Find("Scroll View").gameObject.transform.Find("Viewport").gameObject;
        content = viewport.transform.Find("Content").gameObject;
        // 時間ないので直接ぶち込む
        testPapers = Resources.LoadAll<Texture>("SampleScore");
        SetScoreTitle ();
	}

	void Update () {

	}

    /// <summary>
    /// 戻るボタン
    /// </summary>
    public void ClickBackButton () {
        this.gameObject.SetActive (false);
	}

    /// <summary>
    /// ReadScoreViewのインスタンス作成時にタイトルの初期化
    /// </summary>
	private void SetScoreTitle () {
		GameObject toggleScrollTitleInstance;
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Score");
        // 楽譜の数だけインスタンス作成
		for(int i = 0; i < directoryInfo.GetDirectories ().Length; i++) {
			DirectoryInfo tmpDirInfo = directoryInfo.GetDirectories () [i];
			toggleScrollTitleInstance = Instantiate(toggleScrollTitlePrerfab);
			toggleScrollTitleInstance.GetComponentInChildren<Text>().text = tmpDirInfo.Name;
			toggleScrollTitleInstance.transform.SetParent(content.transform);
            toggleScrollTitleInstance.GetComponent<Toggle>().group = toggleScrollTitleInstance.GetComponentInParent<ToggleGroup>();
        }
	}

	public void GetScoreImage() {
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Score");

		for(int i = 0; i < directoryInfo.GetDirectories ().Length; i++) { // Score下のディレクトリ
			DirectoryInfo tmpDirInfo = directoryInfo.GetDirectories () [i];
			for(int j = 0; j < tmpDirInfo.GetFiles().Length; j++) { // Scoreの中のファイル
				FileInfo tmpFileInfo = tmpDirInfo.GetFiles () [j];
				Debug.Log (tmpFileInfo.Name);
			}
		}
	}

    /// <summary>
    /// 楽譜選択ボタンが押された
    /// </summary>
    public void clickButtonSelectScrole () {
        GameObject scoreBookInstance = Instantiate(scoreBookPrerfab, new Vector3(0, 1, 1), Quaternion.Euler(0, 180, 90));
        GameObject book = scoreBookInstance.transform.Find("Book").gameObject;


        // ページのテクスチャを探し出して貼り付ける
        for (int i = 0; i < book.GetComponent<Renderer>().materials.Length; i++) {
            //Debug.Log(":" +  book.GetComponent<Renderer>().materials[i].name + ":");
            if (book.GetComponent<Renderer>().materials[i].name == "PageSpaceL (Instance)") {
                book.GetComponent<Renderer>().materials[i].mainTexture = testPapers[0];
            } else if (book.GetComponent<Renderer>().materials[i].name == "PageSpaceR (Instance)") {
                book.GetComponent<Renderer>().materials[i].mainTexture = testPapers[1];
            }
        }
        this.gameObject.SetActive(false);
    }
}
