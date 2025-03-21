using UnityEngine;

public abstract class Inhabitant
{
    public int currHp;
    public int maxHp;
    public int ac;
    public string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(10, 20);
    }
}
