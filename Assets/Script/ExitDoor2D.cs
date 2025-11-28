using UnityEngine;

public class ExitDoor2D : MonoBehaviour
{
    [Header("Interior Setup")]
    public GameObject houseInterior;      // Interior rumah
    public Transform exitSpawn;           // Posisi Player di luar rumah

    [Header("Camera Setup")]
    public Camera mainCamera;             // Kamera luar rumah
    public Camera interiorCamera;         // Kamera interior

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ExitDoor OnTriggerEnter2D called with: " + other.name);

        if(other.CompareTag("Player"))
        {
            Debug.Log("Player detected at exit!");

            // Sembunyikan interior
            if(houseInterior != null)
            {
                houseInterior.SetActive(false);
                Debug.Log("House interior deactivated");
            }

            // Pindahkan Player ke luar rumah
            if(exitSpawn != null)
            {
                other.transform.position = exitSpawn.position;
                Debug.Log("Player moved outside: " + exitSpawn.position);
            }
            else
            {
                Debug.LogWarning("exitSpawn belum diassign!");
            }

            // Ganti kamera
            if(interiorCamera != null && mainCamera != null)
            {
                interiorCamera.enabled = false;
                mainCamera.enabled = true;
                Debug.Log("Camera switched back to mainCamera");
            }
            else
            {
                Debug.LogWarning("Cameras belum diassign!");
            }
        }
    }
}
