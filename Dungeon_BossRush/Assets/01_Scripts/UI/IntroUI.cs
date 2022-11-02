using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.Universal;

public class IntroUI : MonoBehaviour
{
    private TextMeshProUGUI title1 = null;
    private TextMeshProUGUI title2 = null;

    private GameObject startBtnObj = null;
    private GameObject quitBtnObj = null;

    private GameObject difficultyPanel = null;

    private Light2D pointLight;

    private List<GameObject> introGroup = new List<GameObject>();

    private void Awake()
    {
        title1 = transform.Find("Title1").gameObject.GetComponent<TextMeshProUGUI>();
        title2 = transform.Find("Title2").gameObject.GetComponent<TextMeshProUGUI>();

        startBtnObj = transform.Find("StartButton").gameObject;
        quitBtnObj = transform.Find("QuitButton").gameObject;
        difficultyPanel = transform.Find("DifficultyPanel").gameObject;

        pointLight = GameObject.Find("Point Light 2D").GetComponent<Light2D>();

        difficultyPanel.SetActive(false);

        introGroup.Add(title1.gameObject);
        introGroup.Add(title2.gameObject);
        introGroup.Add(startBtnObj);
        introGroup.Add(quitBtnObj);
    }

    private void Start()
    {
        StartUIMove();
    }

    public void StartUIMove()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(title1.transform.DOMoveX(525f, 1f))
           .Join(title2.transform.DOMoveX(600f, 1f));
        seq.Append(startBtnObj.transform.DOMoveX(1545f, 0.75f))
           .Insert(1.25f, quitBtnObj.transform.DOMoveX(1545f, 0.75f));

        DOTween.To(() => 0f, (x) => pointLight.intensity = x, 1f, 1.75f);
    }

    public void DifficultyPanelTween()
    {
        if(!difficultyPanel.activeSelf) {
            foreach(GameObject obj in introGroup)
                obj.SetActive(false);
            difficultyPanel.SetActive(true);
            difficultyPanel.transform.DOLocalMoveY(0, 0.75f);
        }
        else {
            difficultyPanel.transform.DOLocalMoveY(-1000, 0.75f).OnComplete(() => {
                foreach(GameObject obj in introGroup)
                    obj.SetActive(true);
            });
        }
    }
}
