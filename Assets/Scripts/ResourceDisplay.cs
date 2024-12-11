using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    // Reference to the Text component where the iron amount will be displayed
    public Text ironText;

    // Reference to the ResourceManager script
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text with the current numIron value
        ironText.text = ResourceManager.Instance.numIron.ToString();
        
    }
}