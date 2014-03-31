using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using Resourcer;

public class LicenseAgreementViewModel : Screen
{
    IEventAggregator eventAggregator;

    public LicenseAgreementViewModel(IEventAggregator eventAggregator)
    {
        this.eventAggregator = eventAggregator;
    }

    public void Agree()
    {
        eventAggregator.Publish<AgeedToLicenseEvent>();
    }

    public void Close()
    {
        eventAggregator.Publish<CloseApplicationEvent>();
    }

    protected override void OnActivate()
    {
        var richTextBox = GetRichTextBox();
        using (var asStream = Resource.AsStream("PlatformInstaller.LicenseAgreement.rtf"))
        {
            richTextBox.Selection.Load(asStream, DataFormats.Rtf);
        }
    }

    public void Copy()
    {
        var richTextBox = GetRichTextBox();
        richTextBox.CopyToClipboard();
    }

    RichTextBox GetRichTextBox()
    {
        var view = (LicenseAgreementView) base.GetView();
        return view.licenseBrowser;
    }
}