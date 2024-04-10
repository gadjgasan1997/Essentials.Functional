using System.Diagnostics.CodeAnalysis;
using LanguageExt;
using LanguageExt.Common;

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения Bind для монады Validation
/// </summary>
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class ValidationBindExtensions
{
    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<Validation<Error, TResult>> BindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Validation<Error, TResult>> func)
    {
        var validation = await task.ConfigureAwait(false);
        return validation.Bind(func);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<Validation<Error, TResult>> BindAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<Validation<Error, TResult>>> func)
    {
        if (validation.IsSuccess)
            return await func((TValue) validation.Case).ConfigureAwait(false);
        
        return (Seq<Error>) validation.Case;
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<Validation<Error, TResult>> BindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<Validation<Error, TResult>>> func)
    {
        var validation = await task.ConfigureAwait(false);
        return await validation.BindAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<Validation<Error, TResult>> BindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, TResult> func)
    {
        var validation = await task.ConfigureAwait(false);
        return validation.Bind<TResult>(value => func(value));
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<Validation<Error, TResult>> BindAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<TResult>> func)
    {
        if (validation.IsSuccess)
            return await func((TValue) validation.Case).ConfigureAwait(false);
        
        return (Seq<Error>) validation.Case;
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<Validation<Error, TResult>> BindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<TResult>> func)
    {
        var validation = await task.ConfigureAwait(false);
        return await validation.BindAsync(func).ConfigureAwait(false);
    }
}