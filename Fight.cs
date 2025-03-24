using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private Monster theMonster;
    public Fight(Monster m)
    {
        this.theMonster = m;
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }

    }
    

    public void startFight()
    {
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.
        bool isAlive = true;
        while (isAlive)
        {
            int toHit = Random.Range(0, 20);
            if (toHit >= this.defender.getAC())
            {
                int damage = Random.Range(0, 20);
                Debug.Log("Attacker deals " + damage + "damage");
                if (defender.currHp < 1)
                {
                    Debug.Log("Defender falls!");
                    isAlive = false;
                    break;
                }
            }
            else
            {
                Debug.Log("Defender misses");
                
            }
            Inhabitant temp = this.attacker;
            this.attacker = this.defender;
            this.defender = temp;

        }
    }
}
