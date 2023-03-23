using System;

namespace Padutronics.Commands.Adapters.System.Windows.Input;

public sealed class CommandToCommandAdapter : global::System.Windows.Input.ICommand
{
    private readonly ICommand adaptee;

    public CommandToCommandAdapter(ICommand adaptee)
    {
        this.adaptee = adaptee;
    }

    public event EventHandler? CanExecuteChanged
    {
        add
        {
            if (value is not null)
            {
                adaptee.CanExecuteChanged += new EventHandler<CanExecuteChangedEventArgs>(value);
            }
        }
        remove
        {
            if (value is not null)
            {
                adaptee.CanExecuteChanged -= new EventHandler<CanExecuteChangedEventArgs>(value);
            }
        }
    }

    public bool CanExecute(object? parameter)
    {
        return adaptee.CanExecute();
    }

    public void Execute(object? parameter)
    {
        adaptee.Execute();
    }
}