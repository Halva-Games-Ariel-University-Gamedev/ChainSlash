using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
        GameManager.Instance?.UpdateHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        GameManager.Instance?.UpdateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // keep your bodyCollider logic / debug here if you want
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
