using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Joiners;
using Cosmos.Splitters;
using Humanizer;

namespace Cosmos
{
    /// <summary>
    /// Case format<br />
    /// ��Сд��ʽ����
    /// </summary>
    public class CaseFormat
    {
        private readonly bool _humanizerMode;
        private readonly ISplitter _splitter;

        private CaseFormat(ISplitter splitter)
        {
            _splitter = splitter ?? throw new ArgumentNullException(nameof(splitter));
            _humanizerMode = false;
        }

        private CaseFormat()
        {
            _splitter = null;
            _humanizerMode = true;
        }

        /// <summary>
        /// To<br />
        /// ת��
        /// </summary>
        /// <param name="style"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public string To(Style style, string sequence)
        {
            var list = _splitter.SplitToList(sequence);
            IJoiner joiner;
            switch (style)
            {
                case Style.LOWER_CAMEL:
                    {
                        CaseFormatUtils.LowerCase(list);
                        CaseFormatUtils.UpperCaseEachFirstChar(list);
                        CaseFormatUtils.LowerCaseFirstItemFirstChar(list);
                        joiner = Joiner.On("");
                        break;
                    }

                case Style.LOWER_HYPHEN:
                    {
                        CaseFormatUtils.LowerCase(list);
                        joiner = Joiner.On("-");
                        break;
                    }

                case Style.LOWER_UNDERSCORE:
                    {
                        CaseFormatUtils.LowerCase(list);
                        joiner = Joiner.On("_");
                        break;
                    }

                case Style.UPPER_CAMEL:
                    {
                        CaseFormatUtils.LowerCase(list);
                        CaseFormatUtils.UpperCaseEachFirstChar(list);
                        joiner = Joiner.On("");
                        break;
                    }

                case Style.UPPER_UNDERSCORE:
                    {
                        CaseFormatUtils.UpperCase(list);
                        joiner = Joiner.On("_");
                        break;
                    }

                default:
                    throw new InvalidOperationException("Invalid operation.");
            }

            return joiner.Join(list);
        }

        /// <summary>
        /// To<br />
        /// ת��
        /// </summary>
        /// <param name="transformer"></param>
        /// <param name="sequence"></param>
        /// <param name="joinOnStr"></param>
        /// <returns></returns>
        public string To(IStringTransformer transformer, string sequence, string joinOnStr = " ")
        {
            if (!_humanizerMode)
            {
                var list = _splitter.SplitToList(sequence);
                var joiner = Joiner.On(joinOnStr);
                sequence = joiner.Join(list);
            }

            return sequence.Transform(transformer);
        }

        /// <summary>
        /// Create a <see cref="CaseFormat"/> instance with a hyphen splitter.
        /// </summary>
        public static CaseFormat LowerHyphen => new CaseFormat(Splitter.On("-"));

        /// <summary>
        /// Create a <see cref="CaseFormat"/> instance with a lower underscore splitter.
        /// </summary>
        public static CaseFormat LowerUnderscore => new CaseFormat(Splitter.On("_"));

        /// <summary>
        /// Create a <see cref="CaseFormat"/> instance with a upper underscore splitter.
        /// </summary>
        public static CaseFormat UpperUnderscore => new CaseFormat(Splitter.On("_"));

        /// <summary>
        /// Create a <see cref="CaseFormat"/> instance with a normal splitter.
        /// </summary>
        public static CaseFormat Instance => new CaseFormat(Splitter.OnPattern("-_ "));

        /// <summary>
        /// Create a <see cref="CaseFormat"/> instance in humanizer mode.
        /// </summary>
        public static CaseFormat Humanizer => new CaseFormat();

        private static class CaseFormatUtils
        {
            public static void LowerCase(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    list[i] = list[i].ToLower();
                }
            }

            public static void UpperCase(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    list[i] = list[i].ToUpper();
                }
            }

            // ReSharper disable once UnusedMember.Global
            // ReSharper disable once UnusedMember.Local
            public static void LowerCaseEachFirstChar(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].IsNullOrWhiteSpace())
                        continue;

                    var array = list[i].ToCharArray();

                    array[0] = array[0].ToLowerInvariant();
                    list[i] = new string(array);
                }
            }

            public static void UpperCaseEachFirstChar(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].IsNullOrWhiteSpace())
                        continue;

                    var array = list[i].ToCharArray();

                    array[0] = array[0].ToUpperInvariant();
                    list[i] = new string(array);
                }
            }

            public static void LowerCaseFirstItemFirstChar(List<string> list)
            {
                if (list != null && list.Any() && !list[0].IsNullOrWhiteSpace())
                {
                    var array = list[0].ToCharArray();

                    array[0] = array[0].ToLowerInvariant();
                    list[0] = new string(array);
                }
            }

            // ReSharper disable once UnusedMember.Local
            public static void UpperCaseFirstItemFirstChar(List<string> list)
            {
                if (list != null && list.Any() && !list[0].IsNullOrWhiteSpace())
                {
                    var array = list[0].ToCharArray();

                    array[0] = array[0].ToUpperInvariant();
                    list[0] = new string(array);
                }
            }
        }

        /// <summary>
        /// Case format style<be />
        /// ��Сд��ʽ����ʽ
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// Lower camel<br />
            /// Сд���շ�
            /// </summary>
            // ReSharper disable once InconsistentNaming
            LOWER_CAMEL,

            /// <summary>
            /// Lower hyphen<br />
            /// Сд�����
            /// </summary>
            // ReSharper disable once InconsistentNaming
            LOWER_HYPHEN,

            /// <summary>
            /// Lower underscore<br />
            /// Сд���»���
            /// </summary>
            // ReSharper disable once InconsistentNaming
            LOWER_UNDERSCORE,

            /// <summary>
            /// Upper camel<br />
            /// ��д���շ�
            /// </summary>
            // ReSharper disable once InconsistentNaming
            UPPER_CAMEL,

            /// <summary>
            /// Upper underscore<br />
            /// ��д���»���
            /// </summary>
            // ReSharper disable once InconsistentNaming
            UPPER_UNDERSCORE
        }
    }
}