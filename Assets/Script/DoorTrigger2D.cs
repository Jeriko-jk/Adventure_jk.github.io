using UnityEngine;

public class DoorTrigger2D : MonoBehaviour
{
    [Header("Interior Setup")]
    public GameObject houseInterior;      // Interior rumah
    public Transform interiorSpawn;       // Posisi Player di dalam rumah

    [Header("Camera Setup")]
    public Camera mainCamera;             // Kamera luar rumah
    public Camera interiorCamera;         // Kamera interior

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with: " + other.name);

        if(other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");

            // Aktifkan interior
            if(houseInterior != null)
            {
                houseInterior.SetActive(true);
                Debug.Log("House interior activated");
            }
            else
            {
                Debug.LogWarning("houseInterior belum diassign!");
            }

            // Pindahkan Player ke interior
            if(interiorSpawn != null)
            {
                other.transform.position = interiorSpawn.position;
                Debug.Log("Player moved to interior: " + interiorSpawn.position);
            }
            else
            {
                Debug.LogWarning("interiorSpawn belum diassign!");
            }

            // Ganti kamera
            if(interiorCamera != null && mainCamera != null)
            {
                interiorCamera.enabled = true;
                mainCamera.enabled = false;
                Debug.Log("Camera switched to interiorCamera");
            }
            else
            {
                Debug.LogWarning("Cameras belum diassign!");
            }
        }
    }
}
