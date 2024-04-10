using LanguageExt;
using LanguageExt.Common;
using static System.Environment;
// ReSharper disable MemberCanBePrivate.Global

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения для ошибок
/// </summary>
public static class ErrorExtensions
{
    /// <summary>
    /// Возвращает сообщение для логирования из ошибки
    /// </summary>
    /// <param name="error">Ошибка</param>
    /// <param name="exMessageGetter">Делегат получения сообщения из исключения (при его наличии)</param>
    /// <returns>Сообщение для логирования</returns>
    public static string ToLogMessage(
        this Error error,
        Func<Exception, string>? exMessageGetter = null)
    {
        exMessageGetter ??= exception => exception.Message;

        return error is { IsExceptional: true, Exception.Case: not null }
            ? exMessageGetter((Exception)error.Exception.Case)
            : error.Message;
    }

    /// <summary>
    /// Возвращает сообщение для логирования из списка ошибок
    /// </summary>
    /// <param name="errors">Список ошибок</param>
    /// <param name="separator">Разделитель для строк (Пустая строка по умолчанию)</param>
    /// <param name="exMessageGetter">Делегат получения сообщения из исключения (при его наличии)</param>
    /// <returns>Сообщение для логирования</returns>
    public static string ToLogMessage(
        this Seq<Error> errors,
        string? separator = null,
        Func<Exception, string>? exMessageGetter = null)
    {
        return string.Join(
            separator ?? NewLine,
            errors.Select(error => error.ToLogMessage(exMessageGetter)));
    }

    /// <summary>
    /// Возвращает исключение из полученной ошибки
    /// </summary>
    /// <param name="error">Ошибка</param>
    /// <returns>Исключение</returns>
    public static Exception ToException(this Error error) => error.Exception.IfNone(new Exception(error.Message));

    /// <summary>
    /// Возвращает агрегированное исключение из списка ошибок
    /// </summary>
    /// <param name="errors">Список ошибок</param>
    /// <returns></returns>
    public static Exception ToAggregateException(this Seq<Error> errors)
    {
        if (errors.Count is 1)
            return errors.First().ToException();
        
        return new AggregateException(
            innerExceptions: errors.Select(error => error.ToException()));
    }
}