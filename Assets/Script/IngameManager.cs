using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public static IngameManager Instance { get; set; }
    public static UserDataManager UserDataManager { get; private set; }
    public static AnimalManager AnimalManager { get; private set; }
    public static CraftingPopup CraftingPopup { get; private set; }
    public static UITopMenu UITopMenu { get; private set; }
    
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
        
        GameDataManager.Load();

        UserDataManager = new UserDataManager();

        AnimalManager = GameObject.Find("AnimalManager").GetComponent<AnimalManager>();
        UITopMenu = GameObject.Find("UITopMenu").GetComponent<UITopMenu>();
        CraftingPopup = GameObject.Find("CraftingPopup").GetComponent<CraftingPopup>();
        CraftingPopup.Disable();
    }
}
