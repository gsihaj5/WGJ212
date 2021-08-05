using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadScreenManager : MonoBehaviour
{
    private GameObject _scoreManager;
    [SerializeField] private TMP_Text _endGameScoreText;
    private int _enemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = GameObject.Find("ScoreManager");
        _enemyKilled = _scoreManager.GetComponent<ScoreManager>().enemyKilled;
    }

    // Update is called once per frame
    void Update()
    {
        _endGameScoreText.text = _enemyKilled.ToString();
    }
}