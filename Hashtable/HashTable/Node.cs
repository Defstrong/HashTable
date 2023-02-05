using System.Collections.Specialized;

namespace Another.HashTable
{
    internal sealed class Node<K, V>
    {
        public K Key;
        public V Value;
        public Node(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }

}
