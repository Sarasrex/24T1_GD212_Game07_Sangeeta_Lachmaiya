using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoveText : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        Destroy(gameObject);
    }
}