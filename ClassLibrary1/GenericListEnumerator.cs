using ClassLibrary1;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassLibrary1
{
    public class GenericListEnumerator <X> : IEnumerator <X>
    {
        private GenericList<X> _genericList;
        private int _current;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            _genericList = genericList;
        }

        public void Dispose()
        {
            _genericList = null;
        }

        public bool MoveNext()
        {
            if (_genericList.Count == 0 || _genericList.Count - 1 <= _current)
            {
                return false;
            }
            _current++;
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }

        public X Current
        {
            get { return _genericList.GetElement(_current); }
            
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}