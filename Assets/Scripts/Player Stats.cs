using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int Lives;
    
    public int startMoney = 400;
    public int startLives = 20;

    public static int Rounds;

    void Start()
    {
        money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
}
