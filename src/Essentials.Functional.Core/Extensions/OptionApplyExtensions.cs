using LanguageExt;
// ReSharper disable InconsistentNaming

namespace Essentials.Functional.Extensions;

/// <summary>
/// Методы расширения на монадах <see cref="Option{A}" /> для их агрегации
/// </summary>
public static class OptionApplyExtensions
{
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, TResult>(
        this (Option<T1>, Option<T2>) tuple,
        Func<T1, T2, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>) tuple,
        Func<T1, T2, T3, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>) tuple,
        Func<T1, T2, T3, T4, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="T5">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, T5, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>, Option<T5>) tuple,
        Func<T1, T2, T3, T4, T5, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty),
                tuple.Item5.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="T5">Тип значения монады</typeparam>
    /// <typeparam name="T6">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, T5, T6, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>, Option<T5>, Option<T6>) tuple,
        Func<T1, T2, T3, T4, T5, T6, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty),
                tuple.Item5.ToValidation(string.Empty),
                tuple.Item6.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="T5">Тип значения монады</typeparam>
    /// <typeparam name="T6">Тип значения монады</typeparam>
    /// <typeparam name="T7">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>, Option<T5>, Option<T6>, Option<T7>) tuple,
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty),
                tuple.Item5.ToValidation(string.Empty),
                tuple.Item6.ToValidation(string.Empty),
                tuple.Item7.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="T5">Тип значения монады</typeparam>
    /// <typeparam name="T6">Тип значения монады</typeparam>
    /// <typeparam name="T7">Тип значения монады</typeparam>
    /// <typeparam name="T8">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>, Option<T5>, Option<T6>, Option<T7>, Option<T8>) tuple,
        Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty),
                tuple.Item5.ToValidation(string.Empty),
                tuple.Item6.ToValidation(string.Empty),
                tuple.Item7.ToValidation(string.Empty),
                tuple.Item8.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="T5">Тип значения монады</typeparam>
    /// <typeparam name="T6">Тип значения монады</typeparam>
    /// <typeparam name="T7">Тип значения монады</typeparam>
    /// <typeparam name="T8">Тип значения монады</typeparam>
    /// <typeparam name="T9">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>, Option<T5>, Option<T6>, Option<T7>, Option<T8>, Option<T9>) tuple,
        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty),
                tuple.Item5.ToValidation(string.Empty),
                tuple.Item6.ToValidation(string.Empty),
                tuple.Item7.ToValidation(string.Empty),
                tuple.Item8.ToValidation(string.Empty),
                tuple.Item9.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
    
    /// <summary>
    /// Обрабатывает кортеж из монад типа <see cref="Option{A}" />
    /// </summary>
    /// <param name="tuple">Кортеж</param>
    /// <param name="Some">Делегат, выполняющийся в случае, если все монады в кортеже имеют значение</param>
    /// <typeparam name="T1">Тип значения монады</typeparam>
    /// <typeparam name="T2">Тип значения монады</typeparam>
    /// <typeparam name="T3">Тип значения монады</typeparam>
    /// <typeparam name="T4">Тип значения монады</typeparam>
    /// <typeparam name="T5">Тип значения монады</typeparam>
    /// <typeparam name="T6">Тип значения монады</typeparam>
    /// <typeparam name="T7">Тип значения монады</typeparam>
    /// <typeparam name="T8">Тип значения монады</typeparam>
    /// <typeparam name="T9">Тип значения монады</typeparam>
    /// <typeparam name="T10">Тип значения монады</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns>Монада с результатом</returns>
    public static Option<TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        this (Option<T1>, Option<T2>, Option<T3>, Option<T4>, Option<T5>, Option<T6>, Option<T7>, Option<T8>, Option<T9>, Option<T10>) tuple,
        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Some)
    {
        return (
                tuple.Item1.ToValidation(string.Empty),
                tuple.Item2.ToValidation(string.Empty),
                tuple.Item3.ToValidation(string.Empty),
                tuple.Item4.ToValidation(string.Empty),
                tuple.Item5.ToValidation(string.Empty),
                tuple.Item6.ToValidation(string.Empty),
                tuple.Item7.ToValidation(string.Empty),
                tuple.Item8.ToValidation(string.Empty),
                tuple.Item9.ToValidation(string.Empty),
                tuple.Item10.ToValidation(string.Empty))
            .Apply(Some)
            .Match(result => result, _ => Option<TResult>.None);
    }
}