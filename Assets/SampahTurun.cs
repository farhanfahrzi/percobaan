using UnityEngine;

public class SampahTurun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TongSampah"))
        {
            GP2Manager manager = FindObjectOfType<GP2Manager>();
            manager.TambahSkor();
            Destroy(gameObject);
        }
        else if (other.CompareTag("BatasBawah"))
        {
            GP2Manager manager = FindObjectOfType<GP2Manager>();
            manager.KurangiSkor();
            Destroy(gameObject);
        }
    }
}