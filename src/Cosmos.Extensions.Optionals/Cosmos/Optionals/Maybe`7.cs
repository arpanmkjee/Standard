using System;
using System.Collections.Generic;
using Cosmos.Optionals.Internals;

namespace Cosmos.Optionals {
    /// <summary>
    /// Maybe
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    [Serializable]
    public readonly struct Maybe<T1, T2, T3, T4, T5, T6, T7> : IOptionalImpl<(T1, T2, T3, T4, T5, T6, T7), Maybe<T1, T2, T3, T4, T5, T6, T7>>,
                                                               IEquatable<Maybe<T1, T2, T3, T4, T5, T6, T7>>,
                                                               IComparable<Maybe<T1, T2, T3, T4, T5, T6, T7>> {
        private readonly Maybe<T1> _o1;
        private readonly Maybe<T2> _o2;
        private readonly Maybe<T3> _o3;
        private readonly Maybe<T4> _o4;
        private readonly Maybe<T5> _o5;
        private readonly Maybe<T6> _o6;
        private readonly Maybe<T7> _o7;
        private readonly bool _hasValue;
        private readonly IReadOnlyDictionary<string, int> _optionalIndexCache;

        internal Maybe(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, bool hasValue) {
            _o1 = Optional.From(value1);
            _o2 = Optional.From(value2);
            _o3 = Optional.From(value3);
            _o4 = Optional.From(value4);
            _o5 = Optional.From(value5);
            _o6 = Optional.From(value6);
            _o7 = Optional.From(value7);
            _hasValue = hasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(7);
        }

        internal Maybe(T1 value1, string key1, T2 value2, string key2, T3 value3, string key3, T4 value4, string key4, T5 value5, string key5, T6 value6, string key6, T7 value7,
            string key7, bool hasValue) {
            _o1 = Optional.From(value1);
            _o2 = Optional.From(value2);
            _o3 = Optional.From(value3);
            _o4 = Optional.From(value4);
            _o5 = Optional.From(value5);
            _o6 = Optional.From(value6);
            _o7 = Optional.From(value7);
            _hasValue = hasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(7, key1, key2, key3, key4, key5, key6, key7);
        }

        internal Maybe(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4, Maybe<T5> maybe5, Maybe<T6> maybe6, Maybe<T7> maybe7) {
            _o1 = maybe1;
            _o2 = maybe2;
            _o3 = maybe3;
            _o4 = maybe4;
            _o5 = maybe5;
            _o6 = maybe6;
            _o7 = maybe7;
            _hasValue = _o1.HasValue && _o2.HasValue && _o3.HasValue && _o4.HasValue && _o5.HasValue && _o6.HasValue && _o7.HasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(7, maybe1.Key, maybe2.Key, maybe3.Key, maybe4.Key, maybe5.Key, maybe6.Key, maybe7.Key);
        }

        /// <summary>
        /// Gets value of he first item
        /// </summary>
        public T1 Item1 => _o1.Value;

        /// <summary>
        /// Gets value of he second item
        /// </summary>
        public T2 Item2 => _o2.Value;

        /// <summary>
        /// Gets value of he third item
        /// </summary>
        public T3 Item3 => _o3.Value;

        /// <summary>
        /// Gets value of he forth item
        /// </summary>
        public T4 Item4 => _o4.Value;

        /// <summary>
        /// Gets value of he fifth item
        /// </summary>
        public T5 Item5 => _o5.Value;

        /// <summary>
        /// Gets value of he sixth item
        /// </summary>
        public T6 Item6 => _o6.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T7 Item7 => _o7.Value;

        /// <inheritdoc />
        public (T1, T2, T3, T4, T5, T6, T7) Value => (Item1, Item2, Item3, Item4, Item5, Item6, Item7);

        /// <inheritdoc />
        public bool HasValue => _hasValue && _o1.HasValue && _o2.HasValue && _o3.HasValue && _o4.HasValue && _o5.HasValue && _o6.HasValue && _o7.HasValue;
        
        /// <inheritdoc />
        public string Key => _o7.Key;
        
        #region Index

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="index"></param>
        public object this[int index] {
            get {
                return index switch {
                    0 => _o1.Value,
                    1 => _o2.Value,
                    2 => _o3.Value,
                    3 => _o4.Value,
                    4 => _o5.Value,
                    5 => _o6.Value,
                    6 => _o7.Value,
                    _ => throw new IndexOutOfRangeException($"Index value '{index}' must between [0, 7).")
                };
            }
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="key"></param>
        public object this[string key]
            => _optionalIndexCache.TryGetValue(key, out var index)
                ? this[index]
                : default;

        #endregion

        #region Deconstruct

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        /// <param name="item6"></param>
        /// <param name="item7"></param>
        public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7) {
            item1 = _o1.Value;
            item2 = _o2.Value;
            item3 = _o3.Value;
            item4 = _o4.Value;
            item5 = _o5.Value;
            item6 = _o6.Value;
            item7 = _o7.Value;
        }

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="maybe1"></param>
        /// <param name="maybe2"></param>
        /// <param name="maybe3"></param>
        /// <param name="maybe4"></param>
        /// <param name="maybe5"></param>
        /// <param name="maybe6"></param>
        /// <param name="maybe7"></param>
        public void Deconstruct(out Maybe<T1> maybe1, out Maybe<T2> maybe2, out Maybe<T3> maybe3, out Maybe<T4> maybe4, out Maybe<T5> maybe5, out Maybe<T6> maybe6,
            out Maybe<T7> maybe7) {
            maybe1 = _o1;
            maybe2 = _o2;
            maybe3 = _o3;
            maybe4 = _o4;
            maybe5 = _o5;
            maybe6 = _o6;
            maybe7 = _o7;
        }

        #endregion

        #region Equals

        /// <inheritdoc />
        public bool Equals((T1, T2, T3, T4, T5, T6, T7) other) {
            return Item1.Equals(other.Item1) &&
                   Item2.Equals(other.Item2) &&
                   Item3.Equals(other.Item3) &&
                   Item4.Equals(other.Item4) &&
                   Item5.Equals(other.Item5) &&
                   Item6.Equals(other.Item6) &&
                   Item7.Equals(other.Item7);
        }

        /// <inheritdoc />
        public bool Equals(Maybe<T1, T2, T3, T4, T5, T6, T7> other) {
            if (!HasValue && !other.HasValue)
                return true;
            if (HasValue && other.HasValue)
                return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) &&
                       EqualityComparer<T2>.Default.Equals(Item2, other.Item2) &&
                       EqualityComparer<T3>.Default.Equals(Item3, other.Item3) &&
                       EqualityComparer<T4>.Default.Equals(Item4, other.Item4) &&
                       EqualityComparer<T5>.Default.Equals(Item5, other.Item5) &&
                       EqualityComparer<T6>.Default.Equals(Item6, other.Item6) &&
                       EqualityComparer<T7>.Default.Equals(Item7, other.Item7);
            return false;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Maybe<T1, T2, T3, T4, T5, T6, T7> maybe && Equals(maybe);

        #endregion

        #region Compare to

        /// <inheritdoc />
        public int CompareTo((T1, T2, T3, T4, T5, T6, T7) other) {
            if (!HasValue) return -1;
            var v = new[] {
                CompareHelper.Compare(Item1, other.Item1, 7),
                CompareHelper.Compare(Item2, other.Item2, 6),
                CompareHelper.Compare(Item3, other.Item3, 5),
                CompareHelper.Compare(Item4, other.Item4, 4),
                CompareHelper.Compare(Item5, other.Item5, 3),
                CompareHelper.Compare(Item6, other.Item6, 2),
                CompareHelper.Compare(Item7, other.Item7, 1)
            };
            return CompareHelper.Calc(v);
        }

        /// <inheritdoc />
        public int CompareTo(Maybe<T1, T2, T3, T4, T5, T6, T7> other) {
            if (HasValue && !other.HasValue) return 1;
            if (!HasValue && other.HasValue) return -1;
            var v = new[] {
                CompareHelper.Compare(Item1, other.Item1, 7),
                CompareHelper.Compare(Item2, other.Item2, 6),
                CompareHelper.Compare(Item3, other.Item3, 5),
                CompareHelper.Compare(Item4, other.Item4, 4),
                CompareHelper.Compare(Item5, other.Item5, 3),
                CompareHelper.Compare(Item6, other.Item6, 2),
                CompareHelper.Compare(Item7, other.Item7, 1)
            };
            return CompareHelper.Calc(v);
        }

        #endregion

        #region ==/!=

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Maybe<T1, T2, T3, T4, T5, T6, T7> left, Maybe<T1, T2, T3, T4, T5, T6, T7> right) => left.Equals(right);

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Maybe<T1, T2, T3, T4, T5, T6, T7> left, Maybe<T1, T2, T3, T4, T5, T6, T7> right) => !left.Equals(right);

        #endregion

        #region < <= > >=

        /// <summary>
        /// Determines if an optional is less than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Maybe<T1, T2, T3, T4, T5, T6, T7> left, Maybe<T1, T2, T3, T4, T5, T6, T7> right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if an optional is less than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Maybe<T1, T2, T3, T4, T5, T6, T7> left, Maybe<T1, T2, T3, T4, T5, T6, T7> right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines if an optional is greater than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Maybe<T1, T2, T3, T4, T5, T6, T7> left, Maybe<T1, T2, T3, T4, T5, T6, T7> right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if an optional is greater than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Maybe<T1, T2, T3, T4, T5, T6, T7> left, Maybe<T1, T2, T3, T4, T5, T6, T7> right) => left.CompareTo(right) >= 0;

        #endregion

        #region MyRegion

        /// <summary>
        /// Convert maybe to tuple
        /// </summary>
        /// <param name="maybe"></param>
        /// <returns></returns>
        public static implicit operator (T1, T2, T3, T4, T5, T6, T7)(Maybe<T1, T2, T3, T4, T5, T6, T7> maybe) {
            return maybe.Value;
        }

        /// <summary>
        /// Convert maybe from tuple
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static explicit operator Maybe<T1, T2, T3, T4, T5, T6, T7>((T1, T2, T3, T4, T5, T6, T7) tuple) {
            return Optional.From(tuple);
        }

        #endregion

        #region ToString

        /// <inheritdoc />
        public override string ToString() {
            return HasValue
                ? $"Some(Item1:{Item1},Item2:{Item2},Item3:{Item3},Item4:{Item4},Item5:{Item5},Item6:{Item6},Item7:{Item7})"
                : "None";
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode() {
            return HasValue
                ? Value.GetHashCode()
                : 0;
        }

        #endregion

        #region Contains / Exists

        /// <inheritdoc />
        public bool Contains((T1, T2, T3, T4, T5, T6, T7) value) {
            return _o1.Contains(value.Item1) &&
                   _o2.Contains(value.Item2) &&
                   _o3.Contains(value.Item3) &&
                   _o4.Contains(value.Item4) &&
                   _o5.Contains(value.Item5) &&
                   _o6.Contains(value.Item6) &&
                   _o7.Contains(value.Item7);
        }

        /// <inheritdoc />
        public bool Exists(Func<(T1, T2, T3, T4, T5, T6, T7), bool> predicate) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && predicate(Value);
        }

        #endregion

        #region Value or

        /// <inheritdoc />
        public (T1, T2, T3, T4, T5, T6, T7) ValueOr((T1, T2, T3, T4, T5, T6, T7) alternative) {
            return HasValue ? Value : alternative;
        }

        /// <inheritdoc />
        public (T1, T2, T3, T4, T5, T6, T7) ValueOr(Func<(T1, T2, T3, T4, T5, T6, T7)> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? Value : alternativeFactory();
        }

        #endregion

        #region Or / Else

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> Or((T1, T2, T3, T4, T5, T6, T7) alternative) {
            return HasValue ? this : Optional.From(alternative);
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> Or(Func<(T1, T2, T3, T4, T5, T6, T7)> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? this : Optional.From(alternativeFactory());
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> Else(Maybe<T1, T2, T3, T4, T5, T6, T7> alternativeMaybe) {
            return HasValue ? this : alternativeMaybe;
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> Else(Func<Maybe<T1, T2, T3, T4, T5, T6, T7>> alternativeMaybeFactory) {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return HasValue ? this : alternativeMaybeFactory();
        }

        #endregion

        #region With exception

        /// <inheritdoc />
        public Either<(T1, T2, T3, T4, T5, T6, T7), TException> WithException<TException>(TException exception) {
            return Match(
                someFactory: Optional.Some<(T1, T2, T3, T4, T5, T6, T7), TException>,
                noneFactory: () => Optional.None<(T1, T2, T3, T4, T5, T6, T7), TException>(exception));
        }

        /// <inheritdoc />
        public Either<(T1, T2, T3, T4, T5, T6, T7), TException> WithException<TException>(Func<TException> exceptionFactory) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return Match(
                someFactory: Optional.Some<(T1, T2, T3, T4, T5, T6, T7), TException>,
                noneFactory: () => Optional.None<(T1, T2, T3, T4, T5, T6, T7), TException>(exceptionFactory()));
        }

        #endregion

        #region Match

        /// <inheritdoc />
        public TResult Match<TResult>(Func<(T1, T2, T3, T4, T5, T6, T7), TResult> someFactory, Func<TResult> noneFactory) {
            if (someFactory is null)
                throw new ArgumentNullException(nameof(someFactory));
            if (noneFactory is null)
                throw new ArgumentNullException(nameof(noneFactory));
            return HasValue ? someFactory(Value) : noneFactory();
        }

        /// <inheritdoc />
        public void Match(Action<(T1, T2, T3, T4, T5, T6, T7)> someAct, Action noneAct) {
            if (someAct is null)
                throw new ArgumentNullException(nameof(someAct));
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (HasValue)
                someAct(Value);
            else
                noneAct();
        }

        /// <inheritdoc />
        public void MatchMaybe(Action<(T1, T2, T3, T4, T5, T6, T7)> maybeAct) {
            if (maybeAct is null)
                throw new ArgumentNullException(nameof(maybeAct));
            if (HasValue)
                maybeAct(Value);
        }

        /// <inheritdoc />
        public void MatchNone(Action noneAct) {
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (!HasValue)
                noneAct();
        }

        #endregion

        #region Map

        /// <inheritdoc />
        public Maybe<TResult> Map<TResult>(Func<(T1, T2, T3, T4, T5, T6, T7), TResult> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: val => Optional.Some(mapping(val)),
                noneFactory: Optional.None<TResult>);
        }

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult>(Func<(T1, T2, T3, T4, T5, T6, T7), Maybe<TResult>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: mapping,
                noneFactory: Optional.None<TResult>);
        }

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult, TException>(Func<(T1, T2, T3, T4, T5, T6, T7), Either<TResult, TException>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return FlatMap(val => mapping(val).WithoutException());
        }

        #endregion

        #region Filter

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> Filter(bool condition) {
            return HasValue && !condition ? Nothing : this;
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> Filter(Func<(T1, T2, T3, T4, T5, T6, T7), bool> predicate) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Nothing : this;
        }

        #endregion

        #region Not null

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7> NotNull() {
            return HasValue &&
                   _o1.Value == null &&
                   _o2.Value == null &&
                   _o3.Value == null &&
                   _o4.Value == null &&
                   _o5.Value == null &&
                   _o6.Value == null &&
                   _o7.Value == null
                ? Nothing
                : this;
        }

        #endregion

        #region To wrapped object

        /// <summary>
        /// To wrapped optional some
        /// </summary>
        /// <returns></returns>
        public Some<(T1, T2, T3, T4, T5, T6, T7)> ToWrappedSome() => new Some<(T1, T2, T3, T4, T5, T6, T7)>(Value);

        /// <summary>
        /// To wrapped optional none
        /// </summary>
        /// <returns></returns>
        public None<(T1, T2, T3, T4, T5, T6, T7)> ToWrappedNone() => new None<(T1, T2, T3, T4, T5, T6, T7)>();

        #endregion

        /// <summary>
        /// Nothing
        /// </summary>
        public static Maybe<T1, T2, T3, T4, T5, T6, T7> Nothing => Optional.None<T1, T2, T3, T4, T5, T6, T7>();
    }
}