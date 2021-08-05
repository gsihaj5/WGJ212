using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int enemyKilled = 0;
    [SerializeField] private TMP_Text _enemyKilledText;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Enemy.EnemyKilled += ONEnemyKilled;
    }

    void ONEnemyKilled(object sender, EventArgs e)
    {
        enemyKilled++;
    }

    private void OnDestroy()
    {
        Enemy.EnemyKilled -= ONEnemyKilled;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyKilledText)
            _enemyKilledText.text = enemyKilled.ToString();
    }
}