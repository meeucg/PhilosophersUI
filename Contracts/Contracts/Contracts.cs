namespace Contracts;

/// <summary>
/// Энуметратор States состояний философа IPhilosopher
/// </summary>
public enum States { Eat, Think, Wait }

/// <summary>
/// Интерфейс, отвечающий за управление столом философов в целом
/// Основные методы: 
///     - Iterate - попробовать поменять состояния философов, основываясь на массиве изменений
///     - GetStates - возвращает состояния всех философов на данный момент
/// </summary>
public interface IPhilosophersTable
{
    Task Iterate(bool[] Changes);
    States[] GetStates();
}

/// <summary>
/// Интерфейс управления философами по отдельности
/// </summary>
public interface IPhilosopher
{
    /// <summary>
    /// Владеет ли левым прибором
    /// </summary>
    /// <returns>bool</returns>
    bool HasLeft();
    /// <summary>
    /// Владеет ли правым прибором
    /// </summary>
    /// <returns>bool</returns>
    bool HasRight();

    /// <summary>
    /// Взять левый прибор
    /// </summary>
    /// <returns>bool</returns>
    bool TakeLeft();
    /// <summary>
    /// Взять правый прибор
    /// </summary>
    /// <returns>bool</returns>
    bool TakeRight();

    /// <summary>
    /// Положить левый прибор
    /// </summary>
    /// <returns>bool</returns>
    bool GiveLeft();
    /// <summary>
    /// Положить правый прибор
    /// </summary>
    /// <returns>bool</returns>
    bool GiveRight();

    /// <summary>
    /// Возвращае текущее состояние философа
    /// </summary>
    /// <returns>States</returns>
    States GetState();

    /// <summary>
    /// Попробовать сменить состояние States философа с Eat на Think
    /// </summary>
    void FromEatToThink();
    /// <summary>
    /// Попробовать сменить состояние States философа с Think на Eat
    /// </summary>
    void FromThinkToEat();
}
