using System.Diagnostics.CodeAnalysis;
using LanguageExt;
using LanguageExt.Common;

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения для монады Validation
/// </summary>
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class ValidationExtensions
{
    #region ThrowIfNone

    /// <summary>
    /// Выкидывает исключение в случае ошибок
    /// </summary>
    /// <param name="validation">Задача с объектом validation</param>
    /// <param name="throwIfNone">Делегат получения исключения</param>
    /// <typeparam name="TValue">Тип значения</typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static TValue ThrowIfFail<TValue>(
        this Validation<Error, TValue> validation,
        Func<Seq<Error>, Exception> throwIfNone)
        where TValue : notnull
    {
        return validation.Match(value => value, seq => throw throwIfNone(seq));
    }

    /// <summary>
    /// Выкидывает исключение в случае ошибок
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="throwIfNone">Делегат получения исключения</param>
    /// <typeparam name="TValue">Тип значения</typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task<TValue> ThrowIfFailAsync<TValue>(
        this Task<Validation<Error, TValue>> task,
        Func<Seq<Error>, Exception> throwIfNone)
        where TValue : notnull
    {
        return await task.MatchAsync(value => value, seq => throw throwIfNone(seq));
    }

    #endregion
}