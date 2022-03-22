﻿using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public Transform prefabParent { get; }

    private List<T> poolList;

    public Pool(T _prefab, int _count, Transform _prefabParent)
    {
        prefab = _prefab;
        prefabParent = _prefabParent;
        
        CreatePool(_count);
    }

    private void CreatePool(int _count)
    {
        poolList = new List<T>();

        for (int i = 0; i < _count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActive = false)
    {
        var currentObject = Object.Instantiate(prefab, prefabParent);
        currentObject.gameObject.SetActive(isActive);
        poolList.Add(currentObject);

        return currentObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var item in poolList)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);

                return true;
            }
        }

        element = null;

        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;

        return CreateObject(true);
    }
}
