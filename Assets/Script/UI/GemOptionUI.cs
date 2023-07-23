using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemOptionUI : MonoBehaviour
{
    public void ActiveVow()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf); 
    }
}
