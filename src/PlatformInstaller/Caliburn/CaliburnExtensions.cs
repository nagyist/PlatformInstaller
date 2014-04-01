using System;
using Autofac;
using Caliburn.Micro;
using Parameter = Autofac.Core.Parameter;

public static class CaliburnExtensions
{

    public static T ShowDialog<T>(this IWindowManager windowManager) where T : new()
    {
        var rootModel = new T();
        windowManager.ShowDialog(rootModel);
        return rootModel;
    }

    public static void ActivateModel<T>(this Conductor<object> conductor, params Parameter[] parameters) where T : Screen
    {
        var model = ContainerFactory.Container.Resolve<T>(parameters);
        conductor.ActivateItem(model);
    }
    public static void Publish<T>(this IEventAggregator eventAggregator,Action<T> action = null) where T : new()
    {
        var @event = new T();

        if (action != null)
        {
            action(@event);
        }

        eventAggregator.Publish(@event);
    }
    
}

