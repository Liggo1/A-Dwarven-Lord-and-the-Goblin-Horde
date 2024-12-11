using UnityEngine;
using System.Collections.Generic;

public class PopManager : MonoBehaviour
{
    [SerializeField] private GameObject drunkyPrefab; // Reference to the Drunky prefab
    [SerializeField] private List<NPC> pop = new List<NPC>(); // List to store all NPCs (derived from NPC base class)

    void Start()
    {
        // Instantiate the Drunky prefab and add it to the pop list
        GameObject drunkyObject = Instantiate(drunkyPrefab, Vector3.zero, Quaternion.identity);
        
        // Get the NPC component (assuming Drunky is a subclass of NPC)
        NPC newDrunky = drunkyObject.GetComponent<NPC>();

        // Add the Drunky to the list
        if (newDrunky != null)
        {
            pop.Add(newDrunky);
            //Debug.Log($"Added Drunky. Population size is now: {pop.Count}");
        }
        else
        {
            Debug.LogError("Drunky does not have the NPC component!");
        }
    }

    void Update()
    {
        // You can manage NPCs, update behaviors, etc. here
    }
}