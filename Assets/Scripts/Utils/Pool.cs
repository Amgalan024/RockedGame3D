using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Pool<T> where T : MonoBehaviour
    {
        public event Action<T> OnPoolExpanded;
        public T Prefab { get; }
        public bool AutoExpand { set; get; }
        public Transform Container { get; }
        public List<T> PrefabsPool { private set; get; }

        public Pool(T prefab, int count)
        {
            Prefab = prefab;
            Container = null;
            CreatePool(count);
        }

        public Pool(T prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;
            CreatePool(count);
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            if (AutoExpand)
            {
                return CreateObject(true, true);
            }

            throw new Exception($"There is no element type of {typeof(T)}");
        }

        public T GetFreeElement(Vector3 position)
        {
            if (HasFreeElement(out var element))
            {
                element.transform.position = position;
                return element;
            }

            if (AutoExpand)
            {
                var temp = CreateObject(true, true);
                temp.transform.position = position;
                return temp;
            }

            throw new Exception($"There is no element type of {typeof(T)}");
        }

        private void CreatePool(int count)
        {
            PrefabsPool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                CreateObject(false, false);
            }
        }

        private T CreateObject(bool isExpandingPool, bool isActiveByDeafult = false)
        {
            if (isExpandingPool)
            {
                var createdObject = UnityEngine.Object.Instantiate(PrefabsPool[0], Container.transform.position,
                    Container.transform.rotation);
                createdObject.transform.position = Container.position;
                createdObject.gameObject.SetActive(isActiveByDeafult);
                PrefabsPool.Add(createdObject);
                OnPoolExpanded?.Invoke(createdObject);
                return createdObject;
            }
            else
            {
                var createdObject =
                    UnityEngine.Object.Instantiate(Prefab, Container.transform.position, Container.transform.rotation);
                createdObject.gameObject.SetActive(isActiveByDeafult);
                PrefabsPool.Add(createdObject);
                return createdObject;
            }
        }

        private bool HasFreeElement(out T element)
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
    }
}