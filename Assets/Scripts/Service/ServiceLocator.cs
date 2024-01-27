using System;
using System.Collections.Generic;
using UnityEngine;


public class ServiceLocator
{
    /// <summary>
    /// Currently registered services.
    /// </summary>
    private readonly Dictionary<string, IGameService> services = new Dictionary<string, IGameService>();

    public static ServiceLocator Current { get; private set; }

    public static void Initialize()
    {
        Current = new ServiceLocator();
    }

    /// <summary>
    /// Gets the service instance of the given type.
    /// </summary>
    /// <typeparam name="T">The type of the service to lookup.</typeparam>
    /// <returns>The service instance.</returns>
    public T Get<T>() where T : IGameService
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.Log($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        return (T)services[key];
    }

    /// <summary>
    /// Registers the service with the current service locator.
    /// </summary>
    /// <typeparam name="T">Service type.</typeparam>
    /// <param name="service">Service instance.</param>
    public void Register<T>(T service) where T : IGameService
    {
        string key = typeof(T).Name;
        if (services.ContainsKey(key))
        {
            Debug.Log(
                $"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
            return;
        }

        //Add.
        services.Add(key, service);
    }

    /// <summary>
    /// Unregisters the service from the current service locator.
    /// </summary>
    /// <typeparam name="T">Service type.</typeparam>
    public void Unregister<T>() where T : IGameService
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.Log(
                $"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        services.Remove(key);
    }
}