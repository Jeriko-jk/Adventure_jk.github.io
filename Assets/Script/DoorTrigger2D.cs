using UnityEngine;
using System.Collections;

public class DoorTrigger2D : MonoBehaviour
{
    [Header("Interior Setup")]
    public GameObject houseInterior;      // Interior rumah
    public Transform interiorSpawn;       // Posisi Player di dalam rumah

    [Header("Camera Setup")]
    public Camera mainCamera;             // Kamera luar rumah
    public Camera interiorCamera;         // Kamera interior

    [Header("Debug")]
    public bool debugMode = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (debugMode) Debug.Log("Player detected, entering house");

            // Mulai Coroutine untuk pindah ke interior
            StartCoroutine(EnterHouse(other.gameObject));
        }
    }

    IEnumerator EnterHouse(GameObject player)
    {
        // 1. Aktifkan interior
        if (houseInterior != null)
        {
            houseInterior.SetActive(true);
            if (debugMode) Debug.Log("House interior activated");
        }
        else
        {
            Debug.LogWarning("houseInterior belum diassign!");
        }

        // Tunggu satu frame supaya semua object interior aktif
        yield return null;

        // 2. Pindahkan player ke interior
        if (interiorSpawn != null)
        {
            player.transform.position = interiorSpawn.position;
            if (debugMode) Debug.Log("Player moved to interior: " + interiorSpawn.position);
        }
        else
        {
            Debug.LogWarning("interiorSpawn belum diassign!");
        }

        // 3. Set kamera interior ke posisi tengah houseInterior
        if (interiorCamera != null && houseInterior != null)
        {
            Renderer[] renderers = houseInterior.GetComponentsInChildren<Renderer>();
            if (renderers.Length > 0)
            {
                // Hitung bounds dari seluruh interior
                Bounds bounds = renderers[0].bounds;
                for (int i = 1; i < renderers.Length; i++)
                    bounds.Encapsulate(renderers[i].bounds);

                // Posisikan kamera di tengah interior, Z tetap
                Vector3 camPos = bounds.center;
                camPos.z = interiorCamera.transform.position.z;
                interiorCamera.transform.position = camPos;

                if (debugMode) Debug.Log("Interior camera positioned at center of houseInterior: " + camPos);
            }
        }

        // 4. Ganti kamera
        if (interiorCamera != null && mainCamera != null)
        {
            interiorCamera.enabled = true;
            mainCamera.enabled = false;
            if (debugMode) Debug.Log("Camera switched to interiorCamera");
        }
        else
        {
            Debug.LogWarning("Cameras belum diassign!");
        }
    }
}
