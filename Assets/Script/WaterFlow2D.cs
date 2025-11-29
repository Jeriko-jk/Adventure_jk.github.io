using UnityEngine;

public class WaterFlow2D : MonoBehaviour
{
    public float speedX = 0.3f; // kecepatan horizontal
    public float speedY = 0.0f; // kecepatan vertikal (opsional)

    private SpriteRenderer sr;
    private Material mat;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Buat material instance sendiri agar tidak merubah material lain
        mat = new Material(sr.material);
        sr.material = mat;
    }

    void Update()
    {
        // Hitung offset
        float offsetX = Time.time * speedX;
        float offsetY = Time.time * speedY;

        // Apply offset ke material
        mat.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
