using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { set; get; }
    public Transform Container { get; }
    public List<T> PrefabsPool { private set; get; }
    public Pool(T prefab, int count)
    {
        this.Prefab = prefab;
        this.Container = null;
        CreatePool(count);
    }
    public Pool(T prefab, int count, Transform container)
    {
        this.Prefab = prefab;
        this.Container = container;
        CreatePool(count);
    }
    private void CreatePool(int count)
    {
        this.PrefabsPool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            this.CreateObject(false,false);
        }
    }
    private T CreateObject(bool isExpandingPool, bool isActiveByDeafult = false)
    {
        if (isExpandingPool)
        {
            var createdObject = UnityEngine.Object.Instantiate(PrefabsPool[0], this.Container.transform.position, this.Container.transform.rotation);
            createdObject.transform.position = Container.position;
            createdObject.gameObject.SetActive(isActiveByDeafult);
            this.PrefabsPool.Add(createdObject);
            return createdObject;
        }
        else
        {
            var createdObject = UnityEngine.Object.Instantiate(this.Prefab, this.Container.transform.position, this.Container.transform.rotation);
            createdObject.gameObject.SetActive(isActiveByDeafult);
            this.PrefabsPool.Add(createdObject);
            return createdObject;
        }
    }
    public bool HasFreeElement(out T element)
    {
        foreach (var mono in PrefabsPool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                mono.transform.position = Container.position;
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
        {
            return element;
        }
        if (this.AutoExpand)
        {
            return this.CreateObject(true, true);
        }
        throw new Exception($"There is no element type of {typeof(T)}");
    }

}
