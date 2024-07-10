// using UnityEngine;
// using TMPro;

// public class GP2Manager : MonoBehaviour
// {
//     public GameObject[] sampahTurunPrefabs;
//     public Transform spawnPoint;
//     public Collider2D bottomBoundaryCollider;
//     public TMP_Text skorText;
//     public TMP_Text timerText;
//     public GameObject panelGameOver;

//     public int skorTambahan = 10;
//     public int skorPenalti = 5;

//     public float minX = -8f;
//     public float maxX = 8f;
//     public float spawnInterval = 2f;

//     private float timer = 30f;
//     private bool isGameOver = false;
//     private float nextSpawnTime = 0f;
//     private int skor = 0;

//     private GameObject[] spawnedObjects;

//     void Start()
//     {
//         skorText.text = "Skor: " + skor;
//         UpdateTimerText();
//         panelGameOver.SetActive(false);
//     }

//     void Update()
//     {
//         if (!isGameOver)
//         {
//             UpdateTimer();
//             if (Time.time >= nextSpawnTime)
//             {
//                 SpawnSampahTurun();
//                 nextSpawnTime = Time.time + spawnInterval;
//             }
//         }
//     }

//     void UpdateTimer()
//     {
//         timer -= Time.deltaTime;
//         if (timer <= 0)
//         {
//             timer = 0;
//             GameOver();
//             HapusSampah();
//         }
//         UpdateTimerText();
//     }

//     void UpdateTimerText()
//     {
//         timerText.text = "Timer: " + Mathf.Round(timer).ToString();
//     }

//     void SpawnSampahTurun()
//     {
//         float randomX = Random.Range(minX, maxX);
//         Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, 0f);

//         int randomIndex = Random.Range(0, sampahTurunPrefabs.Length);
//         GameObject selectedPrefab = sampahTurunPrefabs[randomIndex];

//         GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
//         AddToSpawnedObjects(spawnedObject);
//     }

//     void AddToSpawnedObjects(GameObject obj)
//     {
//         if (spawnedObjects == null)
//         {
//             spawnedObjects = new GameObject[1] { obj };
//         }
//         else
//         {
//             System.Array.Resize(ref spawnedObjects, spawnedObjects.Length + 1);
//             spawnedObjects[spawnedObjects.Length - 1] = obj;
//         }
//     }

//     public void TambahSkor()
//     {
//         skor += skorTambahan;
//         if (skor < 0) // Pastikan skor tidak pernah kurang dari 0
//         {
//             skor = 0;
//         }
//         skorText.text = "Skor: " + skor;
//     }

//     public void KurangiSkor()
//     {
//         skor -= skorPenalti;
//         if (skor < 0) // Pastikan skor tidak pernah kurang dari 0
//         {
//             skor = 0;
//         }
//         skorText.text = "Skor: " + skor;
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("SampahTurun"))
//         {
//             KurangiSkor();
//         }
//     }

//     void GameOver()
//     {
//         isGameOver = true;
//         panelGameOver.SetActive(true);
//     }

//     void HapusSampah()
//     {
//         if (spawnedObjects != null)
//         {
//             foreach (GameObject obj in spawnedObjects)
//             {
//                 if (obj != null)
//                 {
//                     Destroy(obj);
//                 }
//             }
//         }
//     }
// }

using UnityEngine;
using TMPro;

public class GP2Manager : MonoBehaviour
{
    public GameObject[] sampahTurunPrefabs;
    public Transform spawnPoint;
    public Collider2D bottomBoundaryCollider;
    public TMP_Text skorText;
    public TMP_Text timerText;
    public GameObject panelGameOver;

    public int skorTambahan = 10;
    public int skorPenalti = 5;

    public float minX = -8f;
    public float maxX = 8f;
    public float spawnInterval = 2f;

    private float timer = 30f;
    private bool isGameOver = false;
    private float nextSpawnTime = 0f;
    private int skor = 0;

    private GameObject[] spawnedObjects;

    void Start()
    {
        skorText.text = "Skor: " + skor;
        UpdateTimerText();
        panelGameOver.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            UpdateTimer();
            if (Time.time >= nextSpawnTime)
            {
                SpawnSampahTurun();
                nextSpawnTime = Time.time + spawnInterval;
            }
        }
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            GameOver();
            HapusSampah();
        }
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timerText.text = "Timer: " + Mathf.Round(timer).ToString();
    }

    void SpawnSampahTurun()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, 0f);

        int randomIndex = Random.Range(0, sampahTurunPrefabs.Length);
        GameObject selectedPrefab = sampahTurunPrefabs[randomIndex];

        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        AddToSpawnedObjects(spawnedObject);
    }

    void AddToSpawnedObjects(GameObject obj)
    {
        if (spawnedObjects == null)
        {
            spawnedObjects = new GameObject[1] { obj };
        }
        else
        {
            System.Array.Resize(ref spawnedObjects, spawnedObjects.Length + 1);
            spawnedObjects[spawnedObjects.Length - 1] = obj;
        }
    }

    public void TambahSkor()
    {
        skor += skorTambahan;
        if (skor < 0) // Pastikan skor tidak pernah kurang dari 0
        {
            skor = 0;
        }
        skorText.text = "Skor: " + skor;
    }

    public void KurangiSkor()
    {
        skor -= skorPenalti;
        if (skor < 0) // Pastikan skor tidak pernah kurang dari 0
        {
            skor = 0;
        }
        skorText.text = "Skor: " + skor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SampahTurun"))
        {
            KurangiSkor();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        panelGameOver.SetActive(true);
        SaveScore(); // Simpan skor ketika permainan berakhir
    }

    void HapusSampah()
    {
        if (spawnedObjects != null)
        {
            foreach (GameObject obj in spawnedObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", skor);
        PlayerPrefs.Save();
        Debug.Log("Skor disimpan: " + skor); // Debug log untuk verifikasi
    }
}
