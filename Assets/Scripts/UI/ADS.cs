using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void showAds ()
    {
        Advertisement.Show("", new ShowOptions() { resultCallback = HandleResult });
    }

    private void HandleResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                StartCoroutine(JogoManager.GameManager.RewardedAds());
                break;

            case ShowResult.Skipped:
                JogoManager.GameManager.ReloadScene();
                break;

            case ShowResult.Failed:
                JogoManager.GameManager.ReloadScene();
                break;
        }
    }
}
