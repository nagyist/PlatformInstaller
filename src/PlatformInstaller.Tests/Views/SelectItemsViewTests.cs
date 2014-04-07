using Autofac;
using NUnit.Framework;

[TestFixture]
public class SelectItemsViewTests
{
    [Test]
    [Explicit]
    [RequiresSTA]
    public void Show()
    {
        ShellViewModel.StartModel = ContainerFactory.Container.Resolve<SelectItemsViewModel>();
        var app = new App();
        app.Run();
    }

    [Test]
    [Explicit]
    [RequiresSTA]
    public void ScreenShot()
    {
        var selectItemsViewModel = ContainerFactory.Container.Resolve<SelectItemsViewModel>();
        foreach (var definition in selectItemsViewModel.PackageDefinitions)
        {
            definition.Selected = true;
        }
        selectItemsViewModel.TakeScreenShot();
    }
}