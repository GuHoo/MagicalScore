using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSelectModeViewController : MonoBehaviour {

    public GameObject scoreBook;
    private ScoreController scoreController;
    private GameObject buttonControlBook;
    private GameObject buttonBackStandard;

    void Start () {
        scoreController = scoreBook.GetComponent<ScoreController>();
		buttonControlBook = transform.Find("ButtonControlBook").gameObject;
        buttonBackStandard = transform.Find("ButtonBackStandard").gameObject;
    }
	
	void Update () {
		
	}

    public void ClickButtonControlBook ()
    {
         buttonControlBook.SetActive(false);
         buttonBackStandard.SetActive(true);
         scoreController.setCanSelectBook(true);
    }

    public void ClickBackStandard()
    {
        buttonBackStandard.SetActive(false);
        buttonControlBook.SetActive(true);
        scoreController.setCanSelectBook(false);
    }
}
