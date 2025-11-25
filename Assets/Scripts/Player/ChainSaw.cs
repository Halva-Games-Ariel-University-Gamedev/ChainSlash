using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public int damage = 1;
    public float knockback = 3f;

    bool isActive = false;
    Collider2D hitbox;

    void Awake()
    {
        hitbox = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Left mouse button controls the chainsaw
        isActive = Input.GetMouseButton(0);
        hitbox.enabled = isActive;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) return;
        if (!other.CompareTag("Enemy")) return;

        EnemyHealth eh = other.GetComponent<EnemyHealth>();
        if (eh != null)
        {
            eh.TakeDamage(damage);

            // simple knockback if has rigidbody
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 dir = (other.transform.position - transform.position).normalized;
                rb.AddForce(dir * knockback, ForceMode2D.Impulse);
            }
        }
    }
}
