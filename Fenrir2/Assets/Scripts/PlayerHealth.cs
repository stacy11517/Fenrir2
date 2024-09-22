using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;    // 玩家最大生命值
    public int currentHealth;      // 玩家當前生命值

    void Start()
    {
        // 初始化玩家生命值
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        // 恢復生命值，但不超過最大生命值
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player healed! Current health: " + currentHealth);
    }
}
