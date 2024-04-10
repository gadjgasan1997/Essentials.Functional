using LanguageExt.Common;
// ReSharper disable InconsistentNaming

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения для <see cref="OptionalResult{A}" />
/// </summary>
public static class OptionalResultExtensions
{
    /// <summary>
    /// Вызывает делегат Some или None в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="optionalResult"></param>
    /// <param name="Some">Делегат, вызывающийся в случае наличия значения</param>
    /// <param name="None">Делегат, вызывающийся в случае отсутствия значения или ошибки</param>
    /// <typeparam name="R">Тип результата</typeparam>
    /// <returns></returns>
    public static R? MatchUnsafe<R>(
        this OptionalResult<R> optionalResult,
        Func<R, R?> Some,
        Func<R?> None)
        where R : class
    {
        return optionalResult.IfFail(_ => null!).MatchUnsafe(Some, None);
    }
}