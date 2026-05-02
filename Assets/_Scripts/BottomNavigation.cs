using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomNavigation : MonoBehaviour
{
    [SerializeField] private List<GameObject> GroupPanels;
    [SerializeField] private List<Button> GroupButtons;
    [SerializeField] private GameObject Indicator;
    public float animationOutBack = 0.3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the bottom navigation
        InitializeBottomNavigation();
    }

    private void InitializeBottomNavigation()
    {
        // Set up button listeners
        for (int i = 0; i < GroupButtons.Count; i++)
        {
            int index = i; // Capture the current index
            GroupButtons[i].onClick.AddListener(() => OnGroupButtonClicked(index));
        }

        // Show the first panel by default
        ShowPanel(2);
    }

    private void OnGroupButtonClicked(int index)
    {
        ShowPanel(index);
    }

    private void ShowPanel(int index)
    {
        // Hide all panels
        foreach (var panel in GroupPanels)
        {
            panel.SetActive(false);
        }

        // Show the selected panel
        if (index >= 0 && index < GroupPanels.Count)
        {
            GroupPanels[index].SetActive(true);
            // Move the indicator to the selected button

            AnimationButton(index);
        }
    }

    private void AnimationButton(int index)
    {
        Indicator.transform.DOLocalMove(
            new Vector3(GroupButtons[index].transform.localPosition.x, Indicator.transform.localPosition.y, 0),
            0.3f
            ).SetEase(Ease.InOutBack, animationOutBack);
    }
}
