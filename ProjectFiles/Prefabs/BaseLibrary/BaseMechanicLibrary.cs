using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystems
{
    public class Pooler<T> where T:MonoBehaviour
    {
        private List<T> _poolElements = new List<T>();
        private bool _isAutoExpand;
        private Transform _prefabContainer;
        private T _prefab;
        public Pooler(T prefab,int poolCount,bool isAutoExpand,Transform poolContainer)
        {
            _prefab = prefab;
            _isAutoExpand = isAutoExpand;
            _prefabContainer = poolContainer;
            for (int i = 0; i < poolCount; i++)
            {
                CreateObject(false);
            }
        }
        private bool TryGetFreeElement(out T element)
        {
            foreach (var poolElement in _poolElements)
            {
                if (!poolElement.gameObject.activeInHierarchy) { element = poolElement;return true; }
            }
            element = null;
            return false;
        }
        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = PoolCreator<T>.InstancePoolObject(_prefab,_prefabContainer);
            _poolElements.Add(createdObject);
            createdObject.gameObject.SetActive(isActiveByDefault);
            return createdObject;
        }
        public T GetFreeElement()
        {
            if (TryGetFreeElement(out var element)) { element.gameObject.SetActive(true); return  element; }
            if(_isAutoExpand) {return CreateObject(true); }
            throw new System.Exception("There is no elements");
        }
    }
    public class PoolCreator<T>:MonoBehaviour where T:MonoBehaviour
    {
        public static T InstancePoolObject(T prefab,Transform prefabContainer)
        {
            return Instantiate(prefab,prefabContainer.position,prefabContainer.rotation,prefabContainer);
        }
    }
}