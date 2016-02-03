using UnityEngine;

public class PlayerNodeState : MonoBehaviour
{
    public int x, y;
    const int mapSize = 5;

    //public FlyingNodeState flyNode;

    public SleepBossState sleepBoss;
    public bool inSleepBossLevel;    

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
   

    public int getMapSize()
    {
        return mapSize;
    }

}
