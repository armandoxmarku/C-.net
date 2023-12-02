
Attack sulmi1 = new Attack("sulmi1",30);
Attack sulmi2 = new Attack("sulmi2",50);
Attack sulmi3 = new Attack("sulmi3",10);
Attack sulmi4 = new Attack("sulmi4",20);


System.Console.WriteLine(sulmi2.DamageAmount);

Enemy kundershtari2 = new Enemy("armiku2");
Enemy kundershtari1 = new Enemy("kundershtari1");
kundershtari1.attackList.Add(sulmi1);
kundershtari1.attackList.Add(sulmi2);
kundershtari1.attackList.Add(sulmi3);
kundershtari1.attackList.Add(sulmi4);
kundershtari1.RandomAttackKundershtar(kundershtari2);
kundershtari1.RandomAttackKundershtar(kundershtari2);




public class Attack
{
    public string name;
    public int DamageAmount;


    public Attack(string name ,int DamageAmount){
       this.name = name;
       this.DamageAmount = DamageAmount;
    }

}

public class Enemy{

    public string name;
    public int health;
    public List<Attack> attackList;
    
    public Enemy(string name){
        this.name = name;
        this.health = 100;
        this.attackList = new List<Attack> ();
    }
    public void randomattack(){
   
        
        Random rnd = new Random();
        int pozicioniRandom = rnd.Next(attackList.Count);
        Attack sulmRandom = attackList[pozicioniRandom];
    }
    public void RandomAttackKundershtar(Enemy armiku){
        Random rnd = new Random();
        int pozicioniRandom = rnd.Next(attackList.Count);
        Attack sulmRandom = attackList[pozicioniRandom];
        armiku.health -= sulmRandom.DamageAmount;
        System.Console.WriteLine($" Sulmoj armikun {armiku.name} me sulmin {sulmRandom.name} me demtim {sulmRandom.DamageAmount} dhe armikut i ngelet {armiku.health} jete");
    }
}