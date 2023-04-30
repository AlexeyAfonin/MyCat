using MyCat.Configs;
using MyCat.Controllers;
using MyCat.Core.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonobehSingleton<UIController>
{
    [Header("UI Elements")]
    [SerializeField] private LayoutGroup actionPanel;
    [SerializeField] private TMP_Text moodTextView;
    [SerializeField] private TMP_Text descriptionTextView;

    [Header("Refs")]
    [SerializeField] private ActionButton actionButtonPrefab;

    private CatActionsConfig _catActionsConfig;
    private CatController _cat;
    private List<ActionButton> _actionButtons = new();

    protected override void Awake()
    {
        base.Awake();

        if (CatActionsController.HasReference)
        {
            _catActionsConfig = CatActionsController.Instance.Config;
        }

        if (CatController.HasReference)
        {
            _cat = CatController.Instance;
        }
    }

    private void Start()
    {
        if (_catActionsConfig is not null)
        {
            _actionButtons.Clear();
            foreach (var action in _catActionsConfig.Actions)
            {
                var actionButton = Instantiate(actionButtonPrefab, actionPanel.transform);
                actionButton.Init(() => _cat.SetReaction(action), action.Icon, action.Name);
                actionButton.name = $"{actionButton.name}_{action.Name}";
                _actionButtons.Add(actionButton);
            }
        }
    }

    public void UpdateInfoPanel(string catMood, string description)
    {
        if (!string.IsNullOrEmpty(catMood))
        {
            moodTextView.text = catMood;
        }

        if (!string.IsNullOrEmpty(description))
        {
            descriptionTextView.text = description;
        }
    }

    public void LockUI(bool isLock)
    {
        _actionButtons.ForEach(b => b.Interactable = !isLock);
    }
}
