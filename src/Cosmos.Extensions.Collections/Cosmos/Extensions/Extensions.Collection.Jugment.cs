﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Extensions of collection
    /// </summary>
   public static class CollectionJudgmentExtensions
    {
        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull(this IEnumerable source) => CollectionJudgment.IsNull(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty(this IEnumerable source) =>
            CollectionJudgment.IsNullOrEmpty(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => CollectionJudgment.IsNullOrEmpty(source);

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this ICollection<T> enumeration, int count)
            => CollectionJudgment.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this ICollection<T> @this, ICollection<T> @that)
            => CollectionJudgment.ContainsEqualCount(@this, @that);

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this IQueryable<T> enumeration, int count)
            => QueryableJudgment.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this IQueryable<T> @this, IQueryable<T> @that)
            => QueryableJudgment.ContainsEqualCount(@this, @that);
    }
}
