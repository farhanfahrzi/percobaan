using UnityEngine;
using TMPro;

public class TeksScore : MonoBehaviour
{
    public TMP_Text skorText;

    void Start()
    {
        int  UpdateSkorUI = PlayerPrefs.GetInt("Skor:");
        skorText.text = "Skor: " + UpdateSkorUI.ToString();
    }
}
