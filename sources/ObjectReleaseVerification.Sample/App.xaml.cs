namespace OutcoldSolutions.ObjectReleaseVerification.Sample
{
    using System.Diagnostics;
    using System.Windows;

    using OutcoldSolutions;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

#if DEBUG
            // Turn on object release verification framework only when we have debug bits
            ObjectReleaseVerifier.Enabled = true;
#endif

            // Add one verification handler, which will write status to the Debug output console.
            ObjectReleaseVerifier.AddVerificationHandler(new TextOutputVerificationHandler((line) => Debug.WriteLine(line)));
            ObjectReleaseVerifier.AddVerificationHandler(new CustomVerificationHandler());
        }
    }
}
