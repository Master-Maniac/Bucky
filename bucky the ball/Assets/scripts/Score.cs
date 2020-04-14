using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public int scoremulti = 2;

    PauseMenu scorestopper;

    float score;
    int number;

    Text scoretext;
    public Text highscoretext;

    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();

        highscoretext.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void scorecount()
    {
        score = score + Time.deltaTime;
        number = (int)score * scoremulti;
        scoretext.text = number.ToString();

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore",(int) score);
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highscoretext.text = "0";
    }
}
