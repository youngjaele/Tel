using System.Collections.Generic;
using UnityEngine;

public class StatsHandler : MonoBehaviour
{
    [SerializeField] private StatsData baseStats;

    public StatsData CurrentStats { get; set; }
    public List<StatsData> statsModifiers = new List<StatsData>();

    private void Awake()
    {
        PlayerSO playerSO = null;
        if (baseStats.playerSO != null)
        {
            playerSO = Instantiate(baseStats.playerSO);
        }

        CurrentStats = new StatsData { playerSO = playerSO };

        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHp = baseStats.maxHp;
        CurrentStats.maxStamina = baseStats.maxStamina;
        CurrentStats.moveSpeed = baseStats.moveSpeed;
        CurrentStats.jumpForce = baseStats.jumpForce;
    }
}
