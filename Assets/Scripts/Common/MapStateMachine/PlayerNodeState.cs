using UnityEngine;

public class PlayerNodeState : MonoBehaviour
{
    private int x, y;
    const int mapSize = 5;

    //public FlyingNodeState flyNode;

    public SleepBossState sleepBoss;
    public bool inSleepBossLevel;

    void Start()
    {
        x = 2;
        y = 2;
    }

    public void MoveLeft()
    {
        if (x > 0)
            x--;
    }

    public void MoveRight()
    {
        if (x < mapSize)
            x++;
    }

    public void MoveUp()
    {
        if (y > 0)
            y--;
    }

    public void MoveDown()
    {
        if (y < mapSize)
            y++;
    }

    public bool isAtSleepBoss()
    {
        if (x == 2 && y == 0)
        {
            inSleepBossLevel = true;
            return true;
        }

        return false;
    }

    public int X()
    {
        return x;
    }

    public int Y()
    {
        return y;
    }

    public int getMapSize()
    {
        return mapSize;
    }

}
