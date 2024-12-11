using UnityEngine;

public class Drunky : NPC
{
    // Drunky-specific behavior or properties
    public float drunkennessLevel;

    // Override the Start method to move Drunky when it spawns
    public override void Start()
    {
        // Call the baseclass NPC Start() method if needed
        //base.Start();

        // Move Drunky to a specific position as soon as he spawns
        transform.position = new Vector3(51, 90);
        Talk();

        
    }

    // Override the Talk method for Drunky
    public override void Talk()
    {
        Debug.Log($"{npcName} says: 'Wha... where am I?'");
    }

    // Drunky-specific method
    public void Drink()
    {
        drunkennessLevel += 10;
        Debug.Log($"{npcName} is getting more drunk! Drunkenness level: {drunkennessLevel}");
    }
}