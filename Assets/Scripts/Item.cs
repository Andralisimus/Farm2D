

public class Item
{
    public static int TYPEPFOOD = 1;

    public string name;
    public string imgUrl;
    public int type;
    public int count;
    public int price;
    public int lvlWhenUnlock;
    public float timeToGrow;

    public Item(string name, string imgUrl, int count, int type, int price, int lvlWhenUnlock, float timeToGrow)
    {
        this.name = name;
        this.imgUrl = imgUrl;
        this.count = count;
        this.type = type;
        this.price = price;
        this.lvlWhenUnlock = lvlWhenUnlock;
        this.timeToGrow = timeToGrow;
    }
}
