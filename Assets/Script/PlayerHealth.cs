using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthFill;
    public RectTransform healthBar; // <-- Goyang HealthBar langsung

    // Shake setting
    public float shakeDuration = 0.15f;
    public float shakeAmount = 8f;
    bool isShaking = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();

        if (!isShaking)
            StartCoroutine(ShakeBar());
    }

    void UpdateHealthBar()
    {
        healthFill.fillAmount = (float)currentHealth / maxHealth;
    }

    System.Collections.IEnumerator ShakeBar()
    {
        isShaking = true;

        Vector3 originalPos = healthBar.anchoredPosition;
        float time = 0f;

        while (time < shakeDuration)
        {
            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);

            healthBar.anchoredPosition = originalPos + new Vector3(x, y, 0);

            time += Time.deltaTime;
            yield return null;
        }

        healthBar.anchoredPosition = originalPos;
        isShaking = false;
    }
}
