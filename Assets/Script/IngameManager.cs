using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public static IngameManager Instance { get; set; }
    public static AnimalManager AnimalManager { get; private set; }
    
    void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        AnimalManager = GameObject.Find("AnimalManager").GetComponent<AnimalManager>();
    }
}
