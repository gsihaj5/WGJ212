using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public static event EventHandler OnGearCollected;
    private float _health = 10f;

    [SerializeField] private TMP_Text healthText;

    private void Update()
    {
        if (_health <= 0)
        {
            SceneManager.LoadScene("DeadScreen");
        }

        healthText.text = _health.ToString("n2");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            Destroy(other.gameObject);
            OnGearCollected?.Invoke(this, EventArgs.Empty);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            _health -= EnemyDamageManager.Damage;
            Destroy(other.gameObject);
        }
    }
}