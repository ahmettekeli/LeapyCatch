using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalScore : MonoBehaviour {
	
	public Text finalSkor;
	public Text highSkor;
	public int highscore = 0;

	// Use this for initialization
	void Start () 
	{
		finalSkor.text = "Your Score: " + ScoreScript.score.ToString();
		if (PlayerPrefs.HasKey("Highscore"))
			highscore = PlayerPrefs.GetInt("Highscore");
	
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerPrefs.HasKey("Highscore"))
        {

            if (ScoreScript.score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", (int)ScoreScript.score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", (int)ScoreScript.score);
            PlayerPrefs.Save(); 
        }
        highscore = PlayerPrefs.GetInt("Highscore");
        highSkor.text = "High Score: "+highscore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start Game");
        }



    }
}
