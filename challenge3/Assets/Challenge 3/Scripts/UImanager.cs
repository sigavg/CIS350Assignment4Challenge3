/* Luke Lesimple
 * Challenge 3
 * manages UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public PlayerControllerX pc;

    public bool won = false;


    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (pc == null)
        {
            pc = GameObject.FindGameObjectWithTag("Balloon").GetComponent<PlayerControllerX>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (pc.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" +
                             "Press R to Try Again";
        }

        if (score >= 10)
        {
            pc.gameOver = true;
            won = true;

            // TODO: stop player running
            //pc.StopRunning();

            scoreText.text = "You Win!" + "\n" +
                             "Press R to Try Again";
        }

        if (pc.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }



    }
}
