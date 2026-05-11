using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomNavigation : MonoBehaviour
{
    [SerializeField] private List<GameObject> GroupPanels;
    [SerializeField] private List<Button> GroupButtons;
    [SerializeField] private GameObject Indicator;
    public float animationOutBack = 0.3f;

    // Cached references for button icons and texts
    private List<Transform> _buttonIcons = new List<Transform>();
    private List<Vector3> _originalIconScales = new List<Vector3>();
    private List<TextMeshProUGUI> _buttonTextsTMPro = new List<TextMeshProUGUI>();
    private List<Text> _buttonTextsUI = new List<Text>();
    private Vector3 _defaultTextPosition = new Vector3(0, -120f, 0); // Initial text position as per user
    private Vector3 _selectedTextPosition = new Vector3(0, -20f, 0); // Target position when selected
    private float _nonSelectedTextScale = 0.8f;
    private float _selectedTextScale = 1.2f;

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

        // Cache icon and text references for each button
        for (int i = 0; i < GroupButtons.Count; i++)
        {
            Button btn = GroupButtons[i];
            
            // Cache icon (first Image component in children)
            Image iconImage = btn.GetComponentInChildren<Image>();
            if (iconImage != null)
            {
                Transform iconTrans = iconImage.transform;
                _buttonIcons.Add(iconTrans);
                _originalIconScales.Add(iconTrans.localScale);
            }
            else
            {
                _buttonIcons.Add(null);
                _originalIconScales.Add(Vector3.one);
            }

            // Cache text components (TextMeshProUGUI or Text)
            TextMeshProUGUI tmpText = btn.GetComponentInChildren<TextMeshProUGUI>();
            Text uiText = btn.GetComponentInChildren<Text>();

            // Cache TMP text
            if (tmpText != null)
            {
                _buttonTextsTMPro.Add(tmpText);
                _buttonTextsUI.Add(null);
                // Set initial non-selected state
                tmpText.rectTransform.localPosition = _defaultTextPosition;
                tmpText.rectTransform.localScale = Vector3.one * _nonSelectedTextScale;
                Color tmpColor = tmpText.color;
                tmpColor.a = 0f;
                tmpText.color = tmpColor;
            }
            else if (uiText != null)
            {
                _buttonTextsTMPro.Add(null);
                _buttonTextsUI.Add(uiText);
                // Set initial non-selected state
                uiText.rectTransform.localPosition = _defaultTextPosition;
                uiText.rectTransform.localScale = Vector3.one * _nonSelectedTextScale;
                Color uiColor = uiText.color;
                uiColor.a = 0f;
                uiText.color = uiColor;
            }
            else
            {
                _buttonTextsTMPro.Add(null);
                _buttonTextsUI.Add(null);
            }
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
        // Move indicator
        Indicator.transform.DOLocalMove(
            new Vector3(GroupButtons[index].transform.localPosition.x, Indicator.transform.localPosition.y, 0),
            0.3f
        ).SetEase(Ease.InOutBack, animationOutBack);

        // Reset all non-selected buttons to original state
        for (int i = 0; i < GroupButtons.Count; i++)
        {
            if (i == index) continue;

            // Reset icon scale to default (1,1,1)
            if (_buttonIcons[i] != null)
            {
                _buttonIcons[i].DOKill();
                _buttonIcons[i].DOScale(Vector3.one, 0.2f).SetEase(Ease.OutQuad);
            }

            // Reset text: move down to default position (0, -120, 0), scale down, fade out
            TextMeshProUGUI tmp = _buttonTextsTMPro[i];
            Text uiText = _buttonTextsUI[i];
            if (tmp != null)
            {
                tmp.rectTransform.DOKill();
                // Move to initial position (0, -120, 0)
                tmp.rectTransform.DOLocalMove(_defaultTextPosition, 0.2f).SetEase(Ease.OutQuad);
                // Scale down
                tmp.rectTransform.DOScale(_nonSelectedTextScale, 0.2f).SetEase(Ease.OutQuad);
                // Fade out
                tmp.DOFade(0f, 0.2f).SetEase(Ease.OutQuad);
            }
            else if (uiText != null)
            {
                uiText.rectTransform.DOKill();
                uiText.rectTransform.DOLocalMove(_defaultTextPosition, 0.2f).SetEase(Ease.OutQuad);
                uiText.rectTransform.DOScale(_nonSelectedTextScale, 0.2f).SetEase(Ease.OutQuad);
                // Fade out using color alpha
                uiText.DOColor(new Color(uiText.color.r, uiText.color.g, uiText.color.b, 0f), 0.2f).SetEase(Ease.OutQuad);
            }
        }

        // Animate selected button's icon (scale up)
        if (_buttonIcons[index] != null)
        {
            _buttonIcons[index].DOKill();
            _buttonIcons[index].DOScale(new Vector3(1.5f, 1.5f, 1f), 0.3f).SetEase(Ease.OutBack);
        }

        // Animate selected button's text: move up, scale up, fade in
        TextMeshProUGUI selectedTmp = _buttonTextsTMPro[index];
        Text selectedUiText = _buttonTextsUI[index];
        if (selectedTmp != null)
        {
            selectedTmp.rectTransform.DOKill();
            // Move up to selected position (0, 0, 0)
            selectedTmp.rectTransform.DOLocalMove(_selectedTextPosition, 0.3f).SetEase(Ease.OutBack);
            // Scale up
            selectedTmp.rectTransform.DOScale(_selectedTextScale, 0.3f).SetEase(Ease.OutBack);
            // Fade in
            selectedTmp.DOFade(1f, 0.3f).SetEase(Ease.OutBack);
        }
        else if (selectedUiText != null)
        {
            selectedUiText.rectTransform.DOKill();
            selectedUiText.rectTransform.DOLocalMove(_selectedTextPosition, 0.3f).SetEase(Ease.OutBack);
            selectedUiText.rectTransform.DOScale(_selectedTextScale, 0.3f).SetEase(Ease.OutBack);
            // Fade in using color alpha
            selectedUiText.DOColor(new Color(selectedUiText.color.r, selectedUiText.color.g, selectedUiText.color.b, 1f), 0.3f).SetEase(Ease.OutBack);
        }
    }
}
