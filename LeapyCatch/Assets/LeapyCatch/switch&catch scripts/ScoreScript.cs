using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour 
{

	public static float score;
	public static float gameLife=3;
    public static float multipliar = 1;

    public Text scoreTxt;
	public static bool gameOver;
	public static int spawnerSelection;
    public GameObject[] lifeLeft;
    public Animator anim;

	// Use this for initialization
	void Start () 
	{
		score = 0;
		gameLife = 3;
		gameOver = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
            Invoke("EndGame", 0.5f);
        if (gameOver)
            Invoke("EndGame", 0.5f);
        if (gameLife == 2)
            lifeLeft[2].SetActive(false);
        else if (gameLife == 1)
            lifeLeft[1].SetActive(false);
        else if (gameLife == 0)
            lifeLeft[0].SetActive(false);
        scoreTxt.text = score.ToString();
	}

	public static void lifeDecrease()
	{
		gameLife -= 1f;
	}

    public static void lifeIncrease()
    {
        gameLife += 1f;
    }

	public static void scoreIncrease()
	{
		score += 1f*multipliar;
	}

    public static void scoreDecrease()
    {
        score -= 1f;
    }

    public static void scoreDecAnim()
    {
        //score -1 animasyonu
    }

    public static void lifeIncAnim()
    {
        //life +1 animasyonu
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
