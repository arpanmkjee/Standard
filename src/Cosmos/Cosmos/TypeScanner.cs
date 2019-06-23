using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Cosmos.Disposables;

namespace Cosmos
{
    /// <summary>
    /// Type Scanner <br />
    /// ����ɨ����
    /// </summary>
    public abstract class TypeScanner : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_SKIP_ASSEMBLIES =
            "^System|^Mscorlib|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted";

        private readonly AnonymousDisposableObject _anonymousDisposableObject;

        /// <summary>
        /// Scanned result cache <br />
        /// �������
        /// </summary>
        protected List<Type> ScannedResultCache { get; private set; } = new List<Type>();

        /// <summary>
        /// Scanned result cached <br />
        /// ���ɨ�����Ƿ��ѻ���
        /// </summary>
        protected bool ScannedResultCached { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// ���� <see cref="TypeScanner"/> ��ʵ��
        /// </summary>
        protected TypeScanner() : this(string.Empty) { }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// ���� <see cref="TypeScanner"/> ��ʵ��
        /// </summary>
        /// <param name="scannerName"></param>
        protected TypeScanner(string scannerName)
        {
            _anonymousDisposableObject = AnonymousDisposableObject.Create(() =>
             {
                 ScannedResultCache.Clear();
                 ScannedResultCache = null;
                 ScannedResultCached = false;
             });
        }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// ���� <see cref="TypeScanner"/> ��ʵ��
        /// </summary>
        /// <param name="baseType"></param>
        protected TypeScanner(Type baseType) : this(string.Empty, baseType) { }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// ���� <see cref="TypeScanner"/> ��ʵ��
        /// </summary>
        /// <param name="scannerName"></param>
        /// <param name="baseType"></param>
        protected TypeScanner(string scannerName, Type baseType) : this(scannerName)
        {
            BaseType = baseType;
        }

        /// <summary>
        /// Base type <br />
        /// ��������
        /// </summary>
        protected Type BaseType { get; }

        /// <summary>
        /// Scan <br />
        /// ɨ��
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Type> Scan()
        {
            if (ScannedResultCached)
            {
                foreach (var cachedType in ScannedResultCache)
                    yield return cachedType;
            }
            else
            {
                var assemblies = GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    if (NeedToIgnore(assembly))
                        continue;
                    var types = _typesFilter(assembly);
                    foreach (var type in types)
                    {
                        ScannedResultCache.Add(type);
                        yield return type;
                    }
                }

                ScannedResultCached = true;
            }

            // ReSharper disable once InconsistentNaming
            IEnumerable<Type> _typesFilter(Assembly assembly)
                => assembly.GetExportedTypes().Where(TypeFilter());
        }

        /// <summary>
        /// Get assemblies <br />
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        /// <summary>
        /// Get skip assemblies' namespaces <br />
        /// ��ȡ���򼯵������ռ䣬�Ա�����
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSkipAssembliesNamespaces() => DEFAULT_SKIP_ASSEMBLIES;

        /// <summary>
        /// Get limited assemblies' namespaces <br />
        /// ��ȡ���򼯵������ռ䣬�Ա����������Щ�����ռ��н���ɨ��
        /// </summary>
        /// <returns></returns>
        protected virtual string GetLimitedAssembliesNamespaces() => string.Empty;

        /// <summary>
        /// Type filter <br />
        /// ���͹�����
        /// </summary>
        /// <returns></returns>
        protected abstract Func<Type, bool> TypeFilter();

        private bool NeedToIgnore(Assembly assembly)
        {
            var skipAssemblies = GetSkipAssembliesNamespaces();
            var limitedAssemblies = GetLimitedAssembliesNamespaces();
            var regexOptions = RegexOptions.IgnoreCase | RegexOptions.Compiled;
            if (string.IsNullOrWhiteSpace(skipAssemblies) && string.IsNullOrWhiteSpace(limitedAssemblies))
                return false;
            if (string.IsNullOrWhiteSpace(limitedAssemblies))
                return Regex.IsMatch(assembly.FullName, skipAssemblies, regexOptions);
            return !Regex.IsMatch(assembly.FullName, limitedAssemblies, regexOptions);
        }

        /// <summary>
        /// Dispose <br />
        /// �ͷ�
        /// </summary>
        public void Dispose()
        {
            _anonymousDisposableObject.Dispose();
        }
    }
}