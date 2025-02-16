using LanguageExt;
using static LanguageExt.Prelude;

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения для фильтрации значений в монадах Try, TryOption, TryAsync, TryOptionAsync
/// </summary>
public static class TryFilterExtensions
{
    /// <summary>
    /// Фильтрует значение в монаде.
    /// Если значение в монаде не удовлетворяет условию <paramref name="predicate" />,
    /// вернет монаду со значением по-умолчанию <paramref name="defaultValue" />.
    /// Иначе вернет монаду с исходным значением.
    /// </summary>
    /// <param name="try">Монада</param>
    /// <param name="predicate">Условие</param>
    /// <param name="defaultValue">Значение по-умолчанию</param>
    /// <typeparam name="T">Тип значения в монаде</typeparam>
    /// <returns>Монада</returns>
    public static Try<T> Filter<T>(this Try<T> @try, Func<T, bool> predicate, T defaultValue) =>
        @try.Bind(value => predicate(value) ? @try : Try(defaultValue));
    
    /// <summary>
    /// Фильтрует значение в монаде.
    /// Если значение в монаде не удовлетворяет условию <paramref name="predicate" />,
    /// вернет монаду со значением по-умолчанию <paramref name="defaultValue" />.
    /// Иначе вернет монаду с исходным значением.
    /// </summary>
    /// <param name="try">Монада</param>
    /// <param name="predicate">Условие</param>
    /// <param name="defaultValue">Значение по-умолчанию</param>
    /// <typeparam name="T">Тип значения в монаде</typeparam>
    /// <returns>Монада</returns>
    public static TryAsync<T> Filter<T>(this TryAsync<T> @try, Func<T, bool> predicate, T defaultValue) =>
        @try.Bind(value => predicate(value) ? @try : TryAsync(defaultValue));
    
    /// <summary>
    /// Фильтрует значение в монаде.
    /// Если значение в монаде не удовлетворяет условию <paramref name="predicate" />,
    /// вернет монаду со значением по-умолчанию <paramref name="defaultValue" />.
    /// Иначе вернет монаду с исходным значением.
    /// </summary>
    /// <param name="try">Монада</param>
    /// <param name="predicate">Условие</param>
    /// <param name="defaultValue">Значение по-умолчанию</param>
    /// <typeparam name="T">Тип значения в монаде</typeparam>
    /// <returns>Монада</returns>
    public static TryOption<T> Filter<T>(this TryOption<T> @try, Func<T, bool> predicate, T defaultValue) =>
        @try.Bind(value => predicate(value) ? @try : TryOption(defaultValue));
    
    /// <summary>
    /// Фильтрует значение в монаде.
    /// Если значение в монаде не удовлетворяет условию <paramref name="predicate" />,
    /// вернет монаду со значением по-умолчанию <paramref name="defaultValue" />.
    /// Иначе вернет монаду с исходным значением.
    /// </summary>
    /// <param name="try">Монада</param>
    /// <param name="predicate">Условие</param>
    /// <param name="defaultValue">Значение по-умолчанию</param>
    /// <typeparam name="T">Тип значения в монаде</typeparam>
    /// <returns>Монада</returns>
    public static TryOptionAsync<T> Filter<T>(this TryOptionAsync<T> @try, Func<T, bool> predicate, T defaultValue) =>
        @try.Bind(value => predicate(value) ? @try : TryOptionAsync(defaultValue));
}