using LanguageExt;
using static LanguageExt.Prelude;

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения для задач
/// </summary>
public static class TaskExtensions
{
    /// <summary>
    /// Ожидает задачу, возвращает объект <see cref="Unit"/>
    /// </summary>
    /// <param name="task">Задача</param>
    /// <returns></returns>
    public static async Task<Unit> ToUnit(this ValueTask task)
    {
        await task.ConfigureAwait(false);
        return unit;
    }
    
    /// <summary>
    /// Ожидает задачу, возвращает объект <see cref="Unit"/>
    /// </summary>
    /// <param name="task">Задача</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Unit> ToUnit<T>(this ValueTask<T> task)
    {
        await task.ConfigureAwait(false);
        return unit;
    }
}