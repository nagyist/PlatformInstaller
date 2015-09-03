﻿using System;
using System.Threading.Tasks;

public interface IInstaller
{
    Version CurrentVersion();
    Version LatestAvailableVersion();
    Task Execute(Action<string> logOutput, Action<string> logError);
    bool Installed();
    int NestedActionCount { get; }
    string Name { get; }
    string Status { get; }
    bool Enabled { get; }
    string ToolTip { get; }
    bool SelectedByDefault { get; }
}