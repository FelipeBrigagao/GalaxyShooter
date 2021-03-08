using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public void DesactivateShields()
    {
        Destroy(this.gameObject);
    }
}
