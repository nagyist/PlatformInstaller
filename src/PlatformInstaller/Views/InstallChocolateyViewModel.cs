using System.Windows;
using Caliburn.Micro;

public class InstallChocolateyViewModel : Screen
{
    IEventAggregator eventAggregator;
    ChocolateyInstaller chocolateyInstaller;

    public InstallChocolateyViewModel(IEventAggregator eventAggregator, ChocolateyInstaller chocolateyInstaller)
    {
        this.eventAggregator = eventAggregator;
        this.chocolateyInstaller = chocolateyInstaller;
    }

    public void Continue()
    {
        eventAggregator.Publish<AgreedToInstallChocolatey>();
    }

    public void Cancel()
    {
        eventAggregator.Publish<HomeEvent>();
    }

    public void ReCheck()
    {
        if (chocolateyInstaller.IsInstalled())
        {
            eventAggregator.Publish<UserInstalledChocolatey>();
        }
    }

    public void Copy()
    {
        Clipboard.SetText(InstallCommand);
    }

    public string InstallCommand = "@powershell -NoProfile -ExecutionPolicy unrestricted -Command \"iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))\" && SET PATH=%PATH%;%systemdrive%\\chocolatey\\bin";
}