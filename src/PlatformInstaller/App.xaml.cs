﻿using Serilog;

public partial class App
{
    static App()
    {
        Logging.Initialise();
        ExceptionHandler.Attach();
        Log.Information(string.Format("Starting PlatformInstaller v{0}", PlatformInstaller.Version));    
    }

    public App()
    {
        ExceptionHandler.Attach(this);
        new AppBootstrapper().Start();
    }
}