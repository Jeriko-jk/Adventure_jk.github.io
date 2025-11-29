using UnityEngine;
using System.Collections;

public class GroundTransition : MonoBehaviour
{
    [Header("Teleport Setup")]
    public Transform spawnTarget;       // Posisi Player teleport
    public Transform cameraTarget;      // Posisi kamera setelah teleport

    [Header("Transition Settings")]
    public float moveDuration = 1f;     // Durasi perpindahan
    public bool smoothCamera = true;    // Kamera ikut lerp
    public bool debugMode = true;

    private bool isTransitioning = false;
    private GameObject playerNear = null;  // Player sedang di dekat area teleport

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika Player masuk trigger, simpan referensi
        if (other.CompareTag("Player"))
        {
            playerNear = other.gameObject;
            if (debugMode)
                Debug.Log("Player ready to teleport. Press Enter!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player keluar trigger
        if (other.CompareTag("Player"))
        {
            playerNear = null;
            if (debugMode)
                Debug.Log("Player left teleport area");
        }
    }

    private void Update()
    {
        // Jika Player di trigger dan tekan Enter
        if (playerNear != null && Input.GetKeyDown(KeyCode.Return) && !isTransitioning)
        {
            if (spawnTarget == null || cameraTarget == null)
            {
                Debug.LogWarning("SpawnTarget atau CameraTarget belum diassign!");
                return;
            }

            StartCoroutine(TeleportPlayer(playerNear));
        }
    }

    private IEnumerator TeleportPlayer(GameObject player)
    {
        isTransitioning = true;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;

        Vector3 startPosPlayer = player.transform.position;
        Vector3 endPosPlayer = spawnTarget.position;

        Camera mainCamera = Camera.main;
        Vector3 startPosCam = mainCamera.transform.position;
        Vector3 endPosCam = new Vector3(cameraTarget.position.x, cameraTarget.position.y, startPosCam.z);

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;

            player.transform.position = Vector3.Lerp(startPosPlayer, endPosPlayer, t);

            if (smoothCamera)
                mainCamera.transform.position = Vector3.Lerp(startPosCam, endPosCam, t);

            yield return null;
        }

        player.transform.position = endPosPlayer;
        mainCamera.transform.position = smoothCamera ? endPosCam : endPosCam;

        if (debugMode)
            Debug.Log("Player teleported to " + endPosPlayer + " | Camera to " + endPosCam);

        isTransitioning = false;
    }
}
