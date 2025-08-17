using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<Balls> allBalls = new List<Balls>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    public void RegisterBall(Balls ball)
    {
        if (!allBalls.contains(ball))
            allBalls.Add(ball);
    }

    public void UnregisterBall(Balls ball)
    {
        if (allBalls.Contains(ball))
            allBalls.Remove(ball);
    }

    public List<Balls> GetAllBalls()
    {
        return allBalls;
    }

}