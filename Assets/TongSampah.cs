using UnityEngine;

public enum JenisTongSampah
{
    Organik,
    Anorganik,
    B3
}

public class TongSampah : MonoBehaviour
{
    public JenisTongSampah jenisTong;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Organik") && jenisTong == JenisTongSampah.Organik)
        {
            BuangSampah(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Anorganik") && jenisTong == JenisTongSampah.Anorganik)
        {
            BuangSampah(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("B3") && jenisTong == JenisTongSampah.B3)
        {
            BuangSampah(collision.gameObject);
        }
    }

    private void BuangSampah(GameObject sampah)
    {
        
    }
}
