using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicGridsColumns
{
    public class Odpowiedz
    {
        public string Tresc { get; set; }
        public string Inne { get; set; }
    }

    public class Pytanie
    {
		public string Tresc {get; set;}
        public List<Odpowiedz> Odpowiedzi { get; set; }

        #region Implementation of IEnumerable

        //public IEnumerator GetEnumerator()
        //{
        //    //return new GenericEnumerator(Odpowiedzi.ToArray());
        //    //foreach (Odpowiedz odp in Odpowiedzi)
        //    //{
        //    //    yield return odp;
        //    //}
        //}

        #endregion
    }

    public class Grupa : IEnumerable
    {
		public string Nazwa {get; set;}
        public List<Pytanie> Pytania { get; set; }
        public List<List<Odpowiedz>> Odpowiedzi { get; set; }

        //public List<Column> Columns { get; set; }

        #region Implementation of IEnumerable

        public IEnumerator GetEnumerator()
        {
            foreach (var obj in Odpowiedzi)
            {
                yield return obj;
            }
        }

        #endregion
    }

    class GenericEnumerator : IEnumerator
    {
        private readonly object[] _list;
        // Enumerators are positioned before the first element
        // until the first MoveNext() call. 

        private int _position = -1;

        public GenericEnumerator(object[] list)
        {
            _list = list;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _list.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                try { return _list[_position]; }
                catch (IndexOutOfRangeException) { throw new InvalidOperationException(); }
            }
        }
    }
}
