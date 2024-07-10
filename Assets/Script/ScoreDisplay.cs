using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int skor = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Skor: " + skor.ToString();
    }
}
