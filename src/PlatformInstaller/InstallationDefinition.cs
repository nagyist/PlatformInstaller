﻿public class InstallationDefinition 
{
    public string Name;
    public string ToolTip;
    public string Image;
    public IInstallRunner Installer;
    public bool Disabled;
    public bool SelectedByDefault;
    public string InstalledVersion;
    public string Status;
    public bool FeedOK;
    
    public InstallationDefinition()
    {
        ToolTip = Name;
    }

    public int SortOrder;
    public bool NoErrors;
}