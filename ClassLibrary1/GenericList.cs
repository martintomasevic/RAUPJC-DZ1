using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class GenericList <X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _lastIndex = -1;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int size)
        {
            _internalStorage = new X[size];
        }

        public void Add(X item)
        {
            if (_lastIndex > _internalStorage.Length - 2)
            {
                X[] temp = new X[_internalStorage.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }
            _internalStorage[++_lastIndex] = item;
        }

        public bool Remove(X item)
        {
            int position = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item)) position = i;
            }
            return RemoveAt(position);
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                return false;
            }

            for (int i = index; i < Count; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[_lastIndex] = default(X);
            _lastIndex--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            int position = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item)) position = i;
                break;
            }
            return position;
        }

        public int Count
        {
            get { return _lastIndex + 1; } 
            
        }
        public void Clear()
        {
            _internalStorage = null;
            _lastIndex = -1;
        }

        public bool Contains(X item)
        {
            foreach (X i in _internalStorage)
            {
                if (i.Equals(item)) return true;
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}