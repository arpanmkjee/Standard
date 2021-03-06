﻿using Cosmos.Conversions;
using Cosmos.Judgments;

namespace Cosmos {
    /// <summary>
    /// Number Utilities
    /// </summary>
    public static class Numbers {

        #region GetMembersBetween

        /// <summary>
        /// Get members between min value and max value (include min and max).
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int[] GetMembersBetween(int min, int max) {
            if (min == max) {
                return new[] {min};
            }

            if (min > max) {
                var t = min;
                min = max;
                max = t;
            }

            var count = max - min + 1;
            var results = new int[count];
            var pointer = min;
            var index = 0;

            while (pointer <= max && index < count) {
                results[index] = pointer;

                ++index;
                ++pointer;
            }

            return results;
        }

        /// <summary>
        /// Get members between min value and max value (include min and max).
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static long[] GetMembersBetween(long min, long max) {
            if (min == max) {
                return new[] {min};
            }

            if (min > max) {
                var t = min;
                min = max;
                max = t;
            }

            var count = max - min + 1;
            var results = new long[count];
            var pointer = min;
            var index = 0L;

            while (pointer <= max && index < count) {
                results[index] = pointer;

                ++index;
                ++pointer;
            }

            return results;
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ParseToInt(object obj) => NumericConversion.ToInt32(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ParseToInt(object obj, int defaultValue) => NumericConversion.ToInt32(obj, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ParseToLong(object obj) => NumericConversion.ToInt64(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ParseToLong(object obj, long defaultValue) => NumericConversion.ToInt64(obj, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ParseToFloat(object obj) => NumericConversion.ToFloat(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ParseToFloat(object obj, float defaultValue) => NumericConversion.ToFloat(obj, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ParseToDouble(object obj) => NumericConversion.ToDouble(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ParseToDouble(object obj, double defaultValue) => NumericConversion.ToDouble(obj, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double ParseToDouble(object obj, int digits) => NumericConversion.ToRoundDouble(obj, digits);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ParseToDouble(object obj, int digits, double defaultValue) => NumericConversion.ToRoundDouble(obj, digits, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ParseToDecimal(object obj) => NumericConversion.ToDecimal(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ParseToDecimal(object obj, decimal defaultValue) => NumericConversion.ToDecimal(obj, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal ParseToDecimal(object obj, int digits) => NumericConversion.ToRoundDecimal(obj, digits);

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ParseToDecimal(object obj, int digits, decimal defaultValue) => NumericConversion.ToRoundDecimal(obj, digits, defaultValue);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="int"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ParseToNullableInt(object obj) => NumericConversion.ToNullableInt32(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="long"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? ParseToNullableLong(object obj) => NumericConversion.ToNullableInt64(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="float"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? ParseToNullableFloat(object obj) => NumericConversion.ToNullableFloat(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ParseToNullableDouble(object obj) => NumericConversion.ToNullableDouble(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ParseToNullableDouble(object obj, int digits) => NumericConversion.ToRoundNullableDouble(obj, digits);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ParseToNullableDecimal(object obj) => NumericConversion.ToNullableDecimal(obj);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ParseToNullableDecimal(object obj, int digits) => NumericConversion.ToRoundNullableDecimal(obj, digits);

        #endregion

        #region Judgment

        /// <summary>
        /// To judge whether the string is integer or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(string str) => NumericJudgment.IsInt32(str);

        /// <summary>
        /// To judge whether the string is numeric or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str) => NumericJudgment.IsNumeric(str);

        /// <summary>
        /// To judge whether the short value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(short value, short left, short right) => NumericJudgment.IsBetween(value, left, right);

        /// <summary>
        /// To judge whether the int value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(int value, int left, int right) => NumericJudgment.IsBetween(value, left, right);

        /// <summary>
        /// To judge whether the long value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(long value, long left, long right) => NumericJudgment.IsBetween(value, left, right);

        /// <summary>
        /// To judge whether the float value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(float value, float left, float right) => NumericJudgment.IsBetween(value, left, right);

        /// <summary>
        /// To judge whether the double value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(double value, double left, double right) => NumericJudgment.IsBetween(value, left, right);

        /// <summary>
        /// To judge whether the decimal value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(decimal value, decimal left, decimal right) => NumericJudgment.IsBetween(value, left, right);

        #endregion

    }
}