using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    


    public Item(string name, string description)
    {
        itemName = name;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            SoulCollect.scoreCount += 100;

            



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
