using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// ��ӻ򸲸�һ��ֵ
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddOrOverride<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;
        }

        /// <summary>
        /// ���ֵ��л�ȡ���ݡ��������ڣ������ֵ������һ�� <see cref="TValue"/> ��ʵ�������ظ�ʵ����
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrAddNewInstance<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = new TValue();
            dictionary.Add(key, res);
            return res;

        }

        /// <summary>
        /// ���ֵ��л�ȡ���ݡ��������ڣ���ͨ�� <see cref="newValueCreator"/> �����ֵ�����ֵ䲢���ظ�ֵ��
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="newValueCreator"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> newValueCreator)
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = newValueCreator(key);
            return dictionary[key] = res;
        }

        /// <summary>
        /// ���ֵ��л�ȡ���ݡ��������ڣ���ָ������ֵ�����ֵ䲢���ظ�ֵ��
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            return dictionary[key] = value;
        }

        /// <summary>
        /// ���ֵ��л�ȡ���ݡ��������ڣ���ͨ�� <see cref="valueCalculator"/> �����ֵ�����أ���ֵ������µ��ֵ��ڡ�
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="valueCalculator"></param>
        /// <returns></returns>
        public static TValue GetOrCalculate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueCalculator)
        {
            if (dictionary != null && dictionary.TryGetValue(key, out var res))
                return res;

            return valueCalculator(key);
        }

        /// <summary>
        /// ���ֵ��л�ȡ���ݡ��������ڣ��򷵻� <see cref="TValue"/> ��Ĭ��ֵ����Ĭ��ֵ����д���ֵ䡣
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : class
        {
            return dictionary != null && dictionary.TryGetValue(key, out var res) ? res : default;
        }

        public static void AddDictionary<TKey, TVal>(this Dictionary<TKey, TVal> me, Dictionary<TKey, TVal> other)
        {
            foreach (var src in other)
            {
                me.Add(src.Key, src.Value);
            }
        }

        public static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {

            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }
    }
}