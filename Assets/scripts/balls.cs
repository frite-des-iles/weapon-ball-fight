using UnityEngine;
using TMPro;

public class Balls : MonoBehaviour
{
    [Header("Mouvement")]
    public float speed = 3f;

    [Header("Santé")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    [SerializeField] private TextMeshPro healthTextPrefab;
    private TextMeshPro healthTextInstance;

    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        rb.linearVelocity = direction * speed;
        if (healthTextPrefab != null)
        {
            healthTextInstance = Instantiate(healthTextPrefab, transform.position, Quaternion.identity, transform);

            healthTextInstance.alignment = TextAlignmentOptions.Center;
            healthTextInstance.text = currentHealth.ToString();

            healthTextInstance.rectTransform.local Position = Vector3.zero;
        }
        GameManager.Instance.RegisterBall(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = rb.linearVelocity;
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
        if (healthTextInstance != null)
        {
            healthTextInstance.transform.localPosition = Vector3.zero;
        }
    }

    //on collision is called once per hit
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 direction = Vector2.Reflect(lastVelocity.normalized, normal);
        if (Vector2.Dot(direction, lastVelocity.normalized) < -0.99f)
        {
            direction += normal * 0.01f;
        }
        rb.linearVelocity = direction.normalized * speed;


    }

}

