using System.Collections.Generic;
using UnityEngine;

namespace Core.Extension
{
    public static class ListExtension
    {
        public static T RandomItem<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list[index];
        }
    }
}