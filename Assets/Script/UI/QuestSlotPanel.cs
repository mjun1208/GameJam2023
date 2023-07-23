using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestSlotPanel : MonoBehaviour
{
    [Serializable]
    public struct QuestIcon
    {
        public QuestType type;
        public Sprite sprite;
    }

    [SerializeField] private Image baseImage;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Button button;

    [SerializeField] private QuestIcon[] icons;

    [SerializeField] private Color originalColor;
    [SerializeField] private Color purchasedColor;

    private Quest curQuest;
    private bool purchased;

    private void Start()
    {
        button.onClick.AddListener(TryPurchase);
    }

    public void SetQuest(Quest quest)
    {
        purchased = false;
        SetState(purchased);

        icon.sprite = FindIcon(quest.QuestType);
        text.text = quest.QuestDesc;
        countText.text = quest.NeedGold.ToString();

        curQuest = quest;
    }

    public void SetState(bool purchased)
    {
        baseImage.color = purchased? purchasedColor:originalColor;
    }

    public void TryPurchase()
    {
        if (IngameManager.UserDataManager.Gold >= curQuest.NeedGold)
        { 
            IngameManager.UserDataManager.Gold -= curQuest.NeedGold;
            IngameManager.UserDataManager.Purchase(curQuest);
            purchased = true;
            SetState(purchased);
        }
    }

    private Sprite FindIcon(QuestType quest)
    {
        return icons.First(x => x.type == quest).sprite;
    }
}
