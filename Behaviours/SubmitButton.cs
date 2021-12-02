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
using Telerik.Windows.Controls;

namespace HAF.Behaviors {
  public class SubmitButton: Behavior<TextBoxBase> {
    public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(Key), typeof(SubmitButton), new PropertyMetadata(Key.Enter));
    public Key Key {
      get { return (Key)this.GetValue(SubmitButton.KeyProperty); }
      set { this.SetValue(SubmitButton.KeyProperty, value); }
    }

    public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(ButtonBase), typeof(SubmitButton), new PropertyMetadata(null));
    public ButtonBase Target {
      get { return (ButtonBase)this.GetValue(SubmitButton.TargetProperty); }
      set { this.SetValue(SubmitButton.TargetProperty, value); }
    }

    protected override void OnAttached() {
      this.AssociatedObject.KeyDown += this.AssociatedObject_KeyDown;
    }

    protected override void OnDetaching() {
      this.AssociatedObject.KeyDown -= this.AssociatedObject_KeyDown;
    }

    private void AssociatedObject_KeyDown(object sender, KeyEventArgs e) {
      if (e.Key == this.Key) {
        this.Target?.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        if (this.Target?.Command != null) {
          this.Target.Command.Execute(this.Target.CommandParameter);
        }
      }
    }
  }
}
