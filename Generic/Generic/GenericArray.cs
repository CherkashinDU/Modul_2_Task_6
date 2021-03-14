using System;
using System.Collections;

namespace Generic
{
    public class GenericArray<T>
    {
        private T[] _array = Array.Empty<T>();

        public GenericArray(params T[] items)
        {
            AddRange(items);
        }

        public int Count => _array.Length;

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return _array[index];
            }
            set
            {
                ValidateIndex(index);

                _array[index] = value;
            }
        }

        public void Add(T item)
        {
            Array.Resize(ref _array, Count + 1);
            _array[Count - 1] = item;
        }

        public void AddRange(T[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void AddRange(GenericArray<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void Remove(T item)
        {
            RemoveAt(Array.IndexOf(_array, item));
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            var newArray = new T[_array.Length - 1];

            var i = 0;
            var j = 0;
            while (i < _array.Length)
            {
                if (i != index)
                {
                    newArray[j] = _array[i];
                    j++;
                }

                i++;
            }

            _array = newArray;
        }

        public void Sort()
        {
            Array.Sort(_array);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
