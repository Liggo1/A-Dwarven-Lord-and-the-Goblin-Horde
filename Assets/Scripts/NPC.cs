using UnityEngine;

public class NPC : MonoBehaviour
{
    // Example variables common to all NPCs
    public string npcName;
    
    public virtual void Start(){
        Debug.Log($"NPC START");
    }

    // You can also have methods common to all NPCs, like:
    public virtual void Talk()
    {
        Debug.Log($"{npcName} says hello!");
    }

    // You can add more common behaviors here, like health management, movement, etc.
}