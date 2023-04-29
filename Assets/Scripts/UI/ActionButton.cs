using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text textView;

    public void Init(Action action, Sprite spriteAction, string textAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(action.Invoke);

        image.sprite = spriteAction;

        textView.text = textAction;
    }
}
