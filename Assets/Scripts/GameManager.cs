using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Scripts.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("Referencies")]
    public Transform startPoint;
    private GameObject _currentPlayer;

     [Header("Animation")]
    public float duration = .5f;
    public float delay =.1f;
    public Ease ease = Ease.OutBack;

    private void Start() {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }

}
