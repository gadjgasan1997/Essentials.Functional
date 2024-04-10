using System.Diagnostics.CodeAnalysis;
using LanguageExt;
using LanguageExt.Common;

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения Match для монады Validation
/// </summary>
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class ValidationMatchExtensions
{
    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<TResult> MatchAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, TResult> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        var validation = await task.ConfigureAwait(false);
        return validation.Match(Succ, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<TResult?> MatchUnsafeAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, TResult?> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        var validation = await task.ConfigureAwait(false);
        return validation.MatchUnsafe(Succ, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<TResult> MatchAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<TResult>> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        return validation.Case switch
        {
            Seq<Error> errors => Fail(errors),
            TValue value => await Succ(value).ConfigureAwait(false),
            _ => Fail(new Seq<Error>())
        };
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<TResult> MatchAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<TResult>> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        var validation = await task.ConfigureAwait(false);
        return await validation.MatchAsync(Succ, Fail).ConfigureAwait(false);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<TResult?> MatchUnsafeAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<TResult?>> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        return validation.Case switch
        {
            Seq<Error> errors => Fail(errors),
            TValue value => await Succ(value).ConfigureAwait(false),
            _ => Fail(new Seq<Error>())
        };
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static async Task<TResult?> MatchUnsafeAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<TResult?>> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        var validation = await task.ConfigureAwait(false);
        return await validation.MatchUnsafeAsync(Succ, Fail).ConfigureAwait(false);
    }
}