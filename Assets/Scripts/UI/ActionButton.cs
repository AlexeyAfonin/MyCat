using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text textView;

    public bool Interactable
    {
        get => button.interactable;
        set => button.interactable = value;
    }

    public void Init(Action action, Sprite spriteAction, string textAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(action.Invoke);

        icon.gameObject.SetActive(spriteAction is not null);
        textView.gameObject.SetActive(spriteAction is null);

        icon.sprite = spriteAction;
        textView.text = textAction;
    }
}
