using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using Telerik.Windows.Controls.Primitives;

namespace HAF.Behaviors {
  public class SelectionCommand: Behavior<ItemsControlSelector> {
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(SelectionCommand), new PropertyMetadata(null));
    public ICommand Command {
      get { return (ICommand)this.GetValue(SelectionCommand.CommandProperty); }
      set { this.SetValue(SelectionCommand.CommandProperty, value); }
    }

    protected override void OnAttached() {
      this.AssociatedObject.SelectionChanged += this.AssociatedObject_SelectionChanged;
    }

    protected override void OnDetaching() {
      this.AssociatedObject.SelectionChanged -= this.AssociatedObject_SelectionChanged;
    }

    private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if(this.AssociatedObject.SelectedItem != null && this.Command != null) {
        this.Command.Execute(this.AssociatedObject.SelectedItem);
        Application.Current.Dispatcher.Invoke(() => {
          this.AssociatedObject.SelectedItem = null;
        }, System.Windows.Threading.DispatcherPriority.Render);
      }
    }
  }
}
