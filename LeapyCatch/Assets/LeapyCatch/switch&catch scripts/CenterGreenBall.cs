using UnityEngine;
using System.Collections;

public class CenterGreenBall : MonoBehaviour {

	public AudioClip destroySound, wrongSound,gameOverSound;
    public BottomModeScript bms;
    //public HalfScreenRotateScript hsrs;
    //public powerUpScript puS;

    public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "green" && collision.gameObject.tag == "green")
		{
			Destroy(collision.gameObject);
			AudioSource.PlayClipAtPoint(destroySound, transform.position);
			ScoreScript.scoreIncrease();
		}

		else
		{
			Destroy(collision.gameObject);
			AudioSource.PlayClipAtPoint(wrongSound, transform.position);
			ScoreScript.lifeDecrease();
		}

		if (ScoreScript.gameLife == 0)
		{
			//AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
			ScoreScript.gameOver = true;
            gameFinish();
        }

	}

	public void gameFinish()
	{
		ScoreScript.gameOver = true;
	}


}
