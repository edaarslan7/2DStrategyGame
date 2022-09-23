using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Fields
    [SerializeField] private float objectCount;
    [SerializeField] private SpawnableObject sampleObject;
    private List<SpawnableObject> objects;
    private GameplayData data;
    #endregion

    #region Core
    public void Initialize(GameplayData data)
    {
        this.data = data;
        objects = new List<SpawnableObject>();
        for (int i = 0; i < objectCount; i++)
        {
            CreateObj();
        }
    }
    public void StartGame()
    {

    }
    public void GameOver()
    {

    }
    #endregion

    #region Executes
    public SpawnableObject GetItem()
    {
        SpawnableObject result = objects.FirstOrDefault(i => i.IsInUse == false);
        if (result == null)
        {
            result = CreateObj();
        }
        return result;
    }

    private SpawnableObject CreateObj()
    {
        SpawnableObject newObj = Instantiate(sampleObject, transform);
        newObj.Initialize(data);
        objects.Add(newObj);
        return newObj;
    }
    #endregion
}
