using LanguageExt;
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения для работы с монадой <see cref="TryOptionAsync{A}" />
/// </summary>
public static class TryOptionAsyncExtensions
{
    /// <summary>
    /// Выкидывает исключение в случае, если монада находится в ошибочном состоянии
    /// </summary>
    /// <param name="tryOptionAsync"></param>
    /// <typeparam name="T">Тип значения в монаде</typeparam>
    /// <returns>Задача</returns>
    public static async Task<Option<T>> IfFailThrowAsync<T>(this TryOptionAsync<T> tryOptionAsync)
    {
        return await tryOptionAsync.Match(
            Option<T>.Some,
            None: () => Option<T>.None,
            Fail: exception => throw exception);
    }
}