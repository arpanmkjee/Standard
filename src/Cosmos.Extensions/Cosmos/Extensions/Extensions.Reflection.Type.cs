﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Type extensions
    /// </summary>
    public static partial class ReflectionExtensions
    {
        #region ToNonNullableType

        /// <summary>
        /// Get non-nullable inderlying <see cref="Type"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(this Type type)
            => Conversions.TypeConversion.ToNonNullableType(type);

        /// <summary>
        /// Get non-nullable inderlying <see cref="TypeInfo"/>
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(this TypeInfo typeinfo)
            => Conversions.TypeConversion.ToNonNullableTypeInfo(typeinfo);

        #endregion

        #region ToTypeInfo

        /// <summary>
        /// Get object's <see cref="TypeInfo"/>
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static TypeInfo TypeInfo(this object @object)
            => @object.GetType().GetTypeInfo();

        /// <summary>
        /// Convert <see cref="Type"/> array to <see cref="TypeInfo"/> list
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<TypeInfo> ToTypeInfo(this Type[] types)
            => types.Select(type => type.GetTypeInfo());

        #endregion

        #region GetPropertyValue

        /// <summary>
        /// Get property value
        /// </summary>
        /// <param name="object">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this object</param>
        /// <returns>Value of the specific property in this object</returns>
        public static object GetPropertyValue(this object @object, string propertyName)
            => @object.TypeInfo().GetProperty(propertyName).GetValue(@object, null);

        #endregion

        #region ToComputeSignature

        /// <summary>
        /// To compute signature
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this TypeInfo typeinfo)
        {
            var sb = new StringBuilder();
            if (typeinfo.IsGenericType)
            {
                sb.Append(typeinfo.GetGenericTypeDefinition().FullName)
                    .Append("[");

                var genericArgs = typeinfo.GetGenericArguments().ToTypeInfo().ToList();
                for (var i = 0; i < genericArgs.Count(); i++)
                {
                    sb.Append(genericArgs[i].ToComputeSignature());
                    if (i != genericArgs.Count() - 1)
                        sb.Append(", ");
                }

                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(typeinfo.FullName))
                    sb.Append(typeinfo.FullName);
                else if (!string.IsNullOrEmpty(typeinfo.Name))
                    sb.Append(typeinfo.Name);
                else
                    sb.Append(typeinfo);
            }

            return sb.ToString();
        }

        /// <summary>
        /// To compute signature
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this Type type) => ToComputeSignature(type.TypeInfo());

        #endregion

        #region IsAssignableToGenericType

        /// <summary>
        /// To judge the given type is assignable to the generic type or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
            => Types.IsGenericImplementation(givenType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="genericType"/> or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(this TypeInfo givenType, TypeInfo genericType)
            => Types.IsGenericImplementation(genericType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType<TGeneric>(this Type givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType<TGeneric>(this TypeInfo givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        /// <summary>
        /// To judge the given type is assignable to the generic type or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor(this Type givenType, Type genericType)
            => Types.IsGenericImplementation(givenType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="genericType"/> or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor(this TypeInfo givenType, TypeInfo genericType)
            => Types.IsGenericImplementation(genericType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor<TGeneric>(this Type givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor<TGeneric>(this TypeInfo givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        #endregion

        #region FindGenericType

        /// <summary>
        /// Find typeinfo from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo FindGenericTypeInfo(this TypeInfo definition, TypeInfo typeinfo)
        {
            var objectTypeInfo = typeof(object).GetTypeInfo();
            while (typeinfo != null && typeinfo != objectTypeInfo)
            {
                if (typeinfo.IsGenericType && typeinfo.GetGenericTypeDefinition().GetTypeInfo() == definition)
                    return typeinfo;

                if (definition.IsInterface)
                {
                    foreach (var type in typeinfo.GetInterfaces())
                    {
                        var typeinfo2 = FindGenericTypeInfo(definition, type.GetTypeInfo());
                        if (typeinfo2 != null)
                            return typeinfo2;
                    }
                }

                typeinfo = typeinfo.BaseType.GetTypeInfo();
            }

            return null;
        }

        /// <summary>
        /// Find typeinfo from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type FindGenericType(this Type definition, Type type)
            => (FindGenericTypeInfo(definition.GetTypeInfo(), type.GetTypeInfo()))?.AsType();

        #endregion

        #region IsAssignableFrom

        public static bool IsAssignableFrom<T>(this object @this)
        {
            Type type = @this.GetType();
            return type.IsAssignableFrom(typeof(T));
        }

        public static bool IsAssignableFrom(this object @this, Type targetType)
        {
            var type = @this.GetType();
            return type.IsAssignableFrom(targetType);
        }

        #endregion
    }
}