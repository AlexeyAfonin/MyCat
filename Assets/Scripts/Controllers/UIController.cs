using MyCat.Configs;
using MyCat.Controllers;
using MyCat.Core.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonobehSingleton<UIController>
{
    [Header("UI Elements")]
    [SerializeField] private LayoutGroup actionPanel;

    [Header("Refs")]
    [SerializeField] private ActionButton actionButtonPrefab;

    private CatActionsConfig _catActionsConfig;

    protected override void Awake()
    {
        base.Awake();

        if (CatActionsController.HasReference)
        {
            _catActionsConfig = CatActionsController.Instance.Config;
        }
    }

    private void Start()
    {
        if (_catActionsConfig is not null)
        {
            foreach (var action in _catActionsConfig.Actions)
            {
                var actionButton = Instantiate(actionButtonPrefab, actionPanel.transform);
                actionButton.Init(() => Debug.Log($"Action: {action.Name}"), null, action.Name);
                actionButton.name = $"{actionButton.name}_{action.Name}";
            }
        }
    }
}
