using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _lastIndex = -1;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int size)
        {
            if(size < 1)
            {
                throw new ArgumentException("Size cannot be less than 1");
            }
            else
            {
                _internalStorage = new int[size];
            }
        }

        public int Count
        {
            get
            {
                /*int size = 0;
                foreach (int i in _internalStorage)
                {
                    if (i != null) size++;
                }
                return size;*/
                return _lastIndex  + 1;
            }
        }

        public void Add(int item)
        {
            if (_lastIndex > _internalStorage.Length - 2)
            {
                int[] temp = new int[_internalStorage.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }
            _internalStorage[++_lastIndex] = item;
        }

        public void Clear()
        {
            _internalStorage = null;
            _lastIndex = -1;
        }

        public bool Contains(int item)
        {
            foreach (int i in _internalStorage)
            {
                if (i == item) return true;
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }        
            return _internalStorage[index];           
        }

        public int IndexOf(int item)
        {
            int position = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i] == item) position = i;
                break;
            }
            return position;
        }

        public bool Remove(int item)
        {
            int position = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i] == item) position = i;
            }
            return RemoveAt(position);
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                return false;
            }
            
            for(int i = index; i < Count; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[_lastIndex] = default(int);
            _lastIndex--;
            return true;
        }

        public override String ToString()
        {
            String temp = "";
            foreach (int i in _internalStorage)
            {
                temp += i + " ";
            }
            return temp;
        }
    }
}
