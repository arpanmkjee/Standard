using System;
using System.Collections.Generic;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to Guid exact
    /// </summary>
    public static class StringGuidExactHelper {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="guidAct"></param>
        /// <returns></returns>
        public static bool Is(string str, string format, Action<Guid> guidAct = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = Guid.TryParseExact(str, format, out var guid);

            if (result)
                guidAct?.Invoke(guid);

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="tries"></param>
        /// <param name="guidAct"></param>
        /// <returns></returns>
        public static bool Is(string str, string format, IEnumerable<IConversionTry<string, Guid>> tries, Action<Guid> guidAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace, (s, act) => Is(s, format, act), tries, guidAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid To(string str, string format, Guid defaultVal = default) {
            if (string.IsNullOrWhiteSpace(str))
                return defaultVal;

            return Guid.TryParse(str, out var guid) ? guid : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Guid To(string str, string format, IEnumerable<IConversionImpl<string, Guid>> impls) {
            return _Helper.ToXXX(str, (s, act) => Is(s, format, act), impls);
        }
    }
}