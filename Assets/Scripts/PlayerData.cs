
[System.Serializable]
public class PlayerData
{
    public int money;
    public int lvl;
    public float lvlProgress;

    public PlayerData(int money, int lvl, float lvlProgress)
    {
        this.money = money;
        this.lvl = lvl;
        this.lvlProgress = lvlProgress;
    }
}
