using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameObjecEventListener : MonoBehaviour
{

    [SerializeField] UnityEvent onStart;
    [SerializeField] UnityEvent onAwake;
    [SerializeField] UnityEvent onEnable;
    [SerializeField] UnityEvent onDisable;
    [SerializeField] UnityEvent onDestroy;

    private void Awake() => onAwake?.Invoke();

    private void OnEnable() => onEnable?.Invoke();
    private void OnDisable() => onDisable?.Invoke();
    private void Start() => onStart?.Invoke();
    private void OnDestroy() => onDestroy?.Invoke();

    // Start is called before the first frame update

}

