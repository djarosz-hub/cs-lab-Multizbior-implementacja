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

 

         modyfikuje bieżący multizbiór tak, aby zawierał tylko te elementy
         które wystepują w `other` lub występują w bieżacym multizbiorze,
         ale nie wystepują równocześnie w obu
         zgłasza `ArgumentNullException` jeśli `other` jest `null`
         zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
         zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> SymmetricExceptWith(IEnumerable<T> other);

         określa, czy multizbiór jest podzbiorem `other`
         zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsSubsetOf(IEnumerable<T> other);

         określa, czy multizbiór jest podzbiorem właściwym `other` (silna inkluzja)
         zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsProperSubsetOf(IEnumerable<T> other);

         określa, czy multizbiór jest nadzbiorem `other`
         zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsSupersetOf(IEnumerable<T> other);

         określa, czy multizbiór jest nadzbiorem właściwym `other` (silna inkluzja)
         zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsProperSupersetOf(IEnumerable<T> other);

         określa, czy multizbiór i `other` mają przynajmniej jeden element wspólny
         zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool Overlaps(IEnumerable<T> other);

         określa, czy multizbiór i `other` mają takie same elementy w tej samej liczności
         nie zwracając uwagi na kolejność ich zapamiętania
         zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool MultiSetEquals(IEnumerable<T> other);


         zwraca obiekt wykorzystywany do określania równości elementów kolekcji
        public IEqualityComparer<T> Comparer { get; }
         -------------------------



         -------------------------
         konstruktory, metody statyczne i operatory -> do zaimplementowania (nie da się zadeklarować w interfejsie)


         Konstruktor, tworzy pusty multizbiór, w którym równość elementów zdefiniowana jest
         za pomocą obiektu `comparer`
        public MultiSet(IEqualityComparer<T> comparer)

         Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
        public MultiSet(IEnumerable<T> sequence)

         Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
         Równośc elementów zdefiniowana jest za pomocą obiektu `comparer`
        public MultiSet(IEnumerable<T> sequence, IEqualityComparer<T> comparer)

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