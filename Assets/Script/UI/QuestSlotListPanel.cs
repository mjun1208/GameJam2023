using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestSlotListPanel : MonoBehaviour
{
    [SerializeField] private QuestSlotPanel prefab;

    private List<QuestSlotPanel> pool = new List<QuestSlotPanel>();

    void Start()
    {
        gameObject.gameObject.SetActive(false);
        prefab.gameObject.SetActive(false);

        var quests = IngameManager.QuestManager.Stage_1_QuestList;
        foreach (var quest in quests)
        {
            Rent().SetQuest(quest);
        }
    }

    void Update()
    {
        
    }

    private QuestSlotPanel Rent()
    {
        QuestSlotPanel obj = null;

        if (pool.Any(x => x.gameObject.activeInHierarchy))
            obj = pool.First(x => x.gameObject.activeInHierarchy);
        else
        {
            obj = Instantiate(prefab.gameObject, prefab.transform.parent).GetComponent<QuestSlotPanel>();
            pool.Add(obj);
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    private void Return(QuestSlotPanel panel)
    {
        panel.gameObject.SetActive(false);
    }

    public void ActiveAutomacally()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
