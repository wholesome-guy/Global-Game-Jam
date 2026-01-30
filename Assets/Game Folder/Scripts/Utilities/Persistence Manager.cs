using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
