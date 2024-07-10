using UnityEngine;

public class DragSampah : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    // Tambahkan variabel public untuk menyimpan referensi GP1Manager
    public GP1Manager GP1Manager;

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition - offset;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    void OnMouseUp()
    {
        isDragging = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("TongSampah"))
        {
            TongSampah tong = hit.collider.GetComponent<TongSampah>();
            if (tong != null && tong.jenisTong == GetJenisSampah())
            {
                GP1Manager.TambahSkor(10);
                Debug.Log("Benar! Skor +10");
            }
            else
            {
                GP1Manager.KurangiSkor(5);
                Debug.Log("Salah! Skor -5");
            }

            // Perbarui pemanggilan ke metode yang benar di GP1Manager
            GP1Manager.SampahTerdestroy();
            Destroy(gameObject);
        }
    }

    private JenisTongSampah GetJenisSampah()
    {
        if (gameObject.CompareTag("Organik"))
            return JenisTongSampah.Organik;
        else if (gameObject.CompareTag("Anorganik"))
            return JenisTongSampah.Anorganik;
        else if (gameObject.CompareTag("B3"))
            return JenisTongSampah.B3;

        return JenisTongSampah.Organik; // Default, bisa disesuaikan
    }
}
