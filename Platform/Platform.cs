using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int health;
    [SerializeField] private float speed;

    /// <summary>
    /// The game bricks that make up the platfrom in correct order
    /// </summary>
    public GameObject[,] bricks;
    public Seireilazed2DArray showable;
    [HideInInspector] public List<GameObject> normalPlatforms = new List<GameObject>();
    [HideInInspector] public List<GameObject> victoryPlatforms = new List<GameObject>();
    [HideInInspector] public Transform startingAnchor;
    [HideInInspector] public Transform endAnchor;

    [SerializeField] private GameEvent onVictoryDestroy;

    public void DisableVictoryPlatforms()
    {
        for (int i = 0; i < victoryPlatforms.Count; i++)
        {
            Destroy(victoryPlatforms[i].GetComponent<WinLevel>());
        }
    }

    public void DestroyNormalPlatforms()
    {
        for (int i = 0; i < normalPlatforms.Count; i++)
        {
            StartCoroutine(FloatCo(normalPlatforms[i]));
        }
    }

    public void TryDestroyVictoryPlatforms()
    {
        if (victoryPlatforms.Count == 0)
            return;

        if (victoryPlatforms[0].GetComponent<WinLevel>() != null)
            return;

        for (int i = 0; i < victoryPlatforms.Count; i++)
        {
            StartCoroutine(FloatCo(victoryPlatforms[i]));
        }

        onVictoryDestroy.Raise();
        Destroy(gameObject, 1f);
    }

    public void AddPlatformAsMoveTarget()
    {
        PlayerInput input = FindObjectOfType<PlayerInput>();
        input.SetTarget(transform.root);
    }

    IEnumerator FloatCo(GameObject obj)
    {
        if (obj == null)
            yield break;

        yield return new WaitForSeconds(UnityEngine.Random.Range(0f, 0.2f));

        Vector3 targetPosition = new Vector3(obj.transform.position.x, -100f, obj.transform.position.z);
        while (Vector3.Distance(obj.transform.position, targetPosition) > 0.1f)
        {
            targetPosition = new Vector3(obj.transform.position.x, -100f, obj.transform.position.z);
            obj.transform.position = Vector3.Lerp(obj.transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;
        }

        obj.transform.position = targetPosition;
        Destroy(obj);
    }
}

[Serializable]
public class Seireilazed2DArray
{

    public GameObject[] data;

    public Seireilazed2DArray(GameObject[,] data)
    {
        int size = data.GetLength(0) * data.GetLength(1);
        this.data = new GameObject[size];
        int index = 0;
        for (int i = 0; i < data.GetLength(0); ++i)
        {
            for (int j = 0; j < data.GetLength(1); ++j)
            {

                this.data[index] = data[i, j];
                ++index;
            }
        }
    }
}
