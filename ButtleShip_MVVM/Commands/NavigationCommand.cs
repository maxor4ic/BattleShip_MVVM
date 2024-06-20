using ButtleShip_MVVM.Commands.Base;
using System.Windows.Controls;

namespace ButtleShip_MVVM.Commands
{
    public class NavigationCommand : BaseCommand
    {
        private readonly Action<Page, Uri> execute;
        private readonly Uri uri;

        public NavigationCommand(Action<Page, Uri> execute, Uri uri)
        {
            this.execute = execute;
            this.uri = uri;
        }

        public override void Execute(object parameter)
        {
            execute.Invoke((Page)parameter, uri);
        }
    }
}
