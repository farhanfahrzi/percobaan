using UnityEngine;
using DG.Tweening;

public class NdutNdut : MonoBehaviour
{
    public float rotationAmount = 90f;
    public float duration = 1f;

    void Start()
    {
        // Panggil fungsi untuk memulai rotasi
        RotateLeftAndRight();
    }

    void RotateLeftAndRight()
    {
        // Buat dua tween untuk rotasi kiri dan kanan
        Tweener rotateLeft = transform.DORotate(new Vector3(0, 0, rotationAmount), duration)
            .SetEase(Ease.Linear);

        Tweener rotateRight = transform.DORotate(new Vector3(0, 0, -rotationAmount), duration)
            .SetEase(Ease.Linear)
            .OnComplete(() => RotateLeftAndRight()); // Panggil kembali fungsi ini setelah rotasi selesai

        // Gabungkan tween kiri dan tween kanan dengan efek yoyo
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rotateLeft);
        sequence.Append(rotateRight);
    }
}
