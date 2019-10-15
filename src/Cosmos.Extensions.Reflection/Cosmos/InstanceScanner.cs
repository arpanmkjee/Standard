using System;
using System.Collections.Generic;

namespace Cosmos
{
    /// <summary>
    /// Instance Scanner<br />
    /// ʵ��ɨ����
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public abstract class InstanceScanner<TClass> : TypeScanner
    {
        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// ����һ���µ� <see cref="InstanceScanner{TClass}"/> ʵ����
        /// </summary>
        protected InstanceScanner() : base() { }

        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// ����һ���µ� <see cref="InstanceScanner{TClass}"/> ʵ����
        /// </summary>
        /// <param name="scannerName"></param>
        protected InstanceScanner(string scannerName) : base(scannerName) { }

        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// ����һ���µ� <see cref="InstanceScanner{TClass}"/> ʵ����
        /// </summary>
        /// <param name="baseType"></param>
        protected InstanceScanner(Type baseType) : base(baseType) { }

        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// ����һ���µ� <see cref="InstanceScanner{TClass}"/> ʵ����
        /// </summary>
        /// <param name="scannerName"></param>
        /// <param name="baseType"></param>
        protected InstanceScanner(string scannerName, Type baseType) : base(scannerName, baseType) { }

        /// <summary>
        /// Scan, and return instances.<br />
        /// ɨ�裬������ʵ����
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TClass> ScanAndReturnInstances()
        {
            foreach (var type in Scan())
            {
                yield return type.CreateInstance<TClass>();
            }
        }
    }
}