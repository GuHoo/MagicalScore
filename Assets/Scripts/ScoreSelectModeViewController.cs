using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSelectModeViewController : MonoBehaviour {

    private GameObject buttonControlBook;
    private GameObject buttonBackStandard;

    void Start () {
		buttonControlBook = transform.Find("ButtonControlBook").gameObject;
        buttonBackStandard = transform.Find("ButtonBackStandard").gameObject;
    }
	
	void Update () {
		
	}

    public void ClickButtonControlBook ()
    {
         buttonControlBook.SetActive(false);
         buttonBackStandard.SetActive(true);
        setCanSelectBooks(true);
    }

    public void ClickBackStandard()
    {
        buttonBackStandard.SetActive(false);
        buttonControlBook.SetActive(true);
        setCanSelectBooks(false);
    }

    // タグがScoreのオブジェクトのcanSelectBookフラグをセットする
    private void setCanSelectBooks(bool flag) {
        GameObject[] scores = GameObject.FindGameObjectsWithTag("Score");
        for (int i = 0; i < scores.Length; i++) {
            scores[i].GetComponent<BookController>().setCanSelectBook(true);
        }
    }
}
