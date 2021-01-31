using System.Collections.Generic;
using System;
using ConsoleApp1;

namespace km.Collections.MultiZbior
{
    /// <summary>
    /// MultiSet, to rozszerzenie koncepcji zbioru, dopuszczające przechowywanie duplikatów elementów 
    /// </summary>
    /// <remarks>
    /// * Reprezentacja wewnętrzna: `Dictionary<T, int>`
    /// * Porządek zapamiętania elementów jest bez znaczenia, zatem {a, b, a} jest tym samym multizbiorem, co {a, a, b}
    /// * W konstruktorze można przekazać informację o sposobie porównywania elementów (`IEqualityComparer<T>`)
    /// </remarks>
    /// <typeparam name="T">dowolny typ, bez ograniczeń</typeparam>

    public interface IMultiSet<T> : ICollection<T>, IEnumerable<T>
    {

        #region === from ICollection<T> ============================================


        /*



         zwraca obiekt wykorzystywany do określania równości elementów kolekcji
        public IEqualityComparer<T> Comparer { get; }
         -------------------------


         Konstruktor, tworzy pusty multizbiór, w którym równość elementów zdefiniowana jest
         za pomocą obiektu `comparer`
        public MultiSet(IEqualityComparer<T> comparer)


         Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
         Równośc elementów zdefiniowana jest za pomocą obiektu `comparer`
        public MultiSet(IEnumerable<T> sequence, IEqualityComparer<T> comparer)

         -------------------------
         konstruktory, metody statyczne i operatory -> do zaimplementowania (nie da się zadeklarować w interfejsie)



         tworzy nowy multizbiór jako sumę multizbiorów `first` i `second`
         zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator +(IMultiSet<T> first, IMultiSet<T> second);

         tworzy nowy multizbiór jako różnicę multizbiorów: od `first` odejmuje `second`
         zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator -(IMultiSet<T> first, IMultiSet<T> second);

         tworzy nowy multizbiór jako część wspólną multizbiorów `first` oraz `second`
         zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator *(IMultiSet<T> first, IMultiSet<T> second);
        */
        #endregion
    }
}