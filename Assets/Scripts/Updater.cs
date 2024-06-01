using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private HashSet<IUpdate> _list;

    public void Add(IUpdate update)
    {
        _list.Add(update);
    }

    public void Remove(IUpdate update)
    {
        if (_list.Contains(update))
            _list.Remove(update);
    }

    private void Awake()
    {
        _list = new HashSet<IUpdate>();
    }

    private void Update()
    {
        foreach (IUpdate update in _list)
        {
            update.Update();
        }
    }
}