using System.Collections;


namespace Another.HashTable
{
    internal class HashTable<K, V> : IEnumerable<V>
    {
        private Node<K, V>[] elementHashTable;
        private int MaxCount { get; set; }
        private int Count { get; set; } = 0;
        public HashTable(int maxCount = 1000)
        {
            MaxCount = maxCount;
            elementHashTable = new Node<K, V>[MaxCount];
        }

        public V this[K key]
        {
            get => Get(key);
            set => Add(key, value);
        }


        private V Get(K key)
        {
            if (elementHashTable is null && MaxCount == 0)
                return default;

            int getHashCodeKey = GetHashCodeKey(key);
            return elementHashTable[getHashCodeKey].Value;
        }
        private void Add(K key, V value)
        {
            if (elementHashTable is null && MaxCount == 0)
                return;

            int getHashCodeKey = GetHashCodeKey(key);
            elementHashTable[getHashCodeKey] = new Node<K, V>(key, value);
            Count++;
        }

        private int GetHashCodeKey(K key) => Math.Abs(key.GetHashCode() % MaxCount);


        public IEnumerator<V> GetEnumerator()
        {
            foreach (var pair in elementHashTable)
            {
                if (pair is not null)
                    yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
