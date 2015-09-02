﻿using System.Reflection;
using Autofac;
using Caliburn.Micro;
using Mindscape.Raygun4Net;

public static class ContainerFactory
{
    public static IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();
        builder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(ThisAssembly())
            .Where(type => (ViewModelConventions.IsInstanceViewOrModel(type)))
            .AsSelf()
            .InstancePerDependency();

        builder.RegisterType<EventAggregator>()
            .As<IEventAggregator>()
            .SingleInstance();
        builder.RegisterType<WindowManager>()
            .As<IWindowManager>()
            .SingleInstance();
        builder.RegisterType<RebootMachine>()
            .SingleInstance();
        builder.RegisterType<AbortInstallationHandler>()
            .SingleInstance();
        builder.RegisterType<InstallFeedbackReporter>()
            .SingleInstance();
        builder.RegisterType<ShellViewModel>()
            .SingleInstance();
        builder.RegisterType<ProcessRunner>()
            .SingleInstance();
        builder.RegisterType<CredentialStore>()
            .SingleInstance();
        builder.RegisterType<ReleaseManager>()
            .SingleInstance();
        builder.RegisterType<Installer>()
            .SingleInstance();
        builder.RegisterType<LicenseAgreement>()
            .SingleInstance();
        builder.RegisterType<AppBootstrapper>()
            .SingleInstance();
        builder.RegisterType<AutoSubscriber>();
        builder.RegisterType<PendingRestartAndResume>()
            .SingleInstance();

        builder.RegisterType<ServiceMatrix2012InstallRunner>()
            .SingleInstance()
            .AsImplementedInterfaces();
        builder.RegisterType<ServiceMatrix2013InstallRunner>()
            .SingleInstance()
            .AsImplementedInterfaces();
        builder.RegisterType<ServicePulseInstallRunner>()
            .SingleInstance()
            .AsImplementedInterfaces();
        builder.RegisterType<ServiceControlInstallRunner>()
            .SingleInstance()
            .AsImplementedInterfaces();
        builder.RegisterType<ServiceInsightInstallRunner>()
            .SingleInstance()
            .AsImplementedInterfaces();
        builder.RegisterType<NServiceBusPrerequisitesInstallRunner>()
            .SingleInstance()
            .AsImplementedInterfaces();

        builder.RegisterInstance(new RaygunClient(Program.RaygunApiKey))
            .SingleInstance();
        
        return builder.Build();
    }

    static Assembly ThisAssembly()
    {
        return typeof(ContainerFactory).Assembly;
    }
}