using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}

[Serializable]
public class StatsData
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHp;
    [Range(1, 100)] public int maxStamina;
    [Range(1.0f, 20.0f)] public float moveSpeed;
    public float maxMoveSpeed = 20.0f;

    [Range(1.0f, 20.0f)] public float jumpForce;

    public PlayerSO playerSO;
}
