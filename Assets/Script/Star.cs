using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] private GameObject EmptyStar;
    [SerializeField] private GameObject StarIcon;
    private bool _isActive;

    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            EmptyStar.SetActive(!_isActive);
            StarIcon.SetActive(_isActive);
        }
    }
}
