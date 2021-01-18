using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int maxScore;
    public Text scoreCounter;
    public Text recordText;
    private bool readyNow=true;
    private int secTimer;
    private Camera mainCamera;
    [SerializeField]private string playerPrefsKey= "BallRunKey";
    
    void Start()
    {
        mainCamera = Camera.main;
        maxScore=LoadRecord(playerPrefsKey);
        recordText.text = maxScore.ToString();
    }

    int LoadRecord(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0;
    }

    void Update()
    {
        if (readyNow)
        {
            StartCoroutine(GameTimer());
        }
    }

    public IEnumerator GameTimer()
    {
        readyNow = false;
        secTimer++;
        scoreCounter.text = secTimer.ToString();
        yield return new WaitForSeconds(1);
        readyNow = true;
    }
    public void EndGame()
    {
        mainCamera.backgroundColor = new Color (Mathf.Lerp(mainCamera.backgroundColor.r,0,0.15f),0,0);
        scoreCounter.color = new Color(Mathf.Lerp(50,255,0.03f),0,0);
        if (mainCamera.backgroundColor==Color.black)
        {
            if (secTimer>maxScore)
            {
                PlayerPrefs.SetInt(playerPrefsKey,secTimer);
            }
            recordText.text = secTimer.ToString();
            recordText.transform.parent.gameObject.SetActive(true);
            scoreCounter.enabled = false;
        }
        
    }
    public void ReloadScene()
    {
        StopCoroutine(GameTimer());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
