// using UnityEngine;
// using TMPro;

// public class GP1Manager : MonoBehaviour
// {
//     public TMP_Text skorText;
//     public TMP_Text timerText;
//     public GameObject parentSampah;
//     public GameObject panelBerhasil;
//     //public GameObject panelKalah1;

//     private int skor = 0;
//     private float waktuSisa = 30f; // Ubah waktu menjadi 30 detik
//     private bool waktuHabis = false;
//     private bool permainanBerlangsung = true;

//     void Start()
//     {
//         UpdateSkorUI();
//         UpdateTimerUI();
//         UpdateTotalChildrenUI();
//         InvokeRepeating("UpdateTimer", 1f, 1f);
//     }

//     void UpdateTimer()
//     {
//         if (permainanBerlangsung)
//         {
//             waktuSisa -= 1f;
//             if (waktuSisa <= 0f)
//             {
//                 waktuSisa = 0f;
//                 waktuHabis = true;
//                 UpdatePanels();
//             }

//             UpdateTimerUI();
//         }
//     }

//     public void TambahSkor(int nilai)
//     {
//         skor += nilai;
//         if (skor < 0)
//             skor = 0;
//         UpdateSkorUI();
//         UpdatePanels();
//     }

//     public void KurangiSkor(int nilai)
//     {
//         skor -= nilai;
//         if (skor < 0)
//             skor = 0;
//         UpdateSkorUI();
//         UpdatePanels();
//     }

//     public void UpdateSkorUI()
//     {
//         skorText.text = "Skor: " + skor.ToString();
//     }

//     void UpdateTimerUI()
//     {
//         int menit = Mathf.FloorToInt(waktuSisa / 60f);
//         int detik = Mathf.FloorToInt(waktuSisa % 60f);
//         timerText.text = string.Format("Waktu: {0:00}:{1:00}", menit, detik);
//     }

//     void UpdatePanels()
//     {
//         if (CheckSemuaSampahTerdestroy())
//         {
//             panelBerhasil.SetActive(true);
//             permainanBerlangsung = false;
//             //panelKalah.SetActive(true);
//         }
//         else if (waktuHabis)
//         {           
//             panelBerhasil.SetActive(true);
//             //panelKalah.SetActive(true);
//         }
//     }

//     bool CheckSemuaSampahTerdestroy()
//     {
//         int jumlahSampah = parentSampah.transform.childCount;

//         for (int i = 1; i < jumlahSampah; i++)
//         {
//             GameObject sampah = parentSampah.transform.GetChild(i).gameObject;
//             if (sampah != null && sampah.activeSelf)
//             {
//                 return false;
//             }
//         }

//         return true;
//     }

//     public void SampahTerdestroy()
//     {
//         UpdateTotalChildrenUI();
//     }

//     void UpdateTotalChildrenUI()
//     {
//         int totalChildren = parentSampah.transform.childCount;

//         if (totalChildren == 0)
//         {
//             panelBerhasil.SetActive(true);
//             permainanBerlangsung = false;
//         }
//     }
// }

using UnityEngine;
using TMPro;

public class GP1Manager : MonoBehaviour
{
    public TMP_Text skorText;
    public TMP_Text timerText;
    public GameObject parentSampah;
    public GameObject panelBerhasil;

    private int skor = 0;
    private float waktuSisa = 30f; // Ubah waktu menjadi 30 detik
    private bool waktuHabis = false;
    private bool permainanBerlangsung = true;

    void Start()
    {
        UpdateSkorUI();
        UpdateTimerUI();
        UpdateTotalChildrenUI();
        InvokeRepeating("UpdateTimer", 1f, 1f);
    }

    void UpdateTimer()
    {
        if (permainanBerlangsung)
        {
            waktuSisa -= 1f;
            if (waktuSisa <= 0f)
            {
                waktuSisa = 0f;
                waktuHabis = true;
                UpdatePanels();
            }

            UpdateTimerUI();
        }
    }

    public void TambahSkor(int nilai)
    {
        skor += nilai;
        if (skor < 0)
            skor = 0;
        UpdateSkorUI();
        UpdatePanels();
    }

    public void KurangiSkor(int nilai)
    {
        skor -= nilai;
        if (skor < 0)
            skor = 0;
        UpdateSkorUI();
        UpdatePanels();
    }

    public void UpdateSkorUI()
    {
        skorText.text = "Skor: " + skor.ToString();
    }

    void UpdateTimerUI()
    {
        int menit = Mathf.FloorToInt(waktuSisa / 60f);
        int detik = Mathf.FloorToInt(waktuSisa % 60f);
        timerText.text = string.Format("Waktu: {0:00}:{1:00}", menit, detik);
    }

    void UpdatePanels()
    {
        if (CheckSemuaSampahTerdestroy())
        {
            panelBerhasil.SetActive(true);
            permainanBerlangsung = false;
            SaveScore();
        }
        else if (waktuHabis)
        {
            panelBerhasil.SetActive(true);
            SaveScore();
            //panelKalah.SetActive(true);
        }
    }

    bool CheckSemuaSampahTerdestroy()
    {
        int jumlahSampah = parentSampah.transform.childCount;

        for (int i = 1; i < jumlahSampah; i++)
        {
            GameObject sampah = parentSampah.transform.GetChild(i).gameObject;
            if (sampah != null && sampah.activeSelf)
            {
                return false;
            }
        }

        return true;
    }

    public void SampahTerdestroy()
    {
        UpdateTotalChildrenUI();
    }

    void UpdateTotalChildrenUI()
    {
        int totalChildren = parentSampah.transform.childCount;

        if (totalChildren == 0)
        {
            panelBerhasil.SetActive(true);
            permainanBerlangsung = false;
            SaveScore();
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", skor);
        PlayerPrefs.Save();
        Debug.Log("Skor disimpan: " + skor); // Debug log untuk verifikasi
    }
}
